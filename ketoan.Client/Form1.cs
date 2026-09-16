using ketoan.Client.Enums;
using ketoan.Client.FormsUI.Danhmuc;
using ketoan.Client.FormsUI.Hethong;
using ketoan.Client.FormsUI.Nhaphang;
using System;
using System.Windows.Forms;
namespace ketoan.Client
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        private DangNhap _frmDangNhap;
        // Constructor nhận FormDangNhap từ bên ngoài
        public FormMain(DangNhap frmDangNhap)
        {
            InitializeComponent();
            _frmDangNhap = frmDangNhap;
        }
        /*
        private void OpenChildFormInTab<T>() where T : System.Windows.Forms.Form, new()
        {
            string tabKey = typeof(T).Name; // Dùng tên class Form làm Key định danh

            // 1. Kiểm tra xem Tab chứa Form này đã mở chưa
            foreach (TabPage tab in tabControlMain.TabPages)
            {
                if (tab.Name == tabKey)
                {
                    tabControlMain.SelectedTab = tab; // Active tab đang mở
                    formChild.Dispose(); // Hủy form tạm vừa khởi tạo để tránh rò rỉ bộ nhớ
                    return;
                }
            }

            // 2. Nếu chưa mở -> Khởi tạo Form con mới
            T formChild = new T
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // 3. Tạo TabPage mới
            TabPage newTabPage = new TabPage
            {
                Name = tabKey,
                Text = formChild.Text // Lấy tiêu đề của Form làm tên Tab
            };

            // 4. Nhúng Form con vào TabPage và hiển thị
            newTabPage.Controls.Add(formChild);
            tabControlMain.TabPages.Add(newTabPage);
            tabControlMain.SelectedTab = newTabPage;

            formChild.Show();
        }
        */

        private void OpenChildFormInTab(Form formChild, string tabKey)
        {
            // 1. Kiểm tra xem Tab theo tabKey này đã mở chưa
            foreach (TabPage tab in tabControlMain.TabPages)
            {
                if (tab.Name == tabKey)
                {
                    tabControlMain.SelectedTab = tab; // Active tab đang mở
                    formChild.Dispose(); // Hủy form tạm vừa khởi tạo để tránh rò rỉ bộ nhớ
                    return;
                }
            }

            // 2. Thiết lập thuộc tính nhúng Form con
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;

            // 3. Tạo TabPage mới
            TabPage newTabPage = new TabPage
            {
                Name = tabKey,           // Đặt Key riêng biệt (ví dụ: "DoiTac_NhaCungCap")
                Text = formChild.Text    // Lấy tiêu đề từ Form con
            };

            // 4. Nhúng Form con vào TabPage và hiển thị
            newTabPage.Controls.Add(formChild);
            tabControlMain.TabPages.Add(newTabPage);
            tabControlMain.SelectedTab = newTabPage;

            formChild.Show();
        }


        private void quyềnNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Quyen();
            OpenChildFormInTab(form, "Quyen");
        }

        private void cấuHìnhChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CauHinhChung();
            OpenChildFormInTab(form, "CauHinhChung");
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DoiMatKhau();
            OpenChildFormInTab(form, "DoiMatKhau");
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DangNhap();
            OpenChildFormInTab(form, "DangNhap");
        }

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabCtrl = sender as TabControl;
            TabPage tabPage = tabCtrl.TabPages[e.Index];
            Rectangle tabRect = tabCtrl.GetTabRect(e.Index);

            bool isActive = (tabCtrl.SelectedIndex == e.Index);

            // 1. Phối màu
            Color backColor = isActive ? Color.FromArgb(0, 122, 204) : Color.FromArgb(230, 230, 230);
            Color textColor = isActive ? Color.White : Color.Black;
            Font tabFont = isActive ? new Font(e.Font, FontStyle.Bold) : e.Font;

            // Tô nền tab
            using (Brush bgBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(bgBrush, tabRect);
            }

            // 2. Định dạng vùng vẽ chữ (Dành 25px bên phải cho nút 'x')
            Rectangle textRect = new Rectangle(
                tabRect.X + 8,
                tabRect.Y,
                tabRect.Width - 30,
                tabRect.Height
            );

            // Vẽ chữ tự động chèn dấu "..." nếu tên quá dài
            TextRenderer.DrawText(
                e.Graphics,
                tabPage.Text,
                tabFont,
                textRect,
                textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis
            );

            // 3. Vẽ nút '×' đóng tab
            Color closeColor = isActive ? Color.White : Color.Gray;
            using (Brush closeBrush = new SolidBrush(closeColor))
            {
                e.Graphics.DrawString(
                    "×",
                    new Font("Arial", 10, FontStyle.Bold),
                    closeBrush,
                    tabRect.Right - 18,
                    tabRect.Y + (tabRect.Height - 16) / 2
                );
            }
        }

        private void tabControlMain_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControlMain.TabPages.Count; i++)
            {
                Rectangle tabRect = tabControlMain.GetTabRect(i);
                Rectangle closeButton = new Rectangle(tabRect.Right - 15, tabRect.Top + 4, 12, 12);

                if (closeButton.Contains(e.Location))
                {
                    tabControlMain.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControlMain.Invalidate(); // Yêu cầu TabControl vẽ lại ngay
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tabControlMain.ItemSize = new Size(150, 30);
            tabControlMain.SizeMode = TabSizeMode.Fixed;

            //if(QuanLyPhien.NgaySinh!=null)
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "Bạn có chắc chắn muốn đăng xuất tài khoản không?",
    "Xác nhận",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                // Xử lý khi chọn Yes
                // 2. Clear thông tin trong SessionManager
                QuanLyPhien.ClearSession();
                // 3. Đóng tất cả các Form con đang mở (Nếu bạn dùng MDI hoặc TabControl)

                // CÁCH A: Nếu bạn dùng MDI Form (Form con mở dạng MdiChildren)
                /*
                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Close();
                }
                */
                // CÁCH B: Nếu bạn dùng TabControl (Ví dụ đóng các Tab/Page đang xem)
                if (tabControlMain != null)
                {
                    tabControlMain.TabPages.Clear();
                }

                // 4. Mở lại Form Đăng nhập và Ẩn/Đóng FormMain
                //DangNhap frmdangNhap = new DangNhap();
                //frmdangNhap.Show();

                // Đóng FormMain hiện tại
                //this.Hide();


                // 2. Hiện lại Form Đăng nhập cũ (đã được làm sạch ô nhập)
                _frmDangNhap.ClearFields(); // Hàm xóa ô txtMatKhau
                _frmDangNhap.Show();

                // 3. Đóng FormMain hiện tại (giải phóng tài nguyên)
                this.Close();
            }
            else
            {
                // Xử lý khi chọn No
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu thoát bằng nút X góc trên của FormMain
            if (e.CloseReason == CloseReason.UserClosing && !_frmDangNhap.Visible)
            {
                Application.Exit(); // Đóng hoàn toàn ứng dụng chạy ngầm
            }
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DonViTinh();
            OpenChildFormInTab(form, "DonViTinh");
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildFormInTab<HangHoa>();
            var form = new HangHoa();
            OpenChildFormInTab(form, "HangHoa");
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildFormInTab<DoiTac>();
            var form = new DoiTac(LoaiDoiTac.NhaCungCap);
            OpenChildFormInTab(form, "DoiTac_NhaCungCap");
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DoiTac(LoaiDoiTac.KhachHang);
            OpenChildFormInTab(form, "DoiTac_KhachHang");
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DanhSachPhieuNhapXuat();
            OpenChildFormInTab(form, "DanhSachPhieuNhapXuat");
        }

        private void danhSáchPhiếuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new DanhSachPhieuNhapXuat();
            OpenChildFormInTab(form, "DanhSachPhieuNhapXuat");
        }
    }
}
