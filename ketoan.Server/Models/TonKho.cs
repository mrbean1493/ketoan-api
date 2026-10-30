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
        public int IdHangHoa { get; set; }

        [Column("so_lo")]
        public string SoLo { get; set; }

        [Column("so_luong")]
        public decimal SoLuong { get; set; }
    }
}
