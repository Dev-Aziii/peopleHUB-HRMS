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
    public partial class form_addDepartment : DevExpress.XtraEditors.XtraForm
    {
        public form_addDepartment()
        {
            InitializeComponent();
        }

        private void form_addDepartment_Load(object sender, EventArgs e)
        {
            e.ToString();
        }

      

        private void btnAdd_Click(object sender, EventArgs e)
        {           
            try
            {
                if (string.IsNullOrWhiteSpace(textEdit_dept.Text))
                {
                    XtraMessageBox.Show("Department name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = XtraMessageBox.Show("Are you sure you want to add this department?",
                                                          "Confirmation",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DbConnection_Invoker dbConn = new DbConnection_Invoker();
                    dbConn.Insert_Department(textEdit_dept.Text);
                    textEdit_dept.Text = string.Empty;

                    form_Departments form = new form_Departments();
                    form.Fetch_Departments();
                    tab_Dashboard mainForm = Application.OpenForms.OfType<tab_Dashboard>().FirstOrDefault();
                    if (mainForm != null)
                    {
                        mainForm.LoadEmployeeDataToChart();
                        mainForm.loadCounts();
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error adding department: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}