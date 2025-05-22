using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace peopleHUB_hrms
{
    public partial class tab_Request : XtraForm
    {
        public static string name;
        public tab_Request()
        {
            InitializeComponent();
        }

        private void tab_Request_Load(object sender, EventArgs e)
        {
            LoadRequestTable_pending();
        }
       
        private void btn_accepted_Click(object sender, EventArgs e)
        {
            LoadRequestTable_accepted();
            gridViewPendingRequest.Columns["REJECT"].Visible = false;
            gridViewPendingRequest.Columns["ACCEPT"].Visible = false;
            if (gridViewPendingRequest.RowCount > 0)
            {
                gridViewPendingRequest.FocusedRowHandle = 0;
            }
        }

        private void btn_pending_Click(object sender, EventArgs e)
        {
            LoadRequestTable_pending();
            gridViewPendingRequest.Columns["REJECT"].Visible = true;
            gridViewPendingRequest.Columns["ACCEPT"].Visible = true;
            if (gridViewPendingRequest.RowCount > 0)
            {
                gridViewPendingRequest.FocusedRowHandle = 0;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadRequestTable_rejected();
            gridViewPendingRequest.Columns["REJECT"].Visible = false;
            gridViewPendingRequest.Columns["ACCEPT"].Visible = false;
            if (gridViewPendingRequest.RowCount > 0)
            {
                gridViewPendingRequest.FocusedRowHandle = 0;
            }
        }

        private void LoadRequestTable_accepted()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable dtEmp = dbConn.Fetch_Request_Accepted();
            grid_pendingRequest.DataSource = dtEmp;
        }
        private void LoadRequestTable_pending()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable dtEmp = dbConn.Fetch_Request_Pending();
            grid_pendingRequest.DataSource = dtEmp;
        }
        private void LoadRequestTable_rejected()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable dtEmp = dbConn.Fetch_Request_Rejected();
            grid_pendingRequest.DataSource = dtEmp;
        }

        private void repBtnAccept_Click(object sender, EventArgs e)
        {
            int selectedIndex = gridViewPendingRequest.FocusedRowHandle;
            int leavereq_id = Convert.ToInt32(gridViewPendingRequest.GetRowCellValue(selectedIndex, "ID"));
            string name = gridViewPendingRequest.GetRowCellValue(selectedIndex, "Employee Name").ToString();

            form_comment commentForm = new form_comment();
            DialogResult result = commentForm.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(commentForm.Comment))
            {
                DbConnection_Invoker dbConn = new DbConnection_Invoker();
                dbConn.Accept_Request(leavereq_id, name, commentForm.Comment);
                LoadRequestTable_pending();
                tab_Dashboard mainForm = Application.OpenForms.OfType<tab_Dashboard>().FirstOrDefault();
                if (mainForm != null)
                {
                    mainForm.loadCounts();
                }
            }
            else
            {
                XtraMessageBox.Show("Action Terminated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void repBtnReject_Click(object sender, EventArgs e)
        {
            int selectedIndex = gridViewPendingRequest.FocusedRowHandle;
            int leavereq_id = Convert.ToInt32(gridViewPendingRequest.GetRowCellValue(selectedIndex, "ID"));
            string name = gridViewPendingRequest.GetRowCellValue(selectedIndex, "Employee Name").ToString();

            form_comment commentForm = new form_comment();
            DialogResult result = commentForm.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(commentForm.Comment))
            {
                DbConnection_Invoker dbConn = new DbConnection_Invoker();
                dbConn.Reject_Request(leavereq_id, name, commentForm.Comment);
                LoadRequestTable_pending();
                tab_Dashboard mainForm = Application.OpenForms.OfType<tab_Dashboard>().FirstOrDefault();
                if (mainForm != null)
                {
                    mainForm.loadCounts();
                }
            }
            else
            {
                XtraMessageBox.Show("Action Terminated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}