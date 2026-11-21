namespace ketoan.Client.FormsUI.Hethong
{
    partial class ResetPass
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
            txtMatKhau = new TextBox();
            btnHuy = new Button();
            btnLuu = new Button();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(140, 87);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(187, 23);
            txtMatKhau.TabIndex = 9;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(190, 127);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(137, 34);
            btnHuy.TabIndex = 8;
            btnHuy.Text = "Thoát/Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(21, 127);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(151, 34);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Chấp nhận";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(18, 90);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(81, 15);
            lblMatKhau.TabIndex = 6;
            lblMatKhau.Text = "Mật khẩu mới";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Enabled = false;
            txtTenDangNhap.Location = new Point(140, 35);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(187, 23);
            txtTenDangNhap.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 38);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 10;
            label1.Text = "Tên tài khoản";
            // 
            // ResetPass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 185);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label1);
            Controls.Add(txtMatKhau);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(lblMatKhau);
            Name = "ResetPass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đổi mật khẩu cho người dùng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMatKhau;
        private Button btnHuy;
        private Button btnLuu;
        private Label lblMatKhau;
        private TextBox txtTenDangNhap;
        private Label label1;
    }
}