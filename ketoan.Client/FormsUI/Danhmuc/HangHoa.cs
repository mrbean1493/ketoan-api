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
        int status = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            status = 1;

            txtTenHHView.Text = "";
            txtVietTatView.Text = "";
            txtMoTa.Text = "";
            txtVietTat.Text = "";
        }

        private async void HangHoa_Load(object sender, EventArgs e)
        {
            await LoadDataDVT();

            await LoadDataToGridView();

            btnSave.Enabled = false;

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
                    txtId.Text = item.Id.ToString();
                    txtTenHHView.Text = item.TenHH.ToString();
                    txtVietTatView.Text = item.VietTat;
                    txtMoTa.Text = item.MoTa;
                    cboDVT.SelectedValue = item.id_dvt;
                }
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await SearchHangHoaAsync();
        }

        private async Task SearchHangHoaAsync()
        {
            string keyword = txtTenHH.Text.Trim();

            // Gọi ApiConnectClient truyền keyword
            try
            {
                var listHangHoa = await _apiClient.GetHangHoaAsync(keyword);
                dataGridView1.DataSource = listHangHoa;

                if (listHangHoa.Count() > 0)
                {
                    // 1. Chọn dòng đầu tiên
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[0].Selected = true;

                    // 2. Giả lập gọi sự kiện CellClick cho ô đầu tiên của dòng đầu tiên (Cột 0, Dòng 0)
                    dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, 0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu từ Server khi Search: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnSave.Enabled = true;
            status = 2;
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đã chọn dòng cần xóa chưa
            if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa từ danh sách!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenHH = txtTenHHView.Text.Trim();

            DialogResult result = MessageBox.Show(
    "Bạn có chắc chắn muốn xóa đơn vị tính " + tenHH + " ?",
    "Xác nhận",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                btnDel.Enabled = false;

                // 3. Gọi API xóa
                var response = await _apiClient.DeleteDonViTinhAsync(id);

                if (response != null && response.Success)
                {
                    MessageBox.Show(response.Message, "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Xóa trắng dữ liệu nhập và reload lại danh sách
                    txtId.Clear();
                    txtTenHHView.Clear();
                    txtMoTa.Clear();
                    txtVietTat.Clear();

                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    btnSave.Enabled = false;
                    status = 0;

                    await LoadDataToGridView();
                }
            }
            else
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (status == 1) 
            {

            }
            else if (status == 2)
            {

            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            status = 0;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnSave.Enabled = false;
        }
    }
}
