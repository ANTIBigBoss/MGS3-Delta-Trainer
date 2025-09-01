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
            DebugFormSwap = new Button();
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
            CamoFormSwap.Location = new Point(730, 245);
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
            LogAOBs.Location = new Point(730, 298);
            LogAOBs.Name = "LogAOBs";
            LogAOBs.Size = new Size(426, 41);
            LogAOBs.TabIndex = 560;
            LogAOBs.Text = "Generate a Log File";
            LogAOBs.UseVisualStyleBackColor = false;
            LogAOBs.Click += LogAOBs_Click;
            // 
            // DebugFormSwap
            // 
            DebugFormSwap.BackgroundImage = (Image)resources.GetObject("DebugFormSwap.BackgroundImage");
            DebugFormSwap.BackgroundImageLayout = ImageLayout.Center;
            DebugFormSwap.Cursor = Cursors.Hand;
            DebugFormSwap.FlatStyle = FlatStyle.Flat;
            DebugFormSwap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            DebugFormSwap.ImageAlign = ContentAlignment.TopCenter;
            DebugFormSwap.ImeMode = ImeMode.NoControl;
            DebugFormSwap.Location = new Point(730, 645);
            DebugFormSwap.Name = "DebugFormSwap";
            DebugFormSwap.Size = new Size(426, 45);
            DebugFormSwap.TabIndex = 561;
            DebugFormSwap.Text = "Debug/Modding Resources";
            DebugFormSwap.UseVisualStyleBackColor = true;
            DebugFormSwap.Visible = false;
            DebugFormSwap.Click += DebugFormSwap_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1185, 702);
            Controls.Add(DebugFormSwap);
            Controls.Add(LogAOBs);
            Controls.Add(WeaponFormSwap);
            Controls.Add(CamoFormSwap);
            Controls.Add(ItemFormSwap);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ANTIBigBoss's MGS3 Delta Trainer - Main Menu - Version 1.0.0.0";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button CamoFormSwap;
        private Button ItemFormSwap;
        private Button WeaponFormSwap;
        private Button LogAOBs;
        private Button DebugFormSwap;
    }
}