using ketoan.Server.Data;
using ketoan.Server.DTOs;
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
                            select new ResponseTonKhoDto
                            {
                                id_hang_hoa = h.Id,
                                viettat = h.VietTat,
                                tenhanghoa = h.TenHH,
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
    }
}
