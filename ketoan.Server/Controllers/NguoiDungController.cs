using ketoan.Server.Data;
using ketoan.Server.DTOs;
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
            bool isValid = BCrypt.Net.BCrypt.Verify(request.MatKhau, user.MatKhau);

            // Nếu bạn tạm thời lưu mật khẩu thô trong DB để test, dùng dòng bên dưới:
            //bool isValid = (user.MatKhau == request.MatKhau);

            if (!isValid)
            {
                return BadRequest(new { message = "Mật khẩu không chính xác." });
            }

            var responseDto = new DangNhapDto
            {
                Message = "Đăng nhập thành công!",
                UserId = user.Id,
                Username = user.TenDangNhap,
                HoTen = user.TenNguoiDung ?? string.Empty, // Nếu thuộc tính HoTen có trong model NguoiDung
                NgaySinh=user.NgaySinh
                //VaiTro = user.VaiTro ?? string.Empty // Nếu có phân quyền
            };

            return Ok(responseDto);
            //return Ok(new { message = "Đăng nhập thành công!", userId = user.Id, username = user.TenDangNhap });
        }

        [HttpPost("doi-mat-khau")]
        public async Task<IActionResult> DoiMatKhau([FromBody] DoiMatKhauDto model)
        {
            try
            {
                // 1. Tìm người dùng theo ID
                var user = await _context.NguoiDungs.FindAsync(model.UserId);
                if (user == null)
                {
                    return BadRequest(new { message = "Người dùng không tồn tại." });
                }

                // 2. Kiểm tra mật khẩu cũ (So sánh chuỗi hoặc Verify băm)
                bool isValid = BCrypt.Net.BCrypt.Verify(model.MatKhauCu, user.MatKhau);

                /*kiểm tra kiểu cũ ko mã hóa
                if (user.MatKhau != model.MatKhauCu)
                {
                    return BadRequest(new { message = "Mật khẩu cũ không chính xác." });
                }
                */
                if (!isValid)
                {
                    return BadRequest(new { message = "Mật khẩu cũ không chính xác." });
                }

                // 3. Cập nhật mật khẩu mới
                user.MatKhau = BCrypt.Net.BCrypt.HashPassword(model.MatKhauMoi);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Đổi mật khẩu thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }



    }
}
