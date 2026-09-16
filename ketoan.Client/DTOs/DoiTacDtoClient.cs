using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ketoan.Client.DTOs
{
    public class DoiTacDtoClient
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("tenDoiTac")]
        public string TenDoiTac { get; set; }

        public string SoDienThoai { get; set; }

        public string SoDienThoai2 { get; set; }

        public string MaDoiTac { get; set; }
    }
}
