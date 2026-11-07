using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ketoan.Client.DTOs
{
    public class HangTonKhoDtoClient
    {
        [JsonPropertyName("id_hang_hoa")]
        public int id_hang_hoa { get; set; }
        [JsonPropertyName("tenHH")]
        public string TenHH { get; set; }

        public string VietTat { get; set; }
        public string MoTa { get; set; }

        public int id_dvt { get; set; }

        public string TenDVT { get; set; }

        public decimal so_luong { get; set; }
    }
}
