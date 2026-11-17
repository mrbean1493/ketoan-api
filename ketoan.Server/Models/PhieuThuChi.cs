using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("phieuthuchi")]
    public class PhieuThuChi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // <--- BỔ SUNG DÒNG NÀY ĐỂ BÁO EF CORE KHÔNG TỰ Ý INSERT CỘT ID
        [Column("id")]

        public int Id { get; set; }

        [Column("id_doi_tac")]
        public int IdDoiTac { get; set; }

        [Column("loai_phieu")]
        public int LoaiPhieu { get; set; }

        [Column("ngay_lap")]
        public DateTime NgayLap { get; set; }

        [Column("tong_tien")]
        public decimal TongTien { get; set; }

        [Column("ngay_cap_nhat")]
        public DateTime NgayCapNhat { get; set; }

        public List<ChiTietPhieuThuChi> ChiTietThuChis { get; set; } = new();
    }
}
