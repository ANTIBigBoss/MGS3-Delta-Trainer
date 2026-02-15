using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public partial class MiscForm : Form
    {
        private bool updatingValues = false;
        private const float MIN_FILTER_VALUE = 0f;
        private const float MAX_FILTER_VALUE = 10f;

        public MiscForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form4_FormClosing);
        }

        #region Form Loading Event & Form Swap

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Location = MemoryManager.GetLastFormLocation();
            InitializeFilterControls();
            UpdatePissFilterControlsState();
            UpdateLightColourControlsState();
            UpdateExtraLightColourControlsState();
            UpdateWorldLightControlsState();
            UpdateFogCheckboxState();
            InitializeDifficultyDropdown();
        }

        private void SwapToWeaponsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Weapon form from the Misc form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "WeaponForm");
            WeaponForm form1 = new();
            form1.Show();
            this.Hide();
        }

        private void SwapToItemsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Item form from the Misc form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "ItemForm");
            ItemForm form2 = new();
            form2.Show();
            this.Hide();
        }

        private void SwapToCamoForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Camo form from the Misc form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "CamoForm");
            CamoForm form3 = new();
            form3.Show();
            this.Hide();
        }

        private void SwapToHealthAndAlertsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Stats and Alert form from the Misc form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "StatsAndAlertForm");
            StatsAndAlertForm form5 = new();
            form5.Show();
            this.Hide();
        }

        private void GameStatsFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Game Stats page from the Misc Form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "GameStatsForm");
            GameStatsForm form7 = new();
            form7.Show();
            this.Hide();
        }

        #endregion

        #region Form Control Helpers

        private void InitializeDifficultyDropdown()
        {
            DifficultyChangeDropdown.Items.Clear();

            var difficulties = new Dictionary<byte, string>
        {
        { 10, "Very Easy" },
        { 20, "Easy" },
        { 30, "Normal" },
        { 40, "Hard" },
        { 50, "Extreme" },
        { 60, "European Extreme" }
        };

            foreach (var difficulty in difficulties)
            {
                DifficultyChangeDropdown.Items.Add(difficulty.Value);
            }

            byte currentDifficultyValue = PointerEffectManager.GetDifficultyValue();
            string currentDifficultyName = difficulties.TryGetValue(currentDifficultyValue, out string name) ? name : "Unknown";

            DifficultyChangeDropdown.SelectedItem = currentDifficultyName;

            if (DifficultyChangeDropdown.SelectedItem == null && DifficultyChangeDropdown.Items.Count > 0)
            {
                DifficultyChangeDropdown.SelectedIndex = 2;
            }
        }

        private void InitializeFilterControls()
        {

            PissFilterRTrackBar.Minimum = 0;
            PissFilterRTrackBar.Maximum = 100; // 100 * 0.1 = 10.0
            PissFilterRTrackBar.TickFrequency = 10; // Every 1.0
            PissFilterRTrackBar.SmallChange = 1; // 0.1
            PissFilterRTrackBar.LargeChange = 10; // 1.0

            PissFilterGTrackBar.Minimum = 0;
            PissFilterGTrackBar.Maximum = 100;
            PissFilterGTrackBar.TickFrequency = 10;
            PissFilterGTrackBar.SmallChange = 1;
            PissFilterGTrackBar.LargeChange = 10;

            PissFilterBTrackBar.Minimum = 0;
            PissFilterBTrackBar.Maximum = 100;
            PissFilterBTrackBar.TickFrequency = 10;
            PissFilterBTrackBar.SmallChange = 1;
            PissFilterBTrackBar.LargeChange = 10;

            PissFilterATrackBar.Minimum = 0;
            PissFilterATrackBar.Maximum = 100;
            PissFilterATrackBar.TickFrequency = 10;
            PissFilterATrackBar.SmallChange = 1;
            PissFilterATrackBar.LargeChange = 10;

            // Light Colour TrackBars - changed to max 10 with 0.1 increments
            LightColourRTrackBar.Minimum = 0;
            LightColourRTrackBar.Maximum = 100;
            LightColourRTrackBar.TickFrequency = 10;
            LightColourRTrackBar.SmallChange = 1;
            LightColourRTrackBar.LargeChange = 10;

            LightColourGTrackBar.Minimum = 0;
            LightColourGTrackBar.Maximum = 100;
            LightColourGTrackBar.TickFrequency = 10;
            LightColourGTrackBar.SmallChange = 1;
            LightColourGTrackBar.LargeChange = 10;

            LightColourBTrackBar.Minimum = 0;
            LightColourBTrackBar.Maximum = 100;
            LightColourBTrackBar.TickFrequency = 10;
            LightColourBTrackBar.SmallChange = 1;
            LightColourBTrackBar.LargeChange = 10;

            LightColourATrackBar.Minimum = 0;
            LightColourATrackBar.Maximum = 100;
            LightColourATrackBar.TickFrequency = 10;
            LightColourATrackBar.SmallChange = 1;
            LightColourATrackBar.LargeChange = 10;

            ExtraLightColourRTrackBar.Minimum = 0;
            ExtraLightColourRTrackBar.Maximum = 100;
            ExtraLightColourRTrackBar.TickFrequency = 10;
            ExtraLightColourRTrackBar.SmallChange = 1;
            ExtraLightColourRTrackBar.LargeChange = 10;

            ExtraLightColourGTrackBar.Minimum = 0;
            ExtraLightColourGTrackBar.Maximum = 100;
            ExtraLightColourGTrackBar.TickFrequency = 10;
            ExtraLightColourGTrackBar.SmallChange = 1;
            ExtraLightColourGTrackBar.LargeChange = 10;

            ExtraLightColourBTrackBar.Minimum = 0;
            ExtraLightColourBTrackBar.Maximum = 100;
            ExtraLightColourBTrackBar.TickFrequency = 10;
            ExtraLightColourBTrackBar.SmallChange = 1;
            ExtraLightColourBTrackBar.LargeChange = 10;

            ExtraLightColourATrackBar.Minimum = 0;
            ExtraLightColourATrackBar.Maximum = 100;
            ExtraLightColourATrackBar.TickFrequency = 10;
            ExtraLightColourATrackBar.SmallChange = 1;
            ExtraLightColourATrackBar.LargeChange = 10;

            WorldLightingTrackBar.Minimum = -200;
            WorldLightingTrackBar.Maximum = 26;
            WorldLightingTrackBar.TickFrequency = 23;
            WorldLightingTrackBar.SmallChange = 1;
            WorldLightingTrackBar.LargeChange = 10;

            LoadFilterValues();
        }

        private void UpdatePissFilterControlsState()
        {
            bool isPissFilterEnabled = EffectManager.Instance.IsPissFilterEnabled();

            PissFilterEditingCheckBox.Checked = !isPissFilterEnabled;

            SetPissFilterControlsEnabled(!isPissFilterEnabled);
        }

        private void UpdateLightColourControlsState()
        {
            bool isLightColourEnabled = EffectManager.Instance.IsLightColourEnabled();

            LightColourEditingCheckBox.Checked = !isLightColourEnabled;

            SetLightColourControlsEnabled(!isLightColourEnabled);
        }

        private void UpdateWorldLightControlsState()
        {
            bool isWorldLightEnabled = EffectManager.Instance.IsWorldLightEnabled();

            WorldLightEditingCheckBox.Checked = !isWorldLightEnabled;

            SetWorldLightControlsEnabled(!isWorldLightEnabled);
        }

        private void SetPissFilterControlsEnabled(bool enabled)
        {
            PissFilterRTrackBar.Enabled = enabled;
            PissFilterGTrackBar.Enabled = enabled;
            PissFilterBTrackBar.Enabled = enabled;
            PissFilterATrackBar.Enabled = enabled;

            PissFilterRTextbox.Enabled = enabled;
            PissFilterGTextbox.Enabled = enabled;
            PissFilterBTextbox.Enabled = enabled;
            PissFilterATextbox.Enabled = enabled;

            Minus1PissFilterR.Enabled = enabled;
            Minus1PissFilterG.Enabled = enabled;
            Minus1PissFilterB.Enabled = enabled;
            Minus1PissFilterA.Enabled = enabled;

            Plus1PissFilterR.Enabled = enabled;
            Plus1PissFilterG.Enabled = enabled;
            Plus1PissFilterB.Enabled = enabled;
            Plus1PissFilterA.Enabled = enabled;

            ResetFiltersButton.Enabled = enabled;

            Color backColor = enabled ? SystemColors.Window : SystemColors.Control;
            Color foreColor = enabled ? SystemColors.ControlText : SystemColors.GrayText;

            PissFilterRTextbox.BackColor = backColor;
            PissFilterGTextbox.BackColor = backColor;
            PissFilterBTextbox.BackColor = backColor;
            PissFilterATextbox.BackColor = backColor;

            PissFilterRTextbox.ForeColor = foreColor;
            PissFilterGTextbox.ForeColor = foreColor;
            PissFilterBTextbox.ForeColor = foreColor;
            PissFilterATextbox.ForeColor = foreColor;
        }

        private void SetLightColourControlsEnabled(bool enabled)
        {
            LightColourRTrackBar.Enabled = enabled;
            LightColourGTrackBar.Enabled = enabled;
            LightColourBTrackBar.Enabled = enabled;
            LightColourATrackBar.Enabled = enabled;

            LightColourRTextbox.Enabled = enabled;
            LightColourGTextbox.Enabled = enabled;
            LightColourBTextbox.Enabled = enabled;
            LightColourATextbox.Enabled = enabled;

            Minus1LightColourR.Enabled = enabled;
            Minus1LightColourG.Enabled = enabled;
            Minus1LightColourB.Enabled = enabled;
            Minus1LightColourA.Enabled = enabled;

            Plus1LightColourR.Enabled = enabled;
            Plus1LightColourG.Enabled = enabled;
            Plus1LightColourB.Enabled = enabled;
            Plus1LightColourA.Enabled = enabled;

            ResetColourLightingButton.Enabled = enabled;

            Color backColor = enabled ? SystemColors.Window : SystemColors.Control;
            Color foreColor = enabled ? SystemColors.ControlText : SystemColors.GrayText;

            LightColourRTextbox.BackColor = backColor;
            LightColourGTextbox.BackColor = backColor;
            LightColourBTextbox.BackColor = backColor;
            LightColourATextbox.BackColor = backColor;

            LightColourRTextbox.ForeColor = foreColor;
            LightColourGTextbox.ForeColor = foreColor;
            LightColourBTextbox.ForeColor = foreColor;
            LightColourATextbox.ForeColor = foreColor;
        }

        private void SetWorldLightControlsEnabled(bool enabled)
        {
            WorldLightingTrackBar.Enabled = enabled;
            WorldLightingTextbox.Enabled = enabled;
            Minus1WorldLight.Enabled = enabled;
            Plus1WorldLight.Enabled = enabled;
            ResetWorldLightingButton.Enabled = enabled;

            Color backColor = enabled ? SystemColors.Window : SystemColors.Control;
            Color foreColor = enabled ? SystemColors.ControlText : SystemColors.GrayText;

            WorldLightingTextbox.BackColor = backColor;
            WorldLightingTextbox.ForeColor = foreColor;
        }

        private void LoadFilterValues()
        {
            updatingValues = true;

            try
            {
                // Piss Filter
                float rValue = EffectManager.Instance.GetFilterValue1Float();
                float gValue = EffectManager.Instance.GetFilterValue2Float();
                float bValue = EffectManager.Instance.GetFilterValue3Float();
                float aValue = EffectManager.Instance.GetFilterValue4Float();

                PissFilterRTextbox.Text = rValue.ToString("F2", CultureInfo.InvariantCulture);
                PissFilterRTrackBar.Value = (int)(rValue * 10);

                PissFilterGTextbox.Text = gValue.ToString("F2", CultureInfo.InvariantCulture);
                PissFilterGTrackBar.Value = (int)(gValue * 10);

                PissFilterBTextbox.Text = bValue.ToString("F2", CultureInfo.InvariantCulture);
                PissFilterBTrackBar.Value = (int)(bValue * 10);

                PissFilterATextbox.Text = aValue.ToString("F2", CultureInfo.InvariantCulture);
                PissFilterATrackBar.Value = (int)(aValue * 10);

                // Light Colour
                float lightRValue = EffectManager.Instance.GetLightColourValue1Float();
                float lightGValue = EffectManager.Instance.GetLightColourValue2Float();
                float lightBValue = EffectManager.Instance.GetLightColourValue3Float();
                float lightAValue = EffectManager.Instance.GetLightColourValue4Float();

                LightColourRTextbox.Text = lightRValue.ToString("F2", CultureInfo.InvariantCulture);
                LightColourRTrackBar.Value = (int)(lightRValue * 10);

                LightColourGTextbox.Text = lightGValue.ToString("F2", CultureInfo.InvariantCulture);
                LightColourGTrackBar.Value = (int)(lightGValue * 10);

                LightColourBTextbox.Text = lightBValue.ToString("F2", CultureInfo.InvariantCulture);
                LightColourBTrackBar.Value = (int)(lightBValue * 10);

                LightColourATextbox.Text = lightAValue.ToString("F2", CultureInfo.InvariantCulture);
                LightColourATrackBar.Value = (int)(lightAValue * 10);


                float worldLightValue = EffectManager.Instance.GetWorldLightBrightnessFloat();
                WorldLightingTextbox.Text = worldLightValue.ToString("F2", CultureInfo.InvariantCulture);
                WorldLightingTrackBar.Value = (int)(worldLightValue * 100);

                LoggingManager.Instance.Log($"Filter Values Loaded - R: {rValue:F2}, G: {gValue:F2}, B: {bValue:F2}, A: {aValue:F2}");
                LoggingManager.Instance.Log($"Light Colour Values Loaded - R: {lightRValue:F2}, G: {lightGValue:F2}, B: {lightBValue:F2}, A: {lightAValue:F2}");
                LoggingManager.Instance.Log($"World Light Value Loaded: {worldLightValue:F2}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error loading filter values: {ex.Message}");
            }
            finally
            {
                updatingValues = false;
            }
        }

        private void UpdateFogCheckboxState()
        {
            bool isFogEnabled = EffectManager.Instance.IsFogEnabled();
            FogCheckBox.Checked = !isFogEnabled; // Checked = fog disabled, Unchecked = fog enabled
        }

        #endregion

        #region TrackBar_Scroll Event Handlers

        #region Piss Filter

        private void PissFilterRTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!PissFilterRTrackBar.Enabled) return;

            float value = PissFilterRTrackBar.Value / 10f;
            PissFilterRTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetFilterR(value);
        }

        private void PissFilterGTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!PissFilterGTrackBar.Enabled) return;

            float value = PissFilterGTrackBar.Value / 10f;
            PissFilterGTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetFilterG(value);
        }

        private void PissFilterBTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!PissFilterBTrackBar.Enabled) return;

            float value = PissFilterBTrackBar.Value / 10f;
            PissFilterBTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetFilterB(value);
        }


        private void PissFilterATrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!PissFilterATrackBar.Enabled) return;

            float value = PissFilterATrackBar.Value / 10f;
            PissFilterATextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetFilterA(value);
        }

        #endregion

        #region Light Colour

        private void LightColourRTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!LightColourRTrackBar.Enabled) return;

            float value = LightColourRTrackBar.Value / 10f;
            LightColourRTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetLightColourR(value);
        }

        private void LightColourGTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!LightColourGTrackBar.Enabled) return;

            float value = LightColourGTrackBar.Value / 10f;
            LightColourGTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetLightColourG(value);
        }

        private void LightColourBTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!LightColourBTrackBar.Enabled) return;

            float value = LightColourBTrackBar.Value / 10f;
            LightColourBTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetLightColourB(value);
        }

        private void LightColourATrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!LightColourATrackBar.Enabled) return;

            float value = LightColourATrackBar.Value / 10f;
            LightColourATextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetLightColourA(value);
        }

        #endregion

        private void WorldLightingTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!WorldLightingTrackBar.Enabled) return;

            float value = WorldLightingTrackBar.Value / 100f;
            WorldLightingTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetWorldLightBrightness(value);
        }


        #endregion

        #region Textbox_TextChanged Event Handlers

        #region Piss Filter

        private void PissFilterRTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!PissFilterRTextbox.Enabled) return;

            if (float.TryParse(PissFilterRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                // Validate range
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues(); // Reload the original value
                    return;
                }

                updatingValues = true;
                PissFilterRTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetFilterR(value);
            }
        }

        private void PissFilterGTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!PissFilterGTextbox.Enabled) return;

            if (float.TryParse(PissFilterGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                // Validate range
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues(); // Reload the original value
                    return;
                }

                updatingValues = true;
                PissFilterGTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetFilterG(value);
            }
        }

        private void PissFilterBTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!PissFilterBTextbox.Enabled) return;

            if (float.TryParse(PissFilterBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                // Validate range
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues(); // Reload the original value
                    return;
                }

                updatingValues = true;
                PissFilterBTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetFilterB(value);
            }
        }

        private void PissFilterATextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!PissFilterATextbox.Enabled) return;

            if (float.TryParse(PissFilterATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                // Validate range
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues(); // Reload the original value
                    return;
                }

                updatingValues = true;
                PissFilterATrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetFilterA(value);
            }
        }

        #endregion

        #region Light Colour

        private void LightColourRTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!LightColourRTextbox.Enabled) return;

            if (float.TryParse(LightColourRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues();
                    return;
                }

                updatingValues = true;
                LightColourRTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetLightColourR(value);
            }
        }

        private void LightColourGTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!LightColourGTextbox.Enabled) return;

            if (float.TryParse(LightColourGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues();
                    return;
                }

                updatingValues = true;
                LightColourGTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetLightColourG(value);
            }
        }

        private void LightColourBTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!LightColourBTextbox.Enabled) return;

            if (float.TryParse(LightColourBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues();
                    return;
                }

                updatingValues = true;
                LightColourBTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetLightColourB(value);
            }
        }

        private void LightColourATextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!LightColourATextbox.Enabled) return;

            if (float.TryParse(LightColourATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues();
                    return;
                }

                updatingValues = true;
                LightColourATrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetLightColourA(value);
            }
        }

        #endregion

        private void WorldLightingTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!WorldLightingTextbox.Enabled) return;

            if (float.TryParse(WorldLightingTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < -2.0f || value > 0.26f)
                {
                    MessageBox.Show($"Value must be between -2.00 and 0.26.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadFilterValues();
                    return;
                }

                updatingValues = true;
                WorldLightingTrackBar.Value = (int)(value * 100);
                updatingValues = false;
                EffectManager.Instance.SetWorldLightBrightness(value);
            }
        }

        #endregion

        #region CheckBox_CheckChanged Event Handlers

        private void WorldLightEditingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (WorldLightEditingCheckBox.Checked)
            {
                EffectManager.Instance.DisableWorldLight();
                SetWorldLightControlsEnabled(true);
            }
            else
            {
                EffectManager.Instance.EnableWorldLight();
                SetWorldLightControlsEnabled(false);
                // Reset value to default when disabling
                EffectManager.Instance.SetWorldLightBrightness(1.0f);
                WorldLightingTextbox.Text = "1.00";
            }
        }

        private void PissFilterEditingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PissFilterEditingCheckBox.Checked)
            {
                EffectManager.Instance.DisablePissFilter();
                SetPissFilterControlsEnabled(true);
            }
            else
            {
                EffectManager.Instance.EnablePissFilter();
                SetPissFilterControlsEnabled(false);
                // Need to tweak a value to set everything back to 1 after disabling
                EffectManager.Instance.SetFilterR(2.0f);

                PissFilterRTextbox.Text = "1";
                PissFilterGTextbox.Text = "1";
                PissFilterBTextbox.Text = "1";
                PissFilterATextbox.Text = "1";
            }
        }

        private void LightColourEditingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LightColourEditingCheckBox.Checked)
            {
                EffectManager.Instance.DisableLightColour();
                SetLightColourControlsEnabled(true);
            }
            else
            {
                EffectManager.Instance.EnableLightColour();
                SetLightColourControlsEnabled(false);
                // Reset values to default when disabling
                EffectManager.Instance.SetLightColourR(1.0f);
                EffectManager.Instance.SetLightColourG(1.0f);
                EffectManager.Instance.SetLightColourB(1.0f);
                EffectManager.Instance.SetLightColourA(1.0f);

                LightColourRTextbox.Text = "1.00";
                LightColourGTextbox.Text = "1.00";
                LightColourBTextbox.Text = "1.00";
                LightColourATextbox.Text = "1.00";
            }
        }

        private void FogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Handle fog checkbox logic here
            if (FogCheckBox.Checked)
            {
                EffectManager.Instance.DisableFog();
            }
            else
            {
                EffectManager.Instance.EnableFog();
            }
        }

        #endregion

        #region Button_Click Event Handlers

        private void ChangeDifficultyButton_Click(object sender, EventArgs e)
        {
            if (DifficultyChangeDropdown.SelectedItem != null)
            {
                string selectedDifficulty = DifficultyChangeDropdown.SelectedItem.ToString();
                var difficulties = new Dictionary<byte, string>
            {
            { 10, "Very Easy" },
            { 20, "Easy" },
            { 30, "Normal" },
            { 40, "Hard" },
            { 50, "Extreme" },
            { 60, "European Extreme" }
            };

                byte difficultyValue = difficulties.FirstOrDefault(x => x.Value == selectedDifficulty).Key;

                if (difficultyValue != 0)
                {
                    bool success = PointerEffectManager.SetDifficultyValue(difficultyValue);
                    if (success)
                    {
                        MessageBox.Show($"Difficulty changed to {selectedDifficulty}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to change difficulty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ResetFiltersButton_Click(object sender, EventArgs e)
        {
            if (!ResetFiltersButton.Enabled) return;

            EffectManager.Instance.EnablePissFilter();
            EffectManager.Instance.SetFilterR(2.0f);

            PissFilterRTextbox.Text = "1";
            PissFilterGTextbox.Text = "1";
            PissFilterBTextbox.Text = "1";
            PissFilterATextbox.Text = "1";

            EffectManager.Instance.DisablePissFilter();
            LoadFilterValues();
        }

        private void ResetColourLightingButton_Click(object sender, EventArgs e)
        {
            if (!ResetColourLightingButton.Enabled) return;

            EffectManager.Instance.EnableLightColour();
            EffectManager.Instance.SetLightColourR(2.0f);

            LightColourRTextbox.Text = "1";
            LightColourGTextbox.Text = "1";
            LightColourBTextbox.Text = "1";
            LightColourATextbox.Text = "1";

            EffectManager.Instance.DisableLightColour();

            LoadFilterValues();
        }

        private void ResetWorldLightingButton_Click(object sender, EventArgs e)
        {
            if (!ResetWorldLightingButton.Enabled) return;

            EffectManager.Instance.SetWorldLightBrightness(1.0f);

            LoadFilterValues();
        }

        private void Minus1WorldLight_Click(object sender, EventArgs e)
        {
            if (!Minus1WorldLight.Enabled) return;

            if (float.TryParse(WorldLightingTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= -2.0f)
                {
                    MessageBox.Show($"Value cannot be less than -2.00. Valid range is -2.00 to 0.26.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 0.01f; // Decrement by 0.01
                WorldLightingTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1WorldLight_Click(object sender, EventArgs e)
        {
            if (!Plus1WorldLight.Enabled) return;

            if (float.TryParse(WorldLightingTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= 0.26f)
                {
                    MessageBox.Show($"Value cannot exceed 0.26. Valid range is -2.00 to 0.26.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 0.01f; // Increment by 0.01
                WorldLightingTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private async void RestartStageButton_Click(object sender, EventArgs e)
        {
            EffectManager.Instance.TriggerStageRestart();
        }

        #region +1 -1 Piss Filter

        private void Minus1PissFilterR_Click(object sender, EventArgs e)
        {
            if (!Minus1PissFilterR.Enabled) return;

            if (float.TryParse(PissFilterRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                PissFilterRTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Minus1PissFilterG_Click(object sender, EventArgs e)
        {
            if (!Minus1PissFilterG.Enabled) return;

            if (float.TryParse(PissFilterGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                PissFilterGTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Minus1PissFilterB_Click(object sender, EventArgs e)
        {
            if (!Minus1PissFilterB.Enabled) return;

            if (float.TryParse(PissFilterBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                PissFilterBTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Minus1PissFilterA_Click(object sender, EventArgs e)
        {
            if (!Minus1PissFilterA.Enabled) return;

            if (float.TryParse(PissFilterATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                PissFilterATextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1PissFilterR_Click(object sender, EventArgs e)
        {
            if (!Plus1PissFilterR.Enabled) return;

            if (float.TryParse(PissFilterRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                PissFilterRTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1PissFilterG_Click(object sender, EventArgs e)
        {
            if (!Plus1PissFilterG.Enabled) return;

            if (float.TryParse(PissFilterGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                PissFilterGTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1PissFilterB_Click(object sender, EventArgs e)
        {
            if (!Plus1PissFilterB.Enabled) return;

            if (float.TryParse(PissFilterBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                PissFilterBTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1PissFilterA_Click(object sender, EventArgs e)
        {
            if (!Plus1PissFilterA.Enabled) return;

            if (float.TryParse(PissFilterATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                PissFilterATextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        #endregion

        #region +1 -1 Light Colour

        private void Minus1LightColourR_Click(object sender, EventArgs e)
        {
            if (!Minus1LightColourR.Enabled) return;

            if (float.TryParse(LightColourRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                LightColourRTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Minus1LightColourG_Click(object sender, EventArgs e)
        {
            if (!Minus1LightColourG.Enabled) return;

            if (float.TryParse(LightColourGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                LightColourGTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Minus1LightColourB_Click(object sender, EventArgs e)
        {
            if (!Minus1LightColourB.Enabled) return;

            if (float.TryParse(LightColourBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                LightColourBTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Minus1LightColourA_Click(object sender, EventArgs e)
        {
            if (!Minus1LightColourA.Enabled) return;

            if (float.TryParse(LightColourATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                LightColourATextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1LightColourR_Click(object sender, EventArgs e)
        {
            if (!Plus1LightColourR.Enabled) return;

            if (float.TryParse(LightColourRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                LightColourRTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1LightColourG_Click(object sender, EventArgs e)
        {
            if (!Plus1LightColourG.Enabled) return;

            if (float.TryParse(LightColourGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                LightColourGTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1LightColourB_Click(object sender, EventArgs e)
        {
            if (!Plus1LightColourB.Enabled) return;

            if (float.TryParse(LightColourBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                LightColourBTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void Plus1LightColourA_Click(object sender, EventArgs e)
        {
            if (!Plus1LightColourA.Enabled) return;

            if (float.TryParse(LightColourATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                LightColourATextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        #endregion

        #endregion

        #region Extra Light Colour Methods

        private void UpdateExtraLightColourControlsState()
        {
            bool isExtraLightColourEnabled = EffectManager.Instance.IsExtraLightColourEnabled();
            ExtraLightColourEditingCheckBox.Checked = !isExtraLightColourEnabled;
            SetExtraLightColourControlsEnabled(!isExtraLightColourEnabled);
        }

        private void SetExtraLightColourControlsEnabled(bool enabled)
        {
            ExtraLightColourRTrackBar.Enabled = enabled;
            ExtraLightColourGTrackBar.Enabled = enabled;
            ExtraLightColourBTrackBar.Enabled = enabled;
            ExtraLightColourATrackBar.Enabled = enabled;

            ExtraLightColourRTextbox.Enabled = enabled;
            ExtraLightColourGTextbox.Enabled = enabled;
            ExtraLightColourBTextbox.Enabled = enabled;
            ExtraLightColourATextbox.Enabled = enabled;

            ExtraMinus1LightColourR.Enabled = enabled;
            ExtraMinus1LightColourG.Enabled = enabled;
            ExtraMinus1LightColourB.Enabled = enabled;
            ExtraMinus1LightColourA.Enabled = enabled;

            ExtraPlus1LightColourR.Enabled = enabled;
            ExtraPlus1LightColourG.Enabled = enabled;
            ExtraPlus1LightColourB.Enabled = enabled;
            ExtraPlus1LightColourA.Enabled = enabled;

            ExtraResetColourLightingButton.Enabled = enabled;

            Color backColor = enabled ? SystemColors.Window : SystemColors.Control;
            Color foreColor = enabled ? SystemColors.ControlText : SystemColors.GrayText;

            ExtraLightColourRTextbox.BackColor = backColor;
            ExtraLightColourGTextbox.BackColor = backColor;
            ExtraLightColourBTextbox.BackColor = backColor;
            ExtraLightColourATextbox.BackColor = backColor;

            ExtraLightColourRTextbox.ForeColor = foreColor;
            ExtraLightColourGTextbox.ForeColor = foreColor;
            ExtraLightColourBTextbox.ForeColor = foreColor;
            ExtraLightColourATextbox.ForeColor = foreColor;
        }

        private void LoadExtraLightColourValues()
        {
            updatingValues = true;

            try
            {
                float extraLightRValue = EffectManager.Instance.GetExtraLightColourValueRFloat();
                float extraLightGValue = EffectManager.Instance.GetExtraLightColourValueGFloat();
                float extraLightBValue = EffectManager.Instance.GetExtraLightColourValueBFloat();
                float extraLightAValue = EffectManager.Instance.GetExtraLightColourValueAFloat();

                ExtraLightColourRTextbox.Text = extraLightRValue.ToString("F2", CultureInfo.InvariantCulture);
                ExtraLightColourRTrackBar.Value = (int)(extraLightRValue * 10);

                ExtraLightColourGTextbox.Text = extraLightGValue.ToString("F2", CultureInfo.InvariantCulture);
                ExtraLightColourGTrackBar.Value = (int)(extraLightGValue * 10);

                ExtraLightColourBTextbox.Text = extraLightBValue.ToString("F2", CultureInfo.InvariantCulture);
                ExtraLightColourBTrackBar.Value = (int)(extraLightBValue * 10);

                ExtraLightColourATextbox.Text = extraLightAValue.ToString("F2", CultureInfo.InvariantCulture);
                ExtraLightColourATrackBar.Value = (int)(extraLightAValue * 10);

                LoggingManager.Instance.Log($"Extra Light Colour Values Loaded - R: {extraLightRValue:F2}, G: {extraLightGValue:F2}, B: {extraLightBValue:F2}, A: {extraLightAValue:F2}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error loading extra light colour values: {ex.Message}");
            }
            finally
            {
                updatingValues = false;
            }
        }

        // Event Handlers for Extra Light Colour
        private void ExtraLightColourEditingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ExtraLightColourEditingCheckBox.Checked)
            {
                EffectManager.Instance.DisableExtraLightColour();
                SetExtraLightColourControlsEnabled(true);
            }
            else
            {
                EffectManager.Instance.EnableExtraLightColour();
                SetExtraLightColourControlsEnabled(false);
                // Reset values to default when disabling
                EffectManager.Instance.SetExtraLightColourR(1.0f);
                EffectManager.Instance.SetExtraLightColourG(1.0f);
                EffectManager.Instance.SetExtraLightColourB(1.0f);
                EffectManager.Instance.SetExtraLightColourA(1.0f);

                ExtraLightColourRTextbox.Text = "1.00";
                ExtraLightColourGTextbox.Text = "1.00";
                ExtraLightColourBTextbox.Text = "1.00";
                ExtraLightColourATextbox.Text = "1.00";
            }
        }

        private void ExtraResetColourLightingButton_Click(object sender, EventArgs e)
        {
            if (!ExtraResetColourLightingButton.Enabled) return;

            EffectManager.Instance.EnableExtraLightColour();
            EffectManager.Instance.SetExtraLightColourR(2.0f);

            ExtraLightColourRTextbox.Text = "1";
            ExtraLightColourGTextbox.Text = "1";
            ExtraLightColourBTextbox.Text = "1";
            ExtraLightColourATextbox.Text = "1";

            EffectManager.Instance.DisableExtraLightColour();
            LoadExtraLightColourValues();
        }

        // TrackBar Scroll Events
        private void ExtraLightColourRTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!ExtraLightColourRTrackBar.Enabled) return;

            float value = ExtraLightColourRTrackBar.Value / 10f;
            ExtraLightColourRTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetExtraLightColourR(value);
        }

        private void ExtraLightColourGTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!ExtraLightColourGTrackBar.Enabled) return;

            float value = ExtraLightColourGTrackBar.Value / 10f;
            ExtraLightColourGTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetExtraLightColourG(value);
        }

        private void ExtraLightColourBTrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!ExtraLightColourBTrackBar.Enabled) return;

            float value = ExtraLightColourBTrackBar.Value / 10f;
            ExtraLightColourBTextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetExtraLightColourB(value);
        }

        private void ExtraLightColourATrackBar_Scroll(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!ExtraLightColourATrackBar.Enabled) return;

            float value = ExtraLightColourATrackBar.Value / 10f;
            ExtraLightColourATextbox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            EffectManager.Instance.SetExtraLightColourA(value);
        }

        // TextBox TextChanged Events
        private void ExtraLightColourRTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!ExtraLightColourRTextbox.Enabled) return;

            if (float.TryParse(ExtraLightColourRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadExtraLightColourValues();
                    return;
                }

                updatingValues = true;
                ExtraLightColourRTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetExtraLightColourR(value);
            }
        }

        private void ExtraLightColourGTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!ExtraLightColourGTextbox.Enabled) return;

            if (float.TryParse(ExtraLightColourGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadExtraLightColourValues();
                    return;
                }

                updatingValues = true;
                ExtraLightColourGTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetExtraLightColourG(value);
            }
        }

        private void ExtraLightColourBTextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!ExtraLightColourBTextbox.Enabled) return;

            if (float.TryParse(ExtraLightColourBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadExtraLightColourValues();
                    return;
                }

                updatingValues = true;
                ExtraLightColourBTrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetExtraLightColourB(value);
            }
        }

        private void ExtraLightColourATextbox_TextChanged(object sender, EventArgs e)
        {
            if (updatingValues) return;
            if (!ExtraLightColourATextbox.Enabled) return;

            if (float.TryParse(ExtraLightColourATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                if (value < MIN_FILTER_VALUE || value > MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value must be between {MIN_FILTER_VALUE:F2} and {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadExtraLightColourValues();
                    return;
                }

                updatingValues = true;
                ExtraLightColourATrackBar.Value = (int)(value * 10);
                updatingValues = false;
                EffectManager.Instance.SetExtraLightColourA(value);
            }
        }

        // +1/-1 Button Events
        private void ExtraMinus1LightColourR_Click(object sender, EventArgs e)
        {
            if (!ExtraMinus1LightColourR.Enabled) return;

            if (float.TryParse(ExtraLightColourRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                ExtraLightColourRTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void ExtraMinus1LightColourG_Click(object sender, EventArgs e)
        {
            if (!ExtraMinus1LightColourG.Enabled) return;

            if (float.TryParse(ExtraLightColourGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                ExtraLightColourGTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void ExtraMinus1LightColourB_Click(object sender, EventArgs e)
        {
            if (!ExtraMinus1LightColourB.Enabled) return;

            if (float.TryParse(ExtraLightColourBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                ExtraLightColourBTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void ExtraMinus1LightColourA_Click(object sender, EventArgs e)
        {
            if (!ExtraMinus1LightColourA.Enabled) return;

            if (float.TryParse(ExtraLightColourATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue <= MIN_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot be less than {MIN_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue - 1f;
                ExtraLightColourATextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void ExtraPlus1LightColourR_Click(object sender, EventArgs e)
        {
            if (!ExtraPlus1LightColourR.Enabled) return;

            if (float.TryParse(ExtraLightColourRTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                ExtraLightColourRTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void ExtraPlus1LightColourG_Click(object sender, EventArgs e)
        {
            if (!ExtraPlus1LightColourG.Enabled) return;

            if (float.TryParse(ExtraLightColourGTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                ExtraLightColourGTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void ExtraPlus1LightColourB_Click(object sender, EventArgs e)
        {
            if (!ExtraPlus1LightColourB.Enabled) return;

            if (float.TryParse(ExtraLightColourBTextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                ExtraLightColourBTextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void ExtraPlus1LightColourA_Click(object sender, EventArgs e)
        {
            if (!ExtraPlus1LightColourA.Enabled) return;

            if (float.TryParse(ExtraLightColourATextbox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentValue))
            {
                if (currentValue >= MAX_FILTER_VALUE)
                {
                    MessageBox.Show($"Value cannot exceed {MAX_FILTER_VALUE:F2}. Valid range is {MIN_FILTER_VALUE:F2} to {MAX_FILTER_VALUE:F2}.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float newValue = currentValue + 1f;
                ExtraLightColourATextbox.Text = newValue.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        #endregion
    }
}