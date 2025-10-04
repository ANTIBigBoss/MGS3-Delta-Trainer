using System.Drawing;
using System.Windows.Forms;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            CamoFormSwap = new Button();
            ItemFormSwap = new Button();
            WeaponFormSwap = new Button();
            LogAOBs = new Button();
            StatsAndAlertForm = new Button();
            PatchNotesButton = new Button();
            MiscFormSwap = new Button();
            GameStatsFormSwap = new Button();
            SuspendLayout();
            // 
            // CamoFormSwap
            // 
            CamoFormSwap.BackgroundImage = (Image)resources.GetObject("CamoFormSwap.BackgroundImage");
            CamoFormSwap.BackgroundImageLayout = ImageLayout.Center;
            CamoFormSwap.Cursor = Cursors.Hand;
            CamoFormSwap.FlatStyle = FlatStyle.Flat;
            CamoFormSwap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            CamoFormSwap.ImageAlign = ContentAlignment.TopCenter;
            CamoFormSwap.ImeMode = ImeMode.NoControl;
            CamoFormSwap.Location = new Point(730, 247);
            CamoFormSwap.Name = "CamoFormSwap";
            CamoFormSwap.Size = new Size(426, 42);
            CamoFormSwap.TabIndex = 555;
            CamoFormSwap.Text = "Camo";
            CamoFormSwap.UseVisualStyleBackColor = true;
            CamoFormSwap.Click += CamoFormSwap_Click;
            // 
            // ItemFormSwap
            // 
            ItemFormSwap.BackgroundImage = (Image)resources.GetObject("ItemFormSwap.BackgroundImage");
            ItemFormSwap.BackgroundImageLayout = ImageLayout.Center;
            ItemFormSwap.Cursor = Cursors.Hand;
            ItemFormSwap.FlatStyle = FlatStyle.Flat;
            ItemFormSwap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ItemFormSwap.ImageAlign = ContentAlignment.TopCenter;
            ItemFormSwap.ImeMode = ImeMode.NoControl;
            ItemFormSwap.Location = new Point(730, 188);
            ItemFormSwap.Name = "ItemFormSwap";
            ItemFormSwap.Size = new Size(426, 42);
            ItemFormSwap.TabIndex = 554;
            ItemFormSwap.Text = "Items";
            ItemFormSwap.UseVisualStyleBackColor = true;
            ItemFormSwap.Click += ItemFormSwap_Click;
            // 
            // WeaponFormSwap
            // 
            WeaponFormSwap.BackColor = SystemColors.ActiveBorder;
            WeaponFormSwap.BackgroundImage = (Image)resources.GetObject("WeaponFormSwap.BackgroundImage");
            WeaponFormSwap.BackgroundImageLayout = ImageLayout.Center;
            WeaponFormSwap.Cursor = Cursors.Hand;
            WeaponFormSwap.FlatStyle = FlatStyle.Flat;
            WeaponFormSwap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            WeaponFormSwap.ImageAlign = ContentAlignment.TopCenter;
            WeaponFormSwap.ImeMode = ImeMode.NoControl;
            WeaponFormSwap.Location = new Point(730, 131);
            WeaponFormSwap.Name = "WeaponFormSwap";
            WeaponFormSwap.Size = new Size(426, 41);
            WeaponFormSwap.TabIndex = 559;
            WeaponFormSwap.Text = "Weapons";
            WeaponFormSwap.UseVisualStyleBackColor = false;
            WeaponFormSwap.Click += WeaponFormSwap_Click;
            // 
            // LogAOBs
            // 
            LogAOBs.BackColor = SystemColors.ActiveBorder;
            LogAOBs.BackgroundImage = (Image)resources.GetObject("LogAOBs.BackgroundImage");
            LogAOBs.BackgroundImageLayout = ImageLayout.Center;
            LogAOBs.Cursor = Cursors.Hand;
            LogAOBs.FlatStyle = FlatStyle.Flat;
            LogAOBs.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LogAOBs.ImageAlign = ContentAlignment.TopCenter;
            LogAOBs.ImeMode = ImeMode.NoControl;
            LogAOBs.Location = new Point(730, 481);
            LogAOBs.Name = "LogAOBs";
            LogAOBs.Size = new Size(426, 41);
            LogAOBs.TabIndex = 560;
            LogAOBs.Text = "Generate a Log File";
            LogAOBs.UseVisualStyleBackColor = false;
            LogAOBs.Click += LogAOBs_Click;
            // 
            // StatsAndAlertForm
            // 
            StatsAndAlertForm.BackgroundImage = (Image)resources.GetObject("StatsAndAlertForm.BackgroundImage");
            StatsAndAlertForm.BackgroundImageLayout = ImageLayout.Center;
            StatsAndAlertForm.Cursor = Cursors.Hand;
            StatsAndAlertForm.FlatStyle = FlatStyle.Flat;
            StatsAndAlertForm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            StatsAndAlertForm.ImageAlign = ContentAlignment.TopCenter;
            StatsAndAlertForm.ImeMode = ImeMode.NoControl;
            StatsAndAlertForm.Location = new Point(730, 307);
            StatsAndAlertForm.Name = "StatsAndAlertForm";
            StatsAndAlertForm.Size = new Size(426, 42);
            StatsAndAlertForm.TabIndex = 562;
            StatsAndAlertForm.Text = "Stats/Alerts";
            StatsAndAlertForm.UseVisualStyleBackColor = true;
            StatsAndAlertForm.Click += StatsAndAlertForm_Click;
            // 
            // PatchNotesButton
            // 
            PatchNotesButton.BackColor = SystemColors.ActiveBorder;
            PatchNotesButton.BackgroundImage = (Image)resources.GetObject("PatchNotesButton.BackgroundImage");
            PatchNotesButton.BackgroundImageLayout = ImageLayout.Center;
            PatchNotesButton.Cursor = Cursors.Hand;
            PatchNotesButton.FlatStyle = FlatStyle.Flat;
            PatchNotesButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            PatchNotesButton.ImageAlign = ContentAlignment.TopCenter;
            PatchNotesButton.ImeMode = ImeMode.NoControl;
            PatchNotesButton.Location = new Point(730, 539);
            PatchNotesButton.Name = "PatchNotesButton";
            PatchNotesButton.Size = new Size(426, 41);
            PatchNotesButton.TabIndex = 563;
            PatchNotesButton.Text = "Patch Notes";
            PatchNotesButton.UseVisualStyleBackColor = false;
            PatchNotesButton.Click += PatchNotesButton_Click;
            // 
            // MiscFormSwap
            // 
            MiscFormSwap.BackColor = SystemColors.ActiveBorder;
            MiscFormSwap.BackgroundImage = (Image)resources.GetObject("MiscFormSwap.BackgroundImage");
            MiscFormSwap.BackgroundImageLayout = ImageLayout.Center;
            MiscFormSwap.Cursor = Cursors.Hand;
            MiscFormSwap.FlatStyle = FlatStyle.Flat;
            MiscFormSwap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            MiscFormSwap.ImageAlign = ContentAlignment.TopCenter;
            MiscFormSwap.ImeMode = ImeMode.NoControl;
            MiscFormSwap.Location = new Point(730, 364);
            MiscFormSwap.Name = "MiscFormSwap";
            MiscFormSwap.Size = new Size(426, 41);
            MiscFormSwap.TabIndex = 564;
            MiscFormSwap.Text = "Misc";
            MiscFormSwap.UseVisualStyleBackColor = false;
            MiscFormSwap.Click += MiscFormSwap_Click;
            // 
            // GameStatsFormSwap
            // 
            GameStatsFormSwap.BackColor = SystemColors.ActiveBorder;
            GameStatsFormSwap.BackgroundImage = (Image)resources.GetObject("GameStatsFormSwap.BackgroundImage");
            GameStatsFormSwap.BackgroundImageLayout = ImageLayout.Center;
            GameStatsFormSwap.Cursor = Cursors.Hand;
            GameStatsFormSwap.FlatStyle = FlatStyle.Flat;
            GameStatsFormSwap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            GameStatsFormSwap.ImageAlign = ContentAlignment.TopCenter;
            GameStatsFormSwap.ImeMode = ImeMode.NoControl;
            GameStatsFormSwap.Location = new Point(730, 421);
            GameStatsFormSwap.Name = "GameStatsFormSwap";
            GameStatsFormSwap.Size = new Size(426, 41);
            GameStatsFormSwap.TabIndex = 565;
            GameStatsFormSwap.Text = "Game Stats";
            GameStatsFormSwap.UseVisualStyleBackColor = false;
            GameStatsFormSwap.Click += GameStatsFormSwap_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1185, 702);
            Controls.Add(GameStatsFormSwap);
            Controls.Add(MiscFormSwap);
            Controls.Add(PatchNotesButton);
            Controls.Add(StatsAndAlertForm);
            Controls.Add(LogAOBs);
            Controls.Add(WeaponFormSwap);
            Controls.Add(CamoFormSwap);
            Controls.Add(ItemFormSwap);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ANTIBigBoss's MGS3 Delta Trainer - Main Menu - Version 1.0.0.6";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button CamoFormSwap;
        private Button ItemFormSwap;
        private Button WeaponFormSwap;
        private Button LogAOBs;
        private Button StatsAndAlertForm;
        private Button PatchNotesButton;
        private Button MiscFormSwap;
        private Button GameStatsFormSwap;
    }
}