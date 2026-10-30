namespace ketoan.Server.DTOs
{
    public class RequestChiTietPhieuNhapXuatDto
    {
        public int HangHoaId { get; set; }
        public int DonViTinhId { get; set; }

        public string SoLo { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
