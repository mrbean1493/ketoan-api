using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("chitietphieunhapxuat")]
    public class ChiTietPhieuNhapXuat
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("phieu_nhap_xuat_id")] 
        public int PhieuNhapXuatId { get; set; }


        [Column("id_hang_hoa")]
        public int IdHangHoa { get; set; }

        [Column("id_dvt")]
        public int IdDvt { get; set; }

        [Column("so_lo")]
        public string SoLo { get; set; }

        [Column("so_luong")]
        public decimal SoLuong { get; set; }

        [Column("don_gia")]
        public decimal DonGia { get; set; }

        [Column("thanh_tien")]
        public decimal ThanhTien { get; set; }

        // Navigation Properties
        public PhieuNhapXuat PhieuNhapXuat { get; set; } = null!;
    }
}
