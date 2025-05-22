using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraCharts;

namespace peopleHUB_hrms
{
    public partial class tab_Dashboard : XtraForm
    {
        string role = string.Empty;

        public void getRole(string Fetchedrole)
        {
            role = Fetchedrole;
        }
        public tab_Dashboard()
        {
            InitializeComponent();
        }

        private void tab_Dashboard_Load(object sender, EventArgs e)
        {

            loadCounts();
            LoadEmployeeDataToChart();
        }

        public  void loadCounts()
        {
            DbConnection_Invoker dbConnection = new DbConnection_Invoker();
            string counts = dbConnection.FetchCounts();
            string[] value = counts.Split('@');

            lblEmployeeCount.Text = Convert.ToInt32(value[0]).ToString();
            lblDepartmentCount.Text = (Convert.ToInt32(value[1])-1).ToString();
            lblLeaveRequestCount.Text = Convert.ToInt32(value[2]).ToString();
        }

        public void LoadEmployeeDataToChart()
        {
            DbConnection_Invoker dbconn = new DbConnection_Invoker();

            DataTable employeeData = dbconn.GetEmployeeCountByDepartment();

            if (employeeData.Rows.Count > 0)
            {
                chartControl1.Series.Clear();

                Series series = new Series("Employees per Department", DevExpress.XtraCharts.ViewType.Doughnut3D);

                foreach (DataRow row in employeeData.Rows)
                {
                    string deptName = row["dept_name"].ToString();
                    int totalEmployees = Convert.ToInt32(row["total_employees"]);

                    series.Points.Add(new SeriesPoint(deptName, totalEmployees));
                }

                chartControl1.Series.Add(series);

                Doughnut3DSeriesView doughnutView = (Doughnut3DSeriesView)series.View;
                doughnutView.ExplodedDistancePercentage = 30;

                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series.Label.TextPattern = "{A}: {V}";
            }
            else
            {
                XtraMessageBox.Show("No data available for employees per department.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void LoadEmployeeDataToBarChart()
        {
            DbConnection_Invoker dbconn = new DbConnection_Invoker();
            DataTable employeeData = dbconn.Fetch_Gender_Counts();

            if (employeeData.Rows.Count > 0)
            {
                chartControl1.Series.Clear();

                Series series = new Series("Gender Count", DevExpress.XtraCharts.ViewType.Bar3D);

                foreach (DataRow row in employeeData.Rows)
                {
                    string gender = row["gender"].ToString();
                    int count = Convert.ToInt32(row["count"]);

                    series.Points.Add(new SeriesPoint(gender, count));
                }

                chartControl1.Series.Add(series);

                Bar3DSeriesView bar3DView = (Bar3DSeriesView)series.View;

                bar3DView.BarWidth = 0.6;
                bar3DView.Transparency = 50;

                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series.Label.TextPattern = "{A}: {V}";
            }
            else
            {
                XtraMessageBox.Show("No data available for gender counts.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void genderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadEmployeeDataToBarChart();
        }

        private void departmentOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadEmployeeDataToChart();
        }
    }
}