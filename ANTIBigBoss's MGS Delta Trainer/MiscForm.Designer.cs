using System.Drawing;
using System.Windows.Forms;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    partial class MiscForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiscForm));
            SwapToHealthAndAlertsForm = new Button();
            SwapToCamoForm = new Button();
            SwapToItemsForm = new Button();
            SwapToWeaponsForm = new Button();
            PissFilterRTextbox = new TextBox();
            PissFilterGTextbox = new TextBox();
            PissFilterBTextbox = new TextBox();
            PissFilterEditingCheckBox = new CheckBox();
            RestartStageButton = new Button();
            FogCheckBox = new CheckBox();
            ResetFiltersButton = new Button();
            PissFilterATextbox = new TextBox();
            PissFilterRTrackBar = new TrackBar();
            PissFilterGTrackBar = new TrackBar();
            PissFilterBTrackBar = new TrackBar();
            PissFilterATrackBar = new TrackBar();
            Plus1PissFilterR = new Button();
            Minus1PissFilterR = new Button();
            Minus1PissFilterG = new Button();
            Plus1PissFilterG = new Button();
            Minus1PissFilterA = new Button();
            Plus1PissFilterA = new Button();
            Minus1PissFilterB = new Button();
            Plus1PissFilterB = new Button();
            Minus1LightColourA = new Button();
            Plus1LightColourA = new Button();
            Minus1LightColourB = new Button();
            Plus1LightColourB = new Button();
            Minus1LightColourG = new Button();
            Plus1LightColourG = new Button();
            Minus1LightColourR = new Button();
            Plus1LightColourR = new Button();
            LightColourATrackBar = new TrackBar();
            LightColourBTrackBar = new TrackBar();
            LightColourGTrackBar = new TrackBar();
            LightColourRTrackBar = new TrackBar();
            LightColourATextbox = new TextBox();
            ResetColourLightingButton = new Button();
            LightColourEditingCheckBox = new CheckBox();
            LightColourBTextbox = new TextBox();
            LightColourGTextbox = new TextBox();
            LightColourRTextbox = new TextBox();
            Minus1WorldLight = new Button();
            Plus1WorldLight = new Button();
            WorldLightingTrackBar = new TrackBar();
            ResetWorldLightingButton = new Button();
            WorldLightEditingCheckBox = new CheckBox();
            WorldLightingTextbox = new TextBox();
            ChangeDifficultyButton = new Button();
            DifficultyChangeDropdown = new ComboBox();
            GameStatsFormSwap = new Button();
            ((System.ComponentModel.ISupportInitialize)PissFilterRTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PissFilterGTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PissFilterBTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PissFilterATrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LightColourATrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LightColourBTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LightColourGTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LightColourRTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WorldLightingTrackBar).BeginInit();
            SuspendLayout();
            // 
            // SwapToHealthAndAlertsForm
            // 
            SwapToHealthAndAlertsForm.BackgroundImage = (Image)resources.GetObject("SwapToHealthAndAlertsForm.BackgroundImage");
            SwapToHealthAndAlertsForm.Cursor = Cursors.Hand;
            SwapToHealthAndAlertsForm.FlatStyle = FlatStyle.Flat;
            SwapToHealthAndAlertsForm.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            SwapToHealthAndAlertsForm.ImageAlign = ContentAlignment.TopCenter;
            SwapToHealthAndAlertsForm.ImeMode = ImeMode.NoControl;
            SwapToHealthAndAlertsForm.Location = new Point(452, 13);
            SwapToHealthAndAlertsForm.Name = "SwapToHealthAndAlertsForm";
            SwapToHealthAndAlertsForm.Size = new Size(130, 31);
            SwapToHealthAndAlertsForm.TabIndex = 647;
            SwapToHealthAndAlertsForm.Text = "Health/Alerts";
            SwapToHealthAndAlertsForm.UseVisualStyleBackColor = true;
            SwapToHealthAndAlertsForm.Click += SwapToHealthAndAlertsForm_Click;
            // 
            // SwapToCamoForm
            // 
            SwapToCamoForm.BackgroundImage = (Image)resources.GetObject("SwapToCamoForm.BackgroundImage");
            SwapToCamoForm.Cursor = Cursors.Hand;
            SwapToCamoForm.FlatStyle = FlatStyle.Flat;
            SwapToCamoForm.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            SwapToCamoForm.ImageAlign = ContentAlignment.TopCenter;
            SwapToCamoForm.ImeMode = ImeMode.NoControl;
            SwapToCamoForm.Location = new Point(316, 13);
            SwapToCamoForm.Name = "SwapToCamoForm";
            SwapToCamoForm.Size = new Size(130, 31);
            SwapToCamoForm.TabIndex = 646;
            SwapToCamoForm.Text = "Camo";
            SwapToCamoForm.UseVisualStyleBackColor = true;
            SwapToCamoForm.Click += SwapToCamoForm_Click;
            // 
            // SwapToItemsForm
            // 
            SwapToItemsForm.BackgroundImage = (Image)resources.GetObject("SwapToItemsForm.BackgroundImage");
            SwapToItemsForm.Cursor = Cursors.Hand;
            SwapToItemsForm.FlatStyle = FlatStyle.Flat;
            SwapToItemsForm.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            SwapToItemsForm.ImageAlign = ContentAlignment.TopCenter;
            SwapToItemsForm.ImeMode = ImeMode.NoControl;
            SwapToItemsForm.Location = new Point(180, 13);
            SwapToItemsForm.Name = "SwapToItemsForm";
            SwapToItemsForm.Size = new Size(130, 31);
            SwapToItemsForm.TabIndex = 645;
            SwapToItemsForm.Text = "Items";
            SwapToItemsForm.UseVisualStyleBackColor = true;
            SwapToItemsForm.Click += SwapToItemsForm_Click;
            // 
            // SwapToWeaponsForm
            // 
            SwapToWeaponsForm.BackgroundImage = (Image)resources.GetObject("SwapToWeaponsForm.BackgroundImage");
            SwapToWeaponsForm.Cursor = Cursors.Hand;
            SwapToWeaponsForm.FlatStyle = FlatStyle.Flat;
            SwapToWeaponsForm.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            SwapToWeaponsForm.ImageAlign = ContentAlignment.TopCenter;
            SwapToWeaponsForm.ImeMode = ImeMode.NoControl;
            SwapToWeaponsForm.Location = new Point(44, 13);
            SwapToWeaponsForm.Name = "SwapToWeaponsForm";
            SwapToWeaponsForm.Size = new Size(130, 31);
            SwapToWeaponsForm.TabIndex = 644;
            SwapToWeaponsForm.Text = "Weapons";
            SwapToWeaponsForm.UseVisualStyleBackColor = true;
            SwapToWeaponsForm.Click += SwapToWeaponsForm_Click;
            // 
            // PissFilterRTextbox
            // 
            PissFilterRTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PissFilterRTextbox.Location = new Point(104, 275);
            PissFilterRTextbox.Name = "PissFilterRTextbox";
            PissFilterRTextbox.Size = new Size(107, 27);
            PissFilterRTextbox.TabIndex = 649;
            PissFilterRTextbox.TextChanged += PissFilterRTextbox_TextChanged;
            // 
            // PissFilterGTextbox
            // 
            PissFilterGTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PissFilterGTextbox.Location = new Point(104, 369);
            PissFilterGTextbox.Name = "PissFilterGTextbox";
            PissFilterGTextbox.Size = new Size(107, 27);
            PissFilterGTextbox.TabIndex = 651;
            PissFilterGTextbox.TextChanged += PissFilterGTextbox_TextChanged;
            // 
            // PissFilterBTextbox
            // 
            PissFilterBTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PissFilterBTextbox.Location = new Point(104, 458);
            PissFilterBTextbox.Name = "PissFilterBTextbox";
            PissFilterBTextbox.Size = new Size(107, 27);
            PissFilterBTextbox.TabIndex = 653;
            PissFilterBTextbox.TextChanged += PissFilterBTextbox_TextChanged;
            // 
            // PissFilterEditingCheckBox
            // 
            PissFilterEditingCheckBox.BackgroundImage = (Image)resources.GetObject("PissFilterEditingCheckBox.BackgroundImage");
            PissFilterEditingCheckBox.FlatStyle = FlatStyle.Flat;
            PissFilterEditingCheckBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PissFilterEditingCheckBox.Location = new Point(44, 163);
            PissFilterEditingCheckBox.Name = "PissFilterEditingCheckBox";
            PissFilterEditingCheckBox.Size = new Size(226, 50);
            PissFilterEditingCheckBox.TabIndex = 865;
            PissFilterEditingCheckBox.Text = "Enable/Disable Filter Editing";
            PissFilterEditingCheckBox.UseVisualStyleBackColor = true;
            PissFilterEditingCheckBox.CheckedChanged += PissFilterEditingCheckBox_CheckedChanged;
            // 
            // RestartStageButton
            // 
            RestartStageButton.BackgroundImage = (Image)resources.GetObject("RestartStageButton.BackgroundImage");
            RestartStageButton.Cursor = Cursors.Hand;
            RestartStageButton.FlatStyle = FlatStyle.Flat;
            RestartStageButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            RestartStageButton.ImageAlign = ContentAlignment.TopCenter;
            RestartStageButton.Location = new Point(990, 163);
            RestartStageButton.Name = "RestartStageButton";
            RestartStageButton.Size = new Size(164, 50);
            RestartStageButton.TabIndex = 866;
            RestartStageButton.Text = "Restart Stage";
            RestartStageButton.UseVisualStyleBackColor = true;
            RestartStageButton.Click += RestartStageButton_Click;
            // 
            // FogCheckBox
            // 
            FogCheckBox.BackgroundImage = (Image)resources.GetObject("FogCheckBox.BackgroundImage");
            FogCheckBox.FlatStyle = FlatStyle.Flat;
            FogCheckBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            FogCheckBox.Location = new Point(990, 219);
            FogCheckBox.Name = "FogCheckBox";
            FogCheckBox.Size = new Size(164, 50);
            FogCheckBox.TabIndex = 867;
            FogCheckBox.Text = "Disable Fog";
            FogCheckBox.UseVisualStyleBackColor = true;
            FogCheckBox.CheckedChanged += FogCheckBox_CheckedChanged;
            // 
            // ResetFiltersButton
            // 
            ResetFiltersButton.BackgroundImage = (Image)resources.GetObject("ResetFiltersButton.BackgroundImage");
            ResetFiltersButton.Cursor = Cursors.Hand;
            ResetFiltersButton.FlatStyle = FlatStyle.Flat;
            ResetFiltersButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            ResetFiltersButton.ImageAlign = ContentAlignment.TopCenter;
            ResetFiltersButton.Location = new Point(44, 219);
            ResetFiltersButton.Name = "ResetFiltersButton";
            ResetFiltersButton.Size = new Size(226, 50);
            ResetFiltersButton.TabIndex = 868;
            ResetFiltersButton.Text = "Reset RGBA Filters";
            ResetFiltersButton.UseVisualStyleBackColor = true;
            ResetFiltersButton.Click += ResetFiltersButton_Click;
            // 
            // PissFilterATextbox
            // 
            PissFilterATextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PissFilterATextbox.Location = new Point(104, 553);
            PissFilterATextbox.Name = "PissFilterATextbox";
            PissFilterATextbox.Size = new Size(107, 27);
            PissFilterATextbox.TabIndex = 870;
            PissFilterATextbox.TextChanged += PissFilterATextbox_TextChanged;
            // 
            // PissFilterRTrackBar
            // 
            PissFilterRTrackBar.BackColor = Color.FromArgb(156, 156, 124);
            PissFilterRTrackBar.Cursor = Cursors.NoMoveHoriz;
            PissFilterRTrackBar.Location = new Point(44, 308);
            PissFilterRTrackBar.Name = "PissFilterRTrackBar";
            PissFilterRTrackBar.Size = new Size(226, 45);
            PissFilterRTrackBar.TabIndex = 871;
            PissFilterRTrackBar.Scroll += PissFilterRTrackBar_Scroll;
            // 
            // PissFilterGTrackBar
            // 
            PissFilterGTrackBar.BackColor = Color.FromArgb(156, 156, 124);
            PissFilterGTrackBar.Cursor = Cursors.NoMoveHoriz;
            PissFilterGTrackBar.Location = new Point(44, 402);
            PissFilterGTrackBar.Name = "PissFilterGTrackBar";
            PissFilterGTrackBar.Size = new Size(226, 45);
            PissFilterGTrackBar.TabIndex = 872;
            PissFilterGTrackBar.Scroll += PissFilterGTrackBar_Scroll;
            // 
            // PissFilterBTrackBar
            // 
            PissFilterBTrackBar.BackColor = Color.FromArgb(156, 156, 124);
            PissFilterBTrackBar.Cursor = Cursors.NoMoveHoriz;
            PissFilterBTrackBar.Location = new Point(44, 491);
            PissFilterBTrackBar.Name = "PissFilterBTrackBar";
            PissFilterBTrackBar.Size = new Size(226, 45);
            PissFilterBTrackBar.TabIndex = 873;
            PissFilterBTrackBar.Scroll += PissFilterBTrackBar_Scroll;
            // 
            // PissFilterATrackBar
            // 
            PissFilterATrackBar.BackColor = Color.FromArgb(156, 156, 124);
            PissFilterATrackBar.Cursor = Cursors.NoMoveHoriz;
            PissFilterATrackBar.Location = new Point(44, 586);
            PissFilterATrackBar.Name = "PissFilterATrackBar";
            PissFilterATrackBar.Size = new Size(226, 45);
            PissFilterATrackBar.TabIndex = 874;
            PissFilterATrackBar.Scroll += PissFilterATrackBar_Scroll;
            // 
            // Plus1PissFilterR
            // 
            Plus1PissFilterR.BackgroundImage = (Image)resources.GetObject("Plus1PissFilterR.BackgroundImage");
            Plus1PissFilterR.Cursor = Cursors.Hand;
            Plus1PissFilterR.FlatStyle = FlatStyle.Flat;
            Plus1PissFilterR.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1PissFilterR.ImageAlign = ContentAlignment.TopCenter;
            Plus1PissFilterR.Location = new Point(220, 274);
            Plus1PissFilterR.Name = "Plus1PissFilterR";
            Plus1PissFilterR.Size = new Size(50, 27);
            Plus1PissFilterR.TabIndex = 875;
            Plus1PissFilterR.Text = "+1";
            Plus1PissFilterR.UseVisualStyleBackColor = true;
            Plus1PissFilterR.Click += Plus1PissFilterR_Click;
            // 
            // Minus1PissFilterR
            // 
            Minus1PissFilterR.BackgroundImage = (Image)resources.GetObject("Minus1PissFilterR.BackgroundImage");
            Minus1PissFilterR.Cursor = Cursors.Hand;
            Minus1PissFilterR.FlatStyle = FlatStyle.Flat;
            Minus1PissFilterR.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1PissFilterR.ImageAlign = ContentAlignment.TopCenter;
            Minus1PissFilterR.Location = new Point(44, 274);
            Minus1PissFilterR.Name = "Minus1PissFilterR";
            Minus1PissFilterR.Size = new Size(50, 27);
            Minus1PissFilterR.TabIndex = 876;
            Minus1PissFilterR.Text = "-1";
            Minus1PissFilterR.UseVisualStyleBackColor = true;
            Minus1PissFilterR.Click += Minus1PissFilterR_Click;
            // 
            // Minus1PissFilterG
            // 
            Minus1PissFilterG.BackgroundImage = (Image)resources.GetObject("Minus1PissFilterG.BackgroundImage");
            Minus1PissFilterG.Cursor = Cursors.Hand;
            Minus1PissFilterG.FlatStyle = FlatStyle.Flat;
            Minus1PissFilterG.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1PissFilterG.ImageAlign = ContentAlignment.TopCenter;
            Minus1PissFilterG.Location = new Point(44, 369);
            Minus1PissFilterG.Name = "Minus1PissFilterG";
            Minus1PissFilterG.Size = new Size(50, 27);
            Minus1PissFilterG.TabIndex = 878;
            Minus1PissFilterG.Text = "-1";
            Minus1PissFilterG.UseVisualStyleBackColor = true;
            Minus1PissFilterG.Click += Minus1PissFilterG_Click;
            // 
            // Plus1PissFilterG
            // 
            Plus1PissFilterG.BackgroundImage = (Image)resources.GetObject("Plus1PissFilterG.BackgroundImage");
            Plus1PissFilterG.Cursor = Cursors.Hand;
            Plus1PissFilterG.FlatStyle = FlatStyle.Flat;
            Plus1PissFilterG.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1PissFilterG.ImageAlign = ContentAlignment.TopCenter;
            Plus1PissFilterG.Location = new Point(220, 369);
            Plus1PissFilterG.Name = "Plus1PissFilterG";
            Plus1PissFilterG.Size = new Size(50, 27);
            Plus1PissFilterG.TabIndex = 877;
            Plus1PissFilterG.Text = "+1";
            Plus1PissFilterG.UseVisualStyleBackColor = true;
            Plus1PissFilterG.Click += Plus1PissFilterG_Click;
            // 
            // Minus1PissFilterA
            // 
            Minus1PissFilterA.BackgroundImage = (Image)resources.GetObject("Minus1PissFilterA.BackgroundImage");
            Minus1PissFilterA.Cursor = Cursors.Hand;
            Minus1PissFilterA.FlatStyle = FlatStyle.Flat;
            Minus1PissFilterA.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1PissFilterA.ImageAlign = ContentAlignment.TopCenter;
            Minus1PissFilterA.Location = new Point(44, 552);
            Minus1PissFilterA.Name = "Minus1PissFilterA";
            Minus1PissFilterA.Size = new Size(50, 27);
            Minus1PissFilterA.TabIndex = 882;
            Minus1PissFilterA.Text = "-1";
            Minus1PissFilterA.UseVisualStyleBackColor = true;
            Minus1PissFilterA.Click += Minus1PissFilterA_Click;
            // 
            // Plus1PissFilterA
            // 
            Plus1PissFilterA.BackgroundImage = (Image)resources.GetObject("Plus1PissFilterA.BackgroundImage");
            Plus1PissFilterA.Cursor = Cursors.Hand;
            Plus1PissFilterA.FlatStyle = FlatStyle.Flat;
            Plus1PissFilterA.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1PissFilterA.ImageAlign = ContentAlignment.TopCenter;
            Plus1PissFilterA.Location = new Point(220, 552);
            Plus1PissFilterA.Name = "Plus1PissFilterA";
            Plus1PissFilterA.Size = new Size(50, 27);
            Plus1PissFilterA.TabIndex = 881;
            Plus1PissFilterA.Text = "+1";
            Plus1PissFilterA.UseVisualStyleBackColor = true;
            Plus1PissFilterA.Click += Plus1PissFilterA_Click;
            // 
            // Minus1PissFilterB
            // 
            Minus1PissFilterB.BackgroundImage = (Image)resources.GetObject("Minus1PissFilterB.BackgroundImage");
            Minus1PissFilterB.Cursor = Cursors.Hand;
            Minus1PissFilterB.FlatStyle = FlatStyle.Flat;
            Minus1PissFilterB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1PissFilterB.ImageAlign = ContentAlignment.TopCenter;
            Minus1PissFilterB.Location = new Point(44, 458);
            Minus1PissFilterB.Name = "Minus1PissFilterB";
            Minus1PissFilterB.Size = new Size(50, 27);
            Minus1PissFilterB.TabIndex = 880;
            Minus1PissFilterB.Text = "-1";
            Minus1PissFilterB.UseVisualStyleBackColor = true;
            Minus1PissFilterB.Click += Minus1PissFilterB_Click;
            // 
            // Plus1PissFilterB
            // 
            Plus1PissFilterB.BackgroundImage = (Image)resources.GetObject("Plus1PissFilterB.BackgroundImage");
            Plus1PissFilterB.Cursor = Cursors.Hand;
            Plus1PissFilterB.FlatStyle = FlatStyle.Flat;
            Plus1PissFilterB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1PissFilterB.ImageAlign = ContentAlignment.TopCenter;
            Plus1PissFilterB.Location = new Point(220, 458);
            Plus1PissFilterB.Name = "Plus1PissFilterB";
            Plus1PissFilterB.Size = new Size(50, 27);
            Plus1PissFilterB.TabIndex = 879;
            Plus1PissFilterB.Text = "+1";
            Plus1PissFilterB.UseVisualStyleBackColor = true;
            Plus1PissFilterB.Click += Plus1PissFilterB_Click;
            // 
            // Minus1LightColourA
            // 
            Minus1LightColourA.BackgroundImage = (Image)resources.GetObject("Minus1LightColourA.BackgroundImage");
            Minus1LightColourA.Cursor = Cursors.Hand;
            Minus1LightColourA.FlatStyle = FlatStyle.Flat;
            Minus1LightColourA.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1LightColourA.ImageAlign = ContentAlignment.TopCenter;
            Minus1LightColourA.Location = new Point(301, 552);
            Minus1LightColourA.Name = "Minus1LightColourA";
            Minus1LightColourA.Size = new Size(50, 27);
            Minus1LightColourA.TabIndex = 900;
            Minus1LightColourA.Text = "-1";
            Minus1LightColourA.UseVisualStyleBackColor = true;
            Minus1LightColourA.Click += Minus1LightColourA_Click;
            // 
            // Plus1LightColourA
            // 
            Plus1LightColourA.BackgroundImage = (Image)resources.GetObject("Plus1LightColourA.BackgroundImage");
            Plus1LightColourA.Cursor = Cursors.Hand;
            Plus1LightColourA.FlatStyle = FlatStyle.Flat;
            Plus1LightColourA.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1LightColourA.ImageAlign = ContentAlignment.TopCenter;
            Plus1LightColourA.Location = new Point(477, 552);
            Plus1LightColourA.Name = "Plus1LightColourA";
            Plus1LightColourA.Size = new Size(50, 27);
            Plus1LightColourA.TabIndex = 899;
            Plus1LightColourA.Text = "+1";
            Plus1LightColourA.UseVisualStyleBackColor = true;
            Plus1LightColourA.Click += Plus1LightColourA_Click;
            // 
            // Minus1LightColourB
            // 
            Minus1LightColourB.BackgroundImage = (Image)resources.GetObject("Minus1LightColourB.BackgroundImage");
            Minus1LightColourB.Cursor = Cursors.Hand;
            Minus1LightColourB.FlatStyle = FlatStyle.Flat;
            Minus1LightColourB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1LightColourB.ImageAlign = ContentAlignment.TopCenter;
            Minus1LightColourB.Location = new Point(301, 458);
            Minus1LightColourB.Name = "Minus1LightColourB";
            Minus1LightColourB.Size = new Size(50, 27);
            Minus1LightColourB.TabIndex = 898;
            Minus1LightColourB.Text = "-1";
            Minus1LightColourB.UseVisualStyleBackColor = true;
            Minus1LightColourB.Click += Minus1LightColourB_Click;
            // 
            // Plus1LightColourB
            // 
            Plus1LightColourB.BackgroundImage = (Image)resources.GetObject("Plus1LightColourB.BackgroundImage");
            Plus1LightColourB.Cursor = Cursors.Hand;
            Plus1LightColourB.FlatStyle = FlatStyle.Flat;
            Plus1LightColourB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1LightColourB.ImageAlign = ContentAlignment.TopCenter;
            Plus1LightColourB.Location = new Point(477, 458);
            Plus1LightColourB.Name = "Plus1LightColourB";
            Plus1LightColourB.Size = new Size(50, 27);
            Plus1LightColourB.TabIndex = 897;
            Plus1LightColourB.Text = "+1";
            Plus1LightColourB.UseVisualStyleBackColor = true;
            Plus1LightColourB.Click += Plus1LightColourB_Click;
            // 
            // Minus1LightColourG
            // 
            Minus1LightColourG.BackgroundImage = (Image)resources.GetObject("Minus1LightColourG.BackgroundImage");
            Minus1LightColourG.Cursor = Cursors.Hand;
            Minus1LightColourG.FlatStyle = FlatStyle.Flat;
            Minus1LightColourG.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1LightColourG.ImageAlign = ContentAlignment.TopCenter;
            Minus1LightColourG.Location = new Point(301, 369);
            Minus1LightColourG.Name = "Minus1LightColourG";
            Minus1LightColourG.Size = new Size(50, 27);
            Minus1LightColourG.TabIndex = 896;
            Minus1LightColourG.Text = "-1";
            Minus1LightColourG.UseVisualStyleBackColor = true;
            Minus1LightColourG.Click += Minus1LightColourG_Click;
            // 
            // Plus1LightColourG
            // 
            Plus1LightColourG.BackgroundImage = (Image)resources.GetObject("Plus1LightColourG.BackgroundImage");
            Plus1LightColourG.Cursor = Cursors.Hand;
            Plus1LightColourG.FlatStyle = FlatStyle.Flat;
            Plus1LightColourG.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1LightColourG.ImageAlign = ContentAlignment.TopCenter;
            Plus1LightColourG.Location = new Point(477, 369);
            Plus1LightColourG.Name = "Plus1LightColourG";
            Plus1LightColourG.Size = new Size(50, 27);
            Plus1LightColourG.TabIndex = 895;
            Plus1LightColourG.Text = "+1";
            Plus1LightColourG.UseVisualStyleBackColor = true;
            Plus1LightColourG.Click += Plus1LightColourG_Click;
            // 
            // Minus1LightColourR
            // 
            Minus1LightColourR.BackgroundImage = (Image)resources.GetObject("Minus1LightColourR.BackgroundImage");
            Minus1LightColourR.Cursor = Cursors.Hand;
            Minus1LightColourR.FlatStyle = FlatStyle.Flat;
            Minus1LightColourR.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1LightColourR.ImageAlign = ContentAlignment.TopCenter;
            Minus1LightColourR.Location = new Point(301, 274);
            Minus1LightColourR.Name = "Minus1LightColourR";
            Minus1LightColourR.Size = new Size(50, 27);
            Minus1LightColourR.TabIndex = 894;
            Minus1LightColourR.Text = "-1";
            Minus1LightColourR.UseVisualStyleBackColor = true;
            Minus1LightColourR.Click += Minus1LightColourR_Click;
            // 
            // Plus1LightColourR
            // 
            Plus1LightColourR.BackgroundImage = (Image)resources.GetObject("Plus1LightColourR.BackgroundImage");
            Plus1LightColourR.Cursor = Cursors.Hand;
            Plus1LightColourR.FlatStyle = FlatStyle.Flat;
            Plus1LightColourR.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1LightColourR.ImageAlign = ContentAlignment.TopCenter;
            Plus1LightColourR.Location = new Point(477, 274);
            Plus1LightColourR.Name = "Plus1LightColourR";
            Plus1LightColourR.Size = new Size(50, 27);
            Plus1LightColourR.TabIndex = 893;
            Plus1LightColourR.Text = "+1";
            Plus1LightColourR.UseVisualStyleBackColor = true;
            Plus1LightColourR.Click += Plus1LightColourR_Click;
            // 
            // LightColourATrackBar
            // 
            LightColourATrackBar.BackColor = Color.FromArgb(156, 156, 124);
            LightColourATrackBar.Cursor = Cursors.NoMoveHoriz;
            LightColourATrackBar.Location = new Point(301, 586);
            LightColourATrackBar.Name = "LightColourATrackBar";
            LightColourATrackBar.Size = new Size(226, 45);
            LightColourATrackBar.TabIndex = 892;
            LightColourATrackBar.Scroll += LightColourATrackBar_Scroll;
            // 
            // LightColourBTrackBar
            // 
            LightColourBTrackBar.BackColor = Color.FromArgb(156, 156, 124);
            LightColourBTrackBar.Cursor = Cursors.NoMoveHoriz;
            LightColourBTrackBar.Location = new Point(301, 491);
            LightColourBTrackBar.Name = "LightColourBTrackBar";
            LightColourBTrackBar.Size = new Size(226, 45);
            LightColourBTrackBar.TabIndex = 891;
            LightColourBTrackBar.Scroll += LightColourBTrackBar_Scroll;
            // 
            // LightColourGTrackBar
            // 
            LightColourGTrackBar.BackColor = Color.FromArgb(156, 156, 124);
            LightColourGTrackBar.Cursor = Cursors.NoMoveHoriz;
            LightColourGTrackBar.Location = new Point(301, 402);
            LightColourGTrackBar.Name = "LightColourGTrackBar";
            LightColourGTrackBar.Size = new Size(226, 45);
            LightColourGTrackBar.TabIndex = 890;
            LightColourGTrackBar.Scroll += LightColourGTrackBar_Scroll;
            // 
            // LightColourRTrackBar
            // 
            LightColourRTrackBar.BackColor = Color.FromArgb(156, 156, 124);
            LightColourRTrackBar.Cursor = Cursors.NoMoveHoriz;
            LightColourRTrackBar.Location = new Point(301, 308);
            LightColourRTrackBar.Name = "LightColourRTrackBar";
            LightColourRTrackBar.Size = new Size(226, 45);
            LightColourRTrackBar.TabIndex = 889;
            LightColourRTrackBar.Scroll += LightColourRTrackBar_Scroll;
            // 
            // LightColourATextbox
            // 
            LightColourATextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            LightColourATextbox.Location = new Point(361, 553);
            LightColourATextbox.Name = "LightColourATextbox";
            LightColourATextbox.Size = new Size(107, 27);
            LightColourATextbox.TabIndex = 888;
            LightColourATextbox.TextChanged += LightColourATextbox_TextChanged;
            // 
            // ResetColourLightingButton
            // 
            ResetColourLightingButton.BackgroundImage = (Image)resources.GetObject("ResetColourLightingButton.BackgroundImage");
            ResetColourLightingButton.Cursor = Cursors.Hand;
            ResetColourLightingButton.FlatStyle = FlatStyle.Flat;
            ResetColourLightingButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            ResetColourLightingButton.ImageAlign = ContentAlignment.TopCenter;
            ResetColourLightingButton.Location = new Point(301, 219);
            ResetColourLightingButton.Name = "ResetColourLightingButton";
            ResetColourLightingButton.Size = new Size(226, 50);
            ResetColourLightingButton.TabIndex = 887;
            ResetColourLightingButton.Text = "Reset RGBA Colour Filters";
            ResetColourLightingButton.UseVisualStyleBackColor = true;
            ResetColourLightingButton.Click += ResetColourLightingButton_Click;
            // 
            // LightColourEditingCheckBox
            // 
            LightColourEditingCheckBox.BackgroundImage = (Image)resources.GetObject("LightColourEditingCheckBox.BackgroundImage");
            LightColourEditingCheckBox.FlatStyle = FlatStyle.Flat;
            LightColourEditingCheckBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            LightColourEditingCheckBox.Location = new Point(301, 163);
            LightColourEditingCheckBox.Name = "LightColourEditingCheckBox";
            LightColourEditingCheckBox.Size = new Size(226, 50);
            LightColourEditingCheckBox.TabIndex = 886;
            LightColourEditingCheckBox.Text = "Enable/Disable Colour Light Editing";
            LightColourEditingCheckBox.UseVisualStyleBackColor = true;
            LightColourEditingCheckBox.CheckedChanged += LightColourEditingCheckBox_CheckedChanged;
            // 
            // LightColourBTextbox
            // 
            LightColourBTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            LightColourBTextbox.Location = new Point(361, 458);
            LightColourBTextbox.Name = "LightColourBTextbox";
            LightColourBTextbox.Size = new Size(107, 27);
            LightColourBTextbox.TabIndex = 885;
            LightColourBTextbox.TextChanged += LightColourBTextbox_TextChanged;
            // 
            // LightColourGTextbox
            // 
            LightColourGTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            LightColourGTextbox.Location = new Point(361, 369);
            LightColourGTextbox.Name = "LightColourGTextbox";
            LightColourGTextbox.Size = new Size(107, 27);
            LightColourGTextbox.TabIndex = 884;
            LightColourGTextbox.TextChanged += LightColourGTextbox_TextChanged;
            // 
            // LightColourRTextbox
            // 
            LightColourRTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            LightColourRTextbox.Location = new Point(361, 275);
            LightColourRTextbox.Name = "LightColourRTextbox";
            LightColourRTextbox.Size = new Size(107, 27);
            LightColourRTextbox.TabIndex = 883;
            LightColourRTextbox.TextChanged += LightColourRTextbox_TextChanged;
            // 
            // Minus1WorldLight
            // 
            Minus1WorldLight.BackgroundImage = (Image)resources.GetObject("Minus1WorldLight.BackgroundImage");
            Minus1WorldLight.Cursor = Cursors.Hand;
            Minus1WorldLight.FlatStyle = FlatStyle.Flat;
            Minus1WorldLight.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Minus1WorldLight.ImageAlign = ContentAlignment.TopCenter;
            Minus1WorldLight.Location = new Point(564, 274);
            Minus1WorldLight.Name = "Minus1WorldLight";
            Minus1WorldLight.Size = new Size(50, 27);
            Minus1WorldLight.TabIndex = 906;
            Minus1WorldLight.Text = "-1";
            Minus1WorldLight.UseVisualStyleBackColor = true;
            Minus1WorldLight.Click += Minus1WorldLight_Click;
            // 
            // Plus1WorldLight
            // 
            Plus1WorldLight.BackgroundImage = (Image)resources.GetObject("Plus1WorldLight.BackgroundImage");
            Plus1WorldLight.Cursor = Cursors.Hand;
            Plus1WorldLight.FlatStyle = FlatStyle.Flat;
            Plus1WorldLight.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Plus1WorldLight.ImageAlign = ContentAlignment.TopCenter;
            Plus1WorldLight.Location = new Point(740, 274);
            Plus1WorldLight.Name = "Plus1WorldLight";
            Plus1WorldLight.Size = new Size(50, 27);
            Plus1WorldLight.TabIndex = 905;
            Plus1WorldLight.Text = "+1";
            Plus1WorldLight.UseVisualStyleBackColor = true;
            Plus1WorldLight.Click += Plus1WorldLight_Click;
            // 
            // WorldLightingTrackBar
            // 
            WorldLightingTrackBar.BackColor = Color.FromArgb(156, 156, 124);
            WorldLightingTrackBar.Cursor = Cursors.NoMoveHoriz;
            WorldLightingTrackBar.Location = new Point(564, 308);
            WorldLightingTrackBar.Name = "WorldLightingTrackBar";
            WorldLightingTrackBar.Size = new Size(226, 45);
            WorldLightingTrackBar.TabIndex = 904;
            WorldLightingTrackBar.Scroll += WorldLightingTrackBar_Scroll;
            // 
            // ResetWorldLightingButton
            // 
            ResetWorldLightingButton.BackgroundImage = (Image)resources.GetObject("ResetWorldLightingButton.BackgroundImage");
            ResetWorldLightingButton.Cursor = Cursors.Hand;
            ResetWorldLightingButton.FlatStyle = FlatStyle.Flat;
            ResetWorldLightingButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            ResetWorldLightingButton.ImageAlign = ContentAlignment.TopCenter;
            ResetWorldLightingButton.Location = new Point(564, 219);
            ResetWorldLightingButton.Name = "ResetWorldLightingButton";
            ResetWorldLightingButton.Size = new Size(226, 50);
            ResetWorldLightingButton.TabIndex = 903;
            ResetWorldLightingButton.Text = "Reset Lighting";
            ResetWorldLightingButton.UseVisualStyleBackColor = true;
            ResetWorldLightingButton.Click += ResetWorldLightingButton_Click;
            // 
            // WorldLightEditingCheckBox
            // 
            WorldLightEditingCheckBox.BackgroundImage = (Image)resources.GetObject("WorldLightEditingCheckBox.BackgroundImage");
            WorldLightEditingCheckBox.FlatStyle = FlatStyle.Flat;
            WorldLightEditingCheckBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            WorldLightEditingCheckBox.Location = new Point(564, 163);
            WorldLightEditingCheckBox.Name = "WorldLightEditingCheckBox";
            WorldLightEditingCheckBox.Size = new Size(226, 50);
            WorldLightEditingCheckBox.TabIndex = 902;
            WorldLightEditingCheckBox.Text = "Enable/Disable World Light Editing";
            WorldLightEditingCheckBox.UseVisualStyleBackColor = true;
            WorldLightEditingCheckBox.CheckedChanged += WorldLightEditingCheckBox_CheckedChanged;
            // 
            // WorldLightingTextbox
            // 
            WorldLightingTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            WorldLightingTextbox.Location = new Point(624, 275);
            WorldLightingTextbox.Name = "WorldLightingTextbox";
            WorldLightingTextbox.Size = new Size(107, 27);
            WorldLightingTextbox.TabIndex = 901;
            WorldLightingTextbox.TextChanged += WorldLightingTextbox_TextChanged;
            // 
            // ChangeDifficultyButton
            // 
            ChangeDifficultyButton.BackgroundImage = (Image)resources.GetObject("ChangeDifficultyButton.BackgroundImage");
            ChangeDifficultyButton.Cursor = Cursors.Hand;
            ChangeDifficultyButton.FlatStyle = FlatStyle.Flat;
            ChangeDifficultyButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            ChangeDifficultyButton.ImeMode = ImeMode.NoControl;
            ChangeDifficultyButton.Location = new Point(989, 278);
            ChangeDifficultyButton.Name = "ChangeDifficultyButton";
            ChangeDifficultyButton.Size = new Size(165, 50);
            ChangeDifficultyButton.TabIndex = 908;
            ChangeDifficultyButton.Text = " Change Difficulty         (Area Change Needed)";
            ChangeDifficultyButton.UseVisualStyleBackColor = true;
            ChangeDifficultyButton.Click += ChangeDifficultyButton_Click;
            // 
            // DifficultyChangeDropdown
            // 
            DifficultyChangeDropdown.BackColor = SystemColors.Control;
            DifficultyChangeDropdown.Cursor = Cursors.Hand;
            DifficultyChangeDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            DifficultyChangeDropdown.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            DifficultyChangeDropdown.FormattingEnabled = true;
            DifficultyChangeDropdown.Items.AddRange(new object[] { "Very Easy", "Easy", "Normal", "Hard", "Extreme", "European Extreme" });
            DifficultyChangeDropdown.Location = new Point(989, 330);
            DifficultyChangeDropdown.Name = "DifficultyChangeDropdown";
            DifficultyChangeDropdown.Size = new Size(165, 23);
            DifficultyChangeDropdown.TabIndex = 907;
            // 
            // GameStatsFormSwap
            // 
            GameStatsFormSwap.BackgroundImage = (Image)resources.GetObject("GameStatsFormSwap.BackgroundImage");
            GameStatsFormSwap.Cursor = Cursors.Hand;
            GameStatsFormSwap.FlatStyle = FlatStyle.Flat;
            GameStatsFormSwap.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            GameStatsFormSwap.ImageAlign = ContentAlignment.TopCenter;
            GameStatsFormSwap.ImeMode = ImeMode.NoControl;
            GameStatsFormSwap.Location = new Point(588, 13);
            GameStatsFormSwap.Name = "GameStatsFormSwap";
            GameStatsFormSwap.Size = new Size(130, 31);
            GameStatsFormSwap.TabIndex = 909;
            GameStatsFormSwap.Text = "Game Stats";
            GameStatsFormSwap.UseVisualStyleBackColor = true;
            GameStatsFormSwap.Click += GameStatsFormSwap_Click;
            // 
            // MiscForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1166, 707);
            Controls.Add(GameStatsFormSwap);
            Controls.Add(ChangeDifficultyButton);
            Controls.Add(DifficultyChangeDropdown);
            Controls.Add(Minus1WorldLight);
            Controls.Add(Plus1WorldLight);
            Controls.Add(WorldLightingTrackBar);
            Controls.Add(ResetWorldLightingButton);
            Controls.Add(WorldLightEditingCheckBox);
            Controls.Add(WorldLightingTextbox);
            Controls.Add(Minus1LightColourA);
            Controls.Add(Plus1LightColourA);
            Controls.Add(Minus1LightColourB);
            Controls.Add(Plus1LightColourB);
            Controls.Add(Minus1LightColourG);
            Controls.Add(Plus1LightColourG);
            Controls.Add(Minus1LightColourR);
            Controls.Add(Plus1LightColourR);
            Controls.Add(LightColourATrackBar);
            Controls.Add(LightColourBTrackBar);
            Controls.Add(LightColourGTrackBar);
            Controls.Add(LightColourRTrackBar);
            Controls.Add(LightColourATextbox);
            Controls.Add(ResetColourLightingButton);
            Controls.Add(LightColourEditingCheckBox);
            Controls.Add(LightColourBTextbox);
            Controls.Add(LightColourGTextbox);
            Controls.Add(LightColourRTextbox);
            Controls.Add(Minus1PissFilterA);
            Controls.Add(Plus1PissFilterA);
            Controls.Add(Minus1PissFilterB);
            Controls.Add(Plus1PissFilterB);
            Controls.Add(Minus1PissFilterG);
            Controls.Add(Plus1PissFilterG);
            Controls.Add(Minus1PissFilterR);
            Controls.Add(Plus1PissFilterR);
            Controls.Add(PissFilterATrackBar);
            Controls.Add(PissFilterBTrackBar);
            Controls.Add(PissFilterGTrackBar);
            Controls.Add(PissFilterRTrackBar);
            Controls.Add(PissFilterATextbox);
            Controls.Add(ResetFiltersButton);
            Controls.Add(FogCheckBox);
            Controls.Add(RestartStageButton);
            Controls.Add(PissFilterEditingCheckBox);
            Controls.Add(PissFilterBTextbox);
            Controls.Add(PissFilterGTextbox);
            Controls.Add(PissFilterRTextbox);
            Controls.Add(SwapToHealthAndAlertsForm);
            Controls.Add(SwapToCamoForm);
            Controls.Add(SwapToItemsForm);
            Controls.Add(SwapToWeaponsForm);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MiscForm";
            Text = "ANTIBigBoss's MGS3 Delta Trainer - Miscellaneous Form";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)PissFilterRTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PissFilterGTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PissFilterBTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PissFilterATrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)LightColourATrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)LightColourBTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)LightColourGTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)LightColourRTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)WorldLightingTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox FogCheckBox;
        private Button SwapToHealthAndAlertsForm;
        private Button SwapToCamoForm;
        private Button SwapToItemsForm;
        private Button SwapToWeaponsForm;
        private TextBox PissFilterRTextbox;
        private TextBox PissFilterGTextbox;
        private TextBox PissFilterBTextbox;
        private CheckBox PissFilterEditingCheckBox;
        private Button RestartStageButton;
        private Button ResetFiltersButton;
        private TextBox PissFilterATextbox;
        private TrackBar PissFilterRTrackBar;
        private TrackBar PissFilterGTrackBar;
        private TrackBar PissFilterBTrackBar;
        private TrackBar PissFilterATrackBar;
        private Button Plus1PissFilterR;
        private Button Minus1PissFilterR;
        private Button Minus1PissFilterG;
        private Button Plus1PissFilterG;
        private Button Minus1PissFilterA;
        private Button Plus1PissFilterA;
        private Button Minus1PissFilterB;
        private Button Plus1PissFilterB;
        private Button Minus1LightColourA;
        private Button Plus1LightColourA;
        private Button Minus1LightColourB;
        private Button Plus1LightColourB;
        private Button Minus1LightColourG;
        private Button Plus1LightColourG;
        private Button Minus1LightColourR;
        private Button Plus1LightColourR;
        private TrackBar LightColourATrackBar;
        private TrackBar LightColourBTrackBar;
        private TrackBar LightColourGTrackBar;
        private TrackBar LightColourRTrackBar;
        private TextBox LightColourATextbox;
        private Button ResetColourLightingButton;
        private CheckBox LightColourEditingCheckBox;
        private TextBox LightColourBTextbox;
        private TextBox LightColourGTextbox;
        private TextBox LightColourRTextbox;
        private Button Minus1WorldLight;
        private Button Plus1WorldLight;
        private TrackBar WorldLightingTrackBar;
        private Button ResetWorldLightingButton;
        private CheckBox WorldLightEditingCheckBox;
        private TextBox WorldLightingTextbox;
        private Button ChangeDifficultyButton;
        private ComboBox DifficultyChangeDropdown;
        private Button GameStatsFormSwap;
    }
}