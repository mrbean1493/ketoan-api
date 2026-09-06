namespace ketoan.Client.FormsUI.Danhmuc
{
    partial class HangHoa
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
            txtId = new TextBox();
            btnRefresh = new Button();
            btnSave = new Button();
            txtMoTa = new TextBox();
            cboDVT = new ComboBox();
            txtVietTatView = new TextBox();
            txtTenHHView = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtVietTat = new TextBox();
            btnTimKiem = new Button();
            txtTenHH = new TextBox();
            btnDel = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(cboDVT);
            groupBox1.Controls.Add(txtVietTatView);
            groupBox1.Controls.Add(txtTenHHView);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtVietTat);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(txtTenHH);
            groupBox1.Controls.Add(btnDel);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1558, 121);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = ".";
            // 
            // txtId
            // 
            txtId.Location = new Point(1332, 20);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Id hàng hóa";
            txtId.Size = new Size(77, 23);
            txtId.TabIndex = 16;
            txtId.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Enabled = false;
            btnRefresh.Location = new Point(399, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 15;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(306, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 14;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += this.btnSave_Click;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(969, 84);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(440, 23);
            txtMoTa.TabIndex = 13;
            // 
            // cboDVT
            // 
            cboDVT.FormattingEnabled = true;
            cboDVT.Items.AddRange(new object[] { "Kg", "Cái", "Chiếc", "Con" });
            cboDVT.Location = new Point(969, 52);
            cboDVT.Name = "cboDVT";
            cboDVT.Size = new Size(440, 23);
            cboDVT.TabIndex = 12;
            // 
            // txtVietTatView
            // 
            txtVietTatView.Location = new Point(98, 81);
            txtVietTatView.Name = "txtVietTatView";
            txtVietTatView.Size = new Size(777, 23);
            txtVietTatView.TabIndex = 11;
            // 
            // txtTenHHView
            // 
            txtTenHHView.Location = new Point(98, 52);
            txtTenHHView.Name = "txtTenHHView";
            txtTenHHView.Size = new Size(777, 23);
            txtTenHHView.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(896, 84);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 9;
            label4.Text = "Mô tả";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(896, 52);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 8;
            label3.Text = "ĐVT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 84);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 7;
            label2.Text = "Tên viết tắt";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 54);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 6;
            label1.Text = "Tên hàng hóa";
            // 
            // txtVietTat
            // 
            txtVietTat.Location = new Point(476, 51);
            txtVietTat.Name = "txtVietTat";
            txtVietTat.PlaceholderText = "Nhập tên viết tắt hàng hóa để tìm kiếm";
            txtVietTat.Size = new Size(254, 23);
            txtVietTat.TabIndex = 5;
            txtVietTat.Visible = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(799, 22);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(75, 23);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTenHH
            // 
            txtTenHH.Location = new Point(480, 22);
            txtTenHH.Name = "txtTenHH";
            txtTenHH.PlaceholderText = "Nhập tên hàng hóa hoặc tên viết tắt để tìm kiếm";
            txtTenHH.Size = new Size(312, 23);
            txtTenHH.TabIndex = 3;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(210, 20);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(75, 23);
            btnDel.TabIndex = 2;
            btnDel.Text = "Xóa";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(111, 20);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(13, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 121);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1558, 443);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // HangHoa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1558, 564);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "HangHoa";
            Text = "Hàng hóa";
            Load += HangHoa_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button btnAdd;
        private Button btnDel;
        private Button btnEdit;
        private TextBox txtVietTat;
        private Button btnTimKiem;
        private TextBox txtTenHH;
        private TextBox txtTenHHView;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSave;
        private TextBox txtMoTa;
        private ComboBox cboDVT;
        private TextBox txtVietTatView;
        private Button btnRefresh;
        private TextBox txtId;
    }
}