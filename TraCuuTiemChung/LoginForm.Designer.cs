
namespace TraCuuTiemChung
{
    partial class LoginForm
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
            this.labelUser = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.labelAppName = new System.Windows.Forms.Label();
            this.cbSaveUser = new System.Windows.Forms.CheckBox();
            this.pictureAppLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(187, 268);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(105, 17);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "Tên đăng nhập";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(350, 268);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(165, 22);
            this.tbUser.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(350, 319);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(165, 22);
            this.tbPassword.TabIndex = 3;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(187, 319);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(138, 17);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Mật khẩu đăng nhập";
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(276, 459);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(155, 23);
            this.btLogin.TabIndex = 4;
            this.btLogin.Text = "Đăng nhập";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.Location = new System.Drawing.Point(164, 165);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(385, 25);
            this.labelAppName.TabIndex = 6;
            this.labelAppName.Text = "Phần mềm quản lý tiêm vacxin trong trường";
            // 
            // cbSaveUser
            // 
            this.cbSaveUser.AutoSize = true;
            this.cbSaveUser.Location = new System.Drawing.Point(350, 432);
            this.cbSaveUser.Name = "cbSaveUser";
            this.cbSaveUser.Size = new System.Drawing.Size(143, 21);
            this.cbSaveUser.TabIndex = 9;
            this.cbSaveUser.Text = "Duy trì đăng nhập";
            this.cbSaveUser.UseVisualStyleBackColor = true;
            // 
            // pictureAppLogo
            // 
            this.pictureAppLogo.Image = global::TraCuuTiemChung.Properties.Resources.KTPMUD_Logo;
            this.pictureAppLogo.Location = new System.Drawing.Point(313, 66);
            this.pictureAppLogo.Name = "pictureAppLogo";
            this.pictureAppLogo.Size = new System.Drawing.Size(74, 78);
            this.pictureAppLogo.TabIndex = 5;
            this.pictureAppLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Vai trò đăng nhập";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Sinh viên",
            "Giảng viên",
            "Quản lý"});
            this.checkedListBox1.Location = new System.Drawing.Point(350, 359);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(175, 72);
            this.checkedListBox1.TabIndex = 11;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 513);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSaveUser);
            this.Controls.Add(this.labelAppName);
            this.Controls.Add(this.pictureAppLogo);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.labelUser);
            this.Name = "LoginForm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureAppLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.PictureBox pictureAppLogo;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.CheckBox cbSaveUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

