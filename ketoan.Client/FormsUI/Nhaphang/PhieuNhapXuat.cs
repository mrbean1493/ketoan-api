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

namespace ketoan.Client.FormsUI.Nhaphang
{
    public partial class PhieuNhapXuat : Form
    {
        private readonly LoaiPhieuNhapXuat _loaiPhieuNhapXuat;
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        int status = 0;
        private BindingList<ChiTietPhieuNhapXuatDtoClient> _bindingListChiTiet;

        // _currentPhieuId = null -> Chế độ Thêm mới
        // _currentPhieuId > 0   -> Chế độ Sửa (Cập nhật)
        private int? _currentPhieuId = null;
        public PhieuNhapXuat(LoaiPhieuNhapXuat loaiPhieuNhapXuat)
        {
            InitializeComponent();
            _loaiPhieuNhapXuat = loaiPhieuNhapXuat;
            _apiClient = new ApiConnectClient();


            CapNhatGiaoDien();
            LoadDoiTac();

        }

        private async void LoadDoiTac()
        {
            dateTimePickerNgayNhap.Value = DateTime.Now;
            // 1. Tạo danh sách dữ liệu mẫu (hoặc lấy từ CSDL/EF Core)
            List<DoiTacDtoClient> listDoiTac = new List<DoiTacDtoClient>
    {
        new DoiTacDtoClient { Id = 1, TenDoiTac = "Công ty TNHH Bánh Cánh Việt và Bánh Cánh Việt", SoDienThoai = "0988123456", SoDienThoai2="0988123456", MaDoiTac = "BCV" },
        new DoiTacDtoClient { Id = 2, TenDoiTac = "Công ty TNHH Salonpas", SoDienThoai = "1111111111", SoDienThoai2="222222222222", MaDoiTac = "BVS" },
        new DoiTacDtoClient { Id = 3, TenDoiTac = "Công ty TNHH Digital", SoDienThoai = "012345678", SoDienThoai2="01212121212", MaDoiTac = "XAY" },
        new DoiTacDtoClient { Id = 4, TenDoiTac = "Công ty TNHH Bánh Cánh Việt 2 và tiki tiki tiki dat", SoDienThoai = "0988123456", SoDienThoai2="0988123456", MaDoiTac = "BCV" },
        new DoiTacDtoClient { Id = 5, TenDoiTac = "Công ty TNHH Salonpas2", SoDienThoai = "1111111111", SoDienThoai2="222222222222", MaDoiTac = "BVS" },
        new DoiTacDtoClient { Id = 6, TenDoiTac = "Công ty TNHH Digital2", SoDienThoai = "012345678", SoDienThoai2="01212121212", MaDoiTac = "XAY" },
        new DoiTacDtoClient { Id = 7, TenDoiTac = "Công ty TNHH Bánh Cánh Việt 3", SoDienThoai = "0988123456", SoDienThoai2="0988123456", MaDoiTac = "BCV" },
        new DoiTacDtoClient { Id = 8, TenDoiTac = "Công ty TNHH Salonpas3", SoDienThoai = "1111111111", SoDienThoai2="222222222222", MaDoiTac = "BVS" },
        new DoiTacDtoClient { Id = 9, TenDoiTac = "Công ty TNHH Digital3", SoDienThoai = "012345678", SoDienThoai2="01212121212", MaDoiTac = "XAY" },
        new DoiTacDtoClient { Id = 10, TenDoiTac = "Công ty TNHH Bánh Cánh Việt 4", SoDienThoai = "0988123456", SoDienThoai2="0988123456", MaDoiTac = "BCV" },
        new DoiTacDtoClient { Id = 11, TenDoiTac = "Công ty TNHH Salonpas4 ", SoDienThoai = "1111111111", SoDienThoai2="222222222222", MaDoiTac = "BVS" },
        new DoiTacDtoClient { Id = 12, TenDoiTac = "Công ty TNHH Digital5", SoDienThoai = "012345678", SoDienThoai2="01212121212", MaDoiTac = "XAY" },
    };
            if (_loaiPhieuNhapXuat == LoaiPhieuNhapXuat.Nhaphang)
            {
                listDoiTac = await _apiClient.GetDoiTacAsync(null, true, null);
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
        private GridLookupHangHoa _lookupHangHoa;
        private GridLookupDVT _lookupDVT;
        private async void PhieuNhapXuat_Load(object sender, EventArgs e)
        {
            // 1. Dữ liệu Hàng hóa và ĐVT
            List<HangHoaDtoClient> listHangHoa = await _apiClient.GetHangHoaAsync();
            List<DonViTinhDtoClient> listDVT = await _apiClient.GetDonViTinhAsync();

            dataGridView1.AutoGenerateColumns = false;

            _bindingListChiTiet= new BindingList<ChiTietPhieuNhapXuatDtoClient>();
            dataGridView1.DataSource = _bindingListChiTiet;

            // 2. Khởi tạo Helper và truyền DataGridView chi tiết vào
            _lookupHangHoa = new GridLookupHangHoa(dataGridView1);
            _lookupHangHoa.SetDataSourceHangHoa(listHangHoa);

            _lookupDVT = new GridLookupDVT(dataGridView1);
            _lookupDVT.SetDataSourceDVT(listDVT);


            // 3. Nhận sự kiện khi chọn 1 hàng hóa trên gợi ý
            _lookupHangHoa.HangHoaSelected += (s, ev) =>
            {
                HangHoaDtoClient item = ev.SelectedProduct;
                int r = ev.RowIndex;
                // 1. Tắt tạm thời việc lắng nghe sự kiện để tránh bật lại Popup khi chuyển Cell
                _lookupHangHoa.IsBusyHangHoa = true;
                try
                {
                    // 1. Ép DataGridView kết thúc trạng thái chỉnh sửa hiện tại
                    dataGridView1.EndEdit();
                    // Điền thông tin hàng hóa vào các ô của dòng tương ứng trên dgvChiTiet
                    dataGridView1.Rows[r].Cells["colMaHH"].Value = item.Id;
                    dataGridView1.Rows[r].Cells["colTenHH"].Value = item.TenHH;
                    dataGridView1.Rows[r].Cells["colDVT"].Value = item.TenDVT;
                    dataGridView1.Rows[r].Cells["colSoLo"].Value = "";
                    dataGridView1.Rows[r].Cells["colDongia"].Value = 0;
                    dataGridView1.Rows[r].Cells["colSL"].Value = 0;
                    dataGridView1.Rows[r].Cells["colThanhTien"].Value = 0;
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
                    _lookupHangHoa.IsBusyHangHoa = false;
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
                    if (row.Cells["colSTT"].Value == null || string.IsNullOrWhiteSpace(row.Cells["colSTT"].Value.ToString()))
                    {
                        // Đánh STT bằng Chỉ số dòng + 1
                        row.Cells["colSTT"].Value = e.RowIndex + 1;
                    }
                }
            }
            // Khi có thay đổi ở 1 trong các cột ảnh hưởng đến tiền
            if (colName == "colSL" || colName == "colDongia")
            {
                TinhThanhTienDong(e.RowIndex);
            }

            // Khi cột Thành tiền thay đổi
            if (colName == "colThanhtien")
            {
                TinhTongTien();
            }
        }
        // 1. Cập nhật Thành tiền ngay khi gõ phím (Real-time)
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

            // Lấy giá trị an toàn (tránh lỗi null hoặc nhập chữ)
            decimal soLuong = Convert.ToDecimal(row.Cells["colSL"].Value ?? 0);
            decimal donGia = Convert.ToDecimal(row.Cells["colDongia"].Value ?? 0);
            //decimal chietKhau = Convert.ToDecimal(row.Cells["colChietKhau"].Value ?? 0); // % Chiết khấu (nếu có)

            // Công thức tính Thành tiền
            decimal thanhTien = soLuong * donGia;

            // Gán lại giá trị cho ô Thành tiền
            row.Cells["colThanhtien"].Value = thanhTien;
        }

        // 1. Hàm tính tổng Thành tiền cho tất cả các dòng trên DataGridView
        private void TinhTongTien()
        {
            decimal tongTien = 0;

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
                    var bindingList = dataGridView1.DataSource as BindingList<ChiTietPhieuNhapXuatDtoClient>;
                    if (bindingList != null)
                    {
                        // Xóa item khỏi BindingList (giao diện sẽ tự xóa dòng)
                        var currentItem = dataGridView1.CurrentRow.DataBoundItem as ChiTietPhieuNhapXuatDtoClient;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
            "Bạn chắc chắn lưu thông tin phiếu nhập xuất không?",
            "Xác nhận lưu phiếu nhập xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );
            if (confirmResult == DialogResult.Yes)
            {



                if (txtSoPhieu.Text == "") //phiếu mới
                {
                    //validate row
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        if(row.Cells["colSTT"].Value != null)
                        {
                            var maHH = row.Cells["colMaHH"].Value?.ToString();
                            if (string.IsNullOrEmpty(maHH))
                            {
                                MessageBox.Show("Thiếu mã hàng hóa dòng STT" + row.Cells["colSTT"].Value, "Cảnh báo");
                                return;
                            }

                            var tenHH = row.Cells["colTenHH"].Value?.ToString();
                            if (string.IsNullOrEmpty(tenHH))
                            {
                                MessageBox.Show("Thiếu tên hàng hóa dòng STT" + row.Cells["colSTT"].Value, "Cảnh báo");
                                return;
                            }

                            var dvt = row.Cells["colDVT"].Value?.ToString();
                            if (string.IsNullOrEmpty(dvt))
                            {
                                MessageBox.Show("Thiếu đơn vị tính hàng hóa dòng STT" + row.Cells["colSTT"].Value, "Cảnh báo");
                                return;
                            }

                            var solo = row.Cells["colSoLo"].Value?.ToString();
                            if (string.IsNullOrEmpty(solo))
                            {
                                MessageBox.Show("Thiếu số lô hàng hóa dòng STT" + row.Cells["colSTT"].Value, "Cảnh báo");
                                return;
                            }

                            var soluong = row.Cells["colSL"].Value?.ToString();
                            if (string.IsNullOrEmpty(soluong))
                            {
                                MessageBox.Show("Thiếu số lượng hàng hóa dòng STT" + row.Cells["colSTT"].Value, "Cảnh báo");
                                return;
                            }
                            if (soluong=="0")
                            {
                                MessageBox.Show("Số lượng =0 hàng hóa dòng STT" + row.Cells["colSTT"].Value, "Cảnh báo");
                                return;
                            }


                            var dongia = row.Cells["colDongia"].Value?.ToString();
                            if (string.IsNullOrEmpty(dongia))
                            {
                                MessageBox.Show("Thiếu đơn giá hàng hóa dòng STT" + row.Cells["colSTT"].Value, "Cảnh báo");
                                return;
                            }
                            if (dongia == "0")
                            {
                                MessageBox.Show("Đơn giá =0 hàng hóa dòng STT" + row.Cells["colSTT"].Value, "Cảnh báo");
                                return;
                            }
                        }
                    }
                }
                else //cập nhật phiếu
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
            this.Close();
        }
    }
}
