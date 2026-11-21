using ketoan.Client.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ketoan.Client.FormsUI.Hethong
{
    public partial class ResetPass : Form
    {
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();

        int Id_user = 0;
        string userName = "";
        public ResetPass(int id, string username)
        {
            InitializeComponent();
            Id_user = id;
            userName = username;
            txtTenDangNhap.Text = username;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            string strMatKhauMoi = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(strMatKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới để đặt cho người dùng " + userName + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var payload = new ResetMatKhauDtoClient
            {
                UserId = Id_user,
                MatKhauMoi = txtMatKhau.Text.Trim(),
            };

            try
            {
                // 3. Gọi API Đổi mật khẩu
                var response = await ApiConnectClient.Client.PostAsJsonAsync("api/NguoiDung/reset-mat-khau", payload);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Đọc thông báo lỗi từ API
                    var errorResponse = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                    string message = errorResponse != null && errorResponse.ContainsKey("message")
                        ? errorResponse["message"]
                        : "Đổi mật khẩu thất bại!";

                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến máy chủ API: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
