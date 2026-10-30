using ketoan.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ketoan.Client.ClassComponent.GridLookupHangHoa;

namespace ketoan.Client.ClassComponent
{
    public class GridLookupDVT : IMessageFilter
    {
        // Biến cờ ngăn chặn bật Popup khi đang thực hiện gán dữ liệu tự động
        public bool IsBusyDVT { get; set; } = false;
        private PopupForm popupForm;
        private DataGridView dgvSuggest;
        private DataGridView dgvParent; // DataGridView gốc chứa danh sách nhập hàng
        private List<DonViTinhDtoClient> _dataSource = new List<DonViTinhDtoClient>();

        public DonViTinhDtoClient SelectedDVT { get; private set; }
        public event EventHandler<DVTSelectedEventArgs> DVTSelected;

        [DllImport("user32.dll")]
        private static extern IntPtr SetFocus(IntPtr hWnd);
        public GridLookupDVT(DataGridView parentDgv)
        {
            this.dgvParent = parentDgv;
            InitializeComponentsCustom();
            AttachParentEvents();

            // Đăng ký bộ lọc thông điệp Windows để bắt phím ESC/Up/Down/Enter toàn cục
            Application.AddMessageFilter(this);
        }

        private void InitializeComponentsCustom()
        {
            // 1. Tạo lưới hiển thị gợi ý (Popup Grid)
            dgvSuggest = new DataGridView
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

            // Bật xuống dòng tự động cho lưới gợi ý
            dgvSuggest.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvSuggest.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Định nghĩa cột gợi ý đơn vị tính
            dgvSuggest.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã ĐVT", Width = 80 });
            dgvSuggest.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDVT", HeaderText = "Tên ĐVT", Width = 80 });
            //dgvSuggest.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn giá", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            //dgvSuggest.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TonKho", HeaderText = "Tồn", Width = 60, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

            dgvSuggest.CellClick += DgvSuggest_CellClick;

            // 2. Tạo Floating Popup Form
            popupForm = new PopupForm();
            popupForm.Controls.Add(dgvSuggest);
        }

        public void SetDataSourceDVT(List<DonViTinhDtoClient> data)
        {
            _dataSource = data ?? new List<DonViTinhDtoClient>();
            dgvSuggest.DataSource = null;
            dgvSuggest.DataSource = _dataSource;
        }
        private void AttachParentEvents()
        {
            if (dgvParent == null) return;

            // Bắt sự kiện người dùng gõ phím vào ô chỉnh sửa của DataGridView cha
            dgvParent.EditingControlShowing += DgvParent_EditingControlShowing;
            dgvParent.ColumnWidthChanged += (s, e) => HidePopup();
            dgvParent.Scroll += (s, e) => HidePopup();
        }

