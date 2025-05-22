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
using System.IO;

namespace peopleHUB_hrms
{
    public partial class tab_Backup : DevExpress.XtraEditors.XtraForm
    {
        public tab_Backup()
        {
            InitializeComponent();
        }

        private void tab_Backup_Load(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = "Select Backup Location",
                    Filter = "Backup Files (*.bak)|*.bak",
                    DefaultExt = "bak",
                    FileName = "peopleHUB_db_backup"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = saveFileDialog.FileName;

                    DbConnection_Invoker dbConn = new DbConnection_Invoker();
                    dbConn.Backup_Database(backupFilePath);

                    XtraMessageBox.Show("Database backup successfully saved to:\n" + backupFilePath,
                                        "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Backup operation was canceled.",
                                        "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("An error occurred during the backup process:\n" + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Select Backup File to Restore",
                    Filter = "Backup Files (*.bak)|*.bak",
                    DefaultExt = "bak",
                    CheckFileExists = true,
                    CheckPathExists = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string restoreFilePath = openFileDialog.FileName;

                    if (File.Exists(restoreFilePath))
                    {
                        DbConnection_Invoker dbConn = new DbConnection_Invoker();
                        dbConn.Restore_Database(restoreFilePath);

                        XtraMessageBox.Show("Database successfully restored from:\n" + restoreFilePath,
                                            "Restore Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("The selected backup file does not exist. Please select a valid file.",
                                            "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Restore operation was canceled.",
                                        "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("An error occurred during the restore process:\n" + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}