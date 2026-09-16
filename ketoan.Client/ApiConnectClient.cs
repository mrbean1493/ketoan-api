using ketoan.Client.DTOs;
using ketoan.Client.Enums;
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

        //2. POST Hàm thêm mới Hàng hóa
        public async Task<ApiResponse<HangHoaDtoClient>> CreateHangHoaAsync(string tenHH, string moTa, string vietTat, int id_dvt)
        {
            var requestData = new { TenHH = tenHH, VietTat=vietTat,MoTa=moTa, id_dvt=id_dvt };
            string jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync("api/hang-hoa", content);
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

            return JsonSerializer.Deserialize<ApiResponse<HangHoaDtoClient>>(jsonResult, _jsonOptions);
        }
        //3. PUT Hàm sửa Hàng hóa
        public async Task<ApiResponse<HangHoaDtoClient>> UpdateHangHoaAsync(int id, string tenHH, string moTa, string vietTat, int id_dvt)
        {
            var requestData = new { TenHH = tenHH, VietTat = vietTat, MoTa = moTa, id_dvt = id_dvt };
            string jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PutAsync($"api/hang-hoa/{id}", content);
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<ApiResponse<HangHoaDtoClient>>(jsonResult, _jsonOptions);
                throw new Exception(errorResult?.Message ?? "Cập nhật thất bại.");
            }

            return JsonSerializer.Deserialize<ApiResponse<HangHoaDtoClient>>(jsonResult, _jsonOptions);
        }
        //4. DELETE Hàm xóa Hàng hóa
        public async Task<ApiResponse<object>> DeleteHangHoaAsync(int id)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"api/hang-hoa/{id}");
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<ApiResponse<object>>(jsonResult, _jsonOptions);
                throw new Exception(errorResult?.Message ?? "Xóa thất bại.");
            }

            return JsonSerializer.Deserialize<ApiResponse<object>>(jsonResult, _jsonOptions);
        }


        // 1. GET: Lấy danh sách Đối tác
        public async Task<List<DoiTacDtoClient>> GetDoiTacAsync(string? keyword = null, bool? isNcc = null,
    bool? isKh = null)
        {
            // 1. Tạo URL mặc định
            string url = "api/doi-tac";
            List<string> queryParams = new List<string>();
            // 2. Nếu có keyword, nối thêm query string ?keyword=... (dùng EscapeDataString để tránh lỗi ký tự đặc biệt/tiếng Việt)
            /*
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                url += $"?keyword={Uri.EscapeDataString(keyword.Trim())}";
            }
            */

            // 1. Thêm tham số keyword nếu có
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                queryParams.Add($"keyword={Uri.EscapeDataString(keyword.Trim())}");
            }

            // 2. Thêm tham số isNcc nếu có truyền
            if (isNcc.HasValue)
            {
                queryParams.Add($"isNcc={isNcc.Value.ToString().ToLower()}");
            }

            // 3. Thêm tham số isKh nếu có truyền
            if (isKh.HasValue)
            {
                queryParams.Add($"isKh={isKh.Value.ToString().ToLower()}");
            }

            // 4. Ghép các query params vào URL chuẩn dấu ? và &
            if (queryParams.Count > 0)
            {
                url += "?" + string.Join("&", queryParams);
            }

            HttpResponseMessage response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<List<DoiTacDtoClient>>>(json, _jsonOptions);

            return result?.Data ?? new List<DoiTacDtoClient>();
        }

        //2. POST Hàm thêm mới Đối tác
        public async Task<ApiResponse<DoiTacDtoClient>> CreateDoiTacAsync(string tenDoiTac,string maDoiTac, string sdt, string sdt2,LoaiDoiTac loaiDoiTac)
        {
            var requestData = new { TenDoiTac = tenDoiTac, SoDienThoai = sdt, SoDienThoai2 = sdt2, MaDoiTac = maDoiTac, loaiDoiTac=loaiDoiTac};
            string jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync("api/doi-tac", content);
            string jsonResult = await response.Content.ReadAsStringAsync();

            // Kiểm tra nếu Server trả về chuỗi rỗng
            if (string.IsNullOrWhiteSpace(jsonResult))
            {
                throw new Exception($"Server không trả về dữ liệu. Status code: {(int)response.StatusCode}");
            }


            // Nếu Server trả về lỗi 400 (Trùng tên hoặc ModelState invalid)
            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<ApiResponse<DoiTacDtoClient>>(jsonResult, _jsonOptions);
                throw new Exception(errorResult?.Message ?? "Thêm mới thất bại.");
            }

            return JsonSerializer.Deserialize<ApiResponse<DoiTacDtoClient>>(jsonResult, _jsonOptions);
        }
        //2.1 Update trạng thái đối tác ncc/kh

        public async Task<ApiResponse<object>> UpdateStatusDoiTacAsync(int id, LoaiDoiTac loaiDoiTac)
        {
            // Gọi HTTP PUT đến Controller Server kèm query parameter loai
            HttpResponseMessage response = await Client.PutAsync($"api/doi-tac/{id}/enable-flag-doi-tac?loai={(int)loaiDoiTac}", null);

            string jsonResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                // Deserialize lỗi trả về từ API nếu có
                return JsonSerializer.Deserialize<ApiResponse<object>>(jsonResult, _jsonOptions)!;
            }

            return JsonSerializer.Deserialize<ApiResponse<object>>(jsonResult, _jsonOptions)!;
        }

        //3. PUT Hàm sửa Đối tác
        public async Task<ApiResponse<DoiTacDtoClient>> UpdateDoiTacAsync(int id, string tenDoiTac, string sdt, string sdt2, string maDoiTac)
        {
            var requestData = new { TenDoiTac = tenDoiTac, SoDienThoai = sdt, SoDienThoai2 = sdt2, MaDoiTac = maDoiTac };
            string jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PutAsync($"api/doi-tac/{id}", content);
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<ApiResponse<DoiTacDtoClient>>(jsonResult, _jsonOptions);
                throw new Exception(errorResult?.Message ?? "Cập nhật thất bại.");
            }

            return JsonSerializer.Deserialize<ApiResponse<DoiTacDtoClient>>(jsonResult, _jsonOptions);
        }
        //4. DELETE Hàm xóa Đối tác
        public async Task<ApiResponse<object>> DeleteDoiTacAsync(int id)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"api/doi-tac/{id}");
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<ApiResponse<object>>(jsonResult, _jsonOptions);
                throw new Exception(errorResult?.Message ?? "Xóa thất bại.");
            }

            return JsonSerializer.Deserialize<ApiResponse<object>>(jsonResult, _jsonOptions);
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

        // Thuộc tính phục vụ hỏi xác nhận ở Client
        public bool IsRequireConfirm { get; set; } = false;
        public int? ExistingId { get; set; }
    }
}
