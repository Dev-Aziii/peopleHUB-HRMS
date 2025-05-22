using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace peopleHUB_hrms
{
    public partial class form_AssignEmployee : XtraForm
    {
        public form_AssignEmployee()
        {
            InitializeComponent();
        }

        int employeeID = 0;
        string employeeType = string.Empty;
        string employeePosition = string.Empty;
        string startDate = string.Empty;
        string endDate = string.Empty;
        string salaryGrade = string.Empty;
        int salaryStepID = 0;

        string deptId { get; set; }
        string deptName { get; set; }

        public void passDeptDetails(string _deptId, string _deptName)
        {
            deptId = _deptId;
            deptName = _deptName;
            LoadEmployeeType();
        }

        private void form_AssignEmployee_Load(object sender, EventArgs e)
        {
            cbx_step.Enabled = false;
            Text = deptName;
            LoadEmployee();
            LoadPosition();
            LoadEmployeeType();
        }

        private void LoadEmployee()
        {
            try
            {
                DbConnection_Invoker dbConn = new DbConnection_Invoker();
                DataTable emptable = dbConn.Fetch_Employee_Assignment();
                search_employee.Properties.DataSource = emptable;
                search_employee.Properties.DisplayMember = "NAME";
                search_employee.Properties.ValueMember = "ID";
                search_employee.Properties.NullText = "Select an Employee";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading Employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPosition()
        {
            try
            {
                DbConnection_Invoker dbConn = new DbConnection_Invoker();
                DataTable emptypetable = dbConn.Fetch_Position();

                
                foreach (DataRow row in emptypetable.Rows)
                {
                    cbx_position.Properties.Items.Add(row["Position Name"]);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading Positions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployeeType()
        {
            try
            {
                DbConnection_Invoker dbConn = new DbConnection_Invoker();
                DataTable emptypetable = dbConn.Fetch_EmployeeType();
                cbx_type.Properties.Items.Clear();
                foreach (DataRow row in emptypetable.Rows)
                {
                    cbx_type.Properties.Items.Add(row["NAME"]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading Employee Type: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbx_SG_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbx_SG.Text))
                {
                    cbx_step.Enabled = true;
                    DbConnection_Invoker dbConn = new DbConnection_Invoker();
                    DataTable emptable = dbConn.Fetch_SG_step(cbx_SG.Text);

                    cbx_step.Properties.DataSource = emptable;

                    cbx_step.Properties.DisplayMember = "STEP";
                    cbx_step.Properties.ValueMember = "ID";

                    cbx_step.Properties.NullText = "Select Salary Grade Step";
                }
                else
                {
                    cbx_step.Enabled = false;

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading Step: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbx_step_EditValueChanged(object sender, EventArgs e)
        {
            GridView view = cbx_step.Properties.View;
            int selectedIndex = view.FocusedRowHandle;
            string rate = view.GetRowCellValue(selectedIndex, "RATE").ToString();
            tbxRate.Text = Convert.ToDecimal(rate).ToString("#,##0.00");
            salaryStepID = Convert.ToInt32(view.GetRowCellValue(selectedIndex, "ID"));
        }

        private void search_employee_EditValueChanged(object sender, EventArgs e)
        {
            GridView view = search_employee.Properties.View;
            int selectedIndex = view.FocusedRowHandle;
            employeeID = Convert.ToInt32(view.GetRowCellValue(selectedIndex, "ID"));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cbx_type.Text) || string.IsNullOrEmpty(cbx_position.Text) ||
         
           string.IsNullOrEmpty(cbx_SG.Text) || string.IsNullOrEmpty(cbx_step.Text))
            {
                XtraMessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            employeeType = cbx_type.Text;
            employeePosition = cbx_position.Text;
            startDate = dateEdit_startDate.Text;
            endDate = dateEdit_endDate.Text;
            DbConnection_Invoker dbconn = new DbConnection_Invoker();
            dbconn.Insert_Employee_Designation(employeeID, employeeType, employeePosition, Convert.ToInt32(deptId), startDate, endDate, salaryStepID);
            tab_Dashboard mainForm = Application.OpenForms.OfType<tab_Dashboard>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.LoadEmployeeDataToChart();
                mainForm.loadCounts();
            }
            Close();
        }

        private void btnAddpos_Click(object sender, EventArgs e)
        {
            form_AddPosition form = null;
            if (form == null)
            {
                form = new form_AddPosition();
            }
            form.ShowDialog();
        }
    }
}
