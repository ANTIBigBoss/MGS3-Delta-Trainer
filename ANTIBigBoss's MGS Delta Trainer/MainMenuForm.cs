using System;
using System.Diagnostics;
using static ANTIBigBoss_s_MGS_Delta_Trainer.HelperMethods;
using System.Security.Principal;
using System.Windows.Forms;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            {
                InitializeComponent();
                this.FormClosing += new FormClosingEventHandler(MainMenuForm_FormClosing);
            }
        }

        private void WeaponFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Weapon form from the Main Menu form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "WeaponForm");
            WeaponForm form1 = new();
            form1.Show();
            this.Hide();
        }

        private void ItemFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Item form from the Main Menu form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "ItemForm");
            ItemForm form2 = new();
            form2.Show();
            this.Hide();
        }

        private void CamoFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Camo form from the Main Menu form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "CamoForm");
            CamoForm form3 = new();
            form3.Show();
            this.Hide();
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoggingManager.Instance.Log("User exiting the trainer.\nEnd of log for this session.\n\n\n\n");
            Application.Exit(); // If we close this form we close the whole application so the user isn't running this without knowing
        }

        private bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

            if (!IsAdministrator())
            {
                // Attempt to restart the application with administrative privileges by checking if the user is an administrator
                try
                {
                    ProcessStartInfo proc = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Application.StartupPath,
                        FileName = Application.ExecutablePath,
                        Verb = "runas"
                    };
                    Process.Start(proc);
                    Application.Exit();
                    return;
                }
                catch (Exception ex)
                {
                    // If an error occurs this will display in the log and if they submit it in a Discord ticket we can troubleshoot
                    LoggingManager.Instance.Log("This application must be run as Administrator.\n\nExiting now and rebooting in Administrator.");
                    Application.Exit();
                    return;
                }
            }

            // Check if the game is running before starting the application if the game isn't running then close the application
            //MemoryManager.Instance.TrainerLooksForGame(sender, e);

            //TimerManager.StartLocationTracking();
            LoggingManager.Instance.Log("Now Tracking the player's map location.\n");
        }

        private void LogAOBs_Click(object sender, EventArgs e)
        {
            LoggingManager.LogAllWeaponsAndItemsAddresses();
            LoggingManager.Instance.LogAOBAddresses();
            LoggingManager.Instance.LogAllMemoryAddressesandValues();
            //StringManager.Instance.DisplayEntirePointer();
            CustomFormManager.CustomMessageBox("Information written to log file in: C:\\Users\\YourUserNameHere\\Documents\\MGS3 CT Log\\MGS3_MC_Cheat_Trainer_Log.txt", "Log Generated");
        }

        private void StatsAndAlertForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Stats and Alert from the Main Menu.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "StatsAndAlertForm");
            StatsAndAlertForm form5 = new();
            form5.Show();
            this.Hide();
        }

        private void PatchNotesButton_Click(object sender, EventArgs e)
        {
            CustomFormManager.CustomMessageBox("\n" +
                "Thanks for using my MGS3 Delta Trainer! - ANTIBigBoss\n\n" +
                "Changelog History:\n\n" +
                "v1.0.0.6:\nPorted over the Game Stats feature from the original Master Collection Trainer. Fixed the bug of title/rank image not showing up properly from the old trainer.\n\n" +
                "v1.0.0.5:\nFixed memory address issues from Konami's 1.1.4 update.\n\n" +
                "v1.0.0.4:\nAdded Misc page from the old trainer but with new options for tweaking, Reworked the Guard Damage options as the broke last game update, added in some filter/lighting editing, added in infinite ammo, no reload & infinite suppressors, added in an option that stops the battery from draining or recharging, restart stage option & difficultly changer also added to the new page.\n\n" +
                "v1.0.0.3:\nFixed memory address issues from Konami's 1.1.3 update and removed Guard Damage options from Stats and Alert as there was inconsistent issues with guards being stuck as invincible.\n\n" +
                "v1.0.0.2:\nPorted in the Stats and Alert functions from the original MGS3 Trainer\n\n" +
                "v1.0.0.1:\nAdded in some extra items and fixed memory address issues from Konami's 1.1.2 update\n\n" +
                "v1.0.0.0: Initial Release, ported over the Weapons, Items and Camo functions from the original MGS3 Trainer", "Patch Notes");
        }

        private void MiscFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Misc page from the Main Menu.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "MiscForm");
            MiscForm form4 = new();
            form4.Show();
            this.Hide();
        }

        private void GameStatsFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Game Stats page from the Main Menu.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "GameStatsForm");
            GameStatsForm form7 = new();
            form7.Show();
            this.Hide();
        }
    }
}