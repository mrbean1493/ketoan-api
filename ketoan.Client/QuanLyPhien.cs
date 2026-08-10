using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketoan.Client
{
    public static class QuanLyPhien
    {
        // Lưu ID người dùng
        public static int UserId { get; set; }

        // Lưu Tên đăng nhập
        public static string TenDangNhap { get; set; } = string.Empty;

        // Lưu Họ tên đầy đủ (nếu có)
        public static string HoTen { get; set; } = string.Empty;

        // Lưu Vai trò / Quyền (ví dụ: "Admin", "NhanVien")
        //public static string VaiTro { get; set; } = string.Empty;

        public static List<string> DanhSachQuyenQLP { get; set; } = new List<string>();
        //để chúc mừng sinh nhật
        public static DateOnly? NgaySinh {  get; set; }

        // Hàm xóa Session khi Đăng xuất
        public static void ClearSession()
        {
            UserId = 0;
            TenDangNhap = string.Empty;
            HoTen = string.Empty;
            //VaiTro = string.Empty;
            NgaySinh = null;
        }
    }
}
