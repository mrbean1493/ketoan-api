using System.ComponentModel.DataAnnotations;

namespace ketoan.Server.DTOs
{
    public class RequestKhoDto
    {
        [Required(ErrorMessage = "Tên kho không được để trống")]
        public string ten_kho { get; set; }
        public string dia_chi { get; set; }
        public string so_dien_thoai { get; set; }
        public string so_dien_thoai_2 { get; set; }
    }
}
