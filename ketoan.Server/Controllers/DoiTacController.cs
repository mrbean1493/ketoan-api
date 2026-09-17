using ketoan.Server.Data;
using ketoan.Server.DTOs;
using ketoan.Server.Enums;
using ketoan.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ketoan.Server.Controllers
{
    [ApiController]
    [Route("api/doi-tac")]
    public class DoiTacController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoiTacController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: api/doi-tac
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] bool? isNcc,
    [FromQuery] bool? isKh)
        {
            var query = _context.DoiTacs.AsQueryable();
            // 1. Lọc theo Nhà cung cấp (nếu có truyền parameter)
            if (isNcc.HasValue)
            {
                query = query.Where(x => x.is_ncc == isNcc.Value);
            }
            // 2. Lọc theo Khách hàng (nếu có truyền parameter)
            if (isKh.HasValue)
            {
                query = query.Where(x => x.is_kh == isKh.Value);
            }
            // Nếu người dùng có truyền từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                //string kw = keyword.Trim().ToLower();
                //string kw = $"%{keyword.Trim()}%"; // Tạo Pattern tìm kiếm dạng %An%
                /*
                query = query.Where(x =>
        EF.Functions.ILike(x.TenDoiTac, kw) ||
        (x.MaDoiTac != null && EF.Functions.ILike(x.MaDoiTac, kw)) ||
        (x.SoDienThoai != null && EF.Functions.ILike(x.SoDienThoai, kw)) ||
        (x.SoDienThoai2 != null && EF.Functions.ILike(x.SoDienThoai2, kw))
    );
                */
                // Sử dụng .ToLower() cho cả thuộc tính DB và từ khóa tìm kiếm
                /*
                query = query.Where(x =>
                    (x.TenDoiTac != null && x.TenDoiTac.ToLower().Contains(kw)) ||
                    (x.MaDoiTac != null && x.MaDoiTac.ToLower().Contains(kw)) ||
                    (x.SoDienThoai != null && x.SoDienThoai.ToLower().Contains(kw)) ||
                    (x.SoDienThoai2 != null && x.SoDienThoai2.ToLower().Contains(kw))
                );
                */
                string kw = keyword.Trim();

                query = query.Where(x =>
                    EF.Functions.ILike(x.TenDoiTac, $"%{kw}%") ||
                    (x.MaDoiTac != null && EF.Functions.ILike(x.MaDoiTac, $"%{kw}%")) ||
                    (x.SoDienThoai != null && EF.Functions.ILike(x.SoDienThoai, $"%{kw}%")) ||
                    (x.SoDienThoai2 != null && EF.Functions.ILike(x.SoDienThoai2, $"%{kw}%"))
                );
            }

            var list = await query
                .Select(x => new ResponseDoiTacDto
                {
                    Id = x.Id,
                    TenDoiTac = x.TenDoiTac,
                    SoDienThoai = x.SoDienThoai,
                    SoDienThoai2 = x.SoDienThoai2,
                    MaDoiTac = x.MaDoiTac
                })
                .ToListAsync();

            return Ok(new ApiResponseDoiTac<List<ResponseDoiTacDto>>
            {
                Success = true,
                Data = list,
                Message = "Lấy danh sách thành công"
            });
        }

        // 2. POST: api/doi-tac
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestDoiTacDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (dto.loaiDoiTac == LoaiDoiTac.KhachHang)//form KH
            {
                //is_kh=true -> trùng -> return
                //is_kh=false -> là ncc -> hỏi có muốn thêm là KH ko

                string tenDoiTacTrimmed = dto.TenDoiTac.Trim();
                string vietTatTrimmed = dto.MaDoiTac.Trim();

                // 1. Lấy ra bản ghi trùng tên hoặc mã đầu tiên tìm thấy
                var existingDoiTac = await _context.DoiTacs
                    .FirstOrDefaultAsync(x => x.TenDoiTac.ToLower() == tenDoiTacTrimmed.ToLower()
                                           || x.MaDoiTac.ToLower() == vietTatTrimmed.ToLower());
                if(existingDoiTac != null)
                {
                    if (existingDoiTac.is_kh)
                    {
                        return BadRequest(new ApiResponseDoiTac<object>
                        {
                            Success = false,
                            Message = $"Đối tác tên '{tenDoiTacTrimmed}' đã tồn tại trong hệ thống!"
                        });
                    }
                    else
                    {
                        // Khi cần hỏi xác nhận từ người dùng
                        return Ok(new ApiResponseDoiTac<object>
                        {
                            Success = false,
                            IsRequireConfirm = true,
                            ExistingId = existingDoiTac.Id,
                            Message = "Đối tác đã tồn tại dưới dạng Nhà cung cấp. Bạn có muốn họ cũng là Khách hàng không?"
                        });
                    }
                }
            }
            else//form NCC
            {
                string tenDoiTacTrimmed = dto.TenDoiTac.Trim();
                string vietTatTrimmed = dto.MaDoiTac.Trim();

                // 1. Lấy ra bản ghi trùng tên hoặc mã đầu tiên tìm thấy
                var existingDoiTac = await _context.DoiTacs
                    .FirstOrDefaultAsync(x => x.TenDoiTac.ToLower() == tenDoiTacTrimmed.ToLower()
                                           || x.MaDoiTac.ToLower() == vietTatTrimmed.ToLower());
                if (existingDoiTac != null)
                {
                    if (existingDoiTac.is_ncc)
                    {
                        return BadRequest(new ApiResponseDoiTac<object>
                        {
                            Success = false,
                            Message = $"Đối tác tên '{tenDoiTacTrimmed}' đã tồn tại trong hệ thống!"
                        });
                    }
                    else
                    {
                        // Khi cần hỏi xác nhận từ người dùng
                        return Ok(new ApiResponseDoiTac<object>
                        {
                            Success = false,
                            IsRequireConfirm = true,
                            ExistingId = existingDoiTac.Id,
                            Message = "Đối tác đã tồn tại dưới dạng Khách hàng. Bạn có muốn họ cũng là Nhà cung cấp không?"
                        });
                    }
                }
            }

            

            // 2. Tạo mới nếu chưa tồn tại
            var model = new DoiTac
            {
                TenDoiTac = dto.TenDoiTac.Trim(),
                SoDienThoai = dto.SoDienThoai.Trim(),
                SoDienThoai2 = dto.SoDienThoai2.Trim(),
                MaDoiTac = dto.MaDoiTac,
                is_ncc = dto.loaiDoiTac == LoaiDoiTac.NhaCungCap,
                is_kh=dto.loaiDoiTac==LoaiDoiTac.KhachHang
            };

            _context.DoiTacs.Add(model);
            await _context.SaveChangesAsync();

            var result = new ResponseDoiTacDto
            {
                Id = model.Id,
                TenDoiTac = model.TenDoiTac,
                SoDienThoai = model.SoDienThoai.Trim(),
                SoDienThoai2 = model.SoDienThoai2.Trim(),
                MaDoiTac = model.MaDoiTac
            };

            // Trả về OkThay vì CreatedAtAction để đảm bảo JSON luôn được ghi vào Response
            return Ok(new ApiResponse<ResponseDoiTacDto>
            {
                Success = true,
                Data = result,
                Message = "Tạo mới thành công"
            });
        }
        //2.1 cập nhật kh cũng là ncc và ngược lại
        [HttpPut("{id}/update-status-doi-tac")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] LoaiDoiTac loai)
        {
            var doiTac = await _context.DoiTacs.FindAsync(id);
            if (doiTac == null) return NotFound();

            if (loai == LoaiDoiTac.KhachHang)
            {
                doiTac.is_kh = true; // cập nhật thêm là KH
            }
            else if (loai == LoaiDoiTac.NhaCungCap)
            {
                doiTac.is_ncc = true; // cập nhật thêm là NCC
            }

            await _context.SaveChangesAsync();
            return Ok(new ApiResponseDoiTac<object> { Success = true, Message = "Cập nhật loại đối tác thành công!" });
        }


        // 3. PUT: api/doi-tac/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResponseDoiTacDto dto)
        {
            var model = await _context.DoiTacs.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            string tenDoiTacTrimmed = dto.TenDoiTac.Trim();
            string maDoiTacTrimmed = dto.MaDoiTac.Trim();
            // Kiểm tra trùng tên với bản ghi KHIỂN KHÁC bản ghi hiện tại
            bool isExist = await _context.DoiTacs
                .AnyAsync(x => x.Id != id && (x.TenDoiTac.ToLower() == tenDoiTacTrimmed.ToLower() || x.MaDoiTac.ToLower() == maDoiTacTrimmed.ToLower()));

            if (isExist)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Tên đối tác '{tenDoiTacTrimmed}' hoặc tên viết tắt '{maDoiTacTrimmed}' đã tồn tại!"
                });
            }


            model.TenDoiTac = dto.TenDoiTac.Trim();
            model.SoDienThoai = dto.SoDienThoai.Trim();
            model.SoDienThoai2 = dto.SoDienThoai2.Trim();
            model.MaDoiTac = dto.MaDoiTac;
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Cập nhật thành công" });
        }

        // 4. DELETE: api/doi-tac/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.DoiTacs.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            // 1. Kiểm tra xem có dữ liệu trong Tồn kho hay không
            bool hasPhieuXuatNhap = await _context.PhieuNhapXuats.AnyAsync(x => x.IdDoiTac == id);
            if (hasPhieuXuatNhap)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Không thể xóa đối tác này vì đã phát sinh lịch sử nhập xuất!"
                });
            }

            // 2. Thực hiện xóa nếu không vướng khóa ngoại

            _context.DoiTacs.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Xóa thành công" });
        }
    }
}
