using ketoan.Client.ClassComponent;
using ketoan.Client.DTOs;
using ketoan.Client.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ketoan.Client.FormsUI.Nhaphang
{
    public partial class DanhSachPhieuNhapXuat : Form
    {
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        private int _loaiPhieu;
        public DanhSachPhieuNhapXuat(bool isNhapKho = true)
        {
            InitializeComponent();
            _apiClient = new ApiConnectClient();

            LoadLoaiPhieu(isNhapKho);
            LoadDoiTac(isNhapKho);
            CapNhatGiaoDien(isNhapKho);
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var iddoitac = 0;
                if (gridLookupDoiTac1.SelectedId == null)
                {
                    iddoitac = 0;
                }
                var result = await _apiClient.GetByLoaiPhieuVaNgayAsync(cboLoaiPhieu.SelectedIndex + 1, dateTimePickerNgayNhapFrom.Value, dateTimePickerNgayNhapTo.Value, iddoitac);

                if (result != null && result.Success && result.Data != null)
                {
                    var phieu = result.Data;

                    // 1. Đổ dữ liệu lên Cuống phiếu (Header)
                    // dateTimePickerNgayNhap.Value = phieu.NgayLap.ToLocalTime(); // Chuyển UTC về giờ máy local

                    // Gán ID đối tác vào Custom Control GridLookupDoiTac mà chúng ta đã cấu hình
                    //gridLookupDoiTac1.SelectedId = phieu.DoiTacId;

                    // 2. Đổ danh sách chi tiết lên DataGridView
                    dataGridView1.DataSource = null;

                    // 2. Tự động đánh số thứ tự cho từng phần tử
                    /*
                    int stt = 1;
                    foreach (var item in phieu.)
                    {
                        item.STT = stt++;
                    }
                    */
                    BindingList<ResponsePhieuNhapXuatDtoClient> bindingList = new BindingList<ResponsePhieuNhapXuatDtoClient>(phieu);
                    dataGridView1.DataSource = bindingList; // phieu.ChiTiets là List<ChiTietPhieuDtoClient>

                }
                else
                {
                    MessageBox.Show(result?.Message ?? "Không thể tải dữ liệu phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow;
            LoaiPhieuNhapXuat lpnx = new LoaiPhieuNhapXuat();
            string NameForm = "NhapKho";
            // Cách B: Lấy qua đối tượng BindingList được gán (An toàn và chuẩn xác nhất nếu dùng DTO)
            if (selectedRow.DataBoundItem is ResponsePhieuNhapXuatDtoClient phieu)
            {
                //int idPhieu = phieu.Id;
                // Thực hiện các thao tác tiếp theo với idPhieu
                if (phieu.LoaiPhieu == 1)
                {
                    lpnx = LoaiPhieuNhapXuat.Nhaphang;
                    NameForm = "NhapKho";
                }
                else if (phieu.LoaiPhieu == 2)
                {
                    lpnx=LoaiPhieuNhapXuat.Trahang;
                    NameForm = "TraHang";
                }
                else if (phieu.LoaiPhieu == 3)
                {
                    lpnx = LoaiPhieuNhapXuat.Xuathang;
                    NameForm = "XuatHang";
                }
                else if (phieu.LoaiPhieu == 4)
                {
                    lpnx = LoaiPhieuNhapXuat.Trahangban;
                    NameForm = "TraHangBan";
                }
                else if (phieu.LoaiPhieu == 5)
                {
                    lpnx = LoaiPhieuNhapXuat.Xuathuy;
                    NameForm = "XuatHuy";
                }
            }


            // 1. Khởi tạo form PhieuNhapXuat ở chế độ thêm mới (Id = 0)
            var formThem = new PhieuNhapXuat(lpnx, 0); // 1 là loại phiếu nhập (hoặc truyền biến tương ứng)

            // 2. Tìm Form chính (MainForm) đang mở trong ứng dụng
            var mainForm = Application.OpenForms.OfType<FormMain>().FirstOrDefault(); // Thay MainForm bằng tên class Form chính của bạn

            if (mainForm != null)
            {
                // 3. Gọi hàm mở tab của Form chính (đặt một tabKey duy nhất cho form thêm mới)
                //string uniqueTabKey = $"PhieuNhapXuat_Them_{DateTime.Now.Ticks}"; // Dùng Ticks để mỗi lần bấm mở ra một tab mới không bị trùng
                mainForm.OpenChildFormInTab(formThem, NameForm);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow;
            LoaiPhieuNhapXuat lpnx = new LoaiPhieuNhapXuat();
            string NameForm = "NhapKho";
            int idphieu = 0;
            // Cách B: Lấy qua đối tượng BindingList được gán (An toàn và chuẩn xác nhất nếu dùng DTO)
            if (selectedRow.DataBoundItem is ResponsePhieuNhapXuatDtoClient phieu)
            {
                idphieu = phieu.Id;
                // Thực hiện các thao tác tiếp theo với idPhieu
                if (phieu.LoaiPhieu == 1)
                {
                    lpnx = LoaiPhieuNhapXuat.Nhaphang;
                    NameForm = "NhapKho";
                }
                else if (phieu.LoaiPhieu == 2)
                {
                    lpnx = LoaiPhieuNhapXuat.Trahang;
                    NameForm = "TraHang";
                }
                else if (phieu.LoaiPhieu == 3)
                {
                    lpnx = LoaiPhieuNhapXuat.Xuathang;
                    NameForm = "XuatHang";
                }
                else if (phieu.LoaiPhieu == 4)
                {
                    lpnx = LoaiPhieuNhapXuat.Trahangban;
                    NameForm = "TraHangBan";
                }
                else if (phieu.LoaiPhieu == 5)
                {
                    lpnx = LoaiPhieuNhapXuat.Xuathuy;
                    NameForm = "XuatHuy";
                }
            }


            // 1. Khởi tạo form PhieuNhapXuat ở chế độ thêm mới (Id = 0)
            var formThem = new PhieuNhapXuat(lpnx, idphieu); // 1 là loại phiếu nhập (hoặc truyền biến tương ứng)

            // 2. Tìm Form chính (MainForm) đang mở trong ứng dụng
            var mainForm = Application.OpenForms.OfType<FormMain>().FirstOrDefault(); // Thay MainForm bằng tên class Form chính của bạn

            if (mainForm != null)
            {
                // 3. Gọi hàm mở tab của Form chính (đặt một tabKey duy nhất cho form thêm mới)
                //string uniqueTabKey = $"PhieuNhapXuat_Them_{DateTime.Now.Ticks}"; // Dùng Ticks để mỗi lần bấm mở ra một tab mới không bị trùng
                mainForm.OpenChildFormInTab(formThem, NameForm);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult confirmResult = MessageBox.Show(
            "Bạn chắc chắn xóa phiếu đang chọn không? Phiếu sẽ không thể khôi phục!",
            "Xác nhận xóa phiếu",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );
            if (confirmResult == DialogResult.Yes)
            {
                var selectedRow = dataGridView1.CurrentRow;
                int idphieu = 0;
                // Cách B: Lấy qua đối tượng BindingList được gán (An toàn và chuẩn xác nhất nếu dùng DTO)
                if (selectedRow.DataBoundItem is ResponsePhieuNhapXuatDtoClient phieu)
                {
                    idphieu = phieu.Id;
                }


                    var response = await _apiClient.DeletePhieuAsync(idphieu);

                if (response != null && response.Success)
                {
                    MessageBox.Show(response.Message, "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnTimKiem.PerformClick();
                }
            }
        }

        private async void DanhSachPhieuNhapXuat_Load(object sender, EventArgs e)
        {
            dateTimePickerNgayNhapFrom.Value = DateTime.Now.AddMonths(-3);
            dateTimePickerNgayNhapTo.Value = DateTime.Now;

            //mặc định lấy danh sách phiếu nhập 3 tháng đổ lại
            try
            {
                var iddoitac = 0;
                if (gridLookupDoiTac1.SelectedId == null)
                {
                    iddoitac = 0;
                }
                var result = await _apiClient.GetByLoaiPhieuVaNgayAsync(cboLoaiPhieu.SelectedIndex + 1, dateTimePickerNgayNhapFrom.Value, dateTimePickerNgayNhapTo.Value, iddoitac);

                if (result != null && result.Success && result.Data != null)
                {
                    var phieu = result.Data;

                    // 1. Đổ dữ liệu lên Cuống phiếu (Header)
                    // dateTimePickerNgayNhap.Value = phieu.NgayLap.ToLocalTime(); // Chuyển UTC về giờ máy local

                    // Gán ID đối tác vào Custom Control GridLookupDoiTac mà chúng ta đã cấu hình
                    //gridLookupDoiTac1.SelectedId = phieu.DoiTacId;

                    // 2. Đổ danh sách chi tiết lên DataGridView
                    dataGridView1.DataSource = null;

                    // 2. Tự động đánh số thứ tự cho từng phần tử
                    /*
                    int stt = 1;
                    foreach (var item in phieu.)
                    {
                        item.STT = stt++;
                    }
                    */
                    BindingList<ResponsePhieuNhapXuatDtoClient> bindingList = new BindingList<ResponsePhieuNhapXuatDtoClient>(phieu);
                    dataGridView1.DataSource = bindingList; // phieu.ChiTiets là List<ChiTietPhieuDtoClient>


                    if (dataGridView1.Rows.Count > 0)
                    {
                        // Bỏ chọn tất cả các dòng trước đó (nếu có)
                        dataGridView1.ClearSelection();

                        // Chọn dòng đầu tiên (index = 0)
                        dataGridView1.Rows[0].Selected = true;

                        // (Tùy chọn) Đặt CurrentRow trỏ đến dòng đầu tiên để kích hoạt hightlight sáng dòng
                        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

                        // Tạo giả lập sự kiện CellEventArgs cho dòng 0, cột 0
                        DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);

                        // Gọi trực tiếp hàm xử lý sự kiện CellClick của DataGridView
                        dataGridView1_CellClick(dataGridView1, args);
                    }

                }
                else
                {
                    MessageBox.Show(result?.Message ?? "Không thể tải dữ liệu phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadLoaiPhieu(bool isNhapKho)
        {

            cboLoaiPhieu.DataSource = null;
            List<string> listLoaiPhieu = new List<string>();

            if (isNhapKho)
            {
                listLoaiPhieu.Add("Nhập kho");
                listLoaiPhieu.Add("Trả hàng");
            }
            else
            {
                listLoaiPhieu.Add("Xuất kho");
                listLoaiPhieu.Add("Trả hàng xuất");
                listLoaiPhieu.Add("Xuất hủy");
            }
            cboLoaiPhieu.DataSource = listLoaiPhieu;
        }

        private async void LoadDoiTac(bool isNhapKho)
        {
            // 1. Tạo danh sách dữ liệu mẫu (hoặc lấy từ CSDL/EF Core)
            List<DoiTacDtoClient> listDoiTac = new List<DoiTacDtoClient>();

            if (isNhapKho)
            {
                listDoiTac = await _apiClient.GetDoiTacAsync(null, true, null);
            }
            else
            {
                listDoiTac = await _apiClient.GetDoiTacAsync(null, null, true);
            }

            // 1. Nạp danh sách DTO của bạn vào Control
            gridLookupDoiTac1.SetDataSourceDoiTac(listDoiTac);

            // 2. Nhận sự kiện chọn đối tác

            gridLookupDoiTac1.DoiTacSelected += (s, ev) =>
            {
                DoiTacDtoClient selected = gridLookupDoiTac1.SelectedDoiTac;
                if (selected != null)
                {
                    int selectedId = selected.Id; // Dùng ID này gán vào PhieuNhap.NhaCungCapId
                }
            };
        }

        private void CapNhatGiaoDien(bool isNhapKho)
        {
            if (isNhapKho)
            {
                this.Text = "Danh sách phiếu nhập hàng hóa";
                //lblTieuDe.Text = "DANH SÁCH KHÁCH HÀNG";
                //txtTenDoiTacView.Text = "Tên khách hàng";
                lblDoiTac.Text = "Tên nhà cung cấp";
            }
            else
            {
                this.Text = "Danh sách phiếu xuất hàng hóa";
                //lblTieuDe.Text = "DANH SÁCH KHÁCH HÀNG";
                //txtTenDoiTacView.Text = "Tên khách hàng";
                lblDoiTac.Text = "Tên khách hàng";
            }


            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // 1. Cột Mã/ID (Ẩn đi hoặc hiển thị tùy bạn)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id", // Tên property trong DTO
                Name = "colId",
                HeaderText = "ID",
                Visible = true // Ẩn cột Id nếu không cần hiển thị cho người dùng xem
            });

            // 2. Cột Ngày lập
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NgayLap",
                Name = "colNgayLap",
                HeaderText = "Ngày lập",
                Width = 150
            });

            // 3. Cột Loại phiếu
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LoaiPhieu",
                Name = "colLoaiPhieu",
                HeaderText = "Loại phiếu",
                Width = 100,
                Visible=false
            });

            // 4. Cột Tổng tiền
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TongTien",
                Name = "colTongTien",
                HeaderText = "Tổng tiền",
                Width = 120,
                DefaultCellStyle = { Format = "N0" } // Định dạng số tiền có dấu phẩy ngăn cách hàng nghìn
            });
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra xem người dùng có bấm nhầm vào dòng tiêu đề (Header) hay không (e.RowIndex < 0 là dòng header)
            if (e.RowIndex < 0) return;

            try
            {
                // 2. Lấy dữ liệu của dòng đang được click bằng cách ép kiểu DataSource về đúng object DTO
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                // Cách A: Lấy trực tiếp từ đối tượng DataBoundItem (Khuyên dùng, cực kỳ an toàn và chuẩn xác)
                if (selectedRow.DataBoundItem is ResponsePhieuNhapXuatDtoClient phieuDto)
                {
                    txtSoPhieu.Text = phieuDto.Id.ToString();

                    // Xử lý logic tiếp theo với idPhieu (ví dụ: gọi API lấy chi tiết phiếu theo ID)
                    // LoadChiTietPhieu(idPhieu);
                    gridLookupDoiTac1.SelectedId = phieuDto.DoiTacId;

                    if (phieuDto.LoaiPhieu == 1)//nhaphang
                    {
                        btnTraHang.Visible = true;
                        btnTraHang.Text = "Trả hàng phiếu đã chọn";
                    }
                    else if (phieuDto.LoaiPhieu == 2)//trahangnhap
                    {
                        btnTraHang.Visible = false;
                    }
                    else if (phieuDto.LoaiPhieu == 3)//xuathang
                    {
                        btnTraHang.Visible = true;
                        btnTraHang.Text = "Trả hàng phiếu đã chọn";
                    }
                    else if (phieuDto.LoaiPhieu == 4)//trahangxuat
                    {
                        btnTraHang.Visible = false;
                    }
                    else if (phieuDto.LoaiPhieu == 5)//xuathuy
                    {
                        btnTraHang.Visible = false;
                    }
                }

                // Hoặc Cách B: Lấy gián tiếp qua tên cột (Nếu bạn đặt tên cột là "colId" hoặc property là "Id")
                // int idPhieu = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn dòng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
