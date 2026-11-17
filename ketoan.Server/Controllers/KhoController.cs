using ketoan.Server.Data;
using ketoan.Server.DTOs;
using ketoan.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ketoan.Server.Controllers
{
    [ApiController]
    [Route("api/kho")]
    public class KhoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KhoController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: api/kho
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Khos
                .Select(x => new ResponseKhoDto
                {
                    Id = x.Id,
                    ten_kho = x.ten_kho,
                    dia_chi = x.dia_chi,
                    so_dien_thoai=x.so_dien_thoai,
                    so_dien_thoai_2=x.so_dien_thoai_2
                })
                .ToListAsync();

            return Ok(new ApiResponse<List<ResponseKhoDto>>
            {
                Success = true,
                Data = list,
                Message = "Lấy danh sách thành công"
            });
        }


        // 2. POST: api/kho
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestKhoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string tenKhoTrimmed = dto.ten_kho.Trim();

            // 1. Kiểm tra trùng tên trong Database (Bỏ qua hoa/thường)
            bool isExist = await _context.Khos
                .AnyAsync(x => x.ten_kho.ToLower() == tenKhoTrimmed.ToLower());

            if (isExist)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Kho '{tenKhoTrimmed}' đã tồn tại trong hệ thống!"
                });
            }

            // 2. Tạo mới nếu chưa tồn tại
            var model = new Kho
            {
                ten_kho = dto.ten_kho.Trim(),
                dia_chi=dto.dia_chi,
                so_dien_thoai=dto.so_dien_thoai,
                so_dien_thoai_2=dto.so_dien_thoai_2
            };

            _context.Khos.Add(model);
            await _context.SaveChangesAsync();

            var result = new ResponseKhoDto
            {
                Id = model.Id,
                ten_kho = model.ten_kho,
                dia_chi = dto.dia_chi,
                so_dien_thoai = dto.so_dien_thoai,
                so_dien_thoai_2 = dto.so_dien_thoai_2
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
            return Ok(new ApiResponseKho<ResponseKhoDto>
            {
                Success = true,
                Data = result,
                Message = "Tạo mới thành công"
            });
        }

        // 3. PUT: api/kho/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestKhoDto dto)
        {
            var model = await _context.Khos.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponseKho<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            string tenKhoTrimmed = dto.ten_kho.Trim();

            // Kiểm tra trùng tên với bản ghi KHIỂN KHÁC bản ghi hiện tại
            bool isExist = await _context.Khos
                .AnyAsync(x => x.Id != id && x.ten_kho.ToLower() == tenKhoTrimmed.ToLower());

            if (isExist)
            {
                return BadRequest(new ApiResponseKho<object>
                {
                    Success = false,
                    Message = $"Tên kho '{tenKhoTrimmed}' đã tồn tại!"
                });
            }


            model.ten_kho = dto.ten_kho.Trim();
            model.dia_chi = dto.dia_chi.Trim();
            model.so_dien_thoai = dto.so_dien_thoai.Trim();
            model.so_dien_thoai_2 = dto.so_dien_thoai_2.Trim();
            await _context.SaveChangesAsync();

            return Ok(new ApiResponseKho<string> { Success = true, Message = "Cập nhật thành công" });
        }

        // 4. DELETE: api/kho/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Khos.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            // 1. Kiểm tra khóa ngoại ở bảng xuất nhập (Thay HangHoas và DvtId theo đúng DbContext của bạn)
            bool isUsedInPhieuXuatNhap = await _context.PhieuNhapXuats.AnyAsync(h => h.MaKho == id);

            if (isUsedInPhieuXuatNhap)
            {
                return BadRequest(new ApiResponseKho<object>
                {
                    Success = false,
                    Message = $"Kho '{model.ten_kho}' đã phát sinh dữ liệu trong phiếu nhập xuất, không thể xóa!"
                });
            }

            // 2. Thực hiện xóa nếu không vướng khóa ngoại

            _context.Khos.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponseKho<string> { Success = true, Message = "Xóa thành công" });
        }
    }
}
