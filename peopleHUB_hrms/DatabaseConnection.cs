using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace peopleHUB_hrms
{
    class DatabaseConnection : IDisposable
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

        public DatabaseConnection()
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

        public void SaveLogout(long logID)
        {
            try
            {
                cmd.Connection = myConn;
                cmd.CommandText = "Save_Logout";
                cmd.Parameters.Clear(); 
                cmd.Parameters.AddWithValue("@Log_ID", logID);  
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveLog(long userId, out long logId)
        {
            logId = 0; 

            try
            {
                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }

                cmd.CommandText = "Save_Log";

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@User_ID", SqlDbType.BigInt).Value = userId;

                SqlParameter logIdParam = new SqlParameter("@Log_ID", SqlDbType.BigInt);
                logIdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(logIdParam);

                cmd.ExecuteNonQuery();

                logId = (long)logIdParam.Value;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error Saving Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }



        public void Generate_Request(long employeeID, DateTime startDate, DateTime endDate, string leaveType, string reason, DateTime dateCreated)
        {
            try
            {
                cmd.CommandText = "Generate_Request";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = employeeID;
                cmd.Parameters.Add("@Start_Date", SqlDbType.Date).Value = startDate;
                cmd.Parameters.Add("@End_Date", SqlDbType.Date).Value = endDate;
                cmd.Parameters.Add("@Leave_Type", SqlDbType.NVarChar, 50).Value = leaveType;
                cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, -1).Value = reason;
                cmd.Parameters.Add("@Date_Created", SqlDbType.DateTime).Value = dateCreated;

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


        public bool SetEmployeeInactive(long employeeId)
        {
            try
            {
                cmd.CommandText = "Set_Employee_Inactive";
                cmd.Connection = myConn;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = employeeId;

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

        public DataTable Fetch_Employee(string status)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear(); 
                cmd.Parameters.AddWithValue("@Status", status);

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

        public DataTable Fetch_Managers()
        {
            try
            {
                cmd.CommandText = "Fetch_Managers"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear(); 

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
        public bool Fetch_User(string username, string password, out string role, out long userId)
        {
            role = string.Empty;
            userId = 0; // Default value for userId
            try
            {
                cmd.CommandText = "Fetch_User";
                cmd.Connection = myConn;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string employeeStatus = reader["Status"].ToString();
                            if (employeeStatus == "Inactive")
                            {
                                XtraMessageBox.Show("This user is inactive. Please contact the administrator.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            role = reader["Role"].ToString();
                            userId = Convert.ToInt64(reader["User_ID"]); 
                        }
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            return false;
        }




        public DataTable Fetch_Departments()
        {
            try
            {
                cmd.CommandText = "Fetch_Department"; 
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Connection = myConn;

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

        public DataTable Fetch_Contract()
        {
            try
            {
                cmd.CommandText = "Fetch_Contract"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

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

        public DataTable Fetch_Employees_By_Department(string departmentName, string status)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_By_Department"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear(); 
                cmd.Parameters.AddWithValue("@department", departmentName);
                cmd.Parameters.AddWithValue("@Status", status); 

                DataTable employeeTable = new DataTable();
                employeeTable.Load(cmd.ExecuteReader());
                return employeeTable;
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

        public DataTable Fetch_Employee_ByID(long empID)
        {
            try
            {
                cmd.CommandText = "Fetch_Employee_ByID";
                cmd.Connection = myConn;
                cmd.Parameters.Add("@EmployeeID", SqlDbType.BigInt).Value = empID;
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


        public DataTable Fetch_PendingRequest(string deptName)
        {
            try
            {
                cmd.CommandText = "Fetch_Request_Pending";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@Dept_Name", SqlDbType.NVarChar, 100).Value = deptName;

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


        public DataTable Fetch_AcceptedRequest(string deptName)
        {
            try
            {
                cmd.CommandText = "Fetch_Request_Accepted";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@Dept_Name", SqlDbType.NVarChar, 100).Value = deptName;

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

        public DataTable Fetch_RejectedRequest(string deptName)
        {
            try
            {
                cmd.CommandText = "Fetch_Request_Rejected";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@Dept_Name", SqlDbType.NVarChar, 100).Value = deptName;

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

        public DataTable Fetch_IndividualRequest(int employeeId)
        {
            try
            {
                cmd.CommandText = "Fetch_Request_Individual";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@Employee_ID", SqlDbType.Int).Value = employeeId;

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



        public string FetchManagerByUsername(string username)
        {
         
            try
            {
                cmd.CommandText = "Fetch_Manager_By_Username"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                myConn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Manager"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error fetching Manager ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public string FetchEmployeeByUsername(string username)
        {

            try
            {
                cmd.CommandText = "Fetch_Employee_By_Username"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                myConn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Employee"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error fetching Manager ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public string FetchAdminByUsername(string username)
        {

            try
            {
                cmd.CommandText = "Fetch_Admin_By_Username"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                myConn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Admin"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error fetching Manager ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void Insert_Employee(string firstName, string lastName, string middleName, int age, string civilStatus, string address,
                          string birthDate, string contactNumber, string email, string emergencyContact, string status,
                          string position, int deptId, int contractId)
        {
            try
            {
                cmd.CommandText = "Insert_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@First_Name", SqlDbType.NVarChar, 50).Value = firstName;
                cmd.Parameters.Add("@Last_Name", SqlDbType.NVarChar, 50).Value = lastName;
                cmd.Parameters.Add("@Middle_Name", SqlDbType.NVarChar, 50).Value = middleName;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Value = age;
                cmd.Parameters.Add("@Civil_Status", SqlDbType.NVarChar, 20).Value = civilStatus;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = address;
                cmd.Parameters.Add("@Birth_Date", SqlDbType.Date).Value = Convert.ToDateTime(birthDate);
                cmd.Parameters.Add("@Contact_Number", SqlDbType.NVarChar, 50).Value = contactNumber;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                cmd.Parameters.Add("@Emergency_Contact", SqlDbType.NVarChar, 50).Value = emergencyContact;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = status;
                cmd.Parameters.Add("@Position", SqlDbType.NVarChar, 50).Value = position;
                cmd.Parameters.Add("@Dept_ID", SqlDbType.Int).Value = deptId;
                cmd.Parameters.Add("@Contract_ID", SqlDbType.Int).Value = contractId;

                SqlParameter usernameParam = new SqlParameter("@Username", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter passwordParam = new SqlParameter("@Password", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);

                cmd.ExecuteNonQuery();

                string username = usernameParam.Value.ToString();
                string password = passwordParam.Value.ToString();

                XtraMessageBox.Show($"Employee successfully added!\nDefault Username: {username}\nDefault Password: {password}",
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

        public bool Edit_Employee(long empId, string firstName, string lastName, string middleName, int age, string civilStatus, string address,
                          string birthDate, string contactNumber, string email, string emergencyContact, string position,
                          int deptId, int contractId)
        {
            try
            {
                cmd.CommandText = "Edit_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@Employee_ID", SqlDbType.BigInt).Value = empId;
                cmd.Parameters.Add("@First_Name", SqlDbType.NVarChar, 50).Value = firstName;
                cmd.Parameters.Add("@Last_Name", SqlDbType.NVarChar, 50).Value = lastName;
                cmd.Parameters.Add("@Middle_Name", SqlDbType.NVarChar, 50).Value = middleName;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Value = age;
                cmd.Parameters.Add("@Civil_Status", SqlDbType.NVarChar, 20).Value = civilStatus;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = address;
                cmd.Parameters.Add("@Birth_Date", SqlDbType.Date).Value = Convert.ToDateTime(birthDate); // Convert the birth date to Date type
                cmd.Parameters.Add("@Contact_Number", SqlDbType.NVarChar, 15).Value = contactNumber;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                cmd.Parameters.Add("@Emergency_Contact", SqlDbType.NVarChar, 50).Value = emergencyContact;
                cmd.Parameters.Add("@Position", SqlDbType.NVarChar, 50).Value = position;
                cmd.Parameters.Add("@Dept_ID", SqlDbType.Int).Value = deptId;
                cmd.Parameters.Add("@Contract_ID", SqlDbType.Int).Value = contractId;

                if (myConn.State != ConnectionState.Open)
                {
                    myConn.Open();
                }

                cmd.ExecuteNonQuery();

                XtraMessageBox.Show("Employee details successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occurred while updating the employee details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