        private void DgvParent_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox txt)
            {
                // Hủy đăng ký cũ để tránh trùng lặp handler
                txt.TextChanged -= ParentCell_TextChanged;
                // Gỡ bỏ sự kiện cũ
                // txt.KeyUp -= ParentCell_KeyUp;
                txt.KeyDown -= ParentCell_KeyDown;

                // Chỉ bắt sự kiện nếu đang ở đúng cột "TenDVT" hoặc cột bạn muốn gợi ý
                int colIndex = dgvParent.CurrentCell.ColumnIndex;
                if (dgvParent.Columns[colIndex].Name == "colDVT" || dgvParent.Columns[colIndex].HeaderText.Contains("ĐVT"))
                {
                    txt.TextChanged += ParentCell_TextChanged;
                    // Sử dụng KeyUp thay vì TextChanged để tránh đứt Focus ký tự đầu
                    //txt.KeyUp += ParentCell_KeyUp;
                    txt.KeyDown += ParentCell_KeyDown;
                }
            }
        }

        private void ParentCell_TextChanged(object sender, EventArgs e)
        {// Nếu đang trong quá trình gán dữ liệu từ code thì BỎ QUA không bật Popup
            if (IsBusyDVT) return;
            if (sender is TextBox txt)
            {
                string keyword = txt.Text.Trim().ToLower();

                List<DonViTinhDtoClient> filtered;
                if (string.IsNullOrEmpty(keyword))
                {
                    filtered = _dataSource;
                }
                else
                {
                    filtered = _dataSource.Where(x =>
                        (!string.IsNullOrEmpty(x.TenDVT) && x.TenDVT.ToLower().Contains(keyword))
                    ).ToList();
                }

                dgvSuggest.DataSource = filtered;

                if (filtered.Count > 0)// && txt.Focused)
                {
                    ShowPopupAtCurrentCell(txt);
                }
                else
                {
                    HidePopup();
                }
            }
        }
        private void ParentCell_KeyUp(object sender, KeyEventArgs e)
        {
            // Bỏ qua các phím điều hướng để tránh bật Popup không cần thiết
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                return;
            }

            if (sender is TextBox txt)
            {
                string keyword = txt.Text.Trim().ToLower();

                List<DonViTinhDtoClient> filtered;
                if (string.IsNullOrEmpty(keyword))
                {
                    filtered = _dataSource;
                }
                else
                {
                    filtered = _dataSource.Where(x =>
                        (!string.IsNullOrEmpty(x.TenDVT) && x.TenDVT.ToLower().Contains(keyword))
                    ).ToList();
                }

                dgvSuggest.DataSource = filtered;

                if (filtered.Count > 0)// && txt.Focused)
                {
                    ShowPopupAtCurrentCell(txt);

                    // Ép lại Focus và vị trí con trỏ nhập liệu về cho Cell đang gõ
                    //txt.Focus();
                    //txt.SelectionStart = txt.Text.Length;
                }
                else
                {
                    HidePopup();
                }
            }
        }
        private void ParentCell_KeyDown(object sender, KeyEventArgs e)
        {
            if (popupForm.Visible && dgvSuggest.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Down)
                {
                    int currentIndex = dgvSuggest.CurrentRow?.Index ?? -1;
                    if (currentIndex < dgvSuggest.Rows.Count - 1)
                    {
                        dgvSuggest.Rows[currentIndex + 1].Selected = true;
                        dgvSuggest.CurrentCell = dgvSuggest.Rows[currentIndex + 1].Cells[0];
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    int currentIndex = dgvSuggest.CurrentRow?.Index ?? 0;
                    if (currentIndex > 0)
                    {
                        dgvSuggest.Rows[currentIndex - 1].Selected = true;
                        dgvSuggest.CurrentCell = dgvSuggest.Rows[currentIndex - 1].Cells[0];
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    SelectCurrentRow();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    HidePopup();
                    e.Handled = true;
                }
            }
        }
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_KEYDOWN = 0x0100;
            if (m.Msg == WM_KEYDOWN && popupForm != null && popupForm.Visible)
            {
                Keys key = (Keys)m.WParam.ToInt32();

                // 1. Nhấn ESC -> Ẩn lưới ngay lập tức
                if (key == Keys.Escape)
                {
                    HidePopup();
                    return true; // Đánh dấu đã xử lý, không cho WinForms can thiệp thêm
                }

                // 2. Nhấn Mũi tên XUỐNG
                if (key == Keys.Down)
                {
                    if (dgvSuggest.Rows.Count > 0)
                    {
                        int currentIndex = dgvSuggest.CurrentRow?.Index ?? -1;
                        if (currentIndex < dgvSuggest.Rows.Count - 1)
                        {
                            dgvSuggest.Rows[currentIndex + 1].Selected = true;
                            dgvSuggest.CurrentCell = dgvSuggest.Rows[currentIndex + 1].Cells[0];
                        }
                    }
                    return true;
                }

                // 3. Nhấn Mũi tên LÊN
                if (key == Keys.Up)
                {
                    if (dgvSuggest.Rows.Count > 0)
                    {
                        int currentIndex = dgvSuggest.CurrentRow?.Index ?? 0;
                        if (currentIndex > 0)
                        {
                            dgvSuggest.Rows[currentIndex - 1].Selected = true;
                            dgvSuggest.CurrentCell = dgvSuggest.Rows[currentIndex - 1].Cells[0];
                        }
                    }
                    return true;
                }

                // 4. Nhấn ENTER -> Chọn dòng
                if (key == Keys.Enter)
                {
                    SelectCurrentRow();
                    return true;
                }
            }
            return false;
        }

        private void ShowPopupAtCurrentCell(TextBox txtEditing)
        {
            if (dgvParent.CurrentCell == null) return;

            // 1. Lấy Rectangle của Cell hiện tại tương quan với DataGridView cha
            Rectangle cellRect = dgvParent.GetCellDisplayRectangle(
                dgvParent.CurrentCell.ColumnIndex,
                dgvParent.CurrentCell.RowIndex,
                false);

            // 2. Chuyển tọa độ Cell sang tọa độ màn hình (Screen Coordinates)
            Point cellScreenLocation = dgvParent.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));

            // 3. Thiết lập kích thước Popup
            int width = Math.Max(cellRect.Width, 300);
            int height = 220;

            popupForm.ShowPopup(cellScreenLocation, new Size(width, height));
            // Tránh xung đột luồng vẽ WinForms khi bắt đầu Edit Cell
            /*
            dgvParent.BeginInvoke(new Action(() =>
            {
                if (dgvParent.IsCurrentCellInEditMode)
                {
                    popupForm.ShowPopup(cellScreenLocation, new Size(width, height));
                }
            }));
            */

            // ÉP CHẮC CHẮN FOCUS VỀ CELL EDITING CONTROL BẰNG NATIVE API
            if (txtEditing != null && txtEditing.IsHandleCreated)
            {
                SetFocus(txtEditing.Handle);
                txtEditing.SelectionStart = txtEditing.Text.Length;
            }
        }
        public void HidePopup()
        {
            if (popupForm != null && popupForm.Visible)
            {
                popupForm.Hide();
            }
        }

        private void DgvSuggest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectCurrentRow();
            }
        }

        private void SelectCurrentRow()
        {
            if (dgvSuggest.CurrentRow != null && dgvParent.CurrentCell != null)
            {
                SelectedDVT = (DonViTinhDtoClient)dgvSuggest.CurrentRow.DataBoundItem;
                int rowIndex = dgvParent.CurrentCell.RowIndex;

                HidePopup();

                // Phát sự kiện báo ra Form chính để gán dữ liệu vào dòng tương ứng
                DVTSelected?.Invoke(this, new DVTSelectedEventArgs
                {
                    SelectedProductDVT = SelectedDVT,
                    RowIndex = rowIndex
                });
            }
        }

        public class DVTSelectedEventArgs : EventArgs
        {
            public DonViTinhDtoClient SelectedProductDVT { get; set; }
            public int RowIndex { get; set; }
        }
    }

    // Subclass PopupForm Native Win32
    internal class PopupFormDVT : Form
    {
        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATE = 3;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public PopupFormDVT()
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
                ShowWindow(this.Handle, 4); // SW_SHOWNOACTIVATE
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
