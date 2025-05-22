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
    public partial class form_monthSelect : DevExpress.XtraEditors.XtraForm
    {
        public static DateTime SelectedDate { get; private set; }
        public form_monthSelect()
        {
            InitializeComponent();          
        }

        private void form_monthSelect_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;
        }

        private void form_monthSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            SelectedDate = new DateTime(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month, 1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectedDate = new DateTime(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month, 1);


            Close();
        }
    }
}