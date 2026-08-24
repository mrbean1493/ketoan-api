using ketoan.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
