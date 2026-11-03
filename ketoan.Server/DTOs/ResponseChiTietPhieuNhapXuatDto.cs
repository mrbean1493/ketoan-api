using System.Text.Json.Serialization;

namespace ketoan.Server.DTOs
{
    public class ResponseChiTietPhieuNhapXuatDto
    {
        public int Id { get; set; }

        [JsonPropertyName("id_hang_hoa")] // <--- Khớp với key JSON từ client
        public int IdHangHoa { get; set; }
        public string MaHang { get; set; } = string.Empty;
        public string TenHangHoa { get; set; } = string.Empty;

        public string SoLo { get; set; }
        public int IdDvt { get; set; }
        public string TenDonViTinh { get; set; } = string.Empty;
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
