using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace peopleHUB_hrms
{
    public partial class MainForm_user : DevExpress.XtraEditors.XtraForm
    {

        public MainForm_user()
        {
            InitializeComponent();
        }

        string pos_name { get; set; }
        string emp_id { get; set; }
        string user_name { get; set; }
        string user_role { get; set; }
        string user_access { get; set; }
        string user_department { get; set; }
        public void useraccount(string name, string role, string access, string department, string empid, string pos)
        {
            user_name = name;
            user_role = role;
            user_access = access;
            user_department = department;
            emp_id = empid;
            pos_name = pos;
        }

        private void MainForm_user_Load(object sender, EventArgs e)
        {

            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            labelControl_empName.Text = user_name;
            labelControl_position.Text = pos_name;
            labelControl_dept.Text = user_department + " Department";

            LoadNotificationLable();
        }

        public void LoadNotificationLable()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable notifications = dbConn.Get_Employee_Notifications(Convert.ToInt32(emp_id));

            if (notifications.Rows.Count > 0)
            {
                labelControl_notif.Text = notifications.Rows.Count.ToString();
            }
            else
            {
                labelControl_notif.Text = "";
            }
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

        private void MainForm_user_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }
        private void btn_leave_Click(object sender, EventArgs e)
        {
            form_leaveApplication form = null;
            if (form == null)
            {
                form = new form_leaveApplication();
            }
            form_leaveApplication.employeeId = Convert.ToInt32(emp_id);
            form.ShowDialog();
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            form_Personalinfo.emp_id = Convert.ToInt32(emp_id);
            form_Personalinfo form = null;
            if (form == null)
            {
                form = new form_Personalinfo();
            }
            form.ShowDialog();
        }

        private void btn_notif_Click(object sender, EventArgs e)
        {
            LoadNotificationLable();
            form_notifations.employeeId = Convert.ToInt32(emp_id);
            form_notifations form = new form_notifations();
            form.ShowDialog();
        }

      

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            form_monthSelect monthSelectForm = new form_monthSelect();
            monthSelectForm.ShowDialog();

            DateTime selectedDate = form_monthSelect.SelectedDate;
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable tbl = dbConn.Fetch_Employee_Name_and_Rate_ByEmpId_v2(Convert.ToInt32(emp_id), selectedDate);

            XtraReport_payroll.name = tbl.Rows[0]["NAME"].ToString();
            XtraReport_payroll.rate = tbl.Rows[0]["Monthly Rate"].ToString();
            XtraReport_payroll.attendanceDeduc = tbl.Rows[0]["Attendance Deductions"].ToString();
            XtraReport_payroll.date = selectedDate.ToString();

            XtraForm_salaryReceipt form = new XtraForm_salaryReceipt();
            form.ShowDialog();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            form_Empattendance.empid = emp_id;
            form_Empattendance form = new form_Empattendance();
            form.ShowDialog();
        }
    }
}