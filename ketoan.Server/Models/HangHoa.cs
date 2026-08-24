using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("hanghoa")] //trên neon.tech
    public class HangHoa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("tenhanghoa")]
        public string TenHH { get; set; }

        [Column("viettat")]
        public string VietTat { get; set; }

        [Column("mota")]
        public string MoTa { get; set; }

        [Column("id_dvt")]
        public int id_dvt { get; set; } //xem xét có cần tên đơn vị tính ko

        // 2. Navigation Property để Controller JOIN/Include lấy thông tin DVT
        [ForeignKey(nameof(id_dvt))]
        public virtual DonViTinh DonViTinh { get; set; }
    }
}
