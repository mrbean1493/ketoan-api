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
    public partial class DanhSachPhieuNhapXuat : Form
    {
        private readonly ApiConnectClient _apiClient = new ApiConnectClient();
        private int _loaiPhieu;
        public DanhSachPhieuNhapXuat(bool isNhapKho=true)
        {
            InitializeComponent();
            _apiClient = new ApiConnectClient();

            LoadLoaiPhieu(isNhapKho);
            LoadDoiTac(isNhapKho);
            CapNhatGiaoDien(isNhapKho);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult confirmResult = MessageBox.Show(
            "Bạn chắc chắn xóa phiếu đang chọn không? Phiếu sẽ không thể khôi phục!",
            "Xác nhận xóa phiếu",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );
            if (confirmResult == DialogResult.Yes)
            {

            }
        }

        private void DanhSachPhieuNhapXuat_Load(object sender, EventArgs e)
        {
            dateTimePickerNgayNhapFrom.Value = DateTime.Now;
            dateTimePickerNgayNhapTo.Value = DateTime.Now;



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
        }
    }
}
