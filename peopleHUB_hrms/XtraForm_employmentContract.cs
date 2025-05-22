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
    public partial class XtraForm_employmentContract : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm_employmentContract()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            XtraReport_Contract report = new XtraReport_Contract();
            report.CreateDocument();
            report.PrintDialog();
        }
    }
}