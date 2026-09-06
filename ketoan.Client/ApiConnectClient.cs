using ketoan.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ketoan.Client
{
    internal class ApiConnectClient
    {
        public static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://ketoan-api-y1cd.onrender.com") // URL Server Render
        };

        

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Tự động map camelCase từ API sang PascalCase của C#
        };
        // 1. GET: Lấy danh sách Đơn vị tính
        public async Task<List<DonViTinhDtoClient>> GetDonViTinhAsync()
        {
            HttpResponseMessage response = await Client.GetAsync("api/don-vi-tinh");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<List<DonViTinhDtoClient>>>(json, _jsonOptions);

            return result?.Data ?? new List<DonViTinhDtoClient>();
        }

        //2. POST Hàm thêm mới Đơn vị tính
        public async Task<ApiResponse<DonViTinhDtoClient>> CreateDonViTinhAsync(string tenDvt)
        {
            var requestData = new { TenDVT = tenDvt };
            string jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync("api/don-vi-tinh", content);
            string jsonResult = await response.Content.ReadAsStringAsync();

            // Kiểm tra nếu Server trả về chuỗi rỗng
            if (string.IsNullOrWhiteSpace(jsonResult))
            {
                throw new Exception($"Server không trả về dữ liệu. Status code: {(int)response.StatusCode}");
            }


            // Nếu Server trả về lỗi 400 (Trùng tên hoặc ModelState invalid)
            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<ApiResponse<DonViTinhDtoClient>>(jsonResult, _jsonOptions);
                throw new Exception(errorResult?.Message ?? "Thêm mới thất bại.");
            }

            return JsonSerializer.Deserialize<ApiResponse<DonViTinhDtoClient>>(jsonResult, _jsonOptions);
        }

        //3. PUT Hàm sửa Đơn vị tính
        public async Task<ApiResponse<DonViTinhDtoClient>> UpdateDonViTinhAsync(int id, string tenDvt)
        {
            var requestData = new { TenDVT = tenDvt };
            string jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PutAsync($"api/don-vi-tinh/{id}", content);
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<ApiResponse<DonViTinhDtoClient>>(jsonResult, _jsonOptions);
                throw new Exception(errorResult?.Message ?? "Cập nhật thất bại.");
            }

            return JsonSerializer.Deserialize<ApiResponse<DonViTinhDtoClient>>(jsonResult, _jsonOptions);
        }

        //4. DELETE Hàm xóa Đơn vị tính
        public async Task<ApiResponse<object>> DeleteDonViTinhAsync(int id)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"api/don-vi-tinh/{id}");
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<ApiResponse<object>>(jsonResult, _jsonOptions);
                throw new Exception(errorResult?.Message ?? "Xóa thất bại.");
            }

            return JsonSerializer.Deserialize<ApiResponse<object>>(jsonResult, _jsonOptions);
        }

        // 1. GET: Lấy danh sách Hàng Hóa
        public async Task<List<HangHoaDtoClient>> GetHangHoaAsync(string? keyword = null)
        {
            // 1. Tạo URL mặc định
            string url = "api/hang-hoa";

            // 2. Nếu có keyword, nối thêm query string ?keyword=... (dùng EscapeDataString để tránh lỗi ký tự đặc biệt/tiếng Việt)
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                url += $"?keyword={Uri.EscapeDataString(keyword.Trim())}";
            }

            HttpResponseMessage response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<List<HangHoaDtoClient>>>(json, _jsonOptions);

            return result?.Data ?? new List<HangHoaDtoClient>();
        }
    }

    public class ApiResponse<T>
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
