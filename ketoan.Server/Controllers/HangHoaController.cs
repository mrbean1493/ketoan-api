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
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.HangHoas
                .Select(x => new ResponseHangHoaDto
                {
                    Id = x.Id,
                    TenHH = x.TenHH,
                    VietTat = x.VietTat,
                    MoTa = x.MoTa,
                    id_dvt = x.id_dvt,
                    DonViTinh = x.DonViTinh,
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
