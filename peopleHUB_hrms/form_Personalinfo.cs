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
    public partial class form_Personalinfo : DevExpress.XtraEditors.XtraForm
    {
        public static int emp_id;
        private bool isPasswordShown = false;
        public form_Personalinfo()
        {
            InitializeComponent();
        }        

        private void form_Personalinfo_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            textEdit_username.Enabled = false;
            textEdit_password.Enabled = false;
            textEdit_newpass.Enabled = false;
            textEdit_confirmpass.Enabled = false;

            textEdit_username.BackColor = Color.Gray;
            textEdit_password.BackColor = Color.Gray;
            textEdit_newpass.BackColor = Color.Gray;
            textEdit_confirmpass.BackColor = Color.Gray;
            bunifuImageButton1.BackColor = Color.Gray;
            btnSave.Appearance.BackColor = Color.Gray;

            textEdit_username.ForeColor = Color.White;
            textEdit_password.ForeColor = Color.White;
            textEdit_confirmpass.ForeColor = Color.White;
            textEdit_newpass.ForeColor = Color.White;

            textEdit_password.Properties.PasswordChar = '*';
            textEdit_confirmpass.Properties.PasswordChar = '*';
            textEdit_newpass.Properties.PasswordChar = '*';

            LoadUserAccountDetails();
            LoadUserInfoDetails();
        }   

        private void LoadUserAccountDetails()
        {
            try
            {
                DbConnection_Invoker dbConn = new DbConnection_Invoker();

                DataTable userAccount = dbConn.Get_UserAccount_By_EmpID(emp_id);

                if (userAccount != null && userAccount.Rows.Count > 0)
                {
                    string username = userAccount.Rows[0]["username"].ToString();
                    string password = userAccount.Rows[0]["password"].ToString();

                    textEdit_username.Text = username;
                    textEdit_password.Text = password;
                }
                else
                {
                    textEdit_username.Text = string.Empty;
                    textEdit_password.Text = string.Empty;

                    XtraMessageBox.Show("No user account found for the given employee ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserInfoDetails()
        {
            try
            {
                DbConnection_Invoker dbConn = new DbConnection_Invoker();

                DataTable userAccount = dbConn.Fetch_Employee_Information(emp_id);

                if (userAccount != null && userAccount.Rows.Count > 0)
                {                    
                    txtName.Text = userAccount.Rows[0]["Name"].ToString();
                    txtDept.Text = userAccount.Rows[0]["Department"].ToString();
                    textPos.Text = userAccount.Rows[0]["Position"].ToString();
                    textHired.Text = userAccount.Rows[0]["Designation Date"].ToString();
                    textEmail.Text = userAccount.Rows[0]["Email"].ToString();
                    txtAddress.Text = userAccount.Rows[0]["Address"].ToString();
                    txtContact.Text = userAccount.Rows[0]["Contact"].ToString();
                    txtType.Text = userAccount.Rows[0]["Type"].ToString();
                    txtSdate.Text = userAccount.Rows[0]["Start Date"].ToString();
                    txtEdate.Text = userAccount.Rows[0]["End Date"].ToString();
                }
                else
                {
                    textEdit_username.Text = string.Empty;
                    textEdit_password.Text = string.Empty;

                    XtraMessageBox.Show("No user account found for the given employee ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show(
       "Are you sure you want to save these changes?",
       "Confirmation",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(textEdit_newpass.Text))
                {
                    XtraMessageBox.Show(
                        "Password cannot be blank.",
                        "System Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return; 
                }

                if (textEdit_newpass.Text.Length < 6)
                {
                    XtraMessageBox.Show(
                        "Password must be at least 6 characters long.",
                        "System Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return; 
                }

                if (textEdit_newpass.Text.Equals(textEdit_confirmpass.Text))
                {
                    try
                    {
                        DbConnection_Invoker dbConn = new DbConnection_Invoker();
                        dbConn.Update_UserAccount_By_EmpID(emp_id, textEdit_username.Text, textEdit_confirmpass.Text);

                        XtraMessageBox.Show(
                            "User details updated successfully. Please log in again.",
                            "System Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        Form mainFormUser = Application.OpenForms["MainForm_user"];
                        mainFormUser?.Close();
                        Close();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(
                            "An error occurred while updating user details:\n" + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show(
                        "Password does not match.",
                        "System Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show(
                    "Changes were not saved.",
                    "System Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            textEdit_username.Enabled = !textEdit_username.Enabled;
            textEdit_password.Enabled = !textEdit_password.Enabled;
            textEdit_newpass.Enabled = !textEdit_newpass.Enabled;
            textEdit_confirmpass.Enabled = !textEdit_confirmpass.Enabled;

            if (!textEdit_username.Enabled && !textEdit_password.Enabled &&
                !textEdit_newpass.Enabled && !textEdit_confirmpass.Enabled)
            {
                textEdit_username.BackColor = Color.Gray;
                textEdit_password.BackColor = Color.Gray;
                textEdit_newpass.BackColor = Color.Gray;
                textEdit_confirmpass.BackColor = Color.Gray;
                bunifuImageButton1.BackColor = Color.Gray;
                btnSave.Appearance.BackColor = Color.Gray;

                textEdit_username.ForeColor = Color.White;
                textEdit_password.ForeColor = Color.White;
                textEdit_newpass.ForeColor = Color.White;
                textEdit_confirmpass.ForeColor = Color.White;
                btn_edit.Image = Properties.Resources.pen__1_;
                btnSave.Enabled = false;

            }
            else
            {
                textEdit_username.BackColor = Color.White;
                textEdit_password.BackColor = Color.White;
                textEdit_newpass.BackColor = Color.White;
                textEdit_confirmpass.BackColor = Color.White;
                bunifuImageButton1.BackColor = Color.White;
                btnSave.Appearance.BackColor = Color.FromArgb(0, 192, 0);

                textEdit_username.ForeColor = Color.Black;
                textEdit_password.ForeColor = Color.Black;
                textEdit_newpass.ForeColor = Color.Black;
                textEdit_confirmpass.ForeColor = Color.Black;

                btn_edit.Image = Properties.Resources.pen;
                btnSave.Enabled = true;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            isPasswordShown = !isPasswordShown;

            if (isPasswordShown)
            {
                bunifuImageButton1.Image = Properties.Resources.show_16;
                textEdit_password.Properties.PasswordChar = '\0';
            }
            else
            {
                bunifuImageButton1.Image = Properties.Resources.hide_16;
                textEdit_password.Properties.PasswordChar = '*';
            }
        }
    }
}