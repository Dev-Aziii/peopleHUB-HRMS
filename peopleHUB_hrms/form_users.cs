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
    public partial class form_users : DevExpress.XtraEditors.XtraForm
    {
        public form_users()
        {
            InitializeComponent();
        }

        private void form_users_Load(object sender, EventArgs e)
        {
            Fetch_All_User();
        }

        public void Fetch_All_User()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable employeetbl = dbConn.Fetch_All_User();
            grid_user.DataSource = employeetbl;
        }
    }
}