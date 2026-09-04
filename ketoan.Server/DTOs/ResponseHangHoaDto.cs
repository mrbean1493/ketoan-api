using ketoan.Server.Models;

namespace ketoan.Server.DTOs
{
    public class ResponseHangHoaDto
    {
        public int Id { get; set; }
        public string TenHH { get; set; }

        public string VietTat { get; set; }

        public string MoTa { get; set; }

        public int id_dvt { get; set; }

        public string TenDVT { get; set; }
    }

    // Wrapper chuẩn hóa phản hồi
    public class ApiResponseHangHoa<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
