using ketoan.Server.Data;
using ketoan.Server.DTOs;
using ketoan.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ketoan.Server.Controllers
{
    [ApiController]
    [Route("api/don-vi-tinh")]
    public class DVTController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DVTController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: api/don-vi-tinh
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.DVTs
                .Select(x => new ResponseDVTDto
                {
                    Id = x.Id,
                    TenDVT = x.TenDVT
                })
                .ToListAsync();

            return Ok(new ApiResponse<List<ResponseDVTDto>>
            {
                Success = true,
                Data = list,
                Message = "Lấy danh sách thành công"
            });
        }

        // 2. POST: api/don-vi-tinh
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResquestDVTDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string tenDvtTrimmed = dto.TenDVT.Trim();

            // 1. Kiểm tra trùng tên trong Database (Bỏ qua hoa/thường)
            bool isExist = await _context.DVTs
                .AnyAsync(x => x.TenDVT.ToLower() == tenDvtTrimmed.ToLower());

            if (isExist)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Đơn vị tính '{tenDvtTrimmed}' đã tồn tại trong hệ thống!"
                });
            }

            // 2. Tạo mới nếu chưa tồn tại
            var model = new DonViTinh
            {
                TenDVT = dto.TenDVT.Trim()
            };

            _context.DVTs.Add(model);
            await _context.SaveChangesAsync();

            var result = new ResponseDVTDto
            {
                Id = model.Id,
                TenDVT = model.TenDVT
            };
            /*
            return CreatedAtAction(nameof(GetAll), new ApiResponse<ResponseDVTDto>
            {
                Success = true,
                Data = result,
                Message = "Tạo mới thành công"
            });
            */

            // Trả về OkThay vì CreatedAtAction để đảm bảo JSON luôn được ghi vào Response
            return Ok(new ApiResponse<ResponseDVTDto>
            {
                Success = true,
                Data = result,
                Message = "Tạo mới thành công"
            });
        }

        // 3. PUT: api/don-vi-tinh/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResquestDVTDto dto)
        {
            var model = await _context.DVTs.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            string tenDvtTrimmed = dto.TenDVT.Trim();

            // Kiểm tra trùng tên với bản ghi KHIỂN KHÁC bản ghi hiện tại
            bool isExist = await _context.DVTs
                .AnyAsync(x => x.Id != id && x.TenDVT.ToLower() == tenDvtTrimmed.ToLower());

            if (isExist)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Tên đơn vị tính '{tenDvtTrimmed}' đã tồn tại!"
                });
            }


            model.TenDVT = dto.TenDVT.Trim();
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Cập nhật thành công" });
        }

        // 4. DELETE: api/don-vi-tinh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.DVTs.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            // 1. Kiểm tra khóa ngoại ở bảng Hàng hóa (Thay HangHoas và DvtId theo đúng DbContext của bạn)
            bool isUsedInHangHoa = await _context.HangHoas.AnyAsync(h => h.id_dvt == id);

            if (isUsedInHangHoa)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Đơn vị tính '{model.TenDVT}' đã phát sinh dữ liệu trong danh mục Hàng hóa, không thể xóa!"
                });
            }

            // 2. Thực hiện xóa nếu không vướng khóa ngoại

            _context.DVTs.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Xóa thành công" });
        }
    }
}
