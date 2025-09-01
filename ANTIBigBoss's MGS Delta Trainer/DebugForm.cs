using System;
using System.Windows.Forms;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(DebugForm_FormClosing);
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            this.Location = MemoryManager.GetLastFormLocation();
        }

        private void DebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "DebugForm");
            Application.Exit();
        }

        private void SwapToWeaponsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Weapon form from the Game Stats form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "WeaponForm");
            WeaponForm form1 = new();
            form1.Show();
            this.Hide();
        }

        private void SwapToItemsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Item form from the Game Stats form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "ItemForm");
            ItemForm form2 = new();
            form2.Show();
            this.Hide();
        }

        private void SwapToCamoForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Camo form from the Game Stats form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "CamoForm");
            CamoForm form3 = new();
            form3.Show();
            this.Hide();
        }       

        private void CheatEngineDebugButton_Click(object sender, EventArgs e)
        {
            string processName = txtProcessName.Text.Trim();
            txtProcessName.Text = "MGSDelta-Win64-Shipping";
            string currentAddressInput = txtCurrentAddress.Text.Trim();

            if (string.IsNullOrEmpty(processName))
            {
                MessageBox.Show("Please enter a process name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(currentAddressInput))
            {
                MessageBox.Show("Please enter the current address.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(currentAddressInput, System.Globalization.NumberStyles.HexNumber, null, out long currentAddress))
            {
                MessageBox.Show("Invalid address format. Please enter a valid hexadecimal number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                IntPtr baseAddress = HelperMethods.Instance.GetBaseAddress(processName);
                long offset = HelperMethods.Instance.CalculateOffset(baseAddress, currentAddress);
                IntPtr recomputedAddress = HelperMethods.Instance.RecomputeAbsoluteAddress(baseAddress, offset);
                string cheatEngineString = HelperMethods.Instance.GenerateCheatEngineString(processName, offset);

                txtOffset.Text = $"0x{offset:X}";
                txtRecomputedAddress.Text = $"0x{recomputedAddress.ToInt64():X}";
                txtCheatEngineString.Text = cheatEngineString;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Process Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogAreaAddress_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(StringManager.Instance.GetCurrentMemoryAddress());
        }

        private void GenerateLogButton_Click(object sender, EventArgs e)
        {
            LoggingManager.LogAllWeaponsAndItemsAddresses();
            LoggingManager.Instance.LogAOBAddresses();
            LoggingManager.Instance.LogAllMemoryAddressesandValues();
            CustomMessageBoxManager.CustomMessageBox("Information written to log file in:\n C:\\Users\\YourUserNameHere\\Documents\\MGS3 CT Log\\MGS3_Delta_Trainer_Log.txt", "Log Generated");
        }
    }
}