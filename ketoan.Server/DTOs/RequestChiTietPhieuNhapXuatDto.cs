using System.Text.Json.Serialization;

namespace ketoan.Server.DTOs
{
    public class RequestChiTietPhieuNhapXuatDto
    {
        [JsonPropertyName("id_hang_hoa")] // <--- Khớp với key JSON từ client
        public int HangHoaId { get; set; }
        [JsonPropertyName("id_dvt")]      // <--- Khớp với key JSON từ client
        public int DonViTinhId { get; set; }
        [JsonPropertyName("so_lo")]
        public string SoLo { get; set; }
        [JsonPropertyName("so_luong")]
        public decimal SoLuong { get; set; }
        [JsonPropertyName("don_gia")]
        public decimal DonGia { get; set; }
        [JsonPropertyName("thanh_tien")]
        public decimal ThanhTien { get; set; }
    }
}
