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
    public partial class HangHoa : Form
    {
        public HangHoa()
        {
            InitializeComponent();
        }
        // Khai báo đối tượng kết nối API
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private async void HangHoa_Load(object sender, EventArgs e)
        {
            await LoadDataDVT();

            await LoadDataToGridView();
        }

        private async Task LoadDataDVT()
        {
            try
            {
                // 1. Gọi hàm GET từ ApiConnectClient
                List<DonViTinhDtoClient> listData = await _apiClient.GetDonViTinhAsync();

                // 2. Cấu hình DataGridView tự động tạo cột theo thuộc tính của DTO
                //dataGridView1.AutoGenerateColumns = true;

                // 3. Đổ danh sách dữ liệu vào DataGridView
                cboDVT.DataSource = listData;
                cboDVT.DisplayMember = "TenDVT";   // Tên hiển thị
                cboDVT.ValueMember = "Id";

                if (listData.Count() > 0)
                {
                    // 1. Chọn dòng đầu tiên
                    //dataGridView1.ClearSelection();
                    //dataGridView1.Rows[0].Selected = true;

                    // 2. Giả lập gọi sự kiện CellClick cho ô đầu tiên của dòng đầu tiên (Cột 0, Dòng 0)
                    //dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, 0));
                }

                // 4. (Tùy chọn) Chỉnh lại tên tiêu đề cột hiển thị cho đẹp
                //CustomGridViewHeaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu từ Server: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xử lý đổ dữ liệu
        private async Task LoadDataToGridView()
        {
            try
            {
                // 1. Gọi hàm GET từ ApiConnectClient
                List<HangHoaDtoClient> listData = await _apiClient.GetHangHoaAsync();

                // 2. Cấu hình DataGridView tự động tạo cột theo thuộc tính của DTO
                dataGridView1.AutoGenerateColumns = true;

                // 3. Đổ danh sách dữ liệu vào DataGridView
                dataGridView1.DataSource = listData;

                if (listData.Count() > 0)
                {
                    // 1. Chọn dòng đầu tiên
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[0].Selected = true;

                    // 2. Giả lập gọi sự kiện CellClick cho ô đầu tiên của dòng đầu tiên (Cột 0, Dòng 0)
                    dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, 0));
                }

                // 4. (Tùy chọn) Chỉnh lại tên tiêu đề cột hiển thị cho đẹp
                //CustomGridViewHeaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu từ Server: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ép dữ liệu dòng được chọn thành đối tượng DTO
                var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as HangHoaDtoClient;

                if (item != null)
                {
                    txtTenHHView.Text = item.TenHH.ToString();
                    txtVietTatView.Text = item.VietTat;
                    txtMoTa.Text = item.MoTa;

                    cboDVT.SelectedValue = item.id_dvt;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
