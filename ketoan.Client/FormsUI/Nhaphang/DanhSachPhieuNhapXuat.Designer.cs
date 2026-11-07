namespace ketoan.Client.FormsUI.Nhaphang
{
    partial class DanhSachPhieuNhapXuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            btnTimKiem = new Button();
            dateTimePickerNgayNhapTo = new DateTimePicker();
            label2 = new Label();
            dateTimePickerNgayNhapFrom = new DateTimePicker();
            lblNgayNhap = new Label();
            cboLoaiPhieu = new ComboBox();
            gridLookupDoiTac1 = new ketoan.Client.ClassComponent.GridLookupDoiTac();
            lblDoiTac = new Label();
            label1 = new Label();
            txtSoPhieu = new TextBox();
            lblSoPhieu = new Label();
            dataGridView1 = new DataGridView();
            btnTraHang = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnTraHang);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(dateTimePickerNgayNhapTo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePickerNgayNhapFrom);
            groupBox1.Controls.Add(lblNgayNhap);
            groupBox1.Controls.Add(cboLoaiPhieu);
            groupBox1.Controls.Add(gridLookupDoiTac1);
            groupBox1.Controls.Add(lblDoiTac);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSoPhieu);
            groupBox1.Controls.Add(lblSoPhieu);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1189, 149);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm phiếu nhập xuất";
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(988, 96);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 39);
            btnXoa.TabIndex = 20;
            btnXoa.Text = "Xóa bỏ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(892, 96);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 39);
            btnSua.TabIndex = 19;
            btnSua.Text = "Chỉnh sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(796, 96);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 39);
            btnThem.TabIndex = 18;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(796, 26);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(75, 23);
            btnTimKiem.TabIndex = 17;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dateTimePickerNgayNhapTo
            // 
            dateTimePickerNgayNhapTo.CustomFormat = "dd/MM/yyyy";
            dateTimePickerNgayNhapTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayNhapTo.Location = new Point(648, 26);
            dateTimePickerNgayNhapTo.Name = "dateTimePickerNgayNhapTo";
            dateTimePickerNgayNhapTo.Size = new Size(100, 23);
            dateTimePickerNgayNhapTo.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(523, 29);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 15;
            label2.Text = "Ngày nhập đến ngày";
            // 
            // dateTimePickerNgayNhapFrom
            // 
            dateTimePickerNgayNhapFrom.CustomFormat = "dd/MM/yyyy";
            dateTimePickerNgayNhapFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayNhapFrom.Location = new Point(400, 26);
            dateTimePickerNgayNhapFrom.Name = "dateTimePickerNgayNhapFrom";
            dateTimePickerNgayNhapFrom.Size = new Size(100, 23);
            dateTimePickerNgayNhapFrom.TabIndex = 14;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new Point(287, 29);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(108, 15);
            lblNgayNhap.TabIndex = 13;
            lblNgayNhap.Text = "Ngày nhập từ ngày";
            // 
            // cboLoaiPhieu
            // 
            cboLoaiPhieu.FormattingEnabled = true;
            cboLoaiPhieu.Location = new Point(115, 66);
            cboLoaiPhieu.Name = "cboLoaiPhieu";
            cboLoaiPhieu.Size = new Size(132, 23);
            cboLoaiPhieu.TabIndex = 12;
            // 
            // gridLookupDoiTac1
            // 
            gridLookupDoiTac1.Location = new Point(114, 104);
            gridLookupDoiTac1.Name = "gridLookupDoiTac1";
            gridLookupDoiTac1.SelectedId = null;
            gridLookupDoiTac1.Size = new Size(637, 24);
            gridLookupDoiTac1.TabIndex = 11;
            // 
            // lblDoiTac
            // 
            lblDoiTac.AutoSize = true;
            lblDoiTac.Location = new Point(12, 110);
            lblDoiTac.Name = "lblDoiTac";
            lblDoiTac.Size = new Size(44, 15);
            lblDoiTac.TabIndex = 10;
            lblDoiTac.Text = "Đối tác";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 68);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "Loại phiếu";
            // 
            // txtSoPhieu
            // 
            txtSoPhieu.Location = new Point(114, 26);
            txtSoPhieu.Name = "txtSoPhieu";
            txtSoPhieu.Size = new Size(133, 23);
            txtSoPhieu.TabIndex = 3;
            // 
            // lblSoPhieu
            // 
            lblSoPhieu.AutoSize = true;
            lblSoPhieu.Location = new Point(12, 29);
            lblSoPhieu.Name = "lblSoPhieu";
            lblSoPhieu.Size = new Size(53, 15);
            lblSoPhieu.TabIndex = 2;
            lblSoPhieu.Text = "Số phiếu";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 149);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1189, 383);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnTraHang
            // 
            btnTraHang.Location = new Point(1086, 96);
            btnTraHang.Name = "btnTraHang";
            btnTraHang.Size = new Size(91, 39);
            btnTraHang.TabIndex = 21;
            btnTraHang.Text = "Trả hàng phiếu đã chọn";
            btnTraHang.UseVisualStyleBackColor = true;
            btnTraHang.Visible = false;
            // 
            // DanhSachPhieuNhapXuat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 532);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "DanhSachPhieuNhapXuat";
            Text = "Danh sách phiếu nhập xuất";
            Load += DanhSachPhieuNhapXuat_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtSoPhieu;
        private Label lblSoPhieu;
        private ComboBox cboLoaiPhieu;
        private ClassComponent.GridLookupDoiTac gridLookupDoiTac1;
        private Label lblDoiTac;
        private DateTimePicker dateTimePickerNgayNhapTo;
        private Label label2;
        private DateTimePicker dateTimePickerNgayNhapFrom;
        private Label lblNgayNhap;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnTimKiem;
        private Button btnTraHang;
    }
}