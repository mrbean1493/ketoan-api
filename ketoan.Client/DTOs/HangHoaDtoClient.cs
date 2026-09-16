using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ketoan.Client.DTOs
{
    public class HangHoaDtoClient
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("tenHH")]
        public string TenHH { get; set; }

        public string VietTat { get; set; }
        public string MoTa { get; set; }

        public int id_dvt { get; set; }

        public string TenDVT { get; set; }

        // Mẹo: Override ToString() giúp hiển thị đẹp mắt khi bind vào ComboBox
        //public override string ToString()
        //{
        //    return TenDVT;
        //}
    }
}
