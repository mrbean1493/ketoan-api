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

            return CreatedAtAction(nameof(GetAll), new ApiResponse<ResponseDVTDto>
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

            _context.DVTs.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Xóa thành công" });
        }
    }
}
