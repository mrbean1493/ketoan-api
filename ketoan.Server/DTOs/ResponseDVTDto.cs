namespace ketoan.Server.DTOs
{
    public class ResponseDVTDto
    {
        public int Id { get; set; }
        public string TenDVT { get; set; }
    }

    // Wrapper chuẩn hóa phản hồi
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
