using System.Text.Json.Serialization;

namespace ketoan.Server.DTOs
{
    public class RequestPhieuNhapXuatDto
    {
        //public int Id { get; set; } tạm cmt

        public int LoaiPhieu { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        [JsonPropertyName("id_doi_tac")] // <--- Khớp với key JSON từ client
        public int DoiTacId { get; set; }
        //public string? GhiChu { get; set; }
        //public bool IsPhieuNhap { get; set; }
        public decimal TongTien{ get; set; }
        // Lồng danh sách chi tiết phiếu
        public List<RequestChiTietPhieuNhapXuatDto> ChiTiets { get; set; } = new();
    }
}
