using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("dvt")] //trên neon.tech
    public class DonViTinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ép EF Core không truyền Id để DB tự tăng
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("tendvt")]
        public string TenDVT { get; set; }
    }
}
