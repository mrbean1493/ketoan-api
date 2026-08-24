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
            dataGridView1 = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colId = new DataGridViewTextBoxColumn();
            colTenHangHoa = new DataGridViewTextBoxColumn();
            colVietTat = new DataGridViewTextBoxColumn();
            colDVT = new DataGridViewTextBoxColumn();
            colMoTa = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDel = new Button();
            txtTenHH = new TextBox();
            button1 = new Button();
            txtVietTat = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTenHHView = new TextBox();
            textBox1 = new TextBox();
            cboDVT = new ComboBox();
            textBox2 = new TextBox();
            btnSave = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(cboDVT);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(txtTenHHView);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtVietTat);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(txtTenHH);
            groupBox1.Controls.Add(btnDel);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1558, 196);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = ".";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colSTT, colId, colTenHangHoa, colVietTat, colDVT, colMoTa });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1558, 368);
            dataGridView1.TabIndex = 1;
            // 
            // colSTT
            // 
            colSTT.HeaderText = "STT";
            colSTT.Name = "colSTT";
            colSTT.ReadOnly = true;
            // 
            // colId
            // 
            colId.HeaderText = "Mã hàng hóa";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colTenHangHoa
            // 
            colTenHangHoa.HeaderText = "Tên hàng hóa";
            colTenHangHoa.Name = "colTenHangHoa";
            colTenHangHoa.ReadOnly = true;
            // 
            // colVietTat
            // 
            colVietTat.HeaderText = "Tên viết tắt";
            colVietTat.Name = "colVietTat";
            colVietTat.ReadOnly = true;
            // 
            // colDVT
            // 
            colDVT.HeaderText = "ĐVT";
            colDVT.Name = "colDVT";
            colDVT.ReadOnly = true;
            // 
            // colMoTa
            // 
            colMoTa.HeaderText = "Mô tả";
            colMoTa.Name = "colMoTa";
            colMoTa.ReadOnly = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(13, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(112, 20);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(213, 20);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(75, 23);
            btnDel.TabIndex = 2;
            btnDel.Text = "Xóa";
            btnDel.UseVisualStyleBackColor = true;
            // 
            // txtTenHH
            // 
            txtTenHH.Location = new Point(476, 22);
            txtTenHH.Name = "txtTenHH";
            txtTenHH.PlaceholderText = "Nhập tên hàng hóa để tìm kiếm";
            txtTenHH.Size = new Size(254, 23);
            txtTenHH.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(749, 22);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtVietTat
            // 
            txtVietTat.Location = new Point(476, 51);
            txtVietTat.Name = "txtVietTat";
            txtVietTat.PlaceholderText = "Nhập tên viết tắt hàng hóa để tìm kiếm";
            txtVietTat.Size = new Size(254, 23);
            txtVietTat.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 99);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 6;
            label1.Text = "Tên hàng hóa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 129);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 7;
            label2.Text = "Tên viết tắt";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(896, 97);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 8;
            label3.Text = "ĐVT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(896, 129);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 9;
            label4.Text = "Mô tả";
            // 
            // txtTenHHView
            // 
            txtTenHHView.Location = new Point(98, 97);
            txtTenHHView.Name = "txtTenHHView";
            txtTenHHView.Size = new Size(777, 23);
            txtTenHHView.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(98, 126);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(777, 23);
            textBox1.TabIndex = 11;
            // 
            // cboDVT
            // 
            cboDVT.FormattingEnabled = true;
            cboDVT.Items.AddRange(new object[] { "Kg", "Cái", "Chiếc", "Con" });
            cboDVT.Location = new Point(969, 97);
            cboDVT.Name = "cboDVT";
            cboDVT.Size = new Size(440, 23);
            cboDVT.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(969, 129);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(440, 23);
            textBox2.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(316, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 14;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button btnAdd;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTenHangHoa;
        private DataGridViewTextBoxColumn colVietTat;
        private DataGridViewTextBoxColumn colDVT;
        private DataGridViewTextBoxColumn colMoTa;
        private Button btnDel;
        private Button btnEdit;
        private TextBox txtVietTat;
        private Button button1;
        private TextBox txtTenHH;
        private TextBox txtTenHHView;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSave;
        private TextBox textBox2;
        private ComboBox cboDVT;
        private TextBox textBox1;
    }
}