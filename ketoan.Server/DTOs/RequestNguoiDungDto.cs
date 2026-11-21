using System.Text.Json.Serialization;

namespace ketoan.Server.DTOs
{
    public class RequestNguoiDungDto
    {
        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }

        [JsonPropertyName("TenDangNhap")]
        public string TenDangNhap { get; set; }

        [JsonPropertyName("MatKhau")]
        public string MatKhau { get; set; }

        [JsonPropertyName("SoDienThoai")]
        public string? SoDienThoai { get; set; }

        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        [JsonPropertyName("NgaySinh")]
        public DateOnly? NgaySinh { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }
        [JsonPropertyName("NgayTao")]
        public DateTime NgayTao { get; set; }

        public int ma_kho { get; set; }

        public string? dia_chi { get; set; }
    }

    public class UpdateNguoiDungDto
    {
        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }
        [JsonPropertyName("TenDangNhap")]
        public string TenDangNhap { get; set; }

        [JsonPropertyName("SoDienThoai")]
        public string? SoDienThoai { get; set; }

        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        [JsonPropertyName("NgaySinh")]
        public DateOnly? NgaySinh { get; set; }

        public bool TrangThai { get; set; }

        public int ma_kho { get; set; }

        public string? dia_chi { get; set; }
    }
}
