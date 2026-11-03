using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ketoan.Client.DTOs
{
    internal class ChiTietPhieuNhapXuatDtoClient
    {
        //[JsonPropertyName("id")]
        //public int Id { get; set; }

        // [JsonPropertyName("id_hang_hoa")]
        // Khớp với "hangHoaId" từ Server trả về
        [JsonPropertyName("hangHoaId")]
        public int IdHangHoa { get; set; }

        [JsonPropertyName("id_dvt")]
        public int Id_dvt { get; set; }

        public string TenDVT { get; set; }

        [JsonPropertyName("so_lo")]
        public string SoLo { get; set; }

        [JsonPropertyName("so_luong")]
        public decimal SoLuong { get; set; }

        [JsonPropertyName("don_gia")]
        public decimal DonGia { get; set; }

        //[JsonPropertyName("tong_tien")]
        //public string TongTien { get; set; }

        // Tự động tính Thành tiền
        [JsonPropertyName("thanh_tien")]
        public decimal ThanhTien => SoLuong * DonGia;
    }
}
