using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace peopleHUB_hrms
{
    class DbConnection_Invoker : IDisposable
    {
        SqlConnection myConn = null;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public void Dispose()
        {
            if (myConn != null)
            {
                myConn.Dispose();
                myConn = null;
            }
            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
            if (dr != null)
            {
                dr.Dispose();
                dr = null;
            }
        }
        public DbConnection_Invoker()
        {
            try
            {
                //myConn = new SqlConnection(@"Data Source = LAPTOP_AZI,1433 ; Initial Catalog = EMPLOYEE; USER = ADMINASZYH, PASSWORD = ADMINASZYH;");
                myConn = new SqlConnection(@"Data Source = LAPTOP_AZI,1433 ; Initial Catalog = peopleHUB_db; Integrated Security = True;");
                cmd.CommandType = CommandType.StoredProcedure;
                myConn.Open();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Login module
        public DataTable Get_UserAccount_By_EmpID(int emp_id)
        {
            try
            {
                cmd.CommandText = "Get_UserAccount_By_EmpID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_User(string username, string userpassword)
        {
            try
            {
                cmd.CommandText = "Fetch_User";
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Connection = myConn;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 20).Value = username;
                cmd.Parameters.Add("@userpassword", SqlDbType.NVarChar, 20).Value = userpassword ;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }
        public DataTable Fetch_All_User()
        {
            try
            {
                cmd.CommandText = "Fetch_All_Users";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        #endregion

        #region DEPARTMENTS      
        public void Insert_Position(
             string @post_name)
        {
            try
            {
                cmd.CommandText = "Insert_Position";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@post_name", SqlDbType.NVarChar, 20).Value = @post_name;                
                cmd.ExecuteNonQuery();
                XtraMessageBox.Show("Position successfully added!",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }
        public void Save_Attendance(int emp_id, string appendTime, int hr)
        {
            try
            {
                cmd.CommandText = "Save_Attendance";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;
                cmd.Parameters.Add("@hour", SqlDbType.Int).Value = hr;
                cmd.Parameters.Add("@appendTime", SqlDbType.VarChar, 5).Value = appendTime;

                cmd.ExecuteNonQuery();
                if (appendTime.Equals("AM"))
                {
                    if (hr < 12)
                    {
                        XtraMessageBox.Show("Successfully Timed-IN (AM).", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (hr == 12)
                    {
                        XtraMessageBox.Show("Successfully Timed-OUT (AM).", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (appendTime.Equals("PM"))
                {
                    if (hr >= 13 && hr < 17)
                    {
                        XtraMessageBox.Show("Successfully Timed-IN (PM).", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (hr >= 17)
                    {
                        XtraMessageBox.Show("Successfully Timed-OUT (PM).", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }


        public void Insert_Department(
             string @dept_name)
        {
            try
            {
                cmd.CommandText = "Insert_Department";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@dept_name", SqlDbType.NVarChar, 20).Value = @dept_name;
                cmd.ExecuteNonQuery();
                XtraMessageBox.Show("Position department added!",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }
        public DataTable Fetch_Departments()
        {
            try
            {
                cmd.CommandText = "Fetch_Departments";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }
        #endregion

        #region EMPLOYEE FUNCTIONS

        public string FetchCounts()
        {
            try
            {
                cmd.CommandText = "Fetch_Counts";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Counts"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error fetching counts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return null;
        }

        public DataTable GetEmployeeCountByDepartment()
        {
            DataTable dataTable = new DataTable();
            try
            {
                cmd.Connection = myConn;
                cmd.CommandText = "Fetch_EmployeeCount";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                if (myConn.State != ConnectionState.Open)
                {
                    myConn.Open();
                }

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }


        public DataTable Fetch_Gender_Counts()
        {
            DataTable dataTable = new DataTable();
            try
            {
                cmd.Connection = myConn;
                cmd.CommandText = "Fetch_Gender_Counts";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                if (myConn.State != ConnectionState.Open)
                {
                    myConn.Open();
                }

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        public DataTable Fetch_Employee_Age()
        {
            DataTable dataTable = new DataTable();
            try
            {
                cmd.Connection = myConn;
                cmd.CommandText = "Fetch_Employee_Age";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                if (myConn.State != ConnectionState.Open)
                {
                    myConn.Open();
                }

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        public void Edit_Employee(
            int emp_ID,
            string emp_firstname,
            string emp_middlename,
            string emp_lastname,
            string emp_birthdate,
            string emp_address,
            string emp_contact,
            string emp_email,
            string emp_gender,
            string emp_civilstatus)
        {
            try
            {
                cmd.CommandText = "Edit_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@emp_ID", SqlDbType.Int).Value = emp_ID;
                cmd.Parameters.Add("@emp_firstname", SqlDbType.NVarChar, 20).Value = emp_firstname;
                cmd.Parameters.Add("@emp_middlename", SqlDbType.NVarChar, 20).Value = emp_middlename;
                cmd.Parameters.Add("@emp_lastname", SqlDbType.NVarChar, 20).Value = emp_lastname;
                cmd.Parameters.Add("@emp_birthdate", SqlDbType.Date).Value = Convert.ToDateTime(emp_birthdate);
                cmd.Parameters.Add("@emp_address", SqlDbType.NVarChar, 150).Value = emp_address;
                cmd.Parameters.Add("@emp_contact", SqlDbType.NVarChar, 20).Value = emp_contact;
                cmd.Parameters.Add("@emp_email", SqlDbType.NVarChar, 50).Value = emp_email;
                cmd.Parameters.Add("@emp_gender", SqlDbType.NVarChar, 10).Value = emp_gender;
                cmd.Parameters.Add("@emp_civilstatus", SqlDbType.NVarChar, 20).Value = emp_civilstatus;
                cmd.ExecuteNonQuery();

                XtraMessageBox.Show("Employee successfully updated!",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void Update_UserAccount_By_EmpID(int emp_id, string new_username, string new_password)
        {
            try
            {
                cmd.CommandText = "Update_UserAccount_By_EmpID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;
                cmd.Parameters.Add("@new_username", SqlDbType.NVarChar, 50).Value = new_username;
                cmd.Parameters.Add("@new_password", SqlDbType.NVarChar, 50).Value = new_password;
                cmd.ExecuteNonQuery();

                XtraMessageBox.Show("User account successfully updated!",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void Update_Notification_Status(int notif_id)
        {
            try
            {
                cmd.CommandText = "Update_Notification_Status";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@notif_id", SqlDbType.Int).Value = notif_id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }



        public DataTable Fetch_Employee_ByID(int emp_ID)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_ByID";
                cmd.Connection = myConn;
                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_ID;
                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { myConn.Close(); }
            return null;
        }

        public DataTable Fetch_Attendance()
        {
            try
            {
                cmd.CommandText = "Fetch_Attendance";
                cmd.Connection = myConn;
                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { myConn.Close(); }
            return null;
        }

        public DataTable Fetch_Attendance_By_EmpID(int empid)
        {
            try
            {
                cmd.CommandText = "Fetch_Attendance_By_EmpID";
                cmd.Connection = myConn;
                cmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = empid;
                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { myConn.Close(); }
            return null;
        }

        public DataTable Fetch_Employee()
        {
            try
            {
                cmd.CommandText = "Fetch_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;             

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }        

        public DataTable Fetch_EmployeeType()
        {
            try
            {
                cmd.CommandText = "Fetch_EmployeeType";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_Position()
        {
            try
            {
                cmd.CommandText = "Fetch_Position";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_SG_step(string sg)
        {
            try
            {
                cmd.CommandText = "Fetch_SG_step";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@salaryGrade", SqlDbType.NVarChar, 20).Value = sg;
                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }
        public DataTable Fetch_Employee_ByStatus(string emp_status)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_ByStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@emp_status", SqlDbType.NVarChar, 20).Value = emp_status;
                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }
        public DataTable Fetch_Employee_Assigned(int emp_isAssigned)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_Assigned";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@emp_isAssigned", SqlDbType.Int).Value = emp_isAssigned;
                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_Employee_Assignment()
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_Assignment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_Position_By_EmpID(int emp_id)
        {
            try
            {
                cmd.CommandText = "Fetch_Position_By_EmpID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_Employee_ByDept(int dept_id)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_ByDept";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dept_id", SqlDbType.Int).Value = dept_id;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_Employee_Name_and_Rate_ByEmpId(int emp_id)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_Name_and_Rate_ByEmpId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_Employee_Name_and_Rate_ByEmpId_v2(int emp_id, DateTime month_start)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_Name_and_Rate_ByEmpId_v2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;
                cmd.Parameters.Add("@month_start", SqlDbType.DateTime).Value = month_start;
                cmd.Connection = myConn;

                DataTable emp = new DataTable();
                emp.Load(cmd.ExecuteReader());
                return emp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public void Insert_Employee(
            string emp_firstname,
            string emp_middlename,
            string emp_lastname,
            string emp_birthdate,
            string emp_address,
            string emp_contact,
            string emp_email,
            string emp_gender,
            string emp_civilstatus)
        {

            try
            {
                cmd.CommandText = "Insert_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Add("@emp_firstname", SqlDbType.NVarChar, 20).Value = emp_firstname;
                cmd.Parameters.Add("@emp_middlename", SqlDbType.NVarChar, 20).Value = emp_middlename;
                cmd.Parameters.Add("@emp_lastname", SqlDbType.NVarChar, 20).Value = emp_lastname;
                cmd.Parameters.Add("@emp_birthdate", SqlDbType.Date).Value = Convert.ToDateTime(emp_birthdate)  ;
                cmd.Parameters.Add("@emp_address", SqlDbType.NVarChar, 150).Value = emp_address;
                cmd.Parameters.Add("@emp_contact", SqlDbType.NVarChar, 20).Value = emp_contact;
                cmd.Parameters.Add("@emp_email", SqlDbType.NVarChar, 50).Value = emp_email;
                cmd.Parameters.Add("@emp_gender", SqlDbType.NVarChar, 10).Value = emp_gender;
                cmd.Parameters.Add("@emp_civilstatus", SqlDbType.NVarChar, 20).Value = emp_civilstatus;
                cmd.ExecuteNonQuery();

                XtraMessageBox.Show("Employee successfully added!",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void Insert_Employee_Designation(
         int @emp_ID,
         string @emptype,
         string @position,
         int @dept_id,
         string @startDate,
         string @endDate,
         int @salaryGradeStep_id)
        {
            try
            {
                cmd.CommandText = "Insert_Employee_Designation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@emp_ID", SqlDbType.Int).Value = @emp_ID;
                cmd.Parameters.Add("@emptype", SqlDbType.NVarChar, 20).Value = @emptype;
                cmd.Parameters.Add("@position", SqlDbType.NVarChar, 50).Value = @position;
                cmd.Parameters.Add("@dept_id", SqlDbType.Int).Value = @dept_id;
                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = Convert.ToDateTime(@startDate);
                cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = Convert.ToDateTime(@endDate);
                cmd.Parameters.Add("@salaryGradeStep_id", SqlDbType.Int).Value = @salaryGradeStep_id;

                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string username = cmd.Parameters["@username"].Value.ToString();
                string password = cmd.Parameters["@password"].Value.ToString();

                XtraMessageBox.Show($"Employee successfully added!\n\nDefault Username: {username}\nDefault Password: {password}",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }


        public void Generate_Request(int employeeID, DateTime startDate, DateTime endDate, string leaveType, string reason)
        {
            try
            {
                cmd.CommandText = "Generate_Request";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn; 

                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = employeeID;
                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate;
                cmd.Parameters.Add("@leavetype", SqlDbType.NVarChar, 50).Value = leaveType;
                cmd.Parameters.Add("@reason", SqlDbType.NVarChar, -1).Value = reason;

                cmd.ExecuteNonQuery();

                XtraMessageBox.Show("Leave request successfully generated and marked as 'Pending'.",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataTable Fetch_Request_Individual(int employeeId)
        {
            try
            {
                cmd.CommandText = "Fetch_Request_Individual";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = employeeId;

                DataTable requestTable = new DataTable();

                requestTable.Load(cmd.ExecuteReader());

                return requestTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }
        public DataTable Fetch_Request_Rejected()
        {
            try
            {
                cmd.CommandText = "Fetch_Request_Rejected";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                DataTable deptTable = new DataTable();

                deptTable.Load(cmd.ExecuteReader());

                return deptTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;

        }

        public DataTable Fetch_Request_Accepted()
        {
            try
            {
                cmd.CommandText = "Fetch_Request_Accepted";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                DataTable deptTable = new DataTable();

                deptTable.Load(cmd.ExecuteReader());

                return deptTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;

        }

        public DataTable Fetch_Request_Pending()
        {
            try
            {
                cmd.CommandText = "Fetch_Request_Pending";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                DataTable deptTable = new DataTable();

                deptTable.Load(cmd.ExecuteReader());

                return deptTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public void Accept_Request(int leaveReqID, string name, string comments)
        {
            try
            {
                cmd.CommandText = "Accept_Request";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Add("@LeaveReq_ID", SqlDbType.Int).Value = leaveReqID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name;
                cmd.Parameters.Add("@Comments", SqlDbType.NVarChar, -1).Value = comments;

                cmd.ExecuteNonQuery();
                XtraMessageBox.Show("Leave request approved successfully!",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }

        public bool Set_Employee_Inactive(int emp_id)
        {
            try
            {
                cmd.CommandText = "Set_Employee_Inactive";
                cmd.Connection = myConn;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;

                cmd.ExecuteNonQuery();

                XtraMessageBox.Show("Employee status set to Inactive successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error setting employee status to Inactive: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (myConn != null && myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        public void Backup_Database(string filepath)
        {
            try
            {
                cmd.CommandText = "Backup_Database";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Add("@FilePath", SqlDbType.NVarChar, 200).Value = filepath;

                cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void Restore_Database(string filepath)
        {
            try
            {
                cmd.CommandText = "Restore_Database";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Add("@FilePath", SqlDbType.NVarChar, 200).Value = filepath;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void Reject_Request(int leaveReqID, string name, string comments)
        {
            try
            {
                cmd.CommandText = "Reject_Request";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Add("@LeaveReq_ID", SqlDbType.Int).Value = leaveReqID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name;
                cmd.Parameters.Add("@Comments", SqlDbType.NVarChar, -1).Value = comments;

                cmd.ExecuteNonQuery();
                XtraMessageBox.Show("Leave request rejected successfully!",
                                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
        }
    
        public DataTable Get_Employee_Notifications(int emp_id)
        {
            try
            {
                cmd.CommandText = "Get_Employee_Notifications";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;               

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;
                DataTable deptTable = new DataTable();

                deptTable.Load(cmd.ExecuteReader());

                return deptTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Get_Employee_Notifications_read(int emp_id)
        {
            try
            {
                cmd.CommandText = "Get_Employee_Notifications_read";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;
                DataTable deptTable = new DataTable();

                deptTable.Load(cmd.ExecuteReader());

                return deptTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        public DataTable Fetch_Employee_Information(int emp_id)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_Information";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = emp_id;
                DataTable deptTable = new DataTable();

                deptTable.Load(cmd.ExecuteReader());

                return deptTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Close();
            }
            return null;
        }

        #endregion




    }
}
