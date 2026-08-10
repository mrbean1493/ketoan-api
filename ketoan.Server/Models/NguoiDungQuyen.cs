using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("NguoiDungQuyen")]
    public class NguoiDungQuyen
    {
        [Column("NguoiDungId")]
        public int NguoiDungId { get; set; }

        [ForeignKey("NguoiDungId")]
        public NguoiDung NguoiDung { get; set; } = null!;

        [Column("QuyenId")]
        public int QuyenId { get; set; }

        [ForeignKey("QuyenId")]
        public Quyen Quyen { get; set; } = null!;
    }
}
