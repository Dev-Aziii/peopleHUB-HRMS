using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using System.Data;
using System.Windows.Forms;

namespace peopleHUB_hrms
{
    public partial class form_AddEmployee : XtraForm
    {
        public static int emp_ID;
        public form_AddEmployee()
        {
            InitializeComponent();
        }

        string action { get; set; }
        public void passAction(string _action)
        {
            action = _action;
        }      

        private void form_AddEmployee_Load(object sender, EventArgs e)
        {
            textEdit_firstname.KeyPress += RestrictToLetters;
            textEdit_midname.KeyPress += RestrictToLetters;
            textEdit_lastname.KeyPress += RestrictToLetters;

            if (action.Equals("ADD"))
            {
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
            else
            {
                btnUpdate.Visible = true;
                btnSave.Visible = false;

                Text = "Edit Employee";
                DbConnection_Invoker dbconn = new DbConnection_Invoker();
                DataTable empTBL = dbconn.Fetch_Employee_ByID(emp_ID);
                foreach (DataRow row in empTBL.Rows)
                {
                    textEdit_firstname.Text = row["emp_firstname"].ToString();
                    textEdit_lastname.Text = row["emp_lastname"].ToString();
                    textEdit_midname.Text = row["emp_middlename"].ToString();
                    comboBoxEdit_civilStatus.Text = row["emp_civilstatus"].ToString();
                    textEdit_address.Text = row["emp_address"].ToString();
                    dateEdit_birthdate.EditValue = Convert.ToDateTime(row["emp_birthdate"]);
                    textEdit_contact.Text = row["emp_contact"].ToString();
                    textEdit_email.Text = row["emp_email"].ToString();
                    comboBoxEdit_sex.Text = row["emp_gender"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();

            if (textEdit_firstname.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_firstname, "Enter Firstname");
            }
            else if (textEdit_midname.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_midname, "Enter Middlename or N/A (if not Applicable)");
            }
            else if (textEdit_lastname.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_lastname, "Enter Lastname");
            }
            else if (dateEdit_birthdate.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(dateEdit_birthdate, "Enter Birthdate");
            }
            else if (comboBoxEdit_civilStatus.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(comboBoxEdit_civilStatus, "Select Civil Status");
            }
            else if (comboBoxEdit_sex.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(comboBoxEdit_sex, "Select Sex");
            }
            else if (textEdit_address.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_address, "Enter Address");
            }
            else if (textEdit_contact.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_contact, "Enter Contact Details");
            }
            else if (textEdit_email.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_email, "Enter Email Address");
            }
            else
            {
                string firstName = textEdit_firstname.Text;
                string lastName = textEdit_lastname.Text;
                string middleName = textEdit_midname.Text;
                string civilStatus = comboBoxEdit_civilStatus.Text;
                string address = textEdit_address.Text;
                string birthDate = dateEdit_birthdate.Text;
                string sex = comboBoxEdit_sex.Text;
                string contactNumber = textEdit_contact.Text;
                string email = textEdit_email.Text;

                if (XtraMessageBox.Show("Do you want to add this employee record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    DbConnection_Invoker dbConn = new DbConnection_Invoker();
                    dbConn.Insert_Employee(firstName, middleName, lastName, birthDate, address, contactNumber, email, sex, civilStatus);
                    tab_Employee emptbl = new tab_Employee();
                    emptbl._reload(true);

                    textEdit_firstname.Text = string.Empty;
                    textEdit_lastname.Text = string.Empty;
                    textEdit_midname.Text = string.Empty;
                    comboBoxEdit_civilStatus.Text = string.Empty;
                    textEdit_address.Text = string.Empty;
                    dateEdit_birthdate.Text = string.Empty;
                    comboBoxEdit_sex.Text = string.Empty;
                    textEdit_contact.Text = string.Empty;
                    textEdit_email.Text = string.Empty;
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();

            if (textEdit_firstname.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_firstname, "Enter Firstname");
            }
            else if (textEdit_midname.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_midname, "Enter Middlename or N/A (if not Applicable)");
            }
            else if (textEdit_lastname.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_lastname, "Enter Lastname");
            }
            else if (dateEdit_birthdate.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(dateEdit_birthdate, "Enter Birthdate");
            }
            else if (comboBoxEdit_civilStatus.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(comboBoxEdit_civilStatus, "Select Civil Status");
            }
            else if (comboBoxEdit_sex.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(comboBoxEdit_sex, "Select Sex");
            }
            else if (textEdit_address.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_address, "Enter Address");
            }
            else if (textEdit_contact.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_contact, "Enter Contact Details");
            }
            else if (textEdit_email.Text.Equals(string.Empty))
            {
                dxErrorProvider1.SetError(textEdit_email, "Enter Email Address");
            }
            else
            {
                string firstName = textEdit_firstname.Text;
                string lastName = textEdit_lastname.Text;
                string middleName = textEdit_midname.Text;
                string civilStatus = comboBoxEdit_civilStatus.Text;
                string address = textEdit_address.Text;
                string birthDate = dateEdit_birthdate.Text;
                string sex = comboBoxEdit_sex.Text;
                string contactNumber = textEdit_contact.Text;
                string email = textEdit_email.Text;

                if (XtraMessageBox.Show("Do you want to edit this employee record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    DbConnection_Invoker dbConn = new DbConnection_Invoker();
                    dbConn.Edit_Employee(emp_ID, firstName, middleName, lastName, birthDate, address, contactNumber, email, sex, civilStatus);
                    Close();
                }

            }
        }

        private void RestrictToLetters(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                XtraMessageBox.Show("Error: You cannot input numbers or special characters in this field.",
                            "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true; 
            }
        }
    }
}
