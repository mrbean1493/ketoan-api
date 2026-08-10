using ketoan.Client.FormsUI.Hethong;
using System;
using System.Windows.Forms;
namespace ketoan.Client
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void OpenChildFormInTab<T>() where T : System.Windows.Forms.Form, new()
        {
            string tabKey = typeof(T).Name; // Dùng tên class Form làm Key định danh

            // 1. Kiểm tra xem Tab chứa Form này đã mở chưa
            foreach (TabPage tab in tabControlMain.TabPages)
            {
                if (tab.Name == tabKey)
                {
                    tabControlMain.SelectedTab = tab; // Active tab đang mở
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

        private void quyềnNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildFormInTab<Quyen>();
        }

        private void cấuHìnhChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildFormInTab<CauHinhChung>();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildFormInTab<DoiMatKhau>();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildFormInTab<DangNhap>();
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
    }
}
