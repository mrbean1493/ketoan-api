using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketoan.Client.ClassComponent
{
    internal class DocTienHelper
    {
        private static readonly string[] ChuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        private static readonly string[] Tien = { "", "nghìn", "triệu", "tỷ" };

        public static string DocTienBangChu(decimal soTien)
        {
            if (soTien == 0) return "Không đồng";

            long tien = (long)Math.Abs(soTien);
            if (tien == 0) return "Không đồng";

            string result = "";
            int lan = 0;
            long so = 0;

            do
            {
                so = tien % 1000;
                if (so > 0)
                {
                    string chu = DocBlockBasSo((int)so, tien > 1000);
                    result = chu + " " + Tien[lan] + " " + result;
                }
                else if (lan == 3) // Xử lý trường hợp hàng tỷ tròn (ví dụ 1.000.000.000.000)
                {
                    result = Tien[lan] + " " + result;
                }

                tien /= 1000;
                lan++;
                if (lan > 3) lan = 1; // Vòng lặp lại cấp nghìn, triệu cho số > 1.000 tỷ
            } while (tien > 0);

            result = result.Trim();
            if (string.IsNullOrEmpty(result)) return "Không đồng";

            // Viết hoa chữ cái đầu tiên và thêm đuôi "đồng"
            result = char.ToUpper(result[0]) + result.Substring(1) + " đồng";

            // Dọn dẹp khoảng trắng thừa
            while (result.Contains("  ")) result = result.Replace("  ", " ");

            return result;
        }

        private static string DocBlockBasSo(int number, bool hasParent)
        {
            int tram = number / 100;
            int chuc = (number % 100) / 10;
            int donVi = number % 10;
            string result = "";

            // Đọc hàng trăm
            if (tram > 0 || hasParent)
            {
                result += ChuSo[tram] + " trăm ";
            }

            // Đọc hàng chục
            if (chuc > 1)
            {
                result += ChuSo[chuc] + " mươi ";
                if (donVi == 1) result += "mốt ";
                else if (donVi == 5) result += "lăm ";
                else if (donVi > 0) result += ChuSo[donVi] + " ";
            }
            else if (chuc == 1)
            {
                result += "mười ";
                if (donVi == 5) result += "lăm ";
                else if (donVi > 0) result += ChuSo[donVi] + " ";
            }
            else if (chuc == 0 && donVi > 0)
            {
                if (tram > 0 || hasParent) result += "lẻ ";
                if (donVi == 5 && (tram > 0 || hasParent)) result += "năm ";
                else result += ChuSo[donVi] + " ";
            }

            return result.TrimEnd();
        }
    }
}
