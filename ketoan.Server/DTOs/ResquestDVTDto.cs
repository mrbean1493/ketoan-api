using System.ComponentModel.DataAnnotations;

namespace ketoan.Server.DTOs
{
    public class ResquestDVTDto
    {
        [Required(ErrorMessage = "Tên đơn vị tính không được để trống")]
        public string TenDVT { get; set; }
    }
}
