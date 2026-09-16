using ketoan.Client.DTOs;
using ketoan.Client.Enums;
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
    public partial class DoiTac : Form
    {
        private readonly LoaiDoiTac _loaiDoiTac;
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        int status = 0;
        public DoiTac(LoaiDoiTac loaiDoiTac)
        {
            InitializeComponent();
            _loaiDoiTac = loaiDoiTac;
            _apiClient = new ApiConnectClient();

            CapNhatGiaoDien();
        }

        private void CapNhatGiaoDien()
        {
            if (_loaiDoiTac == LoaiDoiTac.KhachHang)
            {
                this.Text = "Khách hàng";
                //lblTieuDe.Text = "DANH SÁCH KHÁCH HÀNG";
                txtTenDoiTacView.Text = "Tên khách hàng";
            }
            else
            {
                this.Text = "Nhà cung cấp";
                //lblTieuDe.Text = "DANH SÁCH NHÀ CUNG CẤP";
                txtTenDoiTacView.Text = "Tên nhà cung cấp";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            status = 1;

            txtTenDoiTacView.Text = "";
            txtVietTatView.Text = "";
            txtSDT.Text = "";
            txtSDT2.Text = "";
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
            string tenDoiTac = txtTenDoiTacView.Text.Trim();

            DialogResult result = MessageBox.Show(
    "Bạn có chắc chắn muốn xóa " + tenDoiTac + " ?",
    "Xác nhận",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                btnDel.Enabled = false;

                // 3. Gọi API xóa
                var response = await _apiClient.DeleteDoiTacAsync(id);

                if (response != null && response.Success)
                {
                    MessageBox.Show(response.Message, "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Xóa trắng dữ liệu nhập và reload lại danh sách
                    txtId.Clear();
                    txtTenDoiTacView.Text = "";
                    txtVietTatView.Text = "";
                    txtSDT.Text = "";
                    txtSDT2.Text = "";

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

        private async Task LoadDataToGridView()
        {
            try
            {
                // 1. Gọi hàm GET từ ApiConnectClient
                List<DoiTacDtoClient> listData = new List<DoiTacDtoClient>();
                if (_loaiDoiTac == LoaiDoiTac.KhachHang)
                {
                    listData = await _apiClient.GetDoiTacAsync(null,null,true);
                }
                else
                {
                    listData = await _apiClient.GetDoiTacAsync(null,true,null);
                }
                    
                   

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


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                // 1. Kiểm tra dữ liệu đầu vào
                string tenDoiTac = txtTenDoiTacView.Text.Trim();
                if (string.IsNullOrEmpty(tenDoiTac))
                {
                    MessageBox.Show("Vui lòng nhập tên đối tác!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDoiTacView.Focus();
                    return;
                }
                string vietTat = txtVietTatView.Text.Trim();
                if (string.IsNullOrEmpty(vietTat))
                {
                    MessageBox.Show("Vui lòng nhập tên viết tắt!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVietTatView.Focus();
                    return;
                }

                try
                {
                    // 2. Tắt nút để tránh người dùng click liên tục
                    btnAdd.Enabled = false;

                    // 3. Gọi API thêm mới
                    var response = await _apiClient.CreateDoiTacAsync(tenDoiTac, vietTat, txtSDT.Text, txtSDT2.Text, _loaiDoiTac);

                    if (response != null && response.Success)
                    {
                        MessageBox.Show(response.Message, "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Xóa trắng ô nhập liệu và tải lại danh sách trên DataGridView
                        txtTenDoiTacView.Text = "";
                        txtVietTatView.Text = "";
                        txtSDT.Text = "";
                        txtSDT2.Text = "";
                        await LoadDataToGridView();
                    }
                    else if (response != null && !response.Success)
                    {
                        if (response.IsRequireConfirm)
                        {
                            DialogResult confirmResult = MessageBox.Show(
            response.Message,
            "Xác nhận cập nhật đối tác",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

                            // Nếu người dùng bấm YES -> Gọi API để bật thêm flag (is_ncc hoặc is_kh)
                            if (confirmResult == DialogResult.Yes && response.ExistingId.HasValue)
                            {
                                var updateResult = await _apiClient.UpdateStatusDoiTacAsync(response.ExistingId.Value, _loaiDoiTac);

                                if (updateResult != null && updateResult.Success)
                                {
                                    MessageBox.Show("Cập nhật thông tin đối tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await LoadDataToGridView(); // Tải lại DataGridView

                                }
                                else
                                {
                                    MessageBox.Show(updateResult?.Message ?? "Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            return; // Dừng luồng sau khi xử lý xong trường hợp confirm
                        }
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
                if (!int.TryParse(txtId.Text, out int id) || id <= 0)
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cần sửa từ danh sách!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Kiểm tra tên nhập vào
                string tenDoiTac = txtTenDoiTacView.Text.Trim();
                if (string.IsNullOrEmpty(tenDoiTac))
                {
                    MessageBox.Show("Vui lòng nhập tên đối tác!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDoiTacView.Focus();
                    return;
                }
                string vietTat = txtVietTatView.Text.Trim();
                if (string.IsNullOrEmpty(vietTat))
                {
                    MessageBox.Show("Vui lòng nhập tên viết tắt!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVietTatView.Focus();
                    return;
                }

                try
                {
                    btnEdit.Enabled = false;

                    // 3. Gọi API cập nhật
                    var response = await _apiClient.UpdateDoiTacAsync(id, txtTenDoiTacView.Text, txtSDT.Text, txtSDT2.Text, txtVietTatView.Text);

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            status = 0;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnSave.Enabled = false;
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await SearchDoiTacAsync();
        }

        private async Task SearchDoiTacAsync()
        {
            //string keyword = txtTenDoiTacView.Text.Trim();

            string keyword = string.IsNullOrWhiteSpace(txtTenDoiTac.Text) ? null : txtTenDoiTac.Text.Trim();

            // Gọi ApiConnectClient truyền keyword
            try
            {
                var listDoiTac = await _apiClient.GetDoiTacAsync(keyword,_loaiDoiTac==LoaiDoiTac.NhaCungCap,_loaiDoiTac==LoaiDoiTac.KhachHang);
                dataGridView1.DataSource = listDoiTac;

                if (listDoiTac.Count() > 0)
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ép dữ liệu dòng được chọn thành đối tượng DTO
                var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as DoiTacDtoClient;

                if (item != null)
                {
                    txtId.Text = item.Id.ToString();
                    txtTenDoiTacView.Text = item.TenDoiTac.ToString();
                    txtVietTatView.Text = item.MaDoiTac;
                    txtSDT.Text = item.SoDienThoai;
                    txtSDT2.Text = item.SoDienThoai2;
                }
            }
        }

        private async void DoiTac_Load(object sender, EventArgs e)
        {
            await LoadDataToGridView();
        }
    }
}
