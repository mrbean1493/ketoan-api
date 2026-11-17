namespace ketoan.Server.DTOs
{
    public class ResponseKhoDto
    {
        public int Id { get; set; }
        public string ten_kho { get; set; }
        public string dia_chi { get; set; }
        public string so_dien_thoai { get; set; }
        public string so_dien_thoai_2 { get; set; }
    }

    // Wrapper chuẩn hóa phản hồi
    public class ApiResponseKho<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
