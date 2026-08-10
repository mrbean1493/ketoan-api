using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ketoan.Client.FormsUI.Hethong
{
    public partial class DangNhap : Form
    {
        // Địa chỉ URL chạy của Web API Server (thay đúng cổng port của bạn)
        /*Đã có class quản lý 
        private readonly HttpClient _httpClient = new HttpClient
        {
            //BaseAddress = new Uri("https://localhost:5568/")
            BaseAddress = new Uri("https://ketoan-api-y1cd.onrender.com/")
        };
        */
        public DangNhap()
        {
            InitializeComponent();
            lblTrangThai.Text = "";
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            lblTrangThai.Text = "";
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnDangNhap.Enabled = false;

                var loginData = new { TenDangNhap = username, MatKhau = password };
                var response = await ApiConnectClient.Client.PostAsJsonAsync("api/NguoiDung/login", loginData);//NguoiDung lấy từ tên Controller, login lấy trong HttpPost của Controller

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblTrangThai.Text = "Đăng nhập thành công!"; lblTrangThai.ForeColor = Color.Green;
                    this.Hide();
                    // Mở FormMain
                    FormMain main = new FormMain();
                    main.ShowDialog();
                    this.Close();
                }
                else
                {
                    var errorResult = await response.Content.ReadFromJsonAsync<dynamic>();
                    string errorMsg = errorResult?.GetProperty("message").GetString() ?? "Đăng nhập thất bại.";
                    lblTrangThai.Text = "Tài khoản hoặc mật khẩu không đúng!"; lblTrangThai.ForeColor = Color.Red;
                    MessageBox.Show(errorMsg, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến máy chủ API: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDangNhap.Enabled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
