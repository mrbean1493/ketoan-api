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
        [JsonPropertyName("so_lo")]
        public string SoLo { get; set; }

        [JsonPropertyName("id_dvt")]      // <--- Khớp với key JSON từ client
        public int IdDvt { get; set; }

        [JsonPropertyName("tendvt")]
        public string TenDonViTinh { get; set; } = string.Empty;
        [JsonPropertyName("so_luong")]
        public decimal SoLuong { get; set; }
        [JsonPropertyName("don_gia")]
        public decimal DonGia { get; set; }
        [JsonPropertyName("thanh_tien")]
        public decimal ThanhTien { get; set; }
    }
}
