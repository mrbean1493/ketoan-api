using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("doitac")]
    public class DoiTac
    {
        [Key]
        public int Id { get; set; }

        [Column("tendoitac")]
        public string TenDoiTac { get; set; }

        [Column("sodienthoai")]
        public string SoDienThoai { get; set; }

        [Column("sodienthoai2")]
        public string SoDienThoai2 { get; set; }

        [Column("madoitac")]
        public string MaDoiTac { get; set; }

        [Column("is_ncc")]
        public bool is_ncc { get; set; }

        [Column("is_kh")]
        public bool is_kh { get; set; }
    }
}
