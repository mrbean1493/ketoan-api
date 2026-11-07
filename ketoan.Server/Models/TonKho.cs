using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("tonkho")]
    public class TonKho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // <--- BỔ SUNG DÒNG NÀY ĐỂ BÁO EF CORE KHÔNG TỰ Ý INSERT CỘT ID
        [Column("id")]
        
        public int Id { get; set; }

        [Column("id_hang_hoa")]
        public int id_hang_hoa { get; set; }

        [Column("so_lo")]
        public string so_lo { get; set; }

        [Column("so_luong")]
        public decimal so_luong { get; set; }
    }
}
