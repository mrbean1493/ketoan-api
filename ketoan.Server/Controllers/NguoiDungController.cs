using ketoan.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ketoan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NguoiDungController(AppDbContext context)
        {
            _context = context;
        }

        public record LoginRequest(string TenDangNhap, string MatKhau);

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.NguoiDungs
                .FirstOrDefaultAsync(u => u.TenDangNhap.ToLower() == request.TenDangNhap.ToLower());

            if (user == null || !user.TrangThai)
            {
                return BadRequest(new { message = "Tài khoản không tồn tại hoặc đã bị khóa." });
            }

            // Kiểm tra mật khẩu mã hóa BCrypt (hoặc kiểm tra chuỗi nếu bạn chưa hash)
            //bool isValid = BCrypt.Net.BCrypt.Verify(request.MatKhau, user.MatKhau);

            // Nếu bạn tạm thời lưu mật khẩu thô trong DB để test, dùng dòng bên dưới:
            bool isValid = (user.MatKhau == request.MatKhau);

            if (!isValid)
            {
                return BadRequest(new { message = "Mật khẩu không chính xác." });
            }

            return Ok(new { message = "Đăng nhập thành công!", userId = user.Id, username = user.TenDangNhap });
        }
    }
}
