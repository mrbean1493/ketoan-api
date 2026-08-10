using ketoan.Client.DTOs;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ketoan.Client.FormsUI.Hethong
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private async void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string strMatKhauCu = txtMatKhauCu.Text.Trim();
            string strMatKhauMoi = txtMatKhauMoi.Text.Trim();
            string strMatKhauMoi2 = txtMatKhauMoi2.Text.Trim();

            if (string.IsNullOrEmpty(strMatKhauCu) || string.IsNullOrEmpty(strMatKhauMoi) || string.IsNullOrEmpty(strMatKhauMoi2))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu cũ, mới, xác nhận mậ khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (strMatKhauMoi!=strMatKhauMoi2)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới và xác nhận lại mật khẩu mới phải trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (strMatKhauCu == strMatKhauMoi || strMatKhauCu == strMatKhauMoi2)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới và xác nhận lại mật khẩu mới phải khác mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var payload = new DoiMatKhauDtoClient
            {
                UserId = QuanLyPhien.UserId,
                MatKhauCu = txtMatKhauCu.Text.Trim(),
                MatKhauMoi = txtMatKhauMoi.Text.Trim()
            };

            try
            {
                // 3. Gọi API Đổi mật khẩu
                var response = await ApiConnectClient.Client.PostAsJsonAsync("api/NguoiDung/doi-mat-khau", payload);

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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
