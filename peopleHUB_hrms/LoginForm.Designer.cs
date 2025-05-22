namespace peopleHUB_hrms
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
            this.components = new System.ComponentModel.Container();
            this.btn_reset = new System.Windows.Forms.Panel();
            this.txt_reset = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btn_login = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_pass = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_username = new DevExpress.XtraEditors.TextEdit();
            this.btnExit = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_reset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_reset
            // 
            this.btn_reset.Controls.Add(this.txt_reset);
            this.btn_reset.Location = new System.Drawing.Point(755, 602);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(329, 47);
            this.btn_reset.TabIndex = 29;
            this.btn_reset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_reset_MouseClick);
            this.btn_reset.MouseEnter += new System.EventHandler(this.btn_reset_MouseEnter);
            this.btn_reset.MouseLeave += new System.EventHandler(this.btn_reset_MouseLeave);
            // 
            // txt_reset
            // 
            this.txt_reset.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.txt_reset.Location = new System.Drawing.Point(142, 13);
            this.txt_reset.Name = "txt_reset";
            this.txt_reset.Size = new System.Drawing.Size(42, 23);
            this.txt_reset.TabIndex = 0;
            this.txt_reset.Text = "Clear";
            this.txt_reset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_reset_MouseClick);
            this.txt_reset.MouseEnter += new System.EventHandler(this.btn_reset_MouseEnter);
            this.txt_reset.MouseLeave += new System.EventHandler(this.btn_reset_MouseLeave);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(789, 221);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(235, 45);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "USER LOGIN";
            // 
            // btn_login
            // 
            this.btn_login.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_login.Appearance.BackColor2 = System.Drawing.Color.ForestGreen;
            this.btn_login.Appearance.BorderColor = System.Drawing.Color.Green;
            this.btn_login.Appearance.Options.UseBackColor = true;
            this.btn_login.Appearance.Options.UseBorderColor = true;
            this.btn_login.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_login.Location = new System.Drawing.Point(755, 520);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(329, 76);
            this.btn_login.TabIndex = 27;
            this.btn_login.Text = "Login";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // textEdit_pass
            // 
            this.textEdit_pass.Location = new System.Drawing.Point(755, 429);
            this.textEdit_pass.Name = "textEdit_pass";
            this.textEdit_pass.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit_pass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.textEdit_pass.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_pass.Properties.Appearance.Options.UseFont = true;
            this.textEdit_pass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.textEdit_pass.Properties.PasswordChar = '*';
            this.textEdit_pass.Size = new System.Drawing.Size(329, 44);
            this.textEdit_pass.TabIndex = 26;
            // 
            // textEdit_username
            // 
            this.textEdit_username.EditValue = "";
            this.textEdit_username.Location = new System.Drawing.Point(755, 349);
            this.textEdit_username.Name = "textEdit_username";
            this.textEdit_username.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit_username.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.textEdit_username.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_username.Properties.Appearance.Options.UseFont = true;
            this.textEdit_username.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.textEdit_username.Size = new System.Drawing.Size(329, 44);
            this.textEdit_username.TabIndex = 25;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.btnExit.Location = new System.Drawing.Point(1093, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 34);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "X";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this.textEdit_username;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 10;
            this.bunifuElipse3.TargetControl = this.textEdit_pass;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(761, 324);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(100, 24);
            this.bunifuCustomLabel1.TabIndex = 31;
            this.bunifuCustomLabel1.Text = "Username";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(761, 403);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(94, 24);
            this.bunifuCustomLabel2.TabIndex = 32;
            this.bunifuCustomLabel2.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::peopleHUB_hrms.Properties.Resources.logindes;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(847, 791);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 791);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.textEdit_pass);
            this.Controls.Add(this.textEdit_username);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7";
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.btn_reset.ResumeLayout(false);
            this.btn_reset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel btn_reset;
        private DevExpress.XtraEditors.LabelControl txt_reset;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_login;
        private DevExpress.XtraEditors.TextEdit textEdit_pass;
        private DevExpress.XtraEditors.TextEdit textEdit_username;
        private DevExpress.XtraEditors.LabelControl btnExit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
    }
}

