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
    public partial class form_notifations : DevExpress.XtraEditors.XtraForm
    {
        public static int employeeId;
        public form_notifations()
        {
            InitializeComponent();
        }

        private void form_notifations_Load(object sender, EventArgs e)
        {
            LoadNotificationTable();
        }

        private void LoadNotificationTable()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable dtEmp = dbConn.Get_Employee_Notifications(employeeId);
            grid_notif.DataSource = dtEmp;
        }

        private void repbtnRead_Click(object sender, EventArgs e)
        {
            MainForm_user mainForm = Application.OpenForms.OfType<MainForm_user>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.LoadNotificationLable();
            }

            int selectedIndex = gridViewNotif.FocusedRowHandle;       
            int notif_id = Convert.ToInt32(gridViewNotif.GetRowCellValue(selectedIndex, "ID"));

            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            dbConn.Update_Notification_Status(notif_id);
           
            LoadNotificationTable();
        }

        private void unreadStrip_Click(object sender, EventArgs e)
        {
            gridViewNotif.Columns["READ"].Visible = true;
            LoadNotificationTable();
        }

        private void readStrip_Click(object sender, EventArgs e)
        {
            LoadNotificationTable_read();
            gridViewNotif.Columns["READ"].Visible = false;
        }
        private void LoadNotificationTable_read()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable dtEmp = dbConn.Get_Employee_Notifications_read(employeeId);
            grid_notif.DataSource = dtEmp;
        }

        private void form_notifations_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm_user mainForm = Application.OpenForms.OfType<MainForm_user>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.LoadNotificationLable();
            }

        }
        private void form_notifations_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm_user mainForm = Application.OpenForms.OfType<MainForm_user>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.LoadNotificationLable();
            }
        }
    }
}