using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using System.Data;
using System.Windows.Forms;

namespace peopleHUB_hrms
{
    public partial class form_AddPosition : XtraForm
    {
        public form_AddPosition()
        {
            InitializeComponent();
        }        

        private void form_AddPosition_Load(object sender, EventArgs e)
        {
            Fetch_Position();
        }
        public void Fetch_Position()
        {
            DbConnection_Invoker dbConn = new DbConnection_Invoker();
            DataTable tbl = dbConn.Fetch_Position();
            grid_post.DataSource = tbl;
        }

        private void btnAddpos_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textEdit_pos.Text))
                {
                    XtraMessageBox.Show("Position name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = XtraMessageBox.Show("Are you sure you want to add this position?",
                                                          "Confirmation",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DbConnection_Invoker dbConn = new DbConnection_Invoker();
                    dbConn.Insert_Position(textEdit_pos.Text);

                    Fetch_Position();
                    textEdit_pos.Text = string.Empty;

                    XtraMessageBox.Show("Position added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error adding position: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}