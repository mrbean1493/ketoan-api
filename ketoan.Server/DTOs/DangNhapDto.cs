namespace ketoan.Server.DTOs
{
    public class DangNhapDto
    {
        public string Message { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        //public string VaiTro { get; set; } = string.Empty;
        public List<string> DanhSachQuyen { get; set; } = new List<string>();
        public DateOnly? NgaySinh { get; set; }
    }
}
