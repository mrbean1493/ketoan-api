using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("Quyen")] // Tên bảng trong Database Neon
    public class Quyen
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("TenQuyen")]
        public string TenQuyen { get; set; } = string.Empty;

        [Column("MoTa")]
        public string? MoTa { get; set; }

        // Quan hệ 1-Nhiều với bảng trung gian
        public ICollection<NguoiDungQuyen> NguoiDungQuyens { get; set; } = new List<NguoiDungQuyen>();
    }
}
