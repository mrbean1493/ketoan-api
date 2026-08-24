using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketoan.Client.DTOs
{
    public class DonViTinhDtoClient
    {
        public int Id { get; set; }
        public string TenDVT { get; set; }

        // Mẹo: Override ToString() giúp hiển thị đẹp mắt khi bind vào ComboBox
        public override string ToString()
        {
            return TenDVT;
        }
    }
}
