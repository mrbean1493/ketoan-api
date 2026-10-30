using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("phieunhapxuat")]
    public class PhieuNhapXuat
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // <--- BỔ SUNG DÒNG NÀY ĐỂ BÁO EF CORE KHÔNG TỰ Ý INSERT CỘT ID
        public int Id { get; set; }

        [Column("id_doi_tac")]
        public int IdDoiTac { get; set; }

        [Column("loai_phieu")]
        public int LoaiPhieu { get; set; }

        [Column("ngay_lap")]
        public DateTime NgayLap { get; set; }

        [Column("ma_kho")]
        public int MaKho { get; set; }

        [Column("tong_tien")]
        public decimal TongTien { get; set; }

        [Column("ngay_cap_nhat")]
        public DateTime NgayCapNhat { get; set; }

        // Navigation Properties
        public List<ChiTietPhieuNhapXuat> ChiTiets { get; set; } = new();

        //1: nhập hàng
        //2: trả hàng nhập
        //3: bán hàng
        //4: trả hàng bán
        //5: xuất hủy


    }
}
