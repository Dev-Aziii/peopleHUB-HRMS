using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace peopleHUB_hrms
{
    public partial class form_Departments : XtraForm
    {
        public static string date = string.Empty;
        public form_Departments()
        {
            InitializeComponent();

        }

        public static string access = string.Empty;
        private void form_Departments_Load(object sender, EventArgs e)
        {
            gridViewDept.FocusedRowHandle = 0;
            Fetch_Departments();
            Fetch_Employee_ByDept();
        }

        public void Fetch_Departments()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable depttbl = dbConn.Fetch_Departments();
            grid_dept.DataSource = depttbl;
        }

        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = gridViewDept.FocusedRowHandle;
            string deptName = gridViewDept.GetRowCellValue(selectedRow, "Department").ToString();
            string deptID = gridViewDept.GetRowCellValue(selectedRow, "ID").ToString();
            form_AssignEmployee form = null;
            if (form == null)
            {
                form = new form_AssignEmployee();
                form.passDeptDetails(deptID, deptName);
            }
            form.ShowDialog();
            Fetch_Employee_ByDept();
        }

        private void gridViewDept_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Fetch_Employee_ByDept();
        }

        private void Fetch_Employee_ByDept()
        {
            int selectedRow = gridViewDept.FocusedRowHandle;
            string deptID = gridViewDept.GetRowCellValue(selectedRow, "ID").ToString();
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable tbl = dbConn.Fetch_Employee_ByDept(Convert.ToInt32(deptID));
            grid_emp.DataSource = tbl;
        }

        private void addNewDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (access.Contains("Manager"))
            {
                XtraMessageBox.Show("You don't have permission on this action", "System Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                form_addDepartment form = new form_addDepartment();
                form.ShowDialog();
            }
            
        }

        private void repbtnViewContract_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int selectedRow = gridViewEmp.FocusedRowHandle;
            string name = gridViewEmp.GetRowCellValue(selectedRow, "NAME").ToString();
            string date = gridViewEmp.GetRowCellValue(selectedRow, "Designation Date").ToString();
            string pos = gridViewEmp.GetRowCellValue(selectedRow, "Position").ToString();
            string sdate = gridViewEmp.GetRowCellValue(selectedRow, "Start Date").ToString();
            string salary = gridViewEmp.GetRowCellValue(selectedRow, "Rate").ToString();

            XtraReport_Contract.name = name;
            XtraReport_Contract.date = date;
            XtraReport_Contract.position = pos;
            XtraReport_Contract.startDate = sdate;
            XtraReport_Contract.salaryAmount = salary;

            XtraForm_employmentContract form = null;
            if(form == null)
            {
                form = new XtraForm_employmentContract();               
            }
            
            form.ShowDialog();
        }

        private void repBtnSalary_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            form_monthSelect monthSelectForm = new form_monthSelect();
            monthSelectForm.ShowDialog();

            DateTime selectedDate = form_monthSelect.SelectedDate;

            int selectedRow = gridViewEmp.FocusedRowHandle;
            string emp_id = gridViewEmp.GetRowCellValue(selectedRow, "EMPID").ToString();

            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable tbl = dbConn.Fetch_Employee_Name_and_Rate_ByEmpId_v2(Convert.ToInt32(emp_id), selectedDate);

            XtraReport_payroll.name = tbl.Rows[0]["NAME"].ToString();
            XtraReport_payroll.rate = tbl.Rows[0]["Monthly Rate"].ToString();
            XtraReport_payroll.attendanceDeduc = tbl.Rows[0]["Attendance Deductions"].ToString();
            XtraReport_payroll.date = selectedDate.ToString();

            XtraForm_salaryReceipt form = new XtraForm_salaryReceipt();
            form.ShowDialog();
            
        }

    }
}