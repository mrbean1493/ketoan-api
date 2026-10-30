namespace ketoan.Server.DTOs
{
    public class ResponsePhieuNhapXuatDto
    {
        public int Id { get; set; }
        //public string MaPhieu { get; set; } = string.Empty;
        public DateTime NgayLap { get; set; }
        public int DoiTacId { get; set; }
        public string TenDoiTac { get; set; }
        public decimal TongTien { get; set; }

        public int LoaiPhieu { get; set; }
        //public string? GhiChu { get; set; }
        //public bool IsPhieuNhap { get; set; }



        // Lồng danh sách chi tiết phiếu trả về
        public List<ResponseChiTietPhieuNhapXuatDto> ChiTiets { get; set; } = new();
    }
}
