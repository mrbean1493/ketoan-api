using ketoan.Server.Data;
using ketoan.Server.DTOs;
using ketoan.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ketoan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonKhoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TonKhoController(AppDbContext context)
        {
            _context = context;
        }





        /// API lấy danh sách hàng hóa kèm theo số lượng tồn kho
        /// </summary>
        [HttpGet("danh-sach")]
        public async Task<IActionResult> GetDanhSachTonKho(int khoId = 0, bool soluongduong=false)
        {
            try
            {
                // Ví dụ truy vấn kết hợp giữa bảng Hàng hóa và bảng Tồn kho
                var query = from h in _context.HangHoas
                            join t in _context.TonKhos on h.Id equals t.id_hang_hoa into tkGroup
                            from tk in tkGroup.DefaultIfEmpty() // Left join để lấy cả sản phẩm chưa phát sinh giao dịch tồn kho nếu cần
                            // 2. Left Join với bảng Đơn vị tính (DVT) để lấy tên đơn vị tính
                            join d in _context.DVTs on h.id_dvt equals d.Id into dvtGroup
                            from dvt in dvtGroup.DefaultIfEmpty() // Dùng DefaultIfEmpty để phòng hờ hàng hóa chưa gắn đơn vị tính vẫn không bị mất dữ liệu
                            select new ResponseTonKhoDto
                            {
                                id_hang_hoa = h.Id,
                                viettat = h.VietTat,
                                tenhanghoa = h.TenHH,
                                id_dvt=h.id_dvt,
                                tendvt = dvt != null ? dvt.TenDVT : "", // Thay TenDVT bằng tên cột thực tế trong bảng DVT của bạn
                                so_lo = tk != null ? tk.so_lo : "",
                                //DinhMuc = h.DinhMuc,
                                so_luong = tk != null ? tk.so_luong : 0,
                                //TenKho = tk != null ? tk.TenKho : "Chưa xác định"
                            };

                // Nếu có lọc theo kho cụ thể
                if (khoId > 0)
                {
                    // query = query.Where(x => x.KhoId == khoId);
                }
                if (soluongduong)
                {
                    query = query.Where(x => x.so_luong > 0);
                }

                var result = await query.ToListAsync();

                return Ok(new { Success = true, Data = result });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }


        [HttpPost("tinh-lai-ton-kho")]
        public async Task<IActionResult> TinhLaiTonKho()
        {
            try
            {
                // 1. Gom nhóm tính toán từ lịch sử phiếu
                var danhSachPhatSinh = await (from chiTiet in _context.ChiTietPhieuNhapXuats
                                              join phieu in _context.PhieuNhapXuats on chiTiet.PhieuNhapXuatId equals phieu.Id
                                              select new
                                              {
                                                  chiTiet.IdHangHoa,
                                                  chiTiet.SoLo,
                                                  chiTiet.SoLuong,
                                                  IsPhieuNhap = (phieu.LoaiPhieu==1|| phieu.LoaiPhieu == 4) // Điều kiện phân biệt phiếu nhập / xuất
                                              })
                            .GroupBy(x => new { x.IdHangHoa, x.SoLo })
                            .Select(g => new
                            {
                                IdHangHoa = g.Key.IdHangHoa,
                                SoLo = g.Key.SoLo,
                                TongTon = g.Sum(x => x.IsPhieuNhap ? x.SoLuong : -x.SoLuong)
                            })
                            .ToListAsync();

                // 2. (Tùy chọn) Cập nhật ngược lại vào bảng TonKho trong Database
                foreach (var item in danhSachPhatSinh)
                {
                    var tonKhoRecord = await _context.TonKhos.FirstOrDefaultAsync(x => x.id_hang_hoa == item.IdHangHoa && x.so_lo == item.SoLo);
                    if (tonKhoRecord != null)
                    {
                        tonKhoRecord.so_luong = item.TongTon; // Cập nhật số lượng mới
                    }
                    else
                    {
                        // Nếu chưa có dòng tồn kho thì thêm mới
                        _context.TonKhos.Add(new TonKho
                        {
                            id_hang_hoa = item.IdHangHoa,
                            so_lo = item.SoLo, // Gán thêm số lô
                            so_luong = item.TongTon
                        });
                    }
                }

                await _context.SaveChangesAsync();

                return Ok(new { Success = true, Message = "Đã tính toán và cập nhật lại tồn kho thành công!" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }
    }
}
