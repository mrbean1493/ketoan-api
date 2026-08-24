using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("dvt")] //trên neon.tech
    public class DonViTinh
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("TenDVT")]
        public string TenDVT { get; set; }
    }
}
