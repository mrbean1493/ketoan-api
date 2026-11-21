using ketoan.Client.DTOs;
using ketoan.Client.Enums;
using ketoan.Client.FormsUI.Hethong;
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
    public partial class NhanVien : Form
    {
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        int status = 0;
        public NhanVien()
        {
            InitializeComponent();

            CapNhatGiaoDien();

            LoadKho();
        }

        private void CapNhatGiaoDien()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // 1. Cột Mã/ID (Ẩn đi hoặc hiển thị tùy bạn)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id", // Tên property trong DTO
                Name = "colId",
                HeaderText = "Mã đối tác",
                Visible = false // Ẩn cột Id nếu không cần hiển thị cho người dùng xem
            });

            // 2. Cột Tên kho
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenNguoiDung",
                Name = "colTenNguoiDung",
                HeaderText = "Tên người dùng",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenDangNhap",
                Name = "colTenDangNhap",
                HeaderText = "Tài khoản đăng nhập",
                Width = 100
            });


            // 3. Cột Địa chỉ

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "dia_chi",
                Name = "colDiaChi",
                HeaderText = "Địa chỉ",
                Width = 200,
                Visible = true
            });

            // 4. Cột Địa chỉ
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SoDienThoai",
                Name = "colSDT",
                HeaderText = "SĐT",
                Width = 90,
                Visible = true
            });
            // 3. Cột Địa chỉ
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Email",
                Name = "colEmail",
                HeaderText = "Email",
                Width = 90,
                Visible = true
            });

            // 3. Cột Địa chỉ
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NgaySinh",
                Name = "colNgaySinh",
                HeaderText = "Ngày sinh",
                Width = 90,
                Visible = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TrangThai",
                Name = "colTrangThai",
                HeaderText = "Trạng thái",
                Width = 90,
                Visible = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ma_kho",
                Name = "colKho",
                HeaderText = "Kho",
                Width = 50,
                Visible = true
            });
        }

        private async void LoadKho()
        {
            // 1. Tạo danh sách dữ liệu mẫu (hoặc lấy từ CSDL/EF Core)
            List<KhoDtoClient> listKho = new List<KhoDtoClient>();
            listKho = await _apiClient.GetKhoAsync();
            listKho.Insert(0, new KhoDtoClient { Id = 0, ten_kho = "-- Tất cả các kho (Admin) --" });
            cboKho.DataSource = listKho;
            cboKho.ValueMember = "Id";
            cboKho.DisplayMember = "ten_kho";
        }

        private async void NhanVien_Load(object sender, EventArgs e)
        {
            txtId.Text = "";
            await LoadDataToGridView();
        }

        private async Task LoadDataToGridView()
        {
            try
            {
                // 1. Gọi hàm GET từ ApiConnectClient
                List<NguoiDungDtoClient> listData = new List<NguoiDungDtoClient>();
                listData = await _apiClient.GetAllNguoiDungAsync();

                
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            status = 1;

            lblMatKhau.Visible = true;
            txtMatKhau.Visible = true;

            txtHoTen.Focus();
            txtHoTen.Text = "";
            txtId.Text = "";
            txtTenDangNhap.Text = "";
            txtTenDangNhap.Enabled = true;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            status = 2;

            txtHoTen.Focus();
            txtTenDangNhap.Enabled = false;

        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đã chọn dòng cần xóa chưa
            if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn dòng người dùng cần xóa từ danh sách!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenDangNhap = txtTenDangNhap.Text.Trim();

            DialogResult result = MessageBox.Show(
    "Bạn có chắc chắn muốn xóa tài khoản " + tenDangNhap + " ?",
    "Xác nhận",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                btnDel.Enabled = false;

                // 3. Gọi API xóa
                var response = await _apiClient.DeleteNguoiDungAsync(id);

                if (response != null && response.Success)
                {
                    MessageBox.Show(response.Message, "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Xóa trắng dữ liệu nhập và reload lại danh sách
                    txtId.Clear();
                    txtTenDangNhap.Text = "";
                    txtDiaChi.Text = "";
                    txtSDT.Text = "";
                    txtEmail.Text = "";

                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    btnSave.Enabled = false;
                    status = 0;

                    lblMatKhau.Visible = false;
                    txtMatKhau.Visible = false;

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
            lblMatKhau.Visible = false;
            txtMatKhau.Visible = false;

            if (status == 1)
            {
                // 1. Kiểm tra dữ liệu đầu vào
                string HoTen = txtHoTen.Text.Trim();
                if (string.IsNullOrEmpty(HoTen))
                {
                    MessageBox.Show("Vui lòng nhập họ tên người dùng!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }
                string TenDangNhap = txtTenDangNhap.Text.Trim();
                if (string.IsNullOrEmpty(TenDangNhap))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập cho người dùng mới!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                    return;
                }
                string MatKhau = txtMatKhau.Text.Trim();
                if (string.IsNullOrEmpty(MatKhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu đăng nhập cho người dùng mới!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return;
                }

                try
                {
                    // 2. Tắt nút để tránh người dùng click liên tục
                    btnAdd.Enabled = false;

                    // 3. Gọi API thêm mới
                    var request = new NguoiDungDtoClient
                    {
                        TenNguoiDung = HoTen,
                        TenDangNhap = TenDangNhap,
                        MatKhau = MatKhau,
                        SoDienThoai = txtSDT.Text,
                        Email = txtEmail.Text,
                        dia_chi = txtDiaChi.Text,
                        NgaySinh = DateOnly.FromDateTime(dateTimePickerNgaySinh.Value),
                        NgayTao = DateTime.Now,
                        ma_kho = (int)cboKho.SelectedValue,
                    };

                    var response = await _apiClient.CreateNguoiDungAsync(request);

                    if (response != null && response.Success)
                    {
                        MessageBox.Show(response.Message, "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Xóa trắng ô nhập liệu và tải lại danh sách trên DataGridView
                        txtHoTen.Text = "";
                        txtTenDangNhap.Text = "";
                        txtDiaChi.Text = "";
                        txtSDT.Text = "";
                        txtEmail.Text = "";
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
                // 1. Kiểm tra dữ liệu đầu vào
                string HoTen = txtHoTen.Text.Trim();
                if (string.IsNullOrEmpty(HoTen))
                {
                    MessageBox.Show("Vui lòng nhập họ tên người dùng!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }
                string TenDangNhap = txtTenDangNhap.Text.Trim();
                if (string.IsNullOrEmpty(TenDangNhap))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập cho người dùng mới!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                    return;
                }
                

                try
                {
                    // 2. Tắt nút để tránh người dùng click liên tục
                    btnAdd.Enabled = false;

                    // 3. Gọi API thêm mới
                    var request = new NguoiDungDtoClient
                    {
                        TenNguoiDung = HoTen,
                        TenDangNhap = TenDangNhap,
                        SoDienThoai = txtSDT.Text,
                        Email = txtEmail.Text,
                        dia_chi = txtDiaChi.Text,
                        NgaySinh = DateOnly.FromDateTime(dateTimePickerNgaySinh.Value),
                        NgayTao = DateTime.Now,
                        ma_kho = (int)cboKho.SelectedValue
                    };

                    var response = await _apiClient.CreateNguoiDungAsync(request);

                    if (response != null && response.Success)
                    {
                        MessageBox.Show(response.Message, "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Xóa trắng ô nhập liệu và tải lại danh sách trên DataGridView
                        txtHoTen.Text = "";
                        txtTenDangNhap.Text = "";
                        txtDiaChi.Text = "";
                        txtSDT.Text = "";
                        txtEmail.Text = "";
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;

            lblMatKhau.Visible = false;
            txtMatKhau.Visible = false;
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "admin")
            {
                MessageBox.Show("Không thể đổi mật khẩu tài khoản quản trị tại nút này", "Cảnh báo");
                return;
            }
            
            
            if (txtId.Text == "" || txtTenDangNhap.Text =="")
            {
                MessageBox.Show("Vui lòng chọn tài khoản người dùng cần đổi mật khẩu","Cảnh báo");
                return;
            }
            ResetPass rspass = new ResetPass(int.Parse(txtId.Text), txtTenDangNhap.Text);
            rspass.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblMatKhau.Visible = false;
                txtMatKhau.Visible = false;

                txtTenDangNhap.Enabled = false;
                // Ép dữ liệu dòng được chọn thành đối tượng DTO
                var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as NguoiDungDtoClient;

                if (item != null)
                {
                    txtId.Text = item.Id.ToString();
                    txtHoTen.Text = item.TenNguoiDung.ToString();
                    txtTenDangNhap.Text = item.TenDangNhap;
                    txtDiaChi.Text = item.dia_chi;
                    txtSDT.Text = item.SoDienThoai;
                    txtEmail.Text = item.Email;
                    chkIsActive.Checked = item.TrangThai;
                    if(item.ma_kho==null)
                    {
                        cboKho.SelectedValue = 0;
                    }
                    else
                    {
                        cboKho.SelectedValue = (int)item.ma_kho;
                    }
                }
            }
        }
    }
}
