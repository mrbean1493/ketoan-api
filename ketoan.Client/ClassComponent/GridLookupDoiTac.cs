using ketoan.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ketoan.Client.ClassComponent
{
    public partial class GridLookupDoiTac : UserControl
    {
        private TextBox txtSearch;
        private Button btnDropdown;
        private PopupForm popupForm;
        private DataGridView dgvList;

        private List<DoiTacDtoClient> _dataSource = new List<DoiTacDtoClient>();

        public DoiTacDtoClient SelectedDoiTac { get; private set; }
        public event EventHandler DoiTacSelected;

        public GridLookupDoiTac()
        {
            InitializeComponentsCustom();
        }

        private void InitializeComponentsCustom()
        {
            this.Height = 26;
            this.Width = 280;

            txtSearch = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F)
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnDropdown = new Button
            {
                Text = "▼",
                Dock = DockStyle.Right,
                Width = 24,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Height = 22
            };
            btnDropdown.Click += (s, e) => TogglePopup();

            // 1. Tạo DataGridView
            dgvList = new DataGridView
            {
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Vertical,
                TabStop = false,
                Font = new Font("Segoe UI", 9F)
            };
            // 1. Bật tính năng tự xuống dòng cho ô dữ liệu
            dgvList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // 2. Cấu hình tự động điều chỉnh chiều cao hàng theo nội dung
            dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // (Tùy chọn) Bật tự xuống dòng cho cả tiêu đề cột nếu cần
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDoiTac", HeaderText = "Mã", Width = 60 });
            dgvList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDoiTac", HeaderText = "Tên Đối Tác", Width = 170 });
            dgvList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoDienThoai", HeaderText = "Số ĐT", Width = 90 });
            dgvList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoDienThoai2", HeaderText = "Số ĐT 2", Width = 90 });

            dgvList.CellClick += DgvList_CellClick;

            // 2. Tạo Floating Form đóng vai trò làm Popup không cướp Focus
            popupForm = new PopupForm();
            popupForm.Controls.Add(dgvList);

            this.Controls.Add(txtSearch);
            this.Controls.Add(btnDropdown);
        }

        public void SetDataSourceDoiTac(List<DoiTacDtoClient> data)
        {
            _dataSource = data ?? new List<DoiTacDtoClient>();
            dgvList.DataSource = null;
            dgvList.DataSource = _dataSource;
        }

        private void TogglePopup()
        {
            if (popupForm.Visible)
                HidePopup();
            else
                ShowPopup();
        }

        private void ShowPopup()
        {
            if (dgvList.Rows.Count == 0) return;

            // Tính vị trí hiển thị chuẩn tọa độ màn hình
            Point location = this.PointToScreen(new Point(0, this.Height));
            int width = Math.Max(this.Width, 420);
            int height = 200;

            popupForm.ShowPopup(location, new Size(width, height));
        }

        private void HidePopup()
        {
            popupForm.Hide();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            List<DoiTacDtoClient> filtered;
            if (string.IsNullOrEmpty(keyword))
            {
                filtered = _dataSource;
            }
            else
            {
                filtered = _dataSource.Where(x =>
                    (!string.IsNullOrEmpty(x.TenDoiTac) && x.TenDoiTac.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(x.SoDienThoai) && x.SoDienThoai.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(x.SoDienThoai2) && x.SoDienThoai2.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(x.MaDoiTac) && x.MaDoiTac.ToLower().Contains(keyword))
                ).ToList();
            }

            dgvList.DataSource = filtered;

            if (filtered.Count > 0)
            {
                ShowPopup();
            }
            else
            {
                HidePopup();
            }

            // Giữ con trỏ nhập liệu ở TextBox
            txtSearch.Focus();
            txtSearch.SelectionStart = txtSearch.Text.Length;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (popupForm.Visible && dgvList.Rows.Count > 0)
            {
                if (keyData == Keys.Down)
                {
                    int currentIndex = dgvList.CurrentRow?.Index ?? -1;
                    if (currentIndex < dgvList.Rows.Count - 1)
                    {
                        dgvList.Rows[currentIndex + 1].Selected = true;
                        dgvList.CurrentCell = dgvList.Rows[currentIndex + 1].Cells[0];
                    }
                    return true;
                }
                else if (keyData == Keys.Up)
                {
                    int currentIndex = dgvList.CurrentRow?.Index ?? 0;
                    if (currentIndex > 0)
                    {
                        dgvList.Rows[currentIndex - 1].Selected = true;
                        dgvList.CurrentCell = dgvList.Rows[currentIndex - 1].Cells[0];
                    }
                    return true;
                }
                else if (keyData == Keys.Enter)
                {
                    SelectCurrentRow();
                    return true;
                }
                else if (keyData == Keys.Escape)
                {
                    HidePopup();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectCurrentRow();
            }
        }

        private void SelectCurrentRow()
        {
            if (dgvList.CurrentRow != null)
            {
                SelectedDoiTac = (DoiTacDtoClient)dgvList.CurrentRow.DataBoundItem;

                txtSearch.TextChanged -= TxtSearch_TextChanged;
                txtSearch.Text = SelectedDoiTac.TenDoiTac;
                txtSearch.TextChanged += TxtSearch_TextChanged;

                HidePopup();
                DoiTacSelected?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    // Subclass Form hiển thị dưới dạng Popup thả nổi chuẩn Win32
    internal class PopupForm : Form
    {
        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATE = 3;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public PopupForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = (IntPtr)MA_NOACTIVATE;
                return;
            }
            base.WndProc(ref m);
        }

        public void ShowPopup(Point location, Size size)
        {
            this.Location = location;
            this.Size = size;
            if (!this.Visible)
            {
                // Win32 API ShowWindow với SW_SHOWNOACTIVATE (4)
                ShowWindow(this.Handle, 4);
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
