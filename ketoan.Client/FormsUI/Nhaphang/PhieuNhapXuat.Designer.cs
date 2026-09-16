namespace ketoan.Client.FormsUI.Nhaphang
{
    partial class PhieuNhapXuat
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
            btnAddHangHoa = new Button();
            btnAddDoiTac = new Button();
            gridLookupDoiTac1 = new ketoan.Client.ClassComponent.GridLookupDoiTac();
            cboKho = new ComboBox();
            lblKho = new Label();
            lblDoiTac = new Label();
            dateTimePickerNgayNhap = new DateTimePicker();
            lblNgayNhap = new Label();
            txtSoPhieu = new TextBox();
            lblSoPhieu = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colMaHH = new DataGridViewTextBoxColumn();
            colTenHH = new DataGridViewTextBoxColumn();
            colDVT = new DataGridViewTextBoxColumn();
            colSoLo = new DataGridViewTextBoxColumn();
            colSL = new DataGridViewTextBoxColumn();
            colDongia = new DataGridViewTextBoxColumn();
            colThanhtien = new DataGridViewTextBoxColumn();
            groupBox3 = new GroupBox();
            lblTienBangChu = new Label();
            button2 = new Button();
            button1 = new Button();
            lblTongTien = new Label();
            col_id_dvt = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddHangHoa);
            groupBox1.Controls.Add(btnAddDoiTac);
            groupBox1.Controls.Add(gridLookupDoiTac1);
            groupBox1.Controls.Add(cboKho);
            groupBox1.Controls.Add(lblKho);
            groupBox1.Controls.Add(lblDoiTac);
            groupBox1.Controls.Add(dateTimePickerNgayNhap);
            groupBox1.Controls.Add(lblNgayNhap);
            groupBox1.Controls.Add(txtSoPhieu);
            groupBox1.Controls.Add(lblSoPhieu);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1227, 139);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cuống phiếu";
            // 
            // btnAddHangHoa
            // 
            btnAddHangHoa.Anchor = AnchorStyles.Right;
            btnAddHangHoa.Location = new Point(1041, 45);
            btnAddHangHoa.Name = "btnAddHangHoa";
            btnAddHangHoa.Size = new Size(132, 23);
            btnAddHangHoa.TabIndex = 11;
            btnAddHangHoa.Text = "Thêm hàng hóa mới";
            btnAddHangHoa.UseVisualStyleBackColor = true;
            // 
            // btnAddDoiTac
            // 
            btnAddDoiTac.Anchor = AnchorStyles.Right;
            btnAddDoiTac.Location = new Point(1041, 16);
            btnAddDoiTac.Name = "btnAddDoiTac";
            btnAddDoiTac.Size = new Size(132, 23);
            btnAddDoiTac.TabIndex = 10;
            btnAddDoiTac.Text = "Thêm đối tác mới";
            btnAddDoiTac.UseVisualStyleBackColor = true;
            // 
            // gridLookupDoiTac1
            // 
            gridLookupDoiTac1.Location = new Point(116, 57);
            gridLookupDoiTac1.Name = "gridLookupDoiTac1";
            gridLookupDoiTac1.Size = new Size(637, 24);
            gridLookupDoiTac1.TabIndex = 9;
            // 
            // cboKho
            // 
            cboKho.FormattingEnabled = true;
            cboKho.Items.AddRange(new object[] { "Kho chính" });
            cboKho.Location = new Point(632, 21);
            cboKho.Name = "cboKho";
            cboKho.Size = new Size(121, 23);
            cboKho.TabIndex = 7;
            // 
            // lblKho
            // 
            lblKho.AutoSize = true;
            lblKho.Location = new Point(571, 24);
            lblKho.Name = "lblKho";
            lblKho.Size = new Size(28, 15);
            lblKho.TabIndex = 6;
            lblKho.Text = "Kho";
            // 
            // lblDoiTac
            // 
            lblDoiTac.AutoSize = true;
            lblDoiTac.Location = new Point(13, 60);
            lblDoiTac.Name = "lblDoiTac";
            lblDoiTac.Size = new Size(44, 15);
            lblDoiTac.TabIndex = 4;
            lblDoiTac.Text = "Đối tác";
            // 
            // dateTimePickerNgayNhap
            // 
            dateTimePickerNgayNhap.CustomFormat = "dd/MM/yyyy";
            dateTimePickerNgayNhap.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayNhap.Location = new Point(391, 22);
            dateTimePickerNgayNhap.Name = "dateTimePickerNgayNhap";
            dateTimePickerNgayNhap.Size = new Size(100, 23);
            dateTimePickerNgayNhap.TabIndex = 3;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new Point(292, 25);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(65, 15);
            lblNgayNhap.TabIndex = 2;
            lblNgayNhap.Text = "Ngày nhập";
            // 
            // txtSoPhieu
            // 
            txtSoPhieu.Location = new Point(116, 22);
            txtSoPhieu.Name = "txtSoPhieu";
            txtSoPhieu.Size = new Size(101, 23);
            txtSoPhieu.TabIndex = 1;
            // 
            // lblSoPhieu
            // 
            lblSoPhieu.AutoSize = true;
            lblSoPhieu.Location = new Point(12, 29);
            lblSoPhieu.Name = "lblSoPhieu";
            lblSoPhieu.Size = new Size(53, 15);
            lblSoPhieu.TabIndex = 0;
            lblSoPhieu.Text = "Số phiếu";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 139);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1227, 290);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết phiếu";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colSTT, colMaHH, colTenHH, colDVT, colSoLo, colSL, colDongia, colThanhtien, col_id_dvt });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 19);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1221, 268);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            // 
            // colSTT
            // 
            colSTT.HeaderText = "STT";
            colSTT.Name = "colSTT";
            colSTT.Width = 50;
            // 
            // colMaHH
            // 
            colMaHH.HeaderText = "Mã hàng hóa";
            colMaHH.Name = "colMaHH";
            // 
            // colTenHH
            // 
            colTenHH.HeaderText = "Tên hàng hóa";
            colTenHH.Name = "colTenHH";
            colTenHH.Width = 300;
            // 
            // colDVT
            // 
            colDVT.HeaderText = "ĐVT";
            colDVT.Name = "colDVT";
            // 
            // colSoLo
            // 
            colSoLo.HeaderText = "Số lô";
            colSoLo.Name = "colSoLo";
            colSoLo.Width = 150;
            // 
            // colSL
            // 
            colSL.HeaderText = "Số lượng";
            colSL.Name = "colSL";
            // 
            // colDongia
            // 
            colDongia.HeaderText = "Đơn giá";
            colDongia.Name = "colDongia";
            // 
            // colThanhtien
            // 
            colThanhtien.HeaderText = "Thành tiền";
            colThanhtien.Name = "colThanhtien";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblTienBangChu);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(lblTongTien);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 429);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1227, 140);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = ".";
            // 
            // lblTienBangChu
            // 
            lblTienBangChu.AutoSize = true;
            lblTienBangChu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTienBangChu.Location = new Point(13, 62);
            lblTienBangChu.Name = "lblTienBangChu";
            lblTienBangChu.Size = new Size(91, 15);
            lblTienBangChu.TabIndex = 3;
            lblTienBangChu.Text = "Tiền bằng chữ: ";
            // 
            // button2
            // 
            button2.Location = new Point(1041, 105);
            button2.Name = "button2";
            button2.Size = new Size(160, 23);
            button2.TabIndex = 2;
            button2.Text = "Lưu và đóng form";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(921, 105);
            button1.Name = "button1";
            button1.Size = new Size(101, 23);
            button1.TabIndex = 1;
            button1.Text = "Lưu";
            button1.UseVisualStyleBackColor = true;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongTien.Location = new Point(1041, 19);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(63, 15);
            lblTongTien.TabIndex = 0;
            lblTongTien.Text = "Tổng tiền:";
            // 
            // col_id_dvt
            // 
            col_id_dvt.HeaderText = "Id_dvt";
            col_id_dvt.Name = "col_id_dvt";
            col_id_dvt.Visible = false;
            // 
            // PhieuNhapXuat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 569);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "PhieuNhapXuat";
            Text = "Phiếu nhập xuất";
            Load += PhieuNhapXuat_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private GroupBox groupBox3;
        private DateTimePicker dateTimePickerNgayNhap;
        private Label lblNgayNhap;
        private TextBox txtSoPhieu;
        private Label lblSoPhieu;
        private Label lblDoiTac;
        private ComboBox cboKho;
        private Label lblKho;
        private Label lblTongTien;
        private Button button2;
        private Button button1;
        private ClassComponent.GridLookupDoiTac gridLookupDoiTac1;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colMaHH;
        private DataGridViewTextBoxColumn colTenHH;
        private DataGridViewTextBoxColumn colDVT;
        private DataGridViewTextBoxColumn colSoLo;
        private DataGridViewTextBoxColumn colSL;
        private DataGridViewTextBoxColumn colDongia;
        private DataGridViewTextBoxColumn colThanhtien;
        private Button btnAddHangHoa;
        private Button btnAddDoiTac;
        private Label lblTienBangChu;
        private DataGridViewTextBoxColumn col_id_dvt;
    }
}