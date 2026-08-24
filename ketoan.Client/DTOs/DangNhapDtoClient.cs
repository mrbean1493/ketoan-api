using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketoan.Client.DTOs
{
    public class DangNhapDtoClient
    {
        public int UserId { get; set; }
        public string TenDangNhap { get; set; } = string.Empty;
        public string TenNguoiDung { get; set; } = string.Empty;
        //public string VaiTro { get; set; } = string.Empty;
        public List<string> DanhSachQuyen { get; set; } = new List<string>();
        public DateOnly? NgaySinh { get; set; }
    }
}
