using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
namespace peopleHUB_hrms
{
    public partial class MainForm : XtraForm
    {
        private SimpleButton activeButton;
        public MainForm()
        {
            InitializeComponent();
        }

        string emp_id { get; set; }
        string pos_name { get; set; }
        string user_name { get; set; }
        string user_role { get; set; }
        string user_access { get; set; }
        string user_department { get; set; }
        public void useraccount(string name, string role, string access, string department, string pos, string emp)
        {
            user_name = name;
            user_role = role;
            user_access = access;
            user_department = department;
            pos_name = pos;
            emp_id = emp;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            labelControl_name.Text = user_name;
            labelControl_pos.Text = pos_name;
            labelControl_dept.Text = user_department + " Department";
            labelControlDateTime.Text = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy | hh:mm:ss tt");

            Rectangle workingArea = Screen.GetWorkingArea(this);
            MaximizedBounds = new Rectangle(workingArea.Left, workingArea.Top, workingArea.Width - 1, workingArea.Height - 0);
            WindowState = FormWindowState.Maximized;

            SetActiveButton(btnDashboard);
            try
            {
                Thread thread = new Thread(() =>
                {
                    Action action = AddTabpage_Dashboard;
                    BeginInvoke(action);
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (user_access.Contains("Manager"))
            {
                btnBackup.Visible = false;
                btnPosition.Visible = false;
                UserBtn.Visible = false;
            }
            else
            {
                personalInfoTool.Visible = false;
            }
        }

        private void SetActiveButton(SimpleButton button)
        {
            if (activeButton != null)
            {
                activeButton.Appearance.BackColor = Color.RoyalBlue;
                activeButton.Appearance.BackColor2 = Color.FromArgb(26, 45, 66);
            }

            activeButton = button;
            activeButton.Appearance.BackColor = Color.DarkCyan;
            activeButton.Appearance.BackColor2 = Color.DarkCyan;
        }

        private void btnEmployee_Click_1(object sender, EventArgs e)
        {
            SetActiveButton((SimpleButton)sender);
            try
            {
                Thread thread = new Thread(() =>
                {
                    Action action = AddTabpage_Employee;
                    BeginInvoke(action);
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region AddTabpage_Employee
        private void AddTabpage_Employee()
        {
            var form = new tab_Employee();            
            var Index = FindTabIndexByName(tabControlMain, "Employee"); 

            if (Index >= 0)
            {
                tabControlMain.TabIndex = Index;
                tabControlMain.SelectTab(Index);
               
            }
            else
            {
                var tabpage = new TabPage("Employee") { BorderStyle = BorderStyle.Fixed3D };  
                tabControlMain.TabPages.Add(tabpage);
                form.TopLevel = false;
                form.Parent = tabpage;
                form.Show();
                form.Dock = DockStyle.Fill;
                tabControlMain.SelectTab(tabControlMain.TabPages.Count - 1);
            }
        }
        #endregion

        private int FindTabIndexByName(TabControl tabControl, string tabName)
        {
            for (var i = 0; i < tabControl.TabCount; i++)
            {
                if (tabControl.TabPages[i].Text.Trim() == tabName.Trim())
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveButton((SimpleButton)sender);
            try
            {
                Thread thread = new Thread(() =>
                {
                    Action action = AddTabpage_Dashboard;
                    BeginInvoke(action);
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        #region AddTabpage_XtraForm_Dashboard
        private void AddTabpage_Dashboard()
        {
            var form = new tab_Dashboard();
           
            var Index = FindTabIndexByName(tabControlMain, "Dashboard"); 

            if (Index >= 0)
            {
                tabControlMain.TabIndex = Index; 
                tabControlMain.SelectTab(Index);
            }
            else
            {
                var tabpage = new TabPage("Dashboard") { BorderStyle = BorderStyle.Fixed3D }; 
                tabControlMain.TabPages.Add(tabpage);
                form.TopLevel = false; 
                form.Parent = tabpage;
                form.Show(); 
                form.Dock = DockStyle.Fill; 
                tabControlMain.SelectTab(tabControlMain.TabPages.Count - 1); 
            }
        }

        #endregion

        private void timerDate_Tick(object sender, EventArgs e)
        {
            labelControlDateTime.Text = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy | hh:mm:ss tt");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show(
            "Are you sure you want to log out?",
            "Confirm Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm form = new LoginForm();
                form.Show();
                this.Hide();
            }
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            SetActiveButton((SimpleButton)sender);
            try
            {
                Thread thread = new Thread(() =>
                {
                    Action action = AddTabpage_Request;
                    BeginInvoke(action);
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region AddTabpage_XtraForm_Request
        private void AddTabpage_Request()
        {
            tab_Request.name = user_name;
            var form = new tab_Request();
            var Index = FindTabIndexByName(tabControlMain, "Request");

            if (Index >= 0)
            {
                tabControlMain.TabIndex = Index;
                tabControlMain.SelectTab(Index);
            }
            else
            {
                var tabpage = new TabPage("Request") { BorderStyle = BorderStyle.Fixed3D }; 
                tabControlMain.TabPages.Add(tabpage);
                form.TopLevel = false; 
                form.Parent = tabpage;
                form.Show(); 
                form.Dock = DockStyle.Fill;
                tabControlMain.SelectTab(tabControlMain.TabPages.Count - 1); 
            }
        }

        #endregion    

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            SetActiveButton((SimpleButton)sender);
            
            try
            {
                Thread thread = new Thread(() =>
                {
                    Action action = AddTabpage_Departments;
                    BeginInvoke(action);
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region AddTabpage_XtraForm_Request
        private void AddTabpage_Departments()
        {
            form_Departments.access = user_access;

            var form = new form_Departments();
            var Index = FindTabIndexByName(tabControlMain, "Departments");            
            if (Index >= 0)
            {
                tabControlMain.TabIndex = Index;
                tabControlMain.SelectTab(Index);
            }
            else
            {
                var tabpage = new TabPage("Departments") { BorderStyle = BorderStyle.Fixed3D }; 
                tabControlMain.TabPages.Add(tabpage);
                form.TopLevel = false; 
                form.Parent = tabpage;
                form.Show(); 
                form.Dock = DockStyle.Fill;
                tabControlMain.SelectTab(tabControlMain.TabPages.Count - 1); 
            }
        }



        #endregion

        private void btnPosition_Click(object sender, EventArgs e)
        {
            SetActiveButton((SimpleButton)sender);
            form_AddPosition form = null;
            if(form == null)
            {
                form = new form_AddPosition();
            }
            form.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SetActiveButton((SimpleButton)sender);
            tab_Backup form = new tab_Backup();
            form.ShowDialog();
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            SetActiveButton((SimpleButton)sender);
            form_users form = null;
            if(form == null)
            {
                form = new form_users();
            }
            form.ShowDialog();
        }

        private void personalInfoTool_Click(object sender, EventArgs e)
        {
            form_Personalinfo.emp_id = Convert.ToInt32(emp_id);
            form_Personalinfo form = null;
            if (form == null)
            {
                form = new form_Personalinfo();
            }
            form.ShowDialog();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            SetActiveButton((SimpleButton)sender);
            try
            {
                Thread thread = new Thread(() =>
                {
                    Action action = AddTabpage_Attendance;
                    BeginInvoke(action);
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region AddTabpage_XtraForm_Attendance
        private void AddTabpage_Attendance()
        {
            tab_Request.name = user_name;
            var form = new tab_Atttendance();
            var Index = FindTabIndexByName(tabControlMain, "Attendance");

            if (Index >= 0)
            {
                tabControlMain.TabIndex = Index;
                tabControlMain.SelectTab(Index);
            }
            else
            {
                var tabpage = new TabPage("Attendance") { BorderStyle = BorderStyle.Fixed3D };
                tabControlMain.TabPages.Add(tabpage);
                form.TopLevel = false;
                form.Parent = tabpage;
                form.Show();
                form.Dock = DockStyle.Fill;
                tabControlMain.SelectTab(tabControlMain.TabPages.Count - 1);
            }
        }

        #endregion    
    }
}