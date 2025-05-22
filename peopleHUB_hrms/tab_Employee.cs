using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace peopleHUB_hrms
{
    public partial class tab_Employee : XtraForm
    {
        public tab_Employee()
        {
            InitializeComponent();
        }

        public bool reload { get; set; }
        public void _reload(bool _reload)
        {
            reload = _reload;
            timerReload.Start();
        }

        private void tab_Employee_Load(object sender, EventArgs e)
        {
            Fetch_Employee();
        }      

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_AddEmployee form = null;
            if(form == null)
            { form = new form_AddEmployee(); }
            form.passAction("ADD");
            form.ShowDialog();
            Fetch_Employee();
        }

      public void Fetch_Employee()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable employeetbl = dbConn.Fetch_Employee();
            grid_employee.DataSource = employeetbl;
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int selectedIndex = gridView_employee.FocusedRowHandle;
            form_AddEmployee form = null;
           
            int  emp_id = Convert.ToInt32(gridView_employee.GetRowCellValue(selectedIndex, "ID"));
            form_AddEmployee.emp_ID = emp_id;

            if (form == null)
            {
                form = new form_AddEmployee();  
            }
            form.passAction("EDIT");
            form.ShowDialog();
            Fetch_Employee(); // Reload table
            gridView_employee.FocusedRowHandle = selectedIndex;               
        }

        private void timerReload_Tick(object sender, EventArgs e)
        {
            if(reload == true)
            {
                Fetch_Employee();
                timerReload.Stop();
            }
        }

        private void activeEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView_employee.Columns["STATUS"].Visible = true;
            gridView_employee.Columns["EDIT"].Visible = true;
           
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable employeetbl = dbConn.Fetch_Employee_ByStatus("ACTIVE");
            grid_employee.DataSource = employeetbl;
        }

        private void inactiveEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView_employee.Columns["STATUS"].Visible = false;
            gridView_employee.Columns["EDIT"].Visible = false;
            
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable employeetbl = dbConn.Fetch_Employee_ByStatus("INACTIVE");
            grid_employee.DataSource = employeetbl;
        }

        private void allEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView_employee.Columns["STATUS"].Visible = true;
            gridView_employee.Columns["EDIT"].Visible = true;
           
            Fetch_Employee();
        }

        private void assignedEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView_employee.Columns["STATUS"].Visible = false;
            gridView_employee.Columns["EDIT"].Visible = true;
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable employeetbl = dbConn.Fetch_Employee_Assigned(1);
            grid_employee.DataSource = employeetbl;
        }

        private void repBtnStatus_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int selectedRow = gridView_employee.FocusedRowHandle;
            int emp_id = Convert.ToInt32(gridView_employee.GetRowCellValue(selectedRow, "ID"));

            var result = XtraMessageBox.Show("Are you sure to archive this employee?",
                                     "Warning",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DbConnection_Invoker dbconn = new DbConnection_Invoker();
                dbconn.Set_Employee_Inactive(emp_id);

                Fetch_Employee(); 
            }
        }
    }
}