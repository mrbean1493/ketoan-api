namespace ketoan.Server.DTOs
{
    public class ResponseTonKhoDto
    {
        public int id {  get; set; }
        public int id_hang_hoa { get; set; }
        public string viettat { get; set; } = string.Empty;
        public string tenhanghoa { get; set; } = string.Empty;

        public int id_dvt { get; set; }
        public string tendvt { get; set; } = string.Empty;

        public string so_lo { get; set; }
        public decimal so_luong { get; set; }
        public string TenKho { get; set; } = string.Empty;
    }
}
