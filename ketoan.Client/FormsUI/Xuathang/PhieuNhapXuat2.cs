using ketoan.Client.ClassComponent;
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

namespace ketoan.Client.FormsUI.Xuathang
{
    public partial class PhieuNhapXuat2 : Form
    {
        private readonly LoaiPhieuNhapXuat _loaiPhieuNhapXuat;
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        int status = 0;
        private BindingList<ChiTietPhieuNhapXuat2DtoClient> _bindingListChiTiet;

        // _currentPhieuId = null -> Chế độ Thêm mới
        // _currentPhieuId > 0   -> Chế độ Sửa (Cập nhật)
        private int? _currentPhieuId = null;
        public PhieuNhapXuat2(LoaiPhieuNhapXuat loaiPhieuNhapXuat, int idphieu = 0)
        {
            InitializeComponent();

            _loaiPhieuNhapXuat = loaiPhieuNhapXuat;
            _apiClient = new ApiConnectClient();
            //idphieu = 23;
            _currentPhieuId = idphieu;
            CapNhatGiaoDien();


            LoadDoiTac();
        }

        private async Task LoadDataToEditAsync(int phieuId)
        {
            try
            {
                // Gọi hàm từ tầng ApiConnect của bạn (giả sử tên biến instance là _apiConnect)
                var result = await _apiClient.GetPhieuByIdAsync(phieuId);

                if (result != null && result.Success && result.Data != null)
                {
                    var phieu = result.Data;
                    txtSoPhieu.Text = phieuId.ToString();

                    // 1. Đổ dữ liệu lên Cuống phiếu (Header)
                    dateTimePickerNgayNhap.Value = phieu.NgayLap.ToLocalTime(); // Chuyển UTC về giờ máy local

                    // Gán ID đối tác vào Custom Control GridLookupDoiTac mà chúng ta đã cấu hình
                    gridLookupDoiTac1.SelectedId = phieu.DoiTacId;

                    // 2. Đổ danh sách chi tiết lên DataGridView
                    dataGridView1.DataSource = null;

                    // 2. Tự động đánh số thứ tự cho từng phần tử
                    int stt = 1;
                    foreach (var item in phieu.ChiTiets)
                    {
                        item.STT = stt++;
                    }
                    var bindingList = new BindingList<ChiTietPhieuNhapXuatDtoClient>(phieu.ChiTiets);
                    dataGridView1.DataSource = bindingList; // phieu.ChiTiets là List<ChiTietPhieuDtoClient>



                    var tongTien = phieu.TongTien;
                    // Hiển thị ra TextBox tổng tiền (Định dạng N0 cho dễ nhìn, ví dụ: 1.500.000)
                    lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0");

                    lblTienBangChu.Text = "Tổng tiền bằng chữ: " + DocTienHelper.DocTienBangChu(tongTien);
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
        private async void LoadDoiTac()
        {

            // 1. Tạo danh sách dữ liệu mẫu (hoặc lấy từ CSDL/EF Core)
            List<DoiTacDtoClient> listDoiTac = new List<DoiTacDtoClient>();
            if (_loaiPhieuNhapXuat == LoaiPhieuNhapXuat.Nhaphang)
            {
                listDoiTac = await _apiClient.GetDoiTacAsync(null, true, null);
            }
            else if (_loaiPhieuNhapXuat == LoaiPhieuNhapXuat.Xuathang)
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



            //gridLookupDoiTac1.SelectedId = 1;

        }

        private void CapNhatGiaoDien()
        {
            if (_loaiPhieuNhapXuat == LoaiPhieuNhapXuat.Nhaphang)
            {
                this.Text = "Phiếu nhập hàng hóa";
                //lblTieuDe.Text = "DANH SÁCH KHÁCH HÀNG";
                //txtTenDoiTacView.Text = "Tên khách hàng";
                lblDoiTac.Text = "Tên nhà cung cấp";
            }
            else if (_loaiPhieuNhapXuat == LoaiPhieuNhapXuat.Trahang)
            {
                this.Text = "Phiếu trả hàng nhập";
                //lblTieuDe.Text = "DANH SÁCH NHÀ CUNG CẤP";
                //txtTenDoiTacView.Text = "Tên nhà cung cấp";
                lblDoiTac.Text = "Tên nhà cung cấp";
            }
            else if (_loaiPhieuNhapXuat == LoaiPhieuNhapXuat.Xuathang)
            {
                this.Text = "Phiếu xuất hàng hóa";
                //lblTieuDe.Text = "DANH SÁCH NHÀ CUNG CẤP";
                //txtTenDoiTacView.Text = "Tên nhà cung cấp";
                lblDoiTac.Text = "Khách hàng";
            }
            else if (_loaiPhieuNhapXuat == LoaiPhieuNhapXuat.Trahangban)
            {
                this.Text = "Phiếu trả hàng xuất";
                //lblTieuDe.Text = "DANH SÁCH NHÀ CUNG CẤP";
                //txtTenDoiTacView.Text = "Tên nhà cung cấp";
                lblDoiTac.Text = "Khách hàng";
            }
            else
            {
                this.Text = "Phiếu xuất hủy";
                //lblTieuDe.Text = "DANH SÁCH NHÀ CUNG CẤP";
                //txtTenDoiTacView.Text = "Tên nhà cung cấp";
                lblDoiTac.Text = "Khách hàng";
            }
        }

        private GridLookupHangTonKho _lookupHangTonKho;
        private GridLookupDVT _lookupDVT;

        private async void PhieuNhapXuat2_Load(object sender, EventArgs e)
        {
            dateTimePickerNgayNhap.Value = DateTime.Now;


            // 1. Dữ liệu Hàng hóa và ĐVT
            List<HangTonKhoDtoClient> listHangTonKho = await _apiClient.GetHangTonKhoAsync(); //sẽ khá chậm
            List<DonViTinhDtoClient> listDVT = await _apiClient.GetDonViTinhAsync();




            dataGridView1.AutoGenerateColumns = false;

            _bindingListChiTiet = new BindingList<ChiTietPhieuNhapXuat2DtoClient>();
            dataGridView1.DataSource = _bindingListChiTiet;

            if (_currentPhieuId != 0)
            {
                await LoadDataToEditAsync((int)_currentPhieuId);
            }



            // 2. Khởi tạo Helper và truyền DataGridView chi tiết vào
            _lookupHangTonKho = new GridLookupHangTonKho(dataGridView1);
            _lookupHangTonKho.SetDataSourceHangTonKho(listHangTonKho);

            _lookupDVT = new GridLookupDVT(dataGridView1);
            _lookupDVT.SetDataSourceDVT(listDVT);


            // 3. Nhận sự kiện khi chọn 1 hàng hóa trên gợi ý
            _lookupHangTonKho.HangTonKhoSelected += (s, ev) =>
            {
                HangTonKhoDtoClient item = ev.SelectedProductInventory;
                int r = ev.RowIndex;
                // 1. Tắt tạm thời việc lắng nghe sự kiện để tránh bật lại Popup khi chuyển Cell
                _lookupHangTonKho.IsBusyHangHoa = true;
                try
                {
                    // 1. Ép DataGridView kết thúc trạng thái chỉnh sửa hiện tại
                    dataGridView1.EndEdit();
                    // Điền thông tin hàng hóa vào các ô của dòng tương ứng trên dgvChiTiet
                    dataGridView1.Rows[r].Cells["colMaHH"].Value = item.id_hang_hoa;
                    dataGridView1.Rows[r].Cells["colTenHH"].Value = item.TenHH;
                    dataGridView1.Rows[r].Cells["colDVT"].Value = item.TenDVT;
                    dataGridView1.Rows[r].Cells["colSoLo"].Value = "";
                    dataGridView1.Rows[r].Cells["colDongia"].Value = 0m;
                    dataGridView1.Rows[r].Cells["colSL"].Value = 0m;
                    dataGridView1.Rows[r].Cells["colThanhTien"].Value = 0m;
                    dataGridView1.Rows[r].Cells["col_id_dvt"].Value = item.id_dvt;
                    if (dataGridView1.Columns.Contains("colSoLo"))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[r].Cells["colSoLo"];
                        dataGridView1.BeginEdit(true);
                    }
                    TinhThanhTienDong(r);
                }
                finally
                {
                    // 5. Bật lại sự kiện gợi ý
                    _lookupHangTonKho.IsBusyHangHoa = false;
                }

            };


            // 3. Nhận sự kiện khi chọn 1 hàng hóa trên gợi ý
            _lookupDVT.DVTSelected += (s, ev) =>
            {
                DonViTinhDtoClient itemDVT = ev.SelectedProductDVT;
                int r = ev.RowIndex;
                // 1. Tắt tạm thời việc lắng nghe sự kiện để tránh bật lại Popup khi chuyển Cell
                _lookupDVT.IsBusyDVT = true;
                try
                {
                    // 1. Ép DataGridView kết thúc trạng thái chỉnh sửa hiện tại
                    dataGridView1.EndEdit();
                    // Điền thông tin hàng hóa vào các ô của dòng tương ứng trên dgvChiTiet

                    dataGridView1.Rows[r].Cells["col_id_dvt"].Value = itemDVT.Id;
                    dataGridView1.Rows[r].Cells["colDVT"].Value = itemDVT.TenDVT;


                }
                finally
                {
                    // 5. Bật lại sự kiện gợi ý
                    _lookupDVT.IsBusyDVT = false;
                }

            };
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu là dòng Tiêu đề hoặc dòng đang khởi tạo
            if (e.RowIndex < 0) return;

            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            // Chỉ kiểm tra khi có sự thay đổi ở cột Mã hàng hoặc Tên hàng
            if (colName == "colMaHH" || colName == "colTenHH")
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var valMa = row.Cells["colMaHH"].Value;
                var valTen = row.Cells["colTenHH"].Value;

                // Nếu 1 trong 2 cột có dữ liệu thì đánh STT (nếu ô STT chưa có giá trị)
                if ((valMa != null && !string.IsNullOrWhiteSpace(valMa.ToString())) ||
                    (valTen != null && !string.IsNullOrWhiteSpace(valTen.ToString())))
                {
                    row.Cells["colSTT"].Value = e.RowIndex + 1;
                    /*
                    if (row.Cells["colSTT"].Value == null || string.IsNullOrWhiteSpace(row.Cells["colSTT"].Value.ToString()))
                    {
                        // Đánh STT bằng Chỉ số dòng + 1
                        row.Cells["colSTT"].Value = e.RowIndex + 1;
                    }
                    */
                }
            }
            // Khi có thay đổi ở 1 trong các cột ảnh hưởng đến tiền
            if (colName == "colSL" || colName == "colDongia")
            {
                var SLvalue = dataGridView1.Rows[e.RowIndex].Cells["colSL"].Value;
                var DGvalue = dataGridView1.Rows[e.RowIndex].Cells["colDongia"].Value;

                if (SLvalue == null || DGvalue == null) return;


                if (!decimal.TryParse(SLvalue.ToString(), out decimal number))
                {
                    MessageBox.Show("Cột số lượng phải điền dạng số", "Cảnh báo");
                    return;
                }
                if (!decimal.TryParse(DGvalue.ToString(), out decimal number2))
                {
                    MessageBox.Show("Cột đơn giá phải điền dạng số", "Cảnh báo");
                    return;
                }
                TinhThanhTienDong(e.RowIndex);
            }
            TinhTongTien();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                string colName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
                // Nếu đang sửa ô Số lượng, Đơn giá hoặc Chiết khấu -> Commit ngay để tính Thành tiền
                if (colName == "colSL" || colName == "colDongia")
                {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        public void TinhThanhTienDong(int rowIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            if (row.IsNewRow) return;

            // Lấy object DTO đang được bind tại dòng hiện tại
            var item = row.DataBoundItem as ChiTietPhieuNhapXuat2DtoClient;

            //decimal chietKhau = Convert.ToDecimal(row.Cells["colChietKhau"].Value ?? 0); // % Chiết khấu (nếu có)
            if (item != null)
            {
                // Lấy giá trị an toàn (tránh lỗi null hoặc nhập chữ)
                decimal soLuong = Convert.ToDecimal(row.Cells["colSL"].Value ?? 0);
                decimal donGia = Convert.ToDecimal(row.Cells["colDongia"].Value ?? 0);
                item.ThanhTien = soLuong * donGia;
            }
            // Công thức tính Thành tiền


            // Gán lại giá trị cho ô Thành tiền
            //row.Cells["colThanhtien"].Value = thanhTien;
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            /*
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Bỏ qua dòng trống mới (NewRow) nằm ở dưới cùng lưới
                if (row.IsNewRow) continue;

                if (row.Cells["colThanhtien"].Value != null)
                {
                    decimal thanhTien = 0;
                    if (decimal.TryParse(row.Cells["colThanhtien"].Value.ToString(), out thanhTien))
                    {
                        tongTien += thanhTien;
                    }
                }
            }
            */
            // Lấy trực tiếp danh sách từ DataSource của DataGridView
            if (dataGridView1.DataSource is BindingList<ChiTietPhieuNhapXuatDtoClient> list)
            {
                // Dùng LINQ Sum để cộng dồn Thành Tiền của tất cả các dòng cực kỳ gọn gàng
                tongTien = list.Sum(x => x.ThanhTien);
            }


            // Hiển thị ra TextBox tổng tiền (Định dạng N0 cho dễ nhìn, ví dụ: 1.500.000)
            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0");

            lblTienBangChu.Text = "Tổng tiền bằng chữ: " + DocTienHelper.DocTienBangChu(tongTien);
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TinhTongTien();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu người dùng bấm phím Delete (Del)
            if (e.KeyCode == Keys.Delete)
            {
                // 1. Kiểm tra xem có dòng nào đang được chọn không
                if (dataGridView1.CurrentRow != null && !dataGridView1.CurrentRow.IsNewRow)
                {
                    var bindingList = dataGridView1.DataSource as BindingList<ChiTietPhieuNhapXuat2DtoClient>;
                    if (bindingList != null)
                    {
                        // Xóa item khỏi BindingList (giao diện sẽ tự xóa dòng)
                        var currentItem = dataGridView1.CurrentRow.DataBoundItem as ChiTietPhieuNhapXuat2DtoClient;
                        if (currentItem != null)
                        {
                            bindingList.Remove(currentItem);
                        }
                    }
                    else
                    {
                        // Nếu dùng Unbound (không bind DataSource)
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    }

                    // Đánh dấu là đã xử lý phím Delete để tránh tiếng 'Beep'
                    e.Handled = true;
                }
            }
        }
    }
}
