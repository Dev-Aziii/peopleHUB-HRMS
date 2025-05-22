using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace peopleHUB_hrms
{
    public partial class XtraFormAttendance : XtraForm
    {
        public XtraFormAttendance()
        {
            InitializeComponent();
        }

        private void Mytimer_Tick(object sender, EventArgs e)
        {
            MyDate.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy || hh:mm:ss tt").ToUpper();
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            DateTime date = DateTime.Now;
            int hr = date.Hour;
            string ampm = date.ToString("tt").ToUpper();
            if(e.KeyCode.Equals(Keys.Enter))
            {
                DbConnection_Invoker dbconn = new DbConnection_Invoker();
                dbconn.Save_Attendance(Convert.ToInt32(textEditEmpID.Text), ampm, hr);
            }
        }

        private void XtraFormAttendance_Load(object sender, EventArgs e)
        {
            MyDate.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy || hh:mm:ss tt").ToUpper();
        }
    }
}