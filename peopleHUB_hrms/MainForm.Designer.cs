namespace peopleHUB_hrms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new DevExpress.XtraEditors.SimpleButton();
            this.btnEmployee = new DevExpress.XtraEditors.SimpleButton();
            this.btnDepartments = new DevExpress.XtraEditors.SimpleButton();
            this.btnRequest = new DevExpress.XtraEditors.SimpleButton();
            this.btnPosition = new DevExpress.XtraEditors.SimpleButton();
            this.UserBtn = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl_pos = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_dept = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalInfoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlDateTime = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAttendance = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControlMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(331, 97);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1437, 1212);
            this.panelMain.TabIndex = 7;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlMain.Location = new System.Drawing.Point(3, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1431, 1206);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 0;
            // 
            // panelNav
            // 
            this.panelNav.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.panelNav.Appearance.Options.UseBackColor = true;
            this.panelNav.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelNav.Controls.Add(this.flowLayoutPanel1);
            this.panelNav.Controls.Add(this.panelControl1);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNav.Location = new System.Drawing.Point(0, 97);
            this.panelNav.Margin = new System.Windows.Forms.Padding(0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(331, 1212);
            this.panelNav.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.flowLayoutPanel1.Controls.Add(this.btnDashboard);
            this.flowLayoutPanel1.Controls.Add(this.btnEmployee);
            this.flowLayoutPanel1.Controls.Add(this.btnDepartments);
            this.flowLayoutPanel1.Controls.Add(this.btnRequest);
            this.flowLayoutPanel1.Controls.Add(this.btnAttendance);
            this.flowLayoutPanel1.Controls.Add(this.UserBtn);
            this.flowLayoutPanel1.Controls.Add(this.btnPosition);
            this.flowLayoutPanel1.Controls.Add(this.btnBackup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 280);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 784);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDashboard.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.btnDashboard.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnDashboard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnDashboard.Appearance.Options.UseBackColor = true;
            this.btnDashboard.Appearance.Options.UseBorderColor = true;
            this.btnDashboard.Appearance.Options.UseFont = true;
            this.btnDashboard.Appearance.Options.UseForeColor = true;
            this.btnDashboard.Appearance.Options.UseTextOptions = true;
            this.btnDashboard.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnDashboard.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnDashboard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDashboard.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDashboard.Location = new System.Drawing.Point(5, 10);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(326, 90);
            this.btnDashboard.TabIndex = 5;
            this.btnDashboard.Text = "Home/Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEmployee.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.btnEmployee.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnEmployee.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnEmployee.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnEmployee.Appearance.Options.UseBackColor = true;
            this.btnEmployee.Appearance.Options.UseBorderColor = true;
            this.btnEmployee.Appearance.Options.UseFont = true;
            this.btnEmployee.Appearance.Options.UseForeColor = true;
            this.btnEmployee.Appearance.Options.UseTextOptions = true;
            this.btnEmployee.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnEmployee.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.Image")));
            this.btnEmployee.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnEmployee.Location = new System.Drawing.Point(5, 100);
            this.btnEmployee.Margin = new System.Windows.Forms.Padding(0);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(326, 90);
            this.btnEmployee.TabIndex = 9;
            this.btnEmployee.Text = "Employee Pool";
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click_1);
            // 
            // btnDepartments
            // 
            this.btnDepartments.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDepartments.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.btnDepartments.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnDepartments.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartments.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDepartments.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnDepartments.Appearance.Options.UseBackColor = true;
            this.btnDepartments.Appearance.Options.UseBorderColor = true;
            this.btnDepartments.Appearance.Options.UseFont = true;
            this.btnDepartments.Appearance.Options.UseForeColor = true;
            this.btnDepartments.Appearance.Options.UseTextOptions = true;
            this.btnDepartments.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnDepartments.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnDepartments.Image = global::peopleHUB_hrms.Properties.Resources.departments2_32;
            this.btnDepartments.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDepartments.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDepartments.Location = new System.Drawing.Point(5, 190);
            this.btnDepartments.Margin = new System.Windows.Forms.Padding(0);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(326, 90);
            this.btnDepartments.TabIndex = 10;
            this.btnDepartments.Text = "Departments";
            this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRequest.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.btnRequest.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnRequest.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequest.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRequest.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRequest.Appearance.Options.UseBackColor = true;
            this.btnRequest.Appearance.Options.UseBorderColor = true;
            this.btnRequest.Appearance.Options.UseFont = true;
            this.btnRequest.Appearance.Options.UseForeColor = true;
            this.btnRequest.Appearance.Options.UseTextOptions = true;
            this.btnRequest.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnRequest.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRequest.Image = global::peopleHUB_hrms.Properties.Resources.request2_32;
            this.btnRequest.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRequest.Location = new System.Drawing.Point(5, 280);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(0);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(326, 90);
            this.btnRequest.TabIndex = 11;
            this.btnRequest.Text = "Request";
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnPosition
            // 
            this.btnPosition.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPosition.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.btnPosition.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnPosition.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosition.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPosition.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnPosition.Appearance.Options.UseBackColor = true;
            this.btnPosition.Appearance.Options.UseBorderColor = true;
            this.btnPosition.Appearance.Options.UseFont = true;
            this.btnPosition.Appearance.Options.UseForeColor = true;
            this.btnPosition.Appearance.Options.UseTextOptions = true;
            this.btnPosition.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnPosition.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPosition.Image = global::peopleHUB_hrms.Properties.Resources.position_32;
            this.btnPosition.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPosition.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPosition.Location = new System.Drawing.Point(5, 550);
            this.btnPosition.Margin = new System.Windows.Forms.Padding(0);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(326, 90);
            this.btnPosition.TabIndex = 15;
            this.btnPosition.Text = "Position";
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // UserBtn
            // 
            this.UserBtn.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.UserBtn.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.UserBtn.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.UserBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserBtn.Appearance.ForeColor = System.Drawing.Color.White;
            this.UserBtn.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.UserBtn.Appearance.Options.UseBackColor = true;
            this.UserBtn.Appearance.Options.UseBorderColor = true;
            this.UserBtn.Appearance.Options.UseFont = true;
            this.UserBtn.Appearance.Options.UseForeColor = true;
            this.UserBtn.Appearance.Options.UseTextOptions = true;
            this.UserBtn.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.UserBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.UserBtn.Image = ((System.Drawing.Image)(resources.GetObject("UserBtn.Image")));
            this.UserBtn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.UserBtn.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.UserBtn.Location = new System.Drawing.Point(5, 460);
            this.UserBtn.Margin = new System.Windows.Forms.Padding(0);
            this.UserBtn.Name = "UserBtn";
            this.UserBtn.Size = new System.Drawing.Size(326, 90);
            this.UserBtn.TabIndex = 16;
            this.UserBtn.Text = "Users";
            this.UserBtn.Click += new System.EventHandler(this.UserBtn_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBackup.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.btnBackup.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnBackup.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBackup.Appearance.Options.UseBackColor = true;
            this.btnBackup.Appearance.Options.UseBorderColor = true;
            this.btnBackup.Appearance.Options.UseFont = true;
            this.btnBackup.Appearance.Options.UseForeColor = true;
            this.btnBackup.Appearance.Options.UseTextOptions = true;
            this.btnBackup.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnBackup.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBackup.Image = global::peopleHUB_hrms.Properties.Resources.backup_32;
            this.btnBackup.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnBackup.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnBackup.Location = new System.Drawing.Point(5, 640);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(0);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(326, 90);
            this.btnBackup.TabIndex = 14;
            this.btnBackup.Text = "Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.panelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl_pos);
            this.panelControl1.Controls.Add(this.labelControl_dept);
            this.panelControl1.Controls.Add(this.labelControl_name);
            this.panelControl1.Controls.Add(this.pictureBox2);
            this.panelControl1.Controls.Add(this.menuStrip1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(331, 280);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl_pos
            // 
            this.labelControl_pos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl_pos.Appearance.Font = new System.Drawing.Font("Tahoma", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_pos.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_pos.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_pos.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_pos.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_pos.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl_pos.Location = new System.Drawing.Point(12, 204);
            this.labelControl_pos.Name = "labelControl_pos";
            this.labelControl_pos.Size = new System.Drawing.Size(313, 32);
            this.labelControl_pos.TabIndex = 5;
            this.labelControl_pos.Text = "ADMIN";
            // 
            // labelControl_dept
            // 
            this.labelControl_dept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl_dept.Appearance.Font = new System.Drawing.Font("Tahoma", 8.142858F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_dept.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_dept.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_dept.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_dept.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_dept.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl_dept.Location = new System.Drawing.Point(12, 242);
            this.labelControl_dept.Name = "labelControl_dept";
            this.labelControl_dept.Size = new System.Drawing.Size(313, 32);
            this.labelControl_dept.TabIndex = 4;
            this.labelControl_dept.Text = "ADMIN";
            // 
            // labelControl_name
            // 
            this.labelControl_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl_name.Appearance.Font = new System.Drawing.Font("Tahoma", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_name.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl_name.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_name.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_name.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl_name.Location = new System.Drawing.Point(12, 170);
            this.labelControl_name.Name = "labelControl_name";
            this.labelControl_name.Size = new System.Drawing.Size(313, 32);
            this.labelControl_name.TabIndex = 2;
            this.labelControl_name.Text = "ADMIN";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(115, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 105);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(331, 38);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.personalInfoTool});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(99, 34);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(225, 34);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // personalInfoTool
            // 
            this.personalInfoTool.Name = "personalInfoTool";
            this.personalInfoTool.Size = new System.Drawing.Size(225, 34);
            this.personalInfoTool.Text = "Personal Info";
            this.personalInfoTool.Click += new System.EventHandler(this.personalInfoTool_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.panelControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 1309);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1768, 61);
            this.panelControl2.TabIndex = 5;
            // 
            // panelTop
            // 
            this.panelTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.panelTop.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.panelTop.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.panelTop.Appearance.Options.UseBackColor = true;
            this.panelTop.Appearance.Options.UseBorderColor = true;
            this.panelTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTop.Controls.Add(this.pictureEdit1);
            this.panelTop.Controls.Add(this.labelControl1);
            this.panelTop.Controls.Add(this.labelControlDateTime);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1768, 97);
            this.panelTop.TabIndex = 4;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(70, 68);
            this.pictureEdit1.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Location = new System.Drawing.Point(96, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(310, 34);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "PeopleHUB - HR SYSTEM";
            // 
            // labelControlDateTime
            // 
            this.labelControlDateTime.Appearance.Font = new System.Drawing.Font("Tahoma", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlDateTime.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControlDateTime.Location = new System.Drawing.Point(96, 52);
            this.labelControlDateTime.Name = "labelControlDateTime";
            this.labelControlDateTime.Size = new System.Drawing.Size(56, 28);
            this.labelControlDateTime.TabIndex = 1;
            this.labelControlDateTime.Text = "DATE";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timerDate_Tick);
            // 
            // btnAttendance
            // 
            this.btnAttendance.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAttendance.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.btnAttendance.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnAttendance.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAttendance.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAttendance.Appearance.Options.UseBackColor = true;
            this.btnAttendance.Appearance.Options.UseBorderColor = true;
            this.btnAttendance.Appearance.Options.UseFont = true;
            this.btnAttendance.Appearance.Options.UseForeColor = true;
            this.btnAttendance.Appearance.Options.UseTextOptions = true;
            this.btnAttendance.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnAttendance.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAttendance.Image = ((System.Drawing.Image)(resources.GetObject("btnAttendance.Image")));
            this.btnAttendance.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAttendance.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAttendance.Location = new System.Drawing.Point(5, 370);
            this.btnAttendance.Margin = new System.Windows.Forms.Padding(0);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(326, 90);
            this.btnAttendance.TabIndex = 17;
            this.btnAttendance.Text = "Attendance";
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(202)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1768, 1370);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnDashboard;
        private DevExpress.XtraEditors.SimpleButton btnEmployee;
        private DevExpress.XtraEditors.SimpleButton btnDepartments;
        private DevExpress.XtraEditors.SimpleButton btnRequest;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl_name;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControlDateTime;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl labelControl_dept;
        private DevExpress.XtraEditors.LabelControl labelControl_pos;
        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private DevExpress.XtraEditors.SimpleButton btnPosition;
        private DevExpress.XtraEditors.SimpleButton UserBtn;
        private System.Windows.Forms.ToolStripMenuItem personalInfoTool;
        private DevExpress.XtraEditors.SimpleButton btnAttendance;
    }
}