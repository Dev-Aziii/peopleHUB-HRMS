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
    public partial class form_comment : DevExpress.XtraEditors.XtraForm
    {
        public string Comment { get; set; }
        public form_comment()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                XtraMessageBox.Show("Comment cannot be empty. Please provide a valid comment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            DialogResult result = XtraMessageBox.Show("Confirm Action?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Comment = richTextBox1.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void form_comment_FormClosing(object sender, FormClosingEventArgs e)
        {
            tab_Dashboard mainForm = Application.OpenForms.OfType<tab_Dashboard>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.loadCounts();
            }
        }
    }
}