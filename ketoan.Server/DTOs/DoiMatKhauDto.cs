namespace ketoan.Server.DTOs
{
    public class DoiMatKhauDto //tự đổi mk
    {
        public int UserId { get; set; }
        public string MatKhauCu { get; set; } = string.Empty;
        public string MatKhauMoi { get; set; } = string.Empty;
    }

    public class ResetMatKhauDto //admin reset mk
    {
        public int UserId { get; set; }
        public string MatKhauMoi { get; set; } = string.Empty;
    }
}
