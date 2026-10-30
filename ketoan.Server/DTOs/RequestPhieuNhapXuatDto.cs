namespace ketoan.Server.DTOs
{
    public class RequestPhieuNhapXuatDto
    {
        public int Id { get; set; }

        public int LoaiPhieu { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public int DoiTacId { get; set; }
        //public string? GhiChu { get; set; }
        //public bool IsPhieuNhap { get; set; }

        // Lồng danh sách chi tiết phiếu
        public List<RequestChiTietPhieuNhapXuatDto> ChiTiets { get; set; } = new();
    }
}
