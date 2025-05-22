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
    public partial class form_Empattendance : DevExpress.XtraEditors.XtraForm
    {
        public static string empid = string.Empty;
        public form_Empattendance()
        {
            InitializeComponent();
        }

        private void form_Empattendance_Load(object sender, EventArgs e)
        {
            Fetch_Attendance();
        }
        public void Fetch_Attendance()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable employeetbl = dbConn.Fetch_Attendance_By_EmpID(Convert.ToInt32(empid));
            grid_attendance.DataSource = employeetbl;
        }
    }
}