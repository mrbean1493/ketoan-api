using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("NguoiDung")] // Tên bảng trên Neon (mặc định Postgres viết thường)
    public class NguoiDung
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("TenNguoiDung")]
        public string TenNguoiDung { get; set; } = string.Empty;

        [Column("TenDangNhap")]
        public string TenDangNhap { get; set; } = string.Empty;

        [Column("MatKhau")]
        public string MatKhau { get; set; } = string.Empty;

        [Column("SoDienThoai")]
        public string SoDienThoai { get; set; } = string.Empty;

        [Column("Email")]
        public string Email { get; set; } = string.Empty;

        [Column("NgaySinh")]
        public DateOnly? NgaySinh { get; set; }

        [Column("TrangThai")]
        public bool TrangThai { get; set; } = true;
    }
}
