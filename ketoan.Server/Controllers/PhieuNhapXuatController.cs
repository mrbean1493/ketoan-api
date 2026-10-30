using ketoan.Server.Data;
using ketoan.Server.DTOs;
using ketoan.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ketoan.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhieuNhapXuatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PhieuNhapXuatController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: api/PhieuNhapXuat - Lấy danh sách phiếu (Danh mục)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var phieus = await _context.PhieuNhapXuats
                .Select(p => new ResponsePhieuNhapXuatDto
                {
                    Id = p.Id,
                    //MaPhieu = p.MaPhieu,
                    NgayLap = p.NgayLap,
                    DoiTacId = p.IdDoiTac,
                    TongTien = p.TongTien,
                    //GhiChu = p.GhiChu,
                    //IsPhieuNhap = p.IsPhieuNhap
                    LoaiPhieu= p.LoaiPhieu
                })
                .OrderByDescending(p => p.NgayLap)
                .ToListAsync();

            return Ok(new { Success = true, Data = phieus });
        }

        // 2. GET: api/PhieuNhapXuat/5 - Lấy chi tiết 1 phiếu (Bao gồm Cuống + Danh sách dòng)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var phieu = await _context.PhieuNhapXuats
                .Include(p => p.ChiTiets)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (phieu == null)
            {
                return NotFound(new { Success = false, Message = "Không tìm thấy phiếu!" });
            }

            var responseDto = new ResponsePhieuNhapXuatDto
            {
                Id = phieu.Id,
                //MaPhieu = phieu.MaPhieu,
                NgayLap = phieu.NgayLap,
                DoiTacId = phieu.IdDoiTac,
                TongTien = phieu.TongTien,
                //GhiChu = phieu.GhiChu,
                //IsPhieuNhap = phieu.IsPhieuNhap,
                LoaiPhieu = phieu.LoaiPhieu,
                ChiTiets = phieu.ChiTiets.Select(ct => new ResponseChiTietPhieuNhapXuatDto
                {
                    Id = ct.Id,
                    HangHoaId = ct.IdHangHoa,
                    DonViTinhId = ct.IdDvt,
                    SoLo=ct.SoLo,
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia,
                    ThanhTien = ct.ThanhTien


                }).ToList()
            };

            return Ok(new { Success = true, Data = responseDto });
        }

        // 3. POST: api/PhieuNhapXuat - Thêm mới Phiếu + Chi tiết + Cập nhật Tồn kho
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestPhieuNhapXuatDto dto)
        {
            if (!ModelState.IsValid || dto.ChiTiets == null || !dto.ChiTiets.Any())
            {
                return BadRequest(new { Success = false, Message = "Dữ liệu phiếu hoặc chi tiết không hợp lệ!" });
            }

            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync<IActionResult>(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    // A. Tạo Header (Cuống phiếu)
                    var phieu = new PhieuNhapXuat
                    {
                        //Id=dto.Id,
                        //MaPhieu = dto.MaPhieu,
                        NgayLap = dto.NgayLap.ToUniversalTime(),
                        IdDoiTac = dto.DoiTacId,
                        //GhiChu = dto.GhiChu,
                        //IsPhieuNhap = dto.IsPhieuNhap,
                        LoaiPhieu = dto.LoaiPhieu,
                        TongTien = dto.ChiTiets.Sum(x => x.ThanhTien)
                    };

                    _context.PhieuNhapXuats.Add(phieu);
                    await _context.SaveChangesAsync(); // Lấy phieu.Id tự tăng

                    // B. Tạo Detail (Chi tiết phiếu)
                    var chiTiets = dto.ChiTiets.Select(ct => new ChiTietPhieuNhapXuat
                    {
                        Id = phieu.Id,
                        IdHangHoa = ct.HangHoaId,
                        IdDvt = ct.DonViTinhId,
                        SoLo=ct.SoLo,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ThanhTien = ct.ThanhTien
                    }).ToList();

                    await _context.ChiTietPhieuNhapXuats.AddRangeAsync(chiTiets);

                    // C. Cập nhật Tồn kho
                    foreach (var item in dto.ChiTiets)
                    {
                        var tonKho = await _context.TonKhos.FirstOrDefaultAsync(x => x.IdHangHoa == item.HangHoaId && x.SoLo==item.SoLo);
                        if (tonKho == null)
                        {
                            tonKho = new TonKho
                            {
                                IdHangHoa = item.HangHoaId,
                                SoLo=item.SoLo,
                                SoLuong = (dto.LoaiPhieu==1 || dto.LoaiPhieu == 4) ? item.SoLuong : -item.SoLuong
                            };
                            _context.TonKhos.Add(tonKho);
                        }
                        else
                        {
                            if (dto.LoaiPhieu == 1 || dto.LoaiPhieu == 4)
                            {
                                tonKho.SoLuong += item.SoLuong;
                            }
                            else
                            {
                                if (tonKho.SoLuong < item.SoLuong)
                                {
                                    throw new Exception($"Mặt hàng ID {item.HangHoaId} không đủ tồn kho để xuất!");
                                }
                                tonKho.SoLuong -= item.SoLuong;
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok(new { Success = true, Message = "Lưu phiếu thành công!", Id = phieu.Id });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return BadRequest(new { Success = false, Message = ex.Message });
                }
            });
        }

        // 4. PUT: api/PhieuNhapXuat/5 - Cập nhật Phiếu (Thêm/Sửa/Xóa dòng + Revert/Apply Tồn kho)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestPhieuNhapXuatDto dto)
        {
            if (!ModelState.IsValid || dto.ChiTiets == null || !dto.ChiTiets.Any())
            {
                return BadRequest(new { Success = false, Message = "Dữ liệu không hợp lệ!" });
            }

            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync<IActionResult>(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var phieuDb = await _context.PhieuNhapXuats
                        .Include(p => p.ChiTiets)
                        .FirstOrDefaultAsync(p => p.Id == id);

                    if (phieuDb == null)
                    {
                        return NotFound(new { Success = false, Message = "Không tìm thấy phiếu!" });
                    }

                    // BƯỚC 1: Hoàn tác (Revert) tác động tồn kho của các dòng cũ
                    foreach (var oldItem in phieuDb.ChiTiets)
                    {
                        var tonKho = await _context.TonKhos.FirstOrDefaultAsync(t => t.IdHangHoa == oldItem.IdHangHoa && t.SoLo == oldItem.SoLo);
                        if (tonKho != null)
                        {
                            if (phieuDb.LoaiPhieu == 1 || phieuDb.LoaiPhieu == 4)
                                tonKho.SoLuong -= oldItem.SoLuong; // Phiếu nhập cũ -> Trừ trả lại
                            else
                                tonKho.SoLuong += oldItem.SoLuong; // Phiếu xuất cũ -> Cộng trả lại
                        }
                    }

                    // BƯỚC 2: Cập nhật thông tin Header và thay thế Chi tiết cũ bằng Chi tiết mới
                    //
                    //phieuDb.Id = dto.Id;
                    phieuDb.NgayLap = dto.NgayLap.ToUniversalTime();
                    phieuDb.IdDoiTac = dto.DoiTacId;
                    //phieuDb.GhiChu = dto.GhiChu;
                    phieuDb.LoaiPhieu = dto.LoaiPhieu;
                    phieuDb.TongTien = dto.ChiTiets.Sum(x => x.ThanhTien);

                    // Xóa sạch dòng cũ trong DB
                    _context.ChiTietPhieuNhapXuats.RemoveRange(phieuDb.ChiTiets);

                    // Thêm danh sách dòng mới
                    var newChiTiets = dto.ChiTiets.Select(ct => new ChiTietPhieuNhapXuat
                    {
                        Id = phieuDb.Id,
                        IdHangHoa = ct.HangHoaId,
                        IdDvt = ct.DonViTinhId,
                        SoLo=ct.SoLo,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ThanhTien = ct.ThanhTien
                    }).ToList();

                    await _context.ChiTietPhieuNhapXuats.AddRangeAsync(newChiTiets);

                    // BƯỚC 3: Áp dụng tác động tồn kho theo danh sách chi tiết mới
                    foreach (var newItem in dto.ChiTiets)
                    {
                        var tonKho = await _context.TonKhos.FirstOrDefaultAsync(t => t.IdHangHoa == newItem.HangHoaId && t.SoLo == newItem.SoLo);
                        if (tonKho == null)
                        {
                            tonKho = new TonKho
                            {
                                IdHangHoa = newItem.HangHoaId,
                                SoLuong = (dto.LoaiPhieu == 1 || dto.LoaiPhieu == 4) ? newItem.SoLuong : -newItem.SoLuong
                            };
                            _context.TonKhos.Add(tonKho);
                        }
                        else
                        {
                            if (dto.LoaiPhieu == 1 || dto.LoaiPhieu == 4)
                            {
                                tonKho.SoLuong += newItem.SoLuong;
                            }
                            else
                            {
                                if (tonKho.SoLuong < newItem.SoLuong)
                                {
                                    throw new Exception($"Không đủ tồn kho cho mặt hàng ID {newItem.HangHoaId}!");
                                }
                                tonKho.SoLuong -= newItem.SoLuong;
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok(new { Success = true, Message = "Cập nhật phiếu thành công!" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return BadRequest(new { Success = false, Message = ex.Message });
                }
            });
        }

        // 5. DELETE: api/PhieuNhapXuat/5 - Xóa 1 phiếu + Hoàn tồn kho
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync<IActionResult>(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var phieuDb = await _context.PhieuNhapXuats
                        .Include(p => p.ChiTiets)
                        .FirstOrDefaultAsync(p => p.Id == id);

                    if (phieuDb == null)
                    {
                        return NotFound(new { Success = false, Message = "Không tìm thấy phiếu để xóa!" });
                    }

                    // Hoàn tác lại số lượng tồn kho trước khi xóa
                    foreach (var item in phieuDb.ChiTiets)
                    {
                        var tonKho = await _context.TonKhos.FirstOrDefaultAsync(t => t.IdHangHoa == item.IdHangHoa && t.SoLo == item.SoLo);
                        if (tonKho != null)
                        {
                            if (phieuDb.LoaiPhieu == 1 || phieuDb.LoaiPhieu == 4)
                                tonKho.SoLuong -= item.SoLuong;
                            else
                                tonKho.SoLuong += item.SoLuong;
                        }
                    }

                    // EF Core Cascade Delete sẽ tự động xóa ChiTietPhieuNhapXuat liên quan
                    _context.PhieuNhapXuats.Remove(phieuDb);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok(new { Success = true, Message = "Xóa phiếu và cập nhật kho thành công!" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return BadRequest(new { Success = false, Message = ex.Message });
                }
            });
        }
    }
}
