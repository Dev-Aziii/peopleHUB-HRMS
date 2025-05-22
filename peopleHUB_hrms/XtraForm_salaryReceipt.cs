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
using DevExpress.XtraReports.UI;

namespace peopleHUB_hrms
{
    public partial class XtraForm_salaryReceipt : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm_salaryReceipt()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            XtraReport_payroll report = new XtraReport_payroll();
            report.CreateDocument();
            report.PrintDialog();
        }
    }
}