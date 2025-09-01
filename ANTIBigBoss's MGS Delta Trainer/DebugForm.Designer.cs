using System.Windows.Forms;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    partial class DebugForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugForm));
            CheatEngineDebugButton = new System.Windows.Forms.Button();
            GenerateLogButton = new System.Windows.Forms.Button();
            txtProcessName = new System.Windows.Forms.TextBox();
            txtCurrentAddress = new System.Windows.Forms.TextBox();
            txtRecomputedAddress = new System.Windows.Forms.TextBox();
            txtOffset = new System.Windows.Forms.TextBox();
            txtCheatEngineString = new System.Windows.Forms.TextBox();
            LogAllGuardPositions = new System.Windows.Forms.Button();
            LogAreaAddress = new System.Windows.Forms.Button();
            SwapToCamoForm = new System.Windows.Forms.Button();
            SwapToItemsForm = new System.Windows.Forms.Button();
            SwapToWeaponsForm = new System.Windows.Forms.Button();
            textBox29 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CheatEngineDebugButton
            // 
            CheatEngineDebugButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("CheatEngineDebugButton.BackgroundImage");
            CheatEngineDebugButton.Cursor = System.Windows.Forms.Cursors.Hand;
            CheatEngineDebugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CheatEngineDebugButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            CheatEngineDebugButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            CheatEngineDebugButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            CheatEngineDebugButton.Location = new System.Drawing.Point(19, 85);
            CheatEngineDebugButton.Name = "CheatEngineDebugButton";
            CheatEngineDebugButton.Size = new System.Drawing.Size(222, 32);
            CheatEngineDebugButton.TabIndex = 565;
            CheatEngineDebugButton.Text = "Cheat Engine Debug";
            CheatEngineDebugButton.UseVisualStyleBackColor = true;
            CheatEngineDebugButton.Click += this.CheatEngineDebugButton_Click;
            // 
            // GenerateLogButton
            // 
            GenerateLogButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("GenerateLogButton.BackgroundImage");
            GenerateLogButton.Cursor = System.Windows.Forms.Cursors.Hand;
            GenerateLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GenerateLogButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            GenerateLogButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            GenerateLogButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            GenerateLogButton.Location = new System.Drawing.Point(257, 85);
            GenerateLogButton.Name = "GenerateLogButton";
            GenerateLogButton.Size = new System.Drawing.Size(222, 32);
            GenerateLogButton.TabIndex = 566;
            GenerateLogButton.Text = "Generate a Log .txt File";
            GenerateLogButton.UseVisualStyleBackColor = true;
            GenerateLogButton.Click += this.GenerateLogButton_Click;
            // 
            // txtProcessName
            // 
            txtProcessName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            txtProcessName.Location = new System.Drawing.Point(19, 123);
            txtProcessName.Name = "txtProcessName";
            txtProcessName.Size = new System.Drawing.Size(222, 29);
            txtProcessName.TabIndex = 567;
            // 
            // txtCurrentAddress
            // 
            txtCurrentAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            txtCurrentAddress.Location = new System.Drawing.Point(19, 158);
            txtCurrentAddress.Name = "txtCurrentAddress";
            txtCurrentAddress.Size = new System.Drawing.Size(222, 29);
            txtCurrentAddress.TabIndex = 568;
            // 
            // txtRecomputedAddress
            // 
            txtRecomputedAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            txtRecomputedAddress.Location = new System.Drawing.Point(19, 228);
            txtRecomputedAddress.Name = "txtRecomputedAddress";
            txtRecomputedAddress.Size = new System.Drawing.Size(222, 29);
            txtRecomputedAddress.TabIndex = 570;
            // 
            // txtOffset
            // 
            txtOffset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            txtOffset.Location = new System.Drawing.Point(19, 193);
            txtOffset.Name = "txtOffset";
            txtOffset.Size = new System.Drawing.Size(222, 29);
            txtOffset.TabIndex = 569;
            // 
            // txtCheatEngineString
            // 
            txtCheatEngineString.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            txtCheatEngineString.Location = new System.Drawing.Point(19, 263);
            txtCheatEngineString.Name = "txtCheatEngineString";
            txtCheatEngineString.Size = new System.Drawing.Size(222, 29);
            txtCheatEngineString.TabIndex = 571;
            // 
            // LogAllGuardPositions
            // 
            LogAllGuardPositions.BackgroundImage = (System.Drawing.Image)resources.GetObject("LogAllGuardPositions.BackgroundImage");
            LogAllGuardPositions.Cursor = System.Windows.Forms.Cursors.Hand;
            LogAllGuardPositions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            LogAllGuardPositions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            LogAllGuardPositions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            LogAllGuardPositions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            LogAllGuardPositions.Location = new System.Drawing.Point(257, 161);
            LogAllGuardPositions.Name = "LogAllGuardPositions";
            LogAllGuardPositions.Size = new System.Drawing.Size(222, 131);
            LogAllGuardPositions.TabIndex = 572;
            LogAllGuardPositions.Text = "Write all Guard's Current Positions to the Log";
            LogAllGuardPositions.UseVisualStyleBackColor = true;
            // 
            // LogAreaAddress
            // 
            LogAreaAddress.BackgroundImage = (System.Drawing.Image)resources.GetObject("LogAreaAddress.BackgroundImage");
            LogAreaAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            LogAreaAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            LogAreaAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            LogAreaAddress.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            LogAreaAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            LogAreaAddress.Location = new System.Drawing.Point(257, 123);
            LogAreaAddress.Name = "LogAreaAddress";
            LogAreaAddress.Size = new System.Drawing.Size(222, 32);
            LogAreaAddress.TabIndex = 574;
            LogAreaAddress.Text = "Log Address of Area";
            LogAreaAddress.UseVisualStyleBackColor = true;
            LogAreaAddress.Click += this.LogAreaAddress_Click;
            // 
            // SwapToCamoForm
            // 
            SwapToCamoForm.BackgroundImage = (System.Drawing.Image)resources.GetObject("SwapToCamoForm.BackgroundImage");
            SwapToCamoForm.Cursor = System.Windows.Forms.Cursors.Hand;
            SwapToCamoForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SwapToCamoForm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            SwapToCamoForm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            SwapToCamoForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            SwapToCamoForm.Location = new System.Drawing.Point(317, 12);
            SwapToCamoForm.Name = "SwapToCamoForm";
            SwapToCamoForm.Size = new System.Drawing.Size(130, 31);
            SwapToCamoForm.TabIndex = 597;
            SwapToCamoForm.Text = "Camo";
            SwapToCamoForm.UseVisualStyleBackColor = true;
            SwapToCamoForm.Click += this.SwapToCamoForm_Click;
            // 
            // SwapToItemsForm
            // 
            SwapToItemsForm.BackgroundImage = (System.Drawing.Image)resources.GetObject("SwapToItemsForm.BackgroundImage");
            SwapToItemsForm.Cursor = System.Windows.Forms.Cursors.Hand;
            SwapToItemsForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SwapToItemsForm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            SwapToItemsForm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            SwapToItemsForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            SwapToItemsForm.Location = new System.Drawing.Point(181, 12);
            SwapToItemsForm.Name = "SwapToItemsForm";
            SwapToItemsForm.Size = new System.Drawing.Size(130, 31);
            SwapToItemsForm.TabIndex = 596;
            SwapToItemsForm.Text = "Items";
            SwapToItemsForm.UseVisualStyleBackColor = true;
            SwapToItemsForm.Click += this.SwapToItemsForm_Click;
            // 
            // SwapToWeaponsForm
            // 
            SwapToWeaponsForm.BackgroundImage = (System.Drawing.Image)resources.GetObject("SwapToWeaponsForm.BackgroundImage");
            SwapToWeaponsForm.Cursor = System.Windows.Forms.Cursors.Hand;
            SwapToWeaponsForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SwapToWeaponsForm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            SwapToWeaponsForm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            SwapToWeaponsForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            SwapToWeaponsForm.Location = new System.Drawing.Point(45, 12);
            SwapToWeaponsForm.Name = "SwapToWeaponsForm";
            SwapToWeaponsForm.Size = new System.Drawing.Size(130, 31);
            SwapToWeaponsForm.TabIndex = 595;
            SwapToWeaponsForm.Text = "Weapons";
            SwapToWeaponsForm.UseVisualStyleBackColor = true;
            SwapToWeaponsForm.Click += this.SwapToWeaponsForm_Click;
            // 
            // textBox29
            // 
            textBox29.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            textBox29.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox29.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            textBox29.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            textBox29.Location = new System.Drawing.Point(19, 49);
            textBox29.Multiline = true;
            textBox29.Name = "textBox29";
            textBox29.PlaceholderText = "WARNING: If you're not familiar with how Modding and Cheat Engine work I wouldn't use these features";
            textBox29.ReadOnly = true;
            textBox29.Size = new System.Drawing.Size(1111, 30);
            textBox29.TabIndex = 650;
            textBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            this.ClientSize = new System.Drawing.Size(1166, 707);
            this.Controls.Add(textBox29);
            this.Controls.Add(SwapToCamoForm);
            this.Controls.Add(SwapToItemsForm);
            this.Controls.Add(SwapToWeaponsForm);
            this.Controls.Add(LogAreaAddress);
            this.Controls.Add(LogAllGuardPositions);
            this.Controls.Add(txtCheatEngineString);
            this.Controls.Add(txtRecomputedAddress);
            this.Controls.Add(txtOffset);
            this.Controls.Add(txtCurrentAddress);
            this.Controls.Add(txtProcessName);
            this.Controls.Add(GenerateLogButton);
            this.Controls.Add(CheatEngineDebugButton);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Name = "DebugForm";
            this.Text = "MGS3 Cheat Trainer - Debug - ANTIBigBoss - Version 2.9";
            this.Load += this.DebugForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private Button CheatEngineDebugButton;
        private Button GenerateLogButton;
        private TextBox txtProcessName;
        private TextBox txtCurrentAddress;
        private TextBox txtRecomputedAddress;
        private TextBox txtOffset;
        private TextBox txtCheatEngineString;
        private Button LogAllGuardPositions;
        private Button LogAreaAddress;
        private Button SwapToMiscForm;
        private Button SwapToBossForm;
        private Button SwapToHealthAndAlertsForm;
        private Button SwapToCamoForm;
        private Button SwapToItemsForm;
        private Button SwapToWeaponsForm;
        private Button SwapToGameStatsForm;
        private TextBox textBox29;
        private Button SwapToAudioSwapperForm;
    }
}