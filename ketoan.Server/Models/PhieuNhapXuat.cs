using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ketoan.Server.Models
{
    [Table("phieunhapxuat")]
    public class PhieuNhapXuat
    {
        [Key]
        public int Id { get; set; }

        [Column("id_doi_tac")]
        public int IdDoiTac { get; set; }

        [Column("loai_phieu")]
        public int LoaiPhieu { get; set; }

        //1: nhập hàng
        //2: trả hàng nhập
        //3: bán hàng
        //4: trả hàng bán
        //5: xuất hủy


    }
}
