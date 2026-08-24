namespace ketoan.Client.FormsUI.Danhmuc
{
    partial class DonViTinh
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
            btnSave = new Button();
            txtDVT = new TextBox();
            label1 = new Label();
            btnDel = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            txtID = new TextBox();
            txtRefresh = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtRefresh);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtDVT);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnDel);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(509, 80);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = ".";
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
            // txtDVT
            // 
            txtDVT.Location = new Point(109, 46);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(362, 23);
            txtDVT.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 48);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 18;
            label1.Text = "Tên đơn vị tính";
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
            dataGridView1.Location = new Point(0, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(509, 370);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // txtID
            // 
            txtID.Location = new Point(477, 45);
            txtID.Name = "txtID";
            txtID.Size = new Size(21, 23);
            txtID.TabIndex = 21;
            txtID.Visible = false;
            // 
            // txtRefresh
            // 
            txtRefresh.Enabled = false;
            txtRefresh.Location = new Point(423, 12);
            txtRefresh.Name = "txtRefresh";
            txtRefresh.Size = new Size(75, 23);
            txtRefresh.TabIndex = 22;
            txtRefresh.Text = "Refresh";
            txtRefresh.UseVisualStyleBackColor = true;
            // 
            // DonViTinh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 450);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "DonViTinh";
            Text = "Đơn vị tính";
            Load += DonViTinh_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button btnSave;
        private TextBox txtDVT;
        private Label label1;
        private Button btnDel;
        private Button btnEdit;
        private Button btnAdd;
        private Button txtRefresh;
        private TextBox txtID;
    }
}