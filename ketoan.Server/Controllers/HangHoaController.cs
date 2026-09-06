using ketoan.Server.Data;
using ketoan.Server.DTOs;
using ketoan.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ketoan.Server.Controllers
{
    [ApiController]
    [Route("api/hang-hoa")]
    public class HangHoaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HangHoaController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: api/hang-hoa
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? keyword)
        {
            var query = _context.HangHoas.AsQueryable();

            // Nếu người dùng có truyền từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(x => x.TenHH.ToLower().Contains(kw) ||
                                         x.VietTat.ToLower().Contains(kw));
            }

            var list = await query
                .Select(x => new ResponseHangHoaDto
                {
                    Id = x.Id,
                    TenHH = x.TenHH,
                    VietTat = x.VietTat,
                    MoTa = x.MoTa,
                    id_dvt = x.id_dvt,
                    // Trỏ thẳng vào lấy chuỗi TenDVT từ Navigation Property
                    TenDVT = x.DonViTinh != null ? x.DonViTinh.TenDVT : ""
                })
                .ToListAsync();

            return Ok(new ApiResponseHangHoa<List<ResponseHangHoaDto>>
            {
                Success = true,
                Data = list,
                Message = "Lấy danh sách thành công"
            });
        }

        // 2. POST: api/hang-hoa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestHangHoaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string tenHHTrimmed = dto.TenHH.Trim();

            // 1. Kiểm tra trùng tên trong Database (Bỏ qua hoa/thường)
            bool isExist = await _context.HangHoas
                .AnyAsync(x => x.TenHH.ToLower() == tenHHTrimmed.ToLower());

            if (isExist)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Hàng hóa tên '{tenHHTrimmed}' đã tồn tại trong hệ thống!"
                });
            }

            // 2. Tạo mới nếu chưa tồn tại
            var model = new HangHoa
            {
                TenHH = dto.TenHH.Trim(),
                VietTat=dto.VietTat.Trim(),
                MoTa=dto.MoTa.Trim(),
                id_dvt=dto.id_dvt
            };

            _context.HangHoas.Add(model);
            await _context.SaveChangesAsync();

            // Lấy TenDVT từ DB để gán vào DTO trả về
            var tenDvt = await _context.DVTs
                .Where(d => d.Id == model.id_dvt)
                .Select(d => d.TenDVT)
                .FirstOrDefaultAsync() ?? "";

            var result = new ResponseHangHoaDto
            {
                Id = model.Id,
                TenHH = model.TenHH,
                VietTat= model.VietTat.Trim(),
                MoTa= model.MoTa.Trim(),
                id_dvt=model.id_dvt,
                TenDVT=tenDvt
            };

            // Trả về OkThay vì CreatedAtAction để đảm bảo JSON luôn được ghi vào Response
            return Ok(new ApiResponse<ResponseHangHoaDto>
            {
                Success = true,
                Data = result,
                Message = "Tạo mới thành công"
            });
        }

        // 3. PUT: api/hang-hoa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestHangHoaDto dto)
        {
            var model = await _context.HangHoas.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            string tenHHTrimmed = dto.TenHH.Trim();
            string tenVietTatTrimmed = dto.VietTat.Trim();
            // Kiểm tra trùng tên với bản ghi KHIỂN KHÁC bản ghi hiện tại
            bool isExist = await _context.HangHoas
                .AnyAsync(x => x.Id != id && (x.TenHH.ToLower() == tenHHTrimmed.ToLower() || x.VietTat.ToLower() == tenVietTatTrimmed.ToLower()));

            if (isExist)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Tên hàng hóa '{tenHHTrimmed}' hoặc tên viết tắt '{tenVietTatTrimmed}' đã tồn tại!"
                });
            }


            model.TenHH = dto.TenHH.Trim();
            model.VietTat=dto.VietTat.Trim();
            model.MoTa=dto.MoTa.Trim();
            model.id_dvt=dto.id_dvt;
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Cập nhật thành công" });
        }

        // 4. DELETE: api/don-vi-tinh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.HangHoas.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            // 1. Kiểm tra xem có dữ liệu trong Tồn kho hay không
            bool hasTonKho = await _context.TonKhos.AnyAsync(x => x.IdHangHoa == id );
            if (hasTonKho)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Không thể xóa hàng hóa này vì vẫn còn số lượng tồn kho!"
                });
            }

            // 2. Kiểm tra xem đã từng phát sinh giao dịch Nhập/Xuất kho chưa
            bool hasGiaoDich = await _context.ChiTietPhieuNhapXuats.AnyAsync(x => x.IdHangHoa == id);
            if (hasGiaoDich)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Không thể xóa hàng hóa đã phát sinh lịch sử nhập/xuất kho!"
                });
            }


            // 3. Thực hiện xóa nếu không vướng khóa ngoại

            _context.HangHoas.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Xóa thành công" });
        }
    }
}
