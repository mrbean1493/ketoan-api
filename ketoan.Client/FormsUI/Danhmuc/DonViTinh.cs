using ketoan.Client.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ketoan.Client.FormsUI.Danhmuc
{
    public partial class DonViTinh : Form
    {
        public DonViTinh()
        {
            InitializeComponent();
        }

        // Khai báo đối tượng kết nối API
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtDVT.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private async void DonViTinh_Load(object sender, EventArgs e)
        {
            await LoadDataToGridView();
        }

        // Hàm xử lý đổ dữ liệu
        private async Task LoadDataToGridView()
        {
            try
            {
                // 1. Gọi hàm GET từ ApiConnectClient
                List<DonViTinhDtoClient> listData = await _apiClient.GetDonViTinhAsync();

                // 2. Cấu hình DataGridView tự động tạo cột theo thuộc tính của DTO
                dataGridView1.AutoGenerateColumns = true;

                // 3. Đổ danh sách dữ liệu vào DataGridView
                dataGridView1.DataSource = listData;

                // 4. (Tùy chọn) Chỉnh lại tên tiêu đề cột hiển thị cho đẹp
                //CustomGridViewHeaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu từ Server: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm chỉnh tiêu đề cột hiển thị tiếng Việt
        private void CustomGridViewHeaders()
        {
            if (dataGridView1.Columns["Id"] != null)
            {
                dataGridView1.Columns["Id"].HeaderText = "Mã ĐVT";
                dataGridView1.Columns["Id"].Width = 80;
            }

            if (dataGridView1.Columns["UnitName"] != null)
            {
                dataGridView1.Columns["UnitName"].HeaderText = "Tên Đơn Vị Tính";
                dataGridView1.Columns["UnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
