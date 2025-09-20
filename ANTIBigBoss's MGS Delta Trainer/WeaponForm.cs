using System;
using static ANTIBigBoss_s_MGS_Delta_Trainer.MGS3UsableObjects;
using System.Windows.Forms;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public partial class WeaponForm : Form
    {
        public WeaponForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void WeaponForm_Load(object sender, EventArgs e)
        {
            this.Location = MemoryManager.GetLastFormLocation();

            for (int i = 0; i < AllWeaponsChecklist.Items.Count; i++)
            {
                AllWeaponsChecklist.SetItemChecked(i, true);
            }

            // 0 Defaults the user to the first option in the dropdown which is "Current/Max Ammo"
            M1911A1Dropdown.SelectedIndex = 0;
            MK22Dropdown.SelectedIndex = 0;
            XM16E1Dropdown.SelectedIndex = 0;
            SAADropdown.SelectedIndex = 0;
            M37Dropdown.SelectedIndex = 0;
            SVDDropdown.SelectedIndex = 0;
            AK47Dropdown.SelectedIndex = 0;
            MosinDropdown.SelectedIndex = 0;
            RPG7Dropdown.SelectedIndex = 0;
            M63Dropdown.SelectedIndex = 0;
            ScorpionDropdown.SelectedIndex = 0;
            GrenadeDropdown.SelectedIndex = 0;
            WpGrenadeDropdown.SelectedIndex = 0;
            SmokeGrenadeDropdown.SelectedIndex = 0;
            StunGrenadeDropdown.SelectedIndex = 0;
            ChaffGrenadeDropdown.SelectedIndex = 0;
            MagazineDropdown.SelectedIndex = 0;
            HandkerchiefDropdown.SelectedIndex = 0;
            CigSprayDropdown.SelectedIndex = 0;
            TNTDropdown.SelectedIndex = 0;
            BookDropdown.SelectedIndex = 0;
            ClaymoreDropdown.SelectedIndex = 0;
            MousetrapDropdown.SelectedIndex = 0;

            // Setting all to 999 saves the user time if they just want to cheat everything in
            M1911A1TextBox.Text = "999";
            MK22TextBox.Text = "999";
            XM16E1TextBox.Text = "999";
            SAATextBox.Text = "999";
            M37TextBox.Text = "999";
            SVDTextBox.Text = "999";
            AK47TextBox.Text = "999";
            MosinTextBox.Text = "999";
            RPG7TextBox.Text = "999";
            M63TextBox.Text = "999";
            ScorpionTextBox.Text = "999";
            GrenadeTextBox.Text = "999";
            WpGrenadeTextBox.Text = "999";
            SmokeGrenadeTextBox.Text = "999";
            StunGrenadeTextBox.Text = "999";
            ChaffGrenadeTextBox.Text = "999";
            MagazineTextBox.Text = "999";
            HandkerchiefTextBox.Text = "999";
            CigSprayTextBox.Text = "999";
            TNTTextBox.Text = "999";
            BookTextBox.Text = "999";
            ClaymoreTextBox.Text = "999";
            MousetrapTextbox.Text = "999";
            AllTextbox.Text = "999";

            CheckInfiniteAmmoStatus();
            CheckNoReloadStatus();
            CheckInfiniteSuppressorsStatus();
        }

        private const string CurrentAndMax = "Current/Max Ammo";
        private const string CurrentAmmo = "Current Ammo";
        private const string MaxAndCurrentClipSize = "Current/Max Clip";
        private const string MaxAmmo = "Max Ammo";
        private const string ClipSize = "Clip Size";
        private const string MaxClipSize = "Max Clip Size";
        private const string SuppressorCount = "Suppressor Count";

        private string selectedM1911A1Option;
        private string selectedMK22Option;
        private string selectedXM16E1Option;
        private string selectedSAAOption;
        private string selectedM37Option;
        private string selectedSVDOption;
        private string selectedAK47Option;
        private string selectedMosinOption;
        private string selectedRPG7Option;
        private string selectedM63Option;
        private string selectedScorpionOption;
        private string selectedGrenadeOption;
        private string selectedWpGrenadeOption;
        private string selectedSmokeGrenadeOption;
        private string selectedStunGrenadeOption;
        private string selectedChaffGrenadeOption;
        private string selectedMagazineOption;
        private string selectedHandkerchiefOption;
        private string selectedCigSprayOption;
        private string selectedTNTOption;
        private string selectedMousetrapOption;
        private string selectedBookOption;
        private string selectedClaymoreOption;


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #region Weapon Toggles
        private void AddPatriot_Click(object sender, EventArgs e)
        {
            ToggleWeapon(Patriot, true);
            LoggingManager.Instance.Log("Added Patriot");
        }

        private void RemovePatriot_Click(object sender, EventArgs e)
        {
            ToggleWeapon(Patriot, false);
            LoggingManager.Instance.Log("Removed Patriot");
        }

        private void AddEz_Click(object sender, EventArgs e)
        {
            ToggleWeapon(EzGun, true);
            LoggingManager.Instance.Log("Added EZ Gun");
        }

        private void RemoveEz_Click(object sender, EventArgs e)
        {
            ToggleWeapon(EzGun, false);
            LoggingManager.Instance.Log("Removed EZ Gun");
        }

        private void AddKnife_Click(object sender, EventArgs e)
        {
            ToggleWeapon(SurvivalKnife, true);
            LoggingManager.Instance.Log("Added Survival Knife");
        }

        private void RemoveKnife_Click(object sender, EventArgs e)
        {
            ToggleWeapon(SurvivalKnife, false);
            LoggingManager.Instance.Log("Removed Survival Knife");
        }

        private void AddFork_Click(object sender, EventArgs e)
        {
            ToggleWeapon(Fork, true);
            LoggingManager.Instance.Log("Added Fork");
        }

        private void RemoveFork_Click(object sender, EventArgs e)
        {
            ToggleWeapon(Fork, false);
            LoggingManager.Instance.Log("Removed Fork");
        }

        private void AddTorch_Click(object sender, EventArgs e)
        {
            ToggleWeapon(Torch, true);
            LoggingManager.Instance.Log("Added Torch");
        }

        private void RemoveTorch_Click(object sender, EventArgs e)
        {
            ToggleWeapon(Torch, false);
            LoggingManager.Instance.Log("Removed Torch");
        }

        private void AddDMic_Click(object sender, EventArgs e)
        {
            ToggleWeapon(DirectionalMic, true);
            LoggingManager.Instance.Log("Added Directional Mic");
        }

        private void RemoveDMic_Click(object sender, EventArgs e)
        {
            ToggleWeapon(DirectionalMic, false);
            LoggingManager.Instance.Log("Removed Directional Mic");
        }
        #endregion

        private void M1911A1Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedM1911A1Option = (string)comboBox.SelectedItem;
        }

        private void ChangeM1911A1_Click(object sender, EventArgs e)
        {
            string textBoxValue = M1911A1TextBox.Text;

            switch (selectedM1911A1Option)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(M1911A1, textBoxValue);
                    LoggingManager.Instance.Log("Changed M1911A1 Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(M1911A1, textBoxValue);
                    LoggingManager.Instance.Log("Changed M1911A1 Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(M1911A1, textBoxValue);
                    LoggingManager.Instance.Log("Changed M1911A1 Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(M1911A1, textBoxValue);
                    LoggingManager.Instance.Log("Changed M1911A1 Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(M1911A1, textBoxValue);
                    LoggingManager.Instance.Log("Changed M1911A1 Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(M1911A1, textBoxValue);
                    LoggingManager.Instance.Log("Changed M1911A1 Max Clip Size to: " + textBoxValue);
                    break;
                case SuppressorCount:
                    ModifyItemCapacity(M1911A1Surpressor, textBoxValue);
                    LoggingManager.Instance.Log("Changed M1911A1 Suppressor Count to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the M1911A1.");
                    break;
            }
        }

        private void MK22Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedMK22Option = (string)comboBox.SelectedItem;
        }

        private void ChangeMK22_Click(object sender, EventArgs e)
        {
            string textBoxValue = MK22TextBox.Text;

            switch (selectedMK22Option)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(MK22, textBoxValue);
                    LoggingManager.Instance.Log("Changed MK22 Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(MK22, textBoxValue);
                    LoggingManager.Instance.Log("Changed MK22 Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(MK22, textBoxValue);
                    LoggingManager.Instance.Log("Changed MK22 Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(MK22, textBoxValue);
                    LoggingManager.Instance.Log("Changed MK22 Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(MK22, textBoxValue);
                    LoggingManager.Instance.Log("Changed MK22 Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(MK22, textBoxValue);
                    LoggingManager.Instance.Log("Changed MK22 Max Clip Size to: " + textBoxValue);
                    break;
                case SuppressorCount:
                    ModifyItemCapacity(MK22Surpressor, textBoxValue);
                    LoggingManager.Instance.Log("Changed MK22 Suppressor Count to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the MK22.");
                    break;
            }
        }

        private void XM16E1Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedXM16E1Option = (string)comboBox.SelectedItem;
        }

        private void ChangeXM16E1_Click(object sender, EventArgs e)
        {
            string textBoxValue = XM16E1TextBox.Text;

            switch (selectedXM16E1Option)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(XM16E1, textBoxValue);
                    LoggingManager.Instance.Log("Changed XM16E1 Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(XM16E1, textBoxValue);
                    LoggingManager.Instance.Log("Changed XM16E1 Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(XM16E1, textBoxValue);
                    LoggingManager.Instance.Log("Changed XM16E1 Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(XM16E1, textBoxValue);
                    LoggingManager.Instance.Log("Changed XM16E1 Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(XM16E1, textBoxValue);
                    LoggingManager.Instance.Log("Changed XM16E1 Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(XM16E1, textBoxValue);
                    LoggingManager.Instance.Log("Changed XM16E1 Max Clip Size to: " + textBoxValue);
                    break;
                case SuppressorCount:
                    ModifyItemCapacity(XM16E1Surpressor, textBoxValue);
                    LoggingManager.Instance.Log("Changed XM16E1 Suppressor Count to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the XM16E1.");
                    break;
            }
        }

        private void SAADropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedSAAOption = (string)comboBox.SelectedItem;
        }

        private void ChangeSAA_Click(object sender, EventArgs e)
        {
            string textBoxValue = SAATextBox.Text;

            switch (selectedSAAOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(SAA, textBoxValue);
                    LoggingManager.Instance.Log("Changed SAA Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(SAA, textBoxValue);
                    LoggingManager.Instance.Log("Changed SAA Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(SAA, textBoxValue);
                    LoggingManager.Instance.Log("Changed SAA Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(SAA, textBoxValue);
                    LoggingManager.Instance.Log("Changed SAA Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(SAA, textBoxValue);
                    LoggingManager.Instance.Log("Changed SAA Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(SAA, textBoxValue);
                    LoggingManager.Instance.Log("Changed SAA Max Clip Size to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the SAA.");
                    break;
            }
        }

        private void M37Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedM37Option = (string)comboBox.SelectedItem;
        }

        private void ChangeM37_Click(object sender, EventArgs e)
        {
            string textBoxValue = M37TextBox.Text;

            switch (selectedM37Option)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(M37, textBoxValue);
                    LoggingManager.Instance.Log("Changed M37 Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(M37, textBoxValue);
                    LoggingManager.Instance.Log("Changed M37 Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(M37, textBoxValue);
                    LoggingManager.Instance.Log("Changed M37 Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(M37, textBoxValue);
                    LoggingManager.Instance.Log("Changed M37 Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(M37, textBoxValue);
                    LoggingManager.Instance.Log("Changed M37 Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(M37, textBoxValue);
                    LoggingManager.Instance.Log("Changed M37 Max Clip Size to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the M37.");
                    break;
            }
        }

        private void SVDDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedSVDOption = (string)comboBox.SelectedItem;
        }

        private void ChangeSVD_Click(object sender, EventArgs e)
        {
            string textBoxValue = SVDTextBox.Text;

            switch (selectedSVDOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(SVD, textBoxValue);
                    LoggingManager.Instance.Log("Changed SVD Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(SVD, textBoxValue);
                    LoggingManager.Instance.Log("Changed SVD Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(SVD, textBoxValue);
                    LoggingManager.Instance.Log("Changed SVD Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(SVD, textBoxValue);
                    LoggingManager.Instance.Log("Changed SVD Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(SVD, textBoxValue);
                    LoggingManager.Instance.Log("Changed SVD Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(SVD, textBoxValue);
                    LoggingManager.Instance.Log("Changed SVD Max Clip Size to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the SVD.");
                    break;
            }
        }

        private void MosinDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedMosinOption = (string)comboBox.SelectedItem;
        }

        private void ChangeMosin_Click(object sender, EventArgs e)
        {
            string textBoxValue = MosinTextBox.Text;

            switch (selectedMosinOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(Mosin, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mosin Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(Mosin, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mosin Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(Mosin, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mosin Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(Mosin, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mosin Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(Mosin, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mosin Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(Mosin, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mosin Max Clip Size to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Mosin.");
                    break;
            }
        }

        private void RPG7Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedRPG7Option = (string)comboBox.SelectedItem;
        }

        private void ChangeRPG_Click(object sender, EventArgs e)
        {
            string textBoxValue = RPG7TextBox.Text;

            switch (selectedRPG7Option)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(RPG7, textBoxValue);
                    LoggingManager.Instance.Log("Changed RPG7 Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(RPG7, textBoxValue);
                    LoggingManager.Instance.Log("Changed RPG7 Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(RPG7, textBoxValue);
                    LoggingManager.Instance.Log("Changed RPG7 Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(RPG7, textBoxValue);
                    LoggingManager.Instance.Log("Changed RPG7 Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(RPG7, textBoxValue);
                    LoggingManager.Instance.Log("Changed RPG7 Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(RPG7, textBoxValue);
                    LoggingManager.Instance.Log("Changed RPG7 Max Clip Size to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the RPG7.");
                    break;
            }
        }

        private void AK47Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedAK47Option = (string)comboBox.SelectedItem;
        }

        private void ChangeAK47_Click(object sender, EventArgs e)
        {
            string textBoxValue = AK47TextBox.Text;

            switch (selectedAK47Option)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(AK47, textBoxValue);
                    LoggingManager.Instance.Log("Changed AK47 Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(AK47, textBoxValue);
                    LoggingManager.Instance.Log("Changed AK47 Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(AK47, textBoxValue);
                    LoggingManager.Instance.Log("Changed AK47 Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(AK47, textBoxValue);
                    LoggingManager.Instance.Log("Changed AK47 Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(AK47, textBoxValue);
                    LoggingManager.Instance.Log("Changed AK47 Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(AK47, textBoxValue);
                    LoggingManager.Instance.Log("Changed AK47 Max Clip Size to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the AK47.");
                    break;
            }
        }

        private void M63Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedM63Option = (string)comboBox.SelectedItem;
        }

        private void ChangeM63_Click(object sender, EventArgs e)
        {
            string textBoxValue = M63TextBox.Text;

            switch (selectedM63Option)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(M63, textBoxValue);
                    LoggingManager.Instance.Log("Changed M63 Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(M63, textBoxValue);
                    LoggingManager.Instance.Log("Changed M63 Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(M63, textBoxValue);
                    LoggingManager.Instance.Log("Changed M63 Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(M63, textBoxValue);
                    LoggingManager.Instance.Log("Changed M63 Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(M63, textBoxValue);
                    LoggingManager.Instance.Log("Changed M63 Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(M63, textBoxValue);
                    LoggingManager.Instance.Log("Changed M63 Max Clip Size to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the M63.");
                    break;
            }
        }

        private void ScorpionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedScorpionOption = (string)comboBox.SelectedItem;
        }

        private void ChangeScorpion_Click(object sender, EventArgs e)
        {
            string textBoxValue = ScorpionTextBox.Text;

            switch (selectedScorpionOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(Scorpion, textBoxValue);
                    LoggingManager.Instance.Log("Changed Scorpion Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(Scorpion, textBoxValue);
                    LoggingManager.Instance.Log("Changed Scorpion Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(Scorpion, textBoxValue);
                    LoggingManager.Instance.Log("Changed Scorpion Max Ammo to: " + textBoxValue);
                    break;
                case MaxAndCurrentClipSize:
                    ModifyCurrentAndMaxClipSize(Scorpion, textBoxValue);
                    LoggingManager.Instance.Log("Changed Scorpion Current and Max Clip Size to: " + textBoxValue);
                    break;
                case ClipSize:
                    ModifyClipSize(Scorpion, textBoxValue);
                    LoggingManager.Instance.Log("Changed Scorpion Clip Size to: " + textBoxValue);
                    break;
                case MaxClipSize:
                    ModifyMaxClipSize(Scorpion, textBoxValue);
                    LoggingManager.Instance.Log("Changed Scorpion Max Clip Size to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Scorpion.");
                    break;
            }
        }

        private void GrenadeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedGrenadeOption = (string)comboBox.SelectedItem;
        }

        private void ChangeGrenade_Click(object sender, EventArgs e)
        {
            string textBoxValue = GrenadeTextBox.Text;

            switch (selectedGrenadeOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(Grenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Grenade Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(Grenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Grenade Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(Grenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Grenade Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Grenade.");
                    break;
            }

        }

        private void WpGrenadeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedWpGrenadeOption = (string)comboBox.SelectedItem;
        }

        private void ChangeWp_Click(object sender, EventArgs e)
        {
            string textBoxValue = WpGrenadeTextBox.Text;

            switch (selectedWpGrenadeOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(WpGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Wp Grenade Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(WpGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Wp Grenade Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(WpGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Wp Grenade Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Wp Grenade.");
                    break;
            }

        }

        private void SmokeGrenadeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedSmokeGrenadeOption = (string)comboBox.SelectedItem;
        }

        private void ChangeSmoke_Click(object sender, EventArgs e)
        {
            string textBoxValue = SmokeGrenadeTextBox.Text;

            switch (selectedSmokeGrenadeOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(SmokeGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Smoke Grenade Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(SmokeGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Smoke Grenade Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(SmokeGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Smoke Grenade Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Smoke Grenade.");
                    break;
            }

        }

        private void StunGrenadeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedStunGrenadeOption = (string)comboBox.SelectedItem;
        }

        private void ChangeStun_Click(object sender, EventArgs e)
        {
            string textBoxValue = StunGrenadeTextBox.Text;

            switch (selectedStunGrenadeOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(StunGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Stun Grenade Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(StunGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Stun Grenade Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(StunGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Stun Grenade Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Stun Grenade.");
                    break;
            }

        }

        private void ChaffGrenadeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedChaffGrenadeOption = (string)comboBox.SelectedItem;
        }

        private void ChangeChaff_Click(object sender, EventArgs e)
        {
            string textBoxValue = ChaffGrenadeTextBox.Text;

            switch (selectedChaffGrenadeOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(ChaffGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Chaff Grenade Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(ChaffGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Chaff Grenade Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(ChaffGrenade, textBoxValue);
                    LoggingManager.Instance.Log("Changed Chaff Grenade Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Chaff Grenade.");
                    break;
            }

        }

        private void MagazineDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedMagazineOption = (string)comboBox.SelectedItem;
        }

        private void ChangeMagazine_Click(object sender, EventArgs e)
        {
            string textBoxValue = MagazineTextBox.Text;

            switch (selectedMagazineOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(EmptyMag, textBoxValue);
                    LoggingManager.Instance.Log("Changed Empty Magazine Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(EmptyMag, textBoxValue);
                    LoggingManager.Instance.Log("Changed Empty Magazine Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(EmptyMag, textBoxValue);
                    LoggingManager.Instance.Log("Changed Empty Magazine Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Empty Magazine.");
                    break;
            }

        }

        private void HandkerchiefDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedHandkerchiefOption = (string)comboBox.SelectedItem;
        }

        private void ChangeHandkerchief_Click(object sender, EventArgs e)
        {
            string textBoxValue = HandkerchiefTextBox.Text;

            switch (selectedHandkerchiefOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(Handkerchief, textBoxValue);
                    LoggingManager.Instance.Log("Changed Handkerchief Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(Handkerchief, textBoxValue);
                    LoggingManager.Instance.Log("Changed Handkerchief Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(Handkerchief, textBoxValue);
                    LoggingManager.Instance.Log("Changed Handkerchief Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Handkerchief.");
                    break;
            }
        }

        private void CigSprayDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedCigSprayOption = (string)comboBox.SelectedItem;
        }

        private void ChangeCigSpray_Click(object sender, EventArgs e)
        {
            string textBoxValue = CigSprayTextBox.Text;

            switch (selectedCigSprayOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(CigSpray, textBoxValue);
                    LoggingManager.Instance.Log("Changed Cig Spray Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(CigSpray, textBoxValue);
                    LoggingManager.Instance.Log("Changed Cig Spray Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(CigSpray, textBoxValue);
                    LoggingManager.Instance.Log("Changed Cig Spray Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Cig Spray.");
                    break;
            }
        }

        private void TNTDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedTNTOption = (string)comboBox.SelectedItem;
        }

        private void ChangeTNT_Click(object sender, EventArgs e)
        {
            string textBoxValue = TNTTextBox.Text;

            switch (selectedTNTOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(TNT, textBoxValue);
                    LoggingManager.Instance.Log("Changed TNT Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(TNT, textBoxValue);
                    LoggingManager.Instance.Log("Changed TNT Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(TNT, textBoxValue);
                    LoggingManager.Instance.Log("Changed TNT Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the TNT.");
                    break;
            }
        }

        private void BookDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedBookOption = (string)comboBox.SelectedItem;
        }

        private void ChangeBook_Click(object sender, EventArgs e)
        {
            string textBoxValue = BookTextBox.Text;

            switch (selectedBookOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(Book, textBoxValue);
                    LoggingManager.Instance.Log("Changed Book Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(Book, textBoxValue);
                    LoggingManager.Instance.Log("Changed Book Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(Book, textBoxValue);
                    LoggingManager.Instance.Log("Changed Book Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Book.");
                    break;
            }
        }

        private void ClaymoreDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedClaymoreOption = (string)comboBox.SelectedItem;
        }

        private void ChangeClaymore_Click(object sender, EventArgs e)
        {
            string textBoxValue = ClaymoreTextBox.Text;

            switch (selectedClaymoreOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(Claymore, textBoxValue);
                    LoggingManager.Instance.Log("Changed Claymore Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(Claymore, textBoxValue);
                    LoggingManager.Instance.Log("Changed Claymore Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(Claymore, textBoxValue);
                    LoggingManager.Instance.Log("Changed Claymore Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Claymore.");
                    break;
            }
        }

        private void MousetrapDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedMousetrapOption = (string)comboBox.SelectedItem;
        }

        private void ChangeMousetrap_Click(object sender, EventArgs e)
        {
            string textBoxValue = MousetrapTextbox.Text;

            switch (selectedMousetrapOption)
            {
                case CurrentAndMax:
                    ModifyCurrentAndMaxAmmo(Mousetrap, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mousetrap Current and Max Ammo to: " + textBoxValue);
                    break;
                case CurrentAmmo:
                    ModifyAmmo(Mousetrap, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mousetrap Current Ammo to: " + textBoxValue);
                    break;
                case MaxAmmo:
                    ModifyMaxAmmo(Mousetrap, textBoxValue);
                    LoggingManager.Instance.Log("Changed Mousetrap Max Ammo to: " + textBoxValue);
                    break;
                default:
                    MessageBox.Show("Invalid option selected or no option selected.");
                    LoggingManager.Instance.Log("Invalid option selected or no option selected for the Mousetrap.");
                    break;
            }
        }

        private void ChangeAllChecked_Click(object sender, EventArgs e)
        {
            if (!short.TryParse(AllTextbox.Text, out short ammoValue))
            {
                MessageBox.Show("Invalid ammo value.");
                return;
            }

            foreach (var itemChecked in AllWeaponsChecklist.CheckedItems)
            {
                var weaponName = itemChecked.ToString();
                var weapon = GetWeaponByName(weaponName);

                if (weapon != null)
                {
                    ModifyAmmo(weapon, ammoValue.ToString());
                    LoggingManager.Instance.Log("Changed " + weaponName + " Current Ammo to: " + ammoValue);
                    ModifyMaxAmmo(weapon, ammoValue.ToString());
                    LoggingManager.Instance.Log("Changed " + weaponName + " Max Ammo to: " + ammoValue);
                }
            }
        }

        private Weapon GetWeaponByName(string name)
        {
            switch (name)
            {
                case "M1911A1": return M1911A1;
                case "MK22": return MK22;
                case "XM16E1": return XM16E1;
                case "SAA": return SAA;
                case "M37": return M37;
                case "SVD": return SVD;
                case "AK-47": return AK47;
                case "Mosin Nagant": return Mosin;
                case "RPG-7": return RPG7;
                case "M63": return M63;
                case "Scorpion": return Scorpion;
                case "Grenade": return Grenade;
                case "Wp Grenade": return WpGrenade;
                case "Smoke Grenade": return SmokeGrenade;
                case "Stun Grenade": return StunGrenade;
                case "Chaff Grenade": return ChaffGrenade;
                case "Empty Magazine": return EmptyMag;
                case "Handkerchief": return Handkerchief;
                case "Cig Spray": return CigSpray;
                case "C3": return C3;
                case "TNT": return TNT;
                case "Book": return Book;
                case "Claymore": return Claymore;
                case "Mousetrap": return Mousetrap;
                default: return null;
            }
        }

        public void CheckInfiniteAmmoStatus()
        {
            if (EffectManager.Instance.IsInfiniteAmmoDisabled())
            {
                InfAmmoNoReloadCheckBox.Checked = false;
            }
            else
            {
                InfAmmoNoReloadCheckBox.Checked = true;
            }
        }

        public void CheckNoReloadStatus()
        {
            if (EffectManager.Instance.IsNoReloadDisabled())
            {
                NoReloadCheckBox.Checked = false;
            }
            else
            {
                NoReloadCheckBox.Checked = true;
            }
        }

        public void CheckInfiniteSuppressorsStatus()
        {
            InfiniteSuppressorsCheckBox.Checked = TimerManager.IsInfiniteSuppressorEnabled;
        }

        private void InfAmmoNoReloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InfAmmoNoReloadCheckBox.Checked)
            {
                EffectManager.Instance.EnableInfiniteAmmo();
            }
            else
            {
                EffectManager.Instance.DisableInfiniteAmmo();
            }
        }
        private void InfiniteSuppressorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InfiniteSuppressorsCheckBox.Checked)
            {
                TimerManager.ToggleInfiniteSuppressor(true);
            }
            else
            {
                TimerManager.ToggleInfiniteSuppressor(false);
            }
        }

        private void NoReloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NoReloadCheckBox.Checked)
            {
                EffectManager.Instance.EnableNoReload();
            }
            else
            {
                EffectManager.Instance.DisableNoReload();
            }
        }

        private void SwapToItemsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("Navigating to Item Form from the Weapon Form");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "ItemForm");
            ItemForm form2 = new ItemForm();
            form2.Show();
            this.Hide();
        }

        private void SwapToCamoForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Camo form from the Weapon Form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "CamoForm");
            CamoForm form3 = new();
            form3.Show();
            this.Hide();

        }

        private void StatsAndAlertForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Stats and Alert from the Weapon form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "StatsAndAlertForm");
            StatsAndAlertForm form5 = new();
            form5.Show();
            this.Hide();
        }

        private void MiscFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Misc page from the Weapons Form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "MiscForm");
            MiscForm form4 = new();
            form4.Show();
            this.Hide();
        }
    }
}