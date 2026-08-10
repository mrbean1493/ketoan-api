namespace ketoan.Client.FormsUI.Hethong
{
    partial class DoiMatKhau
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtMatKhauMoi2 = new TextBox();
            btnDoiMatKhau = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 21);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 57);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 96);
            label3.Name = "label3";
            label3.Size = new Size(148, 15);
            label3.TabIndex = 2;
            label3.Text = "Xác nhận lại mật khẩu mới";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(198, 18);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(155, 23);
            txtMatKhauCu.TabIndex = 3;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(198, 54);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(155, 23);
            txtMatKhauMoi.TabIndex = 4;
            // 
            // txtMatKhauMoi2
            // 
            txtMatKhauMoi2.Location = new Point(198, 88);
            txtMatKhauMoi2.Name = "txtMatKhauMoi2";
            txtMatKhauMoi2.Size = new Size(155, 23);
            txtMatKhauMoi2.TabIndex = 5;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Location = new Point(23, 131);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(152, 38);
            btnDoiMatKhau.TabIndex = 6;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(201, 131);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(152, 38);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 208);
            Controls.Add(btnThoat);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(txtMatKhauMoi2);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DoiMatKhau";
            Text = "Đổi mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtMatKhauMoi2;
        private Button btnDoiMatKhau;
        private Button btnThoat;
    }
}