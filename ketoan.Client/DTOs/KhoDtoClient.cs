using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ketoan.Client.DTOs
{
    internal class KhoDtoClient
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("ten_kho")]
        public string ten_kho { get; set; }

        [JsonPropertyName("dia_chi")]
        public string dia_chi { get; set; }

        [JsonPropertyName("so_dien_thoai")]
        public string so_dien_thoai { get; set; }

        [JsonPropertyName("so_dien_thoai_2")]
        public string so_dien_thoai_2 { get; set; }
    }
}
