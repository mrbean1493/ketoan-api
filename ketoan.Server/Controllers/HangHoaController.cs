using ketoan.Server.Data;
using ketoan.Server.DTOs;
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
    }
}
