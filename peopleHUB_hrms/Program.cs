using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Threading;
using DevExpress.XtraEditors;

namespace peopleHUB_hrms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex MyApplicationMutex = new Mutex(true, "POINTS_REWARD_SYSTEM");
            if (MyApplicationMutex.WaitOne(0, false))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

                // Show WaitForm1 (loading screen)
                using (WaitForm1 waitForm = new WaitForm1())
                {
                    waitForm.Show();
                    waitForm.Update(); // Refresh UI
                    Thread.Sleep(500); 
                    waitForm.Close();
                }

                // Run the main LoginForm
                Application.Run(new XtraFormAttendance());
            }
            else
            {
                XtraMessageBox.Show("The application instance is already running", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
