namespace ketoan.Client.FormsUI.Danhmuc
{
    partial class DoiTac
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
            txtSDT = new TextBox();
            txtVietTatView = new TextBox();
            txtTenDoiTacView = new TextBox();
            label4 = new Label();
            label3 = new Label();
            lblMaDoiTac = new Label();
            lblTenDoiTac = new Label();
            txtSDT2 = new TextBox();
            btnTimKiem = new Button();
            txtTenDoiTac = new TextBox();
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
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtVietTatView);
            groupBox1.Controls.Add(txtTenDoiTacView);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblMaDoiTac);
            groupBox1.Controls.Add(lblTenDoiTac);
            groupBox1.Controls.Add(txtSDT2);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(txtTenDoiTac);
            groupBox1.Controls.Add(btnDel);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1422, 121);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = ".";
            // 
            // txtId
            // 
            txtId.Location = new Point(1332, 20);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Id đối tác";
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
            btnSave.Click += btnSave_Click;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(708, 51);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(165, 23);
            txtSDT.TabIndex = 13;
            // 
            // txtVietTatView
            // 
            txtVietTatView.Location = new Point(98, 81);
            txtVietTatView.Name = "txtVietTatView";
            txtVietTatView.Size = new Size(465, 23);
            txtVietTatView.TabIndex = 11;
            // 
            // txtTenDoiTacView
            // 
            txtTenDoiTacView.Location = new Point(98, 52);
            txtTenDoiTacView.Name = "txtTenDoiTacView";
            txtTenDoiTacView.Size = new Size(465, 23);
            txtTenDoiTacView.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(655, 88);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 9;
            label4.Text = "SĐT2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(655, 56);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 8;
            label3.Text = "SĐT";
            // 
            // lblMaDoiTac
            // 
            lblMaDoiTac.AutoSize = true;
            lblMaDoiTac.Location = new Point(14, 84);
            lblMaDoiTac.Name = "lblMaDoiTac";
            lblMaDoiTac.Size = new Size(64, 15);
            lblMaDoiTac.TabIndex = 7;
            lblMaDoiTac.Text = "Tên viết tắt";
            // 
            // lblTenDoiTac
            // 
            lblTenDoiTac.AutoSize = true;
            lblTenDoiTac.Location = new Point(14, 54);
            lblTenDoiTac.Name = "lblTenDoiTac";
            lblTenDoiTac.Size = new Size(25, 15);
            lblTenDoiTac.TabIndex = 6;
            lblTenDoiTac.Text = "Tên";
            // 
            // txtSDT2
            // 
            txtSDT2.Location = new Point(708, 80);
            txtSDT2.Name = "txtSDT2";
            txtSDT2.Size = new Size(165, 23);
            txtSDT2.TabIndex = 5;
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
            // txtTenDoiTac
            // 
            txtTenDoiTac.Location = new Point(480, 22);
            txtTenDoiTac.Name = "txtTenDoiTac";
            txtTenDoiTac.PlaceholderText = "Nhập thông tin đối tác để tìm kiếm";
            txtTenDoiTac.Size = new Size(312, 23);
            txtTenDoiTac.TabIndex = 3;
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
            dataGridView1.Size = new Size(1422, 341);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // DoiTac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 462);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "DoiTac";
            Text = "Đối tác";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtId;
        private Button btnRefresh;
        private Button btnSave;
        private TextBox txtSDT;
        private TextBox txtVietTatView;
        private TextBox txtTenDoiTacView;
        private Label label4;
        private Label label3;
        private Label lblMaDoiTac;
        private Label lblTenDoiTac;
        private TextBox txtSDT2;
        private Button btnTimKiem;
        private TextBox txtTenDoiTac;
        private Button btnDel;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView dataGridView1;
    }
}