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
    public partial class tab_Atttendance : DevExpress.XtraEditors.XtraForm
    {
        public tab_Atttendance()
        {
            InitializeComponent();
        }

        private void tab_Atttendance_Load(object sender, EventArgs e)
        {
            Fetch_Attendance();
        }

        public void Fetch_Attendance()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable employeetbl = dbConn.Fetch_Attendance();
            grid_attendance.DataSource = employeetbl;
        }
    }
}