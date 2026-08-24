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
        int status = 0;
        // Khai báo đối tượng kết nối API
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtDVT.Text = "";
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnSave.Enabled = true;
            status = 1;
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
            if (!int.TryParse(txtID.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa từ danh sách!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string TenDVT = txtDVT.Text.Trim();

            DialogResult result = MessageBox.Show(
    "Bạn có chắc chắn muốn xóa đơn vị tính '{TenDVT}' ?",
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
                    txtID.Clear();
                    txtDVT.Clear();

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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //btnAdd.Enabled = true;
            //btnEdit.Enabled = true;
            //btnDel.Enabled = true;
            //btnSave.Enabled = false;

            if (status == 1)
            {
                // 1. Kiểm tra dữ liệu đầu vào
                string tenDvt = txtDVT.Text.Trim();
                if (string.IsNullOrEmpty(tenDvt))
                {
                    MessageBox.Show("Vui lòng nhập tên đơn vị tính!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDVT.Focus();
                    return;
                }

                try
                {
                    // 2. Tắt nút để tránh người dùng click liên tục
                    btnAdd.Enabled = false;

                    // 3. Gọi API thêm mới
                    var response = await _apiClient.CreateDonViTinhAsync(tenDvt);

                    if (response != null && response.Success)
                    {
                        MessageBox.Show(response.Message, "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Xóa trắng ô nhập liệu và tải lại danh sách trên DataGridView
                        txtDVT.Clear();
                        await LoadDataToGridView();
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi (Bao gồm cả lỗi trùng tên do Server trả về)
                    MessageBox.Show(ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Mở lại nút sau khi xử lý xong
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    btnSave.Enabled = false;
                    status = 0;
                }
            }
            else if (status == 2)
            {
                // 1. Kiểm tra ID xem đã chọn dòng nào chưa
                if (!int.TryParse(txtID.Text, out int id) || id <= 0)
                {
                    MessageBox.Show("Vui lòng chọn đơn vị tính cần sửa từ danh sách!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Kiểm tra tên nhập vào
                string tenDvt = txtDVT.Text.Trim();
                if (string.IsNullOrEmpty(tenDvt))
                {
                    MessageBox.Show("Tên đơn vị tính không được để trống!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDVT.Focus();
                    return;
                }

                try
                {
                    btnEdit.Enabled = false;

                    // 3. Gọi API cập nhật
                    var response = await _apiClient.UpdateDonViTinhAsync(id, tenDvt);

                    if (response != null && response.Success)
                    {
                        MessageBox.Show(response.Message, "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Tải lại bảng dữ liệu
                        await LoadDataToGridView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    btnSave.Enabled = false;
                    status = 0;
                }
            }
            
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ép dữ liệu dòng được chọn thành đối tượng DTO
                var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as DonViTinhDtoClient;

                if (item != null)
                {
                    txtID.Text = item.Id.ToString();
                    txtDVT.Text = item.TenDVT;
                }
            }
        }

        private async void txtRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataToGridView();
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnSave.Enabled = false;
            status = 0;
        }
    }
}
