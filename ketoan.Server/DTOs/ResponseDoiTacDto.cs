namespace ketoan.Server.DTOs
{
    public class ResponseDoiTacDto
    {
        public int Id { get; set; }
        public string TenDoiTac { get; set; }

        public string SoDienThoai { get; set; }

        public string SoDienThoai2 { get; set; }

        public string MaDoiTac { get; set; }

        public bool is_ncc { get; set; }
        public bool is_kh { get; set; }
    }

    // Wrapper chuẩn hóa phản hồi
    public class ApiResponseDoiTac<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        // Thuộc tính phục vụ hỏi xác nhận ở Client
        public bool IsRequireConfirm { get; set; } = false;
        public int? ExistingId { get; set; }
    }
}
