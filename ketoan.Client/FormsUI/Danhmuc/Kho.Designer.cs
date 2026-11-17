namespace ketoan.Client.FormsUI.Danhmuc
{
    partial class Kho
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
            txtSDT2 = new TextBox();
            label2 = new Label();
            txtSDT = new TextBox();
            lblSDT = new Label();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtRefresh = new Button();
            txtID = new TextBox();
            btnSave = new Button();
            txtKho = new TextBox();
            label1 = new Label();
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
            groupBox1.Controls.Add(txtSDT2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(lblSDT);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(lblDiaChi);
            groupBox1.Controls.Add(txtRefresh);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtKho);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnDel);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(508, 139);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = ".";
            // 
            // txtSDT2
            // 
            txtSDT2.Location = new Point(313, 104);
            txtSDT2.Name = "txtSDT2";
            txtSDT2.Size = new Size(158, 23);
            txtSDT2.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 108);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 27;
            label2.Text = "SĐT2";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(72, 105);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(148, 23);
            txtSDT.TabIndex = 26;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(17, 109);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(27, 15);
            lblSDT.TabIndex = 25;
            lblSDT.Text = "SĐT";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(72, 75);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(399, 23);
            txtDiaChi.TabIndex = 24;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(18, 77);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(43, 15);
            lblDiaChi.TabIndex = 23;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // txtRefresh
            // 
            txtRefresh.Location = new Point(423, 12);
            txtRefresh.Name = "txtRefresh";
            txtRefresh.Size = new Size(75, 23);
            txtRefresh.TabIndex = 22;
            txtRefresh.Text = "Refresh";
            txtRefresh.UseVisualStyleBackColor = true;
            txtRefresh.Click += txtRefresh_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(477, 45);
            txtID.Name = "txtID";
            txtID.Size = new Size(21, 23);
            txtID.TabIndex = 21;
            txtID.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(320, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 20;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtKho
            // 
            txtKho.Location = new Point(72, 46);
            txtKho.Name = "txtKho";
            txtKho.Size = new Size(399, 23);
            txtKho.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 48);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 18;
            label1.Text = "Tên kho";
            // 
            // btnDel
            // 
            btnDel.Location = new Point(217, 12);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(75, 23);
            btnDel.TabIndex = 17;
            btnDel.Text = "Xóa";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(116, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 16;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(17, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 15;
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
            dataGridView1.Location = new Point(0, 139);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(508, 311);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Kho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 450);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "Kho";
            Text = "Kho";
            Load += Kho_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button txtRefresh;
        private TextBox txtID;
        private Button btnSave;
        private TextBox txtKho;
        private Label label1;
        private Button btnDel;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView dataGridView1;
        private TextBox txtSDT;
        private Label lblSDT;
        private TextBox txtDiaChi;
        private Label lblDiaChi;
        private TextBox txtSDT2;
        private Label label2;
    }
}