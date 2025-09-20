using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ANTIBigBoss_s_MGS_Delta_Trainer.Constants;
using static ANTIBigBoss_s_MGS_Delta_Trainer.HelperMethods;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public partial class StatsAndAlertForm : Form
    {
        private bool infiniteAlertCheckboxState;
        private bool infiniteEvasionCheckboxState;
        private bool infiniteCautionCheckboxState;
        private System.Windows.Forms.Timer continuousMonitoringTimer;

        #region Form Initialization

        public StatsAndAlertForm()
        {
            InitializeComponent();
            InitializeFormEvents();
            InitializeProgressBars();
            InitializeCheckboxStates();
            InitializeMonitoringTimer();
        }

        private void InitializeFormEvents()
        {
            this.Load += StatsAndAlertForm_Load;
            this.FormClosing += StatsAndAlertForm_FormClosing;
        }

        private void InitializeProgressBars()
        {
            AlertProgressBar.Minimum = 0;
            AlertProgressBar.Maximum = 18000;
            AlertProgressBar.ProgressBarColour = Color.Red;

            EvasionProgressBar.Minimum = 0;
            EvasionProgressBar.Maximum = 18000;
            EvasionProgressBar.ProgressBarColour = Color.Orange;

            CautionProgressBar.Minimum = 0;
            CautionProgressBar.Maximum = 18000;
            CautionProgressBar.ProgressBarColour = Color.Yellow;
        }

        private void InitializeCheckboxStates()
        {
            InfiniteAlert.Checked = TimerManager.IsInfiniteAlertEnabled;
            InfiniteEvasion.Checked = TimerManager.IsInfiniteEvasionEnabled;
            InfiniteCaution.Checked = TimerManager.IsInfiniteCautionEnabled;

            infiniteAlertCheckboxState = InfiniteAlert.Checked;
            infiniteEvasionCheckboxState = InfiniteEvasion.Checked;
            infiniteCautionCheckboxState = InfiniteCaution.Checked;
        }

        private void InitializeMonitoringTimer()
        {
            continuousMonitoringTimer = new System.Windows.Forms.Timer();
            continuousMonitoringTimer.Interval = 1000;
            continuousMonitoringTimer.Tick += ContinuousMonitoringTimer_Tick;
            continuousMonitoringTimer.Start();
        }

        private async void StatsAndAlertForm_Load(object sender, EventArgs e)
        {
            this.Location = MemoryManager.GetLastFormLocation();
            CheckInfLifeSnakeStatus();
        }

        #endregion

        #region Damage Radio Button Event Handlers

        // Lethal Damage
        private void NeckSnapLethalRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (NeckSnapLethalRadio.Checked)
                GuardManager.Instance.WriteAllLethalInvincibleValues();
        }

        private void VeryStrongLethalRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (VeryStrongLethalRadio.Checked)
                GuardManager.Instance.WriteAllLethalVeryStrongValues();
        }

        private void NormalLethalRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (NormalLethalRadio.Checked)
                GuardManager.Instance.WriteAllLethalDefaultValues();
        }

        private void VeryWeakLethalRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (VeryWeakLethalRadio.Checked)
                GuardManager.Instance.WriteAllLethalVeryWeakValues();
        }

        private void OneShotKillLethalRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (OneShotKillLethalRadio.Checked)
                GuardManager.Instance.WriteAllLethalOneshotValues();
        }

        private void GuardsTake2xDamageRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (GuardsTake2xDamageRadio.Checked)
                GuardManager.Instance.WriteAllLethalx2Values();
        }

        private void GuardsTake3xDamageRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (GuardsTake3xDamageRadio.Checked)
                GuardManager.Instance.WriteAllLethalx10Values();
        }

        // Sleep Damage
        private void InvincibleZzzRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (InvincibleZzzRadio.Checked)
                GuardManager.Instance.WriteAllSleepInvincibleValues();
        }

        private void VeryStrongZzzRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (VeryStrongZzzRadio.Checked)
                GuardManager.Instance.WriteAllSleepVeryStrongValues();
        }

        private void NormalZzzRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (NormalZzzRadio.Checked)
                GuardManager.Instance.WriteAllSleepNormalValues();
        }

        private void VeryWeakZzzRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (VeryWeakZzzRadio.Checked)
                GuardManager.Instance.WriteAllSleepVeryWeakValues();
        }

        private void OneShotSleepZzzRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (OneShotSleepZzzRadio.Checked)
                GuardManager.Instance.WriteAllSleepOneShotValues();
        }

        // Stun Damage
        private void NeckSnapStunRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (NeckSnapStunRadio.Checked)
                GuardManager.Instance.WriteAllStunInvincibleValues();
        }

        private void VeryStrongStunRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (VeryStrongStunRadio.Checked)
                GuardManager.Instance.WriteAllStunVeryStrongValues();
        }

        private void NormalStunRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (NormalStunRadio.Checked)
                GuardManager.Instance.WriteAllStunDefaultValues();
        }

        private void VeryWeakStunRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (VeryWeakStunRadio.Checked)
                GuardManager.Instance.WriteAllStunVeryWeakValues();
        }

        private void OneShotStunStunRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (OneShotStunStunRadio.Checked)
                GuardManager.Instance.WriteAllStunOneshotValues();
        }

        #endregion

        private void StatsAndAlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            continuousMonitoringTimer?.Stop();
            Application.Exit();
        }

        #region Snake's Health and Stamina
        // Health and Stamina along with pointer logic
        private void Plus100HpValue_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.CurrentHealth, 100);
        }

        private void Minus100HpValue_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.CurrentHealth, -100);
        }

        private void CurrentHpTo1_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.CurrentHealth, 1, true);
            LoggingManager.Instance.Log("Snake's health has been set to 1");
        }

        private void MaxHpTo1_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.MaxHealth, 1, true);
            LoggingManager.Instance.Log("Snake's Max health has been set to 1");
        }

        private void ZeroHP_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.CurrentHealth, 0, true);
            LoggingManager.Instance.Log("Snake's health has been set to 0");
        }

        private void SetStaminaToZero_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.Stamina, 0, true);
            LoggingManager.Instance.Log("Snake's stamina has been set to 0");
        }

        private void Plus10000StaminaValue_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.Stamina, 7500);
            LoggingManager.Instance.Log("Snake has gained 10000 stamina");
        }

        private void Minus10000StaminaValue_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.Stamina, -7500);
            LoggingManager.Instance.Log("Snake has lost 10000 stamina");
        }

        private void FullStamina30000Value_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.Stamina, 30000, true);
            LoggingManager.Instance.Log("Snake has gained the max 30000 stamina");
        }

        private void Plus100MaxHpValue_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.MaxHealth, 100);
            LoggingManager.Instance.Log("Snake has gained 100 health");
        }

        private void Minus100MaxHpValue_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ModifyHealthOrStamina(Constants.HealthType.MaxHealth, -100);
            LoggingManager.Instance.Log("Snake has lost 100 health");
        }
        #endregion

        #region Alert Statuses
        private void button3_Click(object sender, EventArgs e) // Alert Mode Trigger
        {
            GuardManager.TriggerAlert(AlertModes.Alert);
        }

        // This was my workaround fix to stop a double message box from showing when the user tries to check more than one infinite alert mode
        private bool suppressAlertMessages = false;

        private void InfiniteAlert_CheckedChanged(object sender, EventArgs e)
        {
            // If suppressAlertMessages is true, return without further processing
            if (suppressAlertMessages)
            {
                return;
            }

            if (InfiniteEvasion.Checked)
            {
                // The t/f statements are just to stop multiple checkboxes from being checked at once
                // As it could have unintended consequences so this was a good way to stop that
                suppressAlertMessages = true;
                InfiniteAlert.Checked = false;
                MessageBox.Show("Only one Infinite Status allowed at once. \nDeselect Evasion Mode to use this.");
                suppressAlertMessages = false;
            }
            else if (InfiniteCaution.Checked)
            {
                suppressAlertMessages = true;
                InfiniteAlert.Checked = false;
                MessageBox.Show("Only one Infinite Status allowed at once. \nDeselect Caution Mode to use this.");
                suppressAlertMessages = false;
            }
            else
            {
                // Update the class-level variable with the checkbox state
                infiniteAlertCheckboxState = InfiniteAlert.Checked;

                // Check if the checkbox is checked
                if (InfiniteAlert.Checked)
                {
                    GuardManager.TriggerAlert(AlertModes.Alert);
                    // Start the alert timer when the checkbox is checked
                    TimerManager.ToggleInfiniteAlert(true);
                }
                else
                {
                    // Stop the alert timer when the checkbox is unchecked
                    TimerManager.ToggleInfiniteAlert(false);
                }
            }
        }

        private void InfiniteCaution_CheckedChanged(object sender, EventArgs e)
        {
            if (suppressAlertMessages)
            {
                return;
            }

            if (InfiniteEvasion.Checked)
            {
                suppressAlertMessages = true; // Suppress other alert messages temporarily
                InfiniteCaution.Checked = false;
                MessageBox.Show("Only one Infinite Status allowed at once. \nDeselect Evasion Mode to use this.");
                suppressAlertMessages = false; // Allow messages to be shown again
            }
            else if (InfiniteAlert.Checked)
            {
                suppressAlertMessages = true; // Suppress other alert messages temporarily
                InfiniteCaution.Checked = false;
                MessageBox.Show("Only one Infinite Status allowed at once. \nDeselect Alert Mode to use this.");
                suppressAlertMessages = false; // Allow messages to be shown again
            }
            else
            {
                TimerManager.ToggleInfiniteCaution(InfiniteCaution.Checked);
            }
        }

        private void EvasionButton_Click(object sender, EventArgs e)
        {
            // First, find the alert memory region to read the timer values
            IntPtr alertMemoryRegion = MemoryManager.Instance.FindAob("AlertMemoryRegion");
            if (alertMemoryRegion == IntPtr.Zero)
            {
                return;
            }

            // Read current alert and evasion timer values
            short alertTimerValue = GuardManager.ReadAlertTimerValue(alertMemoryRegion);
            short evasionTimerValue = GuardManager.ReadEvasionTimerValue(alertMemoryRegion);

            // Check if either alert or evasion timer indicates an ongoing state
            if (alertTimerValue > 0 || evasionTimerValue > 0)
            {
                MessageBox.Show("Evasion cannot be triggered during active alert or evasion state.", "Action Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Safe to trigger the evasion sequence
                TimerManager.StartEvasionSequence();
            }
        }

        private void InfiniteEvasion_CheckedChanged(object sender, EventArgs e)
        {
            // If suppressAlertMessages is true, return without further processing
            if (suppressAlertMessages)
            {
                return;
            }

            if (InfiniteAlert.Checked)
            {
                suppressAlertMessages = true; // Suppress other alert messages temporarily
                InfiniteEvasion.Checked = false;
                MessageBox.Show("Only one Infinite Status allowed at once. \nDeselect Alert Mode to use this.");
                suppressAlertMessages = false; // Allow messages to be shown again
            }
            else if (InfiniteCaution.Checked)
            {
                suppressAlertMessages = true; // Suppress other alert messages temporarily
                InfiniteEvasion.Checked = false;
                MessageBox.Show("Only one Infinite Status allowed at once. \nDeselect Caution Mode to use this.");
                suppressAlertMessages = false; // Allow messages to be shown again
            }
            else
            {
                TimerManager.ToggleInfiniteEvasion(InfiniteEvasion.Checked);
            }
        }

        private void button9_Click(object sender, EventArgs e) // Caution Mode Trigger
        {
            GuardManager.TriggerAlert(AlertModes.Caution);
        }

        /* Have the progress bar parse the value of the MGS3AlertTimers for Alert, Evasion and Caution 
         then the checkbox will freeze the progress bar value until we uncheck it the the memory value
        and the progress bar value will start going down again */
        private void UpdateProgressBar(ColouredProgressBar progressBar, int timerValue)
        {
            // Ensure the update is done on the UI thread
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => UpdateProgressBar(progressBar, timerValue)));
            }
            else
            {
                if (timerValue >= progressBar.Minimum && timerValue <= progressBar.Maximum)
                {
                    progressBar.Value = timerValue;
                }
                else
                {
                    // Log or handle the error case
                    Console.WriteLine($"Timer value out of range: {timerValue}");
                }
            }
        }

        private void ContinuousMonitoringTimer_Tick(object sender, EventArgs e)
        {
            IntPtr alertMemoryRegion = MemoryManager.Instance.FindAob("AlertMemoryRegion");
            if (alertMemoryRegion == IntPtr.Zero)
            {
                Console.WriteLine("Error: Alert memory region not found.");
                return;
            }

            // Read the timer values
            short alertTimerValue = GuardManager.ReadAlertTimerValue(alertMemoryRegion);
            short evasionTimerValue = GuardManager.ReadEvasionTimerValue(alertMemoryRegion);
            short cautionTimerValue = GuardManager.ReadCautionTimerValue(alertMemoryRegion);

            // Safely update the progress bars on the UI thread otherwise enjoy lag city
            this.Invoke((MethodInvoker)delegate
            {
                UpdateProgressBar(AlertProgressBar, alertTimerValue);
                UpdateProgressBar(EvasionProgressBar, evasionTimerValue);
                UpdateProgressBar(CautionProgressBar, cautionTimerValue);
            });
        }

        private void ClearCautionAndEvasion_Click(object sender, EventArgs e)
        {
            GuardManager.RemoveEvasionAndCaution();
        }

        #endregion

        #region Snake's Serious Injuries
        private void BurnInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.SevereBurns);
            LoggingManager.Instance.Log("Snake has gained a severe burn");
        }

        private void CutInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.DeepCut);
            LoggingManager.Instance.Log("Snake has gained a deep cut");
        }

        private void GunshotRifleInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.GunshotWoundRifle);
            LoggingManager.Instance.Log("Snake has gained a gunshot wound (Rifle)");
        }

        private void GunshotShotgunInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.GunshotWoundShotgun);
            LoggingManager.Instance.Log("Snake has gained a gunshot wound (Shotgun)");
        }

        private void BoneFractureInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.BoneFracture);
            LoggingManager.Instance.Log("Snake has gained a bone fracture");
        }

        private void BulletBeeInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.BulletBee);
            LoggingManager.Instance.Log("Snake has gained a bullet bee");
        }

        private void LeechesInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.Leeches);
            LoggingManager.Instance.Log("Snake has gained a leech");
        }

        private void ArrowInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.ArrowWound);
            LoggingManager.Instance.Log("Snake has gained a arrow");
        }

        private void TranqInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.TranqDart);
            LoggingManager.Instance.Log("Snake has gained a Tranq dart");
        }

        private void VenomPoisoningInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.Poisoned);
            LoggingManager.Instance.Log("Snake has gained venom poisoning");
        }

        private void FoodPoisoningInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.FoodPoisoning);
            LoggingManager.Instance.Log("Snake has gained food poisoning");
        }

        private void CommonColdInjury_Click(object sender, EventArgs e)
        {
            PointerEffectManager.ApplyInjury(Constants.InjuryType.Cold);
            LoggingManager.Instance.Log("Snake has gained the common cold");
        }

        private void RemoveInjuries_Click(object sender, EventArgs e)
        {
            PointerEffectManager.RemoveAllInjuries();
            LoggingManager.Instance.Log("Snake has no more injuries");
        }

        #endregion

        private void SwapToWeaponsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Weapon form from the Stats and Alerts form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "WeaponForm");
            WeaponForm form1 = new();
            form1.Show();
            this.Hide();
        }

        private void SwapToItemsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Item form from the Stats and Alerts form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "ItemForm");
            ItemForm form2 = new();
            form2.Show();
            this.Hide();
        }

        private void SwapToCamoForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Camo form from the Stats and Alerts form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "CamoForm");
            CamoForm form3 = new();
            form3.Show();
            this.Hide();

        }

        private void MiscFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Misc page from the Stats and Alerts Form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "MiscForm");
            MiscForm form4 = new();
            form4.Show();
            this.Hide();
        }

        private void InfLifeSnakeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InfLifeSnakeCheckBox.Checked)
            {
                EffectManager.Instance.EnableInstantLifeRecovery();
                EffectManager.Instance.EnableNoDamageTaken();
            }
            else
            {
                EffectManager.Instance.DisableInstantLifeRecovery();
                EffectManager.Instance.DisableNoDamageTaken();
            }
        }

        public void CheckInfLifeSnakeStatus()
        {
            bool isInstantRecoveryEnabled = EffectManager.Instance.IsInstantLifeRecoveryEnabled();
            bool isNoDamageTakenEnabled = EffectManager.Instance.IsNoDamageTakenEnabled();

            InfLifeSnakeCheckBox.Checked = isInstantRecoveryEnabled && isNoDamageTakenEnabled;
        }
    }
}