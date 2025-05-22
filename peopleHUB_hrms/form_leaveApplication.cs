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
    public partial class form_leaveApplication : DevExpress.XtraEditors.XtraForm
    {

        public static int employeeId;
        public form_leaveApplication()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string leaveType = comboBoxEdit_leaveType.Text;
            DateTime startDate = dateEdit_startDate.DateTime;
            DateTime endDate = dateEdit_endDate.DateTime;
            string reason = richTextBox_Reason.Text;

            if (leaveType.Equals(string.Empty))
            {
                XtraMessageBox.Show("Leave type cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startDate.Equals(string.Empty))
            {
                XtraMessageBox.Show("Start date cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (endDate.Equals(string.Empty))
            {
                XtraMessageBox.Show("End date cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (reason.Equals(string.Empty))
            {
                XtraMessageBox.Show("Reason cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startDate < DateTime.Now)
            {
                XtraMessageBox.Show("Start date cannot be in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startDate > endDate)
            {
                XtraMessageBox.Show("Start date cannot be after the end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dateCreated = DateTime.Now;

            DbConnection_Invoker dbconn = new DbConnection_Invoker();
            dbconn.Generate_Request(employeeId, startDate, endDate, leaveType, reason);
            LoadRequestTable();
            Close();
        }

        private void LoadRequestTable()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable dtEmp = dbConn.Fetch_Request_Individual(employeeId);
            grid_pendingRequest.DataSource = dtEmp;
        }

        private void form_leaveApplication_Load(object sender, EventArgs e)
        {
            LoadRequestTable();
        }
    }
}