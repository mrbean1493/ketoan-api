using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ketoan.Client.DTOs
{
    internal class PhieuNhapXuatDtoClient
    {
        //public string Id { get; set; } tạm cmt
        public DateTime NgayLap { get; set; } = DateTime.Now;
        [JsonPropertyName("id_doi_tac")] // <--- Khớp với key JSON từ client
        public int DoiTacId { get; set; }
        //public string? GhiChu { get; set; }
        //public bool IsPhieuNhap { get; set; }
        public decimal TongTien { get; set; }
        public int LoaiPhieu { get; set; }
        // Danh sách chi tiết truyền lên
        public List<ChiTietPhieuNhapXuatDtoClient> ChiTiets { get; set; } = new();
    }
}
