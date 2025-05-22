using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace peopleHUB_hrms
{    
    public partial class LoginForm : XtraForm
    {
        private bool dragging = false;
        private Point offset;
        public LoginForm()
        {
            InitializeComponent();
        }

        string name;
        string role;
        string access;
        string department;
        string empid;
        string pos;


        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                offset = new Point(e.X, e.Y);
            }
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                this.Location = new Point(this.Location.X + e.X - offset.X, this.Location.Y + e.Y - offset.Y);
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            this.MouseDown += new MouseEventHandler(Login_MouseDown);
            this.MouseMove += new MouseEventHandler(Login_MouseMove);
            this.MouseUp += new MouseEventHandler(Login_MouseUp);
            this.pictureBox1.MouseDown += new MouseEventHandler(Login_MouseDown);
            this.pictureBox1.MouseMove += new MouseEventHandler(Login_MouseMove);
            this.pictureBox1.MouseUp += new MouseEventHandler(Login_MouseUp);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = textEdit_username.Text;
            string password = textEdit_pass.Text;

            SplashScreen1 waitForm = new SplashScreen1();
            waitForm.Show();

            Task.Run(async () =>
            {
                await Task.Delay(3000);

                DbConnection_Invoker dbConn = new DbConnection_Invoker();
                DataTable acc = dbConn.Fetch_User(username, password);
                int count = acc.Rows.Count;

       
                this.Invoke((MethodInvoker)delegate
                {
                    waitForm.Close(); 

                    if (count == 0)
                    {
                        XtraMessageBox.Show("Invalid Username or Password.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        foreach (DataRow row in acc.Rows)
                        {
                            name = row["NAME"].ToString();
                            role = row["Role"].ToString();
                            access = row["Access"].ToString();
                            department = row["Department"].ToString();
                            empid = row["ID"].ToString();
                            pos = row["POSITION"].ToString();

                            if (role == "Employee")
                            {
                                MainForm_user userForm = new MainForm_user();
                                userForm.useraccount(name, role, access, department, empid, pos);
                                userForm.Show();
                            }
                            else
                            {
                                MainForm mainForm = new MainForm();
                                mainForm.useraccount(name, role, access, department, pos, empid);
                                mainForm.Show();
                            }

                            Hide();
                        }
                    }
                });
            });
        }

        #region Reset
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            this.btnExit.ForeColor = Color.Red;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            this.btnExit.ForeColor = Color.Gray;
        }

        private void btn_reset_MouseEnter(object sender, EventArgs e)
        {
            this.txt_reset.ForeColor = Color.Red;
        }

        private void btn_reset_MouseLeave(object sender, EventArgs e)
        {
            this.txt_reset.ForeColor = Color.Gray;
        }

        private void btn_reset_MouseClick(object sender, MouseEventArgs e)
        {
            textEdit_username.Text = "";
            textEdit_pass.Text = "";
        }
        #endregion
    }
}
