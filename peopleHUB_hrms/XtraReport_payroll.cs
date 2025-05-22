using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace peopleHUB_hrms
{
    public partial class XtraReport_payroll : DevExpress.XtraReports.UI.XtraReport
    {
        public static string name = string.Empty;
        public static string rate = string.Empty;
        public static string date = string.Empty;
        public static string attendanceDeduc = string.Empty;
        public XtraReport_payroll()
        {
            InitializeComponent();
        }

        private void xrPanel2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            labelDate.Text = Convert.ToDateTime(date).ToString("MMMM, yyyy");
            xrLabel1.Text = "Name: "+ name;
            grossIncome.Text = "₱ "+ Convert.ToDecimal(rate).ToString("#,##0.00");

            const decimal phic = 900;
           // const decimal philhealth = 300;
            const decimal sss = 1200;
            decimal AttendanceDeductions = Convert.ToDecimal(attendanceDeduc);
            decimal totalDeduc = phic  + sss + AttendanceDeductions;

            cell_SSS.Text = "-" + sss.ToString("#,##0.00");
            cell_PHIC.Text = "-" + phic.ToString("#,##0.00");
            cellATT.Text = "-" + AttendanceDeductions.ToString("#,##0.00");
            cellTotal.Text = totalDeduc.ToString("#,##0.00");

            decimal netincome = Convert.ToDecimal(rate) - totalDeduc;
            netIncome.Text = netincome.ToString("#,##0.00");
        }
    }
}
