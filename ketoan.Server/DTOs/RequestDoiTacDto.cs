using ketoan.Server.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.DTOs
{
    public class RequestDoiTacDto
    {
        [Required(ErrorMessage = "Tên đối tác không được để trống")]
        public string TenDoiTac { get; set; }

        public string SoDienThoai { get; set; }

        public string SoDienThoai2 { get; set; }

        public string MaDoiTac { get; set; }

        public bool is_ncc { get; set; }
        public bool is_kh { get; set; }

        public LoaiDoiTac loaiDoiTac { get; set; }
    }
}
