using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("kho")] //trên neon.tech
    public class Kho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ép EF Core không truyền Id để DB tự tăng
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("ten_kho")]
        public string ten_kho { get; set; }

        [Column("dia_chi")]
        public string dia_chi { get; set; }

        [Column("so_dien_thoai")]
        public string so_dien_thoai { get; set; }

        [Column("so_dien_thoai_2")]
        public string so_dien_thoai_2 { get; set; }
    }
}
