using System;
using static ANTIBigBoss_s_MGS_Delta_Trainer.MGS3UsableObjects;
using System.Windows.Forms;


namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public partial class ItemForm : Form
    {

        public ItemForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);

            // Setting all to 999 saves the user time if they just want to cheat everything in
            LifeMedtextBox.Text = "999";
            BugJuicetextBox.Text = "999";
            FDPtextBox.Text = "999";
            PentazemintextBox.Text = "999";
            AntidotetextBox.Text = "999";
            CMedtextBox.Text = "999";
            DMedtextBox.Text = "999";
            SerumtextBox.Text = "999";
            BandagetextBox.Text = "999";
            DisinfectanttextBox.Text = "999";
            OintmenttextBox.Text = "999";
            SplinttextBox.Text = "999";
            StyptictextBox.Text = "999";
            SutureKittextBox.Text = "999";
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = MemoryManager.GetLastFormLocation();
            CheckInfiniteBatteryStatus();
        }

        private void AddLifeMed_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(LifeMed, LifeMedtextBox.Text);
        }


        private void AddBugJuice_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(BugJuice, BugJuicetextBox.Text);
        }

        private void AddFDP_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(FakeDeathPill, FDPtextBox.Text);
        }

        private void AddPentazemin_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(Pentazemin, PentazemintextBox.Text);
        }

        private void AddAntidote_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(Antidote, AntidotetextBox.Text);
        }

        private void AddCMed_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(ColdMedicine, CMedtextBox.Text);
        }

        private void AddDMed_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(DigestiveMedicine, DMedtextBox.Text);
        }

        private void AddSerum_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(Serum, SerumtextBox.Text);
        }

        private void AddBandage_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(Bandage, BandagetextBox.Text);
        }

        private void AddDisinfectant_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(Disinfectant, DisinfectanttextBox.Text);
        }

        private void AddOintment_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(Ointment, OintmenttextBox.Text);
        }

        private void AddSplint_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(Splint, SplinttextBox.Text);
        }

        private void AddStyptic_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(Styptic, StyptictextBox.Text);
        }

        private void AddSutureKit_Click(object sender, EventArgs e)
        {
            ModifyItemCapacity(SutureKit, SutureKittextBox.Text);
        }

        private void AddCigar_Click(object sender, EventArgs e)
        {
            ToggleItemState(Cigar, true);
        }

        private void RemoveCigar_Click(object sender, EventArgs e)
        {
            ToggleItemState(Cigar, false);
        }

        private void AddBinos_Click(object sender, EventArgs e)
        {
            ToggleItemState(Binoculars, true);
        }

        private void RemoveBinos_Click(object sender, EventArgs e)
        {
            ToggleItemState(Binoculars, false);
        }

        private void AddThermal_Click(object sender, EventArgs e)
        {
            ToggleItemState(ThermalGoggles, true);
        }

        private void RemoveThermal_Click(object sender, EventArgs e)
        {
            ToggleItemState(ThermalGoggles, false);
        }

        private void AddNVG_Click(object sender, EventArgs e)
        {
            ToggleItemState(NightVisionGoggles, true);
        }

        private void RemoveNVG_Click(object sender, EventArgs e)
        {
            ToggleItemState(NightVisionGoggles, false);
        }

        private void AddCamera_Click(object sender, EventArgs e)
        {
            ToggleItemState(Camera, true);
        }

        private void RemoveCamera_Click(object sender, EventArgs e)
        {
            ToggleItemState(Camera, false);
        }

        private void AddMotionD_Click(object sender, EventArgs e)
        {
            ToggleItemState(MotionDetector, true);
        }

        private void RemoveMotionD_Click(object sender, EventArgs e)
        {
            ToggleItemState(MotionDetector, false);
        }

        private void AddSonar_Click(object sender, EventArgs e)
        {
            ToggleItemState(ActiveSonar, true);
        }

        private void RemoveSonar_Click(object sender, EventArgs e)
        {
            ToggleItemState(ActiveSonar, false);
        }

        private void AddMineD_Click(object sender, EventArgs e)
        {
            ToggleItemState(MineDetector, true);
        }

        private void RemoveMineD_Click(object sender, EventArgs e)
        {
            ToggleItemState(MineDetector, false);
        }

        private void AddApSensor_Click(object sender, EventArgs e)
        {
            ToggleItemState(AntiPersonnelSensor, true);
        }

        private void RemoveApSensor_Click(object sender, EventArgs e)
        {
            ToggleItemState(AntiPersonnelSensor, false);
        }

        private void AddBoxA_Click(object sender, EventArgs e)
        {
            ToggleItemState(CBoxA, true);
        }

        private void RemoveBoxA_Click(object sender, EventArgs e)
        {
            ToggleItemState(CBoxA, false);
        }

        private void AddBoxB_Click(object sender, EventArgs e)
        {
            ToggleItemState(CBoxB, true);
        }

        private void RemoveBoxB_Click(object sender, EventArgs e)
        {
            ToggleItemState(CBoxB, false);
        }

        private void AddBoxC_Click(object sender, EventArgs e)
        {
            ToggleItemState(CBoxC, true);
        }

        private void RemoveBoxC_Click(object sender, EventArgs e)
        {
            ToggleItemState(CBoxC, false);
        }

        private void AddBoxD_Click(object sender, EventArgs e)
        {
            ToggleItemState(CBoxD, true);
        }

        private void RemoveBoxD_Click(object sender, EventArgs e)
        {
            ToggleItemState(CBoxD, false);
        }

        private void AddCrocCap_Click(object sender, EventArgs e)
        {
            ToggleItemState(CrocCap, true);
        }

        private void RemoveCrocCap_Click(object sender, EventArgs e)
        {
            ToggleItemState(CrocCap, false);
        }

        private void AddStealth_Click(object sender, EventArgs e)
        {
            ToggleItemState(StealthCamo, true);
        }

        private void RemoveStealth_Click(object sender, EventArgs e)
        {
            ToggleItemState(StealthCamo, false);
        }

        private void AddCompass_Click(object sender, EventArgs e)
        {
            ToggleItemState(Compass, true);
        }

        private void RemoveCompass_Click(object sender, EventArgs e)
        {
            ToggleItemState(Compass, false);
        }

        private void AddAtCamo_Click(object sender, EventArgs e)
        {
            ToggleItemState(AtCamo, true);
        }

        private void RemoveAtCamo_Click(object sender, EventArgs e)
        {
            ToggleItemState(AtCamo, false);
        }

        private void AddBananaCap_Click(object sender, EventArgs e)
        {
            ToggleItemState(MonkeyMask, true);
        }

        private void RemoveBananaCap_Click(object sender, EventArgs e)
        {
            ToggleItemState(MonkeyMask, false);
        }

        private void AddBananaCapGold_Click(object sender, EventArgs e)
        {
            ToggleItemState(BananaCapGold, true);
        }

        private void RemoveBananaCapGold_Click(object sender, EventArgs e)
        {
            ToggleItemState(BananaCapGold, false);
        }

        private void AddAll_Click(object sender, EventArgs e)
        {
            ToggleItemState(Cigar, true);
            ToggleItemState(Binoculars, true);
            ToggleItemState(ThermalGoggles, true);
            ToggleItemState(NightVisionGoggles, true);
            ToggleItemState(Camera, true);
            ToggleItemState(MotionDetector, true);
            ToggleItemState(ActiveSonar, true);
            ToggleItemState(MineDetector, true);
            ToggleItemState(AntiPersonnelSensor, true);
            ToggleItemState(CBoxA, true);
            ToggleItemState(CBoxB, true);
            ToggleItemState(CBoxC, true);
            ToggleItemState(CBoxD, true);
            ToggleItemState(CrocCap, true);
            ToggleItemState(StealthCamo, true);
            ToggleItemState(Compass, true);
            ToggleItemState(AtCamo, true);
            ToggleItemState(MonkeyMask, true);
            ToggleItemState(BananaCapGold, true);
        }

        private void RemoveAll_Click(object sender, EventArgs e)
        {
            ToggleItemState(Cigar, false);
            ToggleItemState(Binoculars, false);
            ToggleItemState(ThermalGoggles, false);
            ToggleItemState(NightVisionGoggles, false);
            ToggleItemState(Camera, false);
            ToggleItemState(MotionDetector, false);
            ToggleItemState(ActiveSonar, false);
            ToggleItemState(MineDetector, false);
            ToggleItemState(AntiPersonnelSensor, false);
            ToggleItemState(CBoxA, false);
            ToggleItemState(CBoxB, false);
            ToggleItemState(CBoxC, false);
            ToggleItemState(CBoxD, false);
            ToggleItemState(CrocCap, false);
            ToggleItemState(StealthCamo, false);
            ToggleItemState(Compass, false);
            ToggleItemState(AtCamo, false);
            ToggleItemState(MonkeyMask, false);
            ToggleItemState(BananaCapGold, false);
        }

        private void SwapToWeaponsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Weapon form from the Item form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "WeaponForm");
            WeaponForm form1 = new();
            form1.Show();
            this.Hide();
        }

        private void SwapToCamoForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Camo form from the Item form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "CamoForm");
            CamoForm form3 = new();
            form3.Show();
            this.Hide();

        }

        private void StatsAndAlertForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Stats and Alert from the Item form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "StatsAndAlertForm");
            StatsAndAlertForm form5 = new();
            form5.Show();
            this.Hide();
        }

        private void BatteryDrainCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BatteryDrainCheckBox.Checked)
            {
                EffectManager.Instance.EnableInfiniteBattery();
            }
            else
            {
                EffectManager.Instance.DisableInfiniteBattery();
            }
        }

        // Helper method to check the battery status and update the checkbox
        public void CheckInfiniteBatteryStatus()
        {
            if (EffectManager.Instance.IsInfiniteBatteryEnabled())
            {
                BatteryDrainCheckBox.Checked = true;
            }
            else
            {
                BatteryDrainCheckBox.Checked = false;
            }
        }

        private void MiscFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Misc page from the Items Form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "MiscForm");
            MiscForm form4 = new();
            form4.Show();
            this.Hide();
        }
    }
}