using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("chitietphieuthuchi")]
    public class ChiTietPhieuThuChi
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // <--- BỔ SUNG DÒNG NÀY ĐỂ BÁO EF CORE KHÔNG TỰ Ý INSERT CỘT ID
        [Column("id")]
        public int Id { get; set; }

        [Column("id_phieu_thu_chi")]
        public int Id_phieu_thu_chi { get; set; }

        [Column("id_phieu_nhap_xuat")]
        public int Id_phieu_nhap_xuat { get; set; }

        [Column("so_tien_thanh_toan")]
        public decimal So_tien_thanh_toan { get; set; }

        // Navigation Properties
        public PhieuThuChi PhieuThuChi { get; set; } = null!;
    }
}
