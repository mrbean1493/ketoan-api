using System.ComponentModel.DataAnnotations;

namespace ketoan.Server.DTOs
{
    public class RequestHangHoaDto
    {
        [Required(ErrorMessage = "Tên hàng hóa không được để trống")]
        public string TenHH { get; set; }

        public string VietTat { get; set; }

        public string MoTa { get; set; }

        public int id_dvt { get; set; }
    }
}
