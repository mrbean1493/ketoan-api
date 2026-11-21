using ketoan.Server.Data;
using ketoan.Server.DTOs;
using ketoan.Server.Models;
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
                TenDangNhap = user.TenDangNhap,
                TenNguoiDung = user.TenNguoiDung ?? string.Empty, // Nếu thuộc tính HoTen có trong model NguoiDung
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

        // 1. GET: api/nguoidung
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? keyword)
        {
            try
            {
                var query = _context.NguoiDungs.AsQueryable();

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
                    //query = query.Where(x => x.TenDoiTac.ToLower().Contains(kw) || x.MaDoiTac.ToLower().Contains(kw));


                    query = query.Where(x =>
                        EF.Functions.ILike(x.TenDangNhap, $"%{kw}%") ||
                        (x.TenNguoiDung != null && EF.Functions.ILike(x.TenNguoiDung, $"%{kw}%"))
                    );

                }

                var list = await query
                    .Select(x => new ResponseNguoiDungDto
                    {
                        Id = x.Id,
                        TenNguoiDung = x.TenNguoiDung,
                        TenDangNhap=x.TenDangNhap,
                        dia_chi = x.dia_chi ?? "",
                        SoDienThoai = x.SoDienThoai,
                        Email = x.Email,
                        ma_kho = x.ma_kho??0,
                        TrangThai=x.TrangThai,
                        NgaySinh=x.NgaySinh??DateOnly.FromDateTime(DateTime.Now),
                        NgayTao=x.NgayTao
                    })
                    .ToListAsync();

                return Ok(new ApiResponse<List<ResponseNguoiDungDto>>
                {
                    Success = true,
                    Data = list,
                    Message = "Lấy danh sách thành công"
                });


            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        // 2. POST: api/nguoidung
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestNguoiDungDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string tenDangNhapTrimmed = dto.TenDangNhap.Trim();

            // 1. Kiểm tra trùng tên đăng nhập trong Database (Bỏ qua hoa/thường)
            bool isExist = await _context.NguoiDungs
                .AnyAsync(x => x.TenDangNhap.ToLower() == tenDangNhapTrimmed.ToLower());

            if (isExist)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Tên đăng nhập '{tenDangNhapTrimmed}' đã tồn tại trong hệ thống!"
                });
            }

            // 2. Tạo mới nếu chưa tồn tại
            var model = new NguoiDung
            {
                TenDangNhap = dto.TenDangNhap.Trim(),
                TenNguoiDung = dto.TenNguoiDung,
                MatKhau= BCrypt.Net.BCrypt.HashPassword(dto.MatKhau),
                SoDienThoai = dto.SoDienThoai ?? "",
                Email = dto.Email ?? "",
                NgaySinh = dto.NgaySinh ?? DateOnly.FromDateTime(DateTime.Now),
                TrangThai = dto.TrangThai,
                NgayTao = dto.NgayTao,
                ma_kho = dto.ma_kho,
                dia_chi = dto.dia_chi ?? ""
            };

            _context.NguoiDungs.Add(model);
            await _context.SaveChangesAsync();

            var result = new ResponseNguoiDungDto
            {
                Id = model.Id,
                TenDangNhap = model.TenDangNhap,
                TenNguoiDung=model.TenNguoiDung,
                SoDienThoai=model.SoDienThoai ?? "",
                Email=model.Email??"",
                NgaySinh=model.NgaySinh??DateOnly.FromDateTime(DateTime.Now),
                TrangThai=model.TrangThai,
                NgayTao=model.NgayTao,
                ma_kho=model.ma_kho??0,
                dia_chi=model.dia_chi??""
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
            return Ok(new ApiResponse<ResponseNguoiDungDto>
            {
                Success = true,
                Data = result,
                Message = "Tạo mới thành công"
            });
        }

        // 3. PUT: api/nguoidung/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateNguoiDungDto dto)
        {
            var model = await _context.NguoiDungs.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            string tenDangNhapTrimmed = dto.TenDangNhap.Trim();

            // Kiểm tra trùng tên với bản ghi KHIỂN KHÁC bản ghi hiện tại
            bool isExist = await _context.NguoiDungs
                .AnyAsync(x => x.Id != id && x.TenDangNhap.ToLower() == tenDangNhapTrimmed.ToLower());

            if (isExist)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Tên đăng nhập '{tenDangNhapTrimmed}' đã tồn tại trong hệ thống!"
                });
            }


            //model.TenDangNhap = dto.TenDangNhap.Trim();
            model.TenNguoiDung = dto.TenNguoiDung;
            model.SoDienThoai = dto.SoDienThoai ?? "";
            model.Email = dto.Email ?? "";
            model.NgaySinh = dto.NgaySinh ?? DateOnly.FromDateTime(DateTime.Now);
            model.TrangThai = dto.TrangThai;
            //model.NgayTao = dto.NgayTao;
            model.ma_kho = dto.ma_kho;
            model.dia_chi = dto.dia_chi ?? "";
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Cập nhật thành công" });
        }

        // 4. DELETE: api/don-vi-tinh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.NguoiDungs.FindAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse<object> { Success = false, Message = "Không tìm thấy dữ liệu" });
            }

            // 1. Kiểm tra khóa ngoại ở bảng Hàng hóa (Thay HangHoas và DvtId theo đúng DbContext của bạn)
            bool isUsedInPhieuNhapXuat = await _context.PhieuNhapXuats.AnyAsync(h => h.id_nguoi_dung == id);

            if (isUsedInPhieuNhapXuat)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Người dùng '{model.TenDangNhap}' đã phát sinh dữ liệu trong Phiếu nhập xuất, không thể xóa. Nếu không muốn hoạt động nữa chuyển trạng thái về không hoạt động!"
                });
            }

            // 2. Thực hiện xóa nếu không vướng khóa ngoại

            _context.NguoiDungs.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string> { Success = true, Message = "Xóa thành công" });
        }

    }
}
