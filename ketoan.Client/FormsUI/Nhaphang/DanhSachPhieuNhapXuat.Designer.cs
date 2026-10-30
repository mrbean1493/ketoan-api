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
            dataGridView1 = new DataGridView();
            txtSoPhieu = new TextBox();
            lblSoPhieu = new Label();
            label1 = new Label();
            gridLookupDoiTac1 = new ketoan.Client.ClassComponent.GridLookupDoiTac();
            lblDoiTac = new Label();
            comboBox1 = new ComboBox();
            dateTimePickerNgayNhapFrom = new DateTimePicker();
            lblNgayNhap = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            btnTimKiem = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePickerNgayNhapFrom);
            groupBox1.Controls.Add(lblNgayNhap);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(gridLookupDoiTac1);
            groupBox1.Controls.Add(lblDoiTac);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSoPhieu);
            groupBox1.Controls.Add(lblSoPhieu);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1113, 149);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm phiếu nhập xuất";
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
            dataGridView1.Size = new Size(1113, 383);
            dataGridView1.TabIndex = 1;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 68);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "Loại phiếu";
            // 
            // gridLookupDoiTac1
            // 
            gridLookupDoiTac1.Location = new Point(114, 104);
            gridLookupDoiTac1.Name = "gridLookupDoiTac1";
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(115, 66);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(132, 23);
            comboBox1.TabIndex = 12;
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
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(648, 26);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(100, 23);
            dateTimePicker1.TabIndex = 16;
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
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(796, 26);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(75, 23);
            btnTimKiem.TabIndex = 17;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(796, 104);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 18;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(892, 104);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 19;
            btnSua.Text = "Chỉnh sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(988, 104);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 20;
            btnXoa.Text = "Xóa bỏ";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // DanhSachPhieuNhapXuat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 532);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "DanhSachPhieuNhapXuat";
            Text = "Danh sách phiếu nhập xuất";
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
        private ComboBox comboBox1;
        private ClassComponent.GridLookupDoiTac gridLookupDoiTac1;
        private Label lblDoiTac;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private DateTimePicker dateTimePickerNgayNhapFrom;
        private Label lblNgayNhap;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnTimKiem;
    }
}