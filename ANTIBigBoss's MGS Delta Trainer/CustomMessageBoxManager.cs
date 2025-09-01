using System;
using System.Drawing;
using System.Windows.Forms;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    internal class CustomMessageBoxManager
    {
        private enum CustomColor
        {
            MGS3ButtonColor, // 156,156,124
            SurvivalViewerColor // 36,44,36
        }

        private static readonly Color MGS3ButtonColor = Color.FromArgb(156, 156, 124);
        private static readonly Color SurvivalViewerColor = Color.FromArgb(36, 44, 36);

        private static Point _lastClick;

        public static void CustomMessageBox(string message, string caption)
        {

            // Future implementation for sound effects:
            // PlayMessageBoxSound("path_to_sound_file.wav");

            Form messageBoxForm = new Form()
            {
                FormBorderStyle = FormBorderStyle.None,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                BackColor = SurvivalViewerColor
            };

            // Custom icon implementation for later use
            //SetMessageBoxIcon(messageBoxForm, "path_to_icon_file.ico");

            Panel titleBarPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = SystemInformation.CaptionHeight,
                BackColor = MGS3ButtonColor,
            };
            messageBoxForm.Controls.Add(titleBarPanel);

            Label titleLabel = new Label()
            {
                Text = caption,
                AutoSize = true,
                ForeColor = Color.Black,
                BackColor = MGS3ButtonColor,
                Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                Location = new Point(10, (titleBarPanel.Height - 20) / 2)
            };
            titleBarPanel.Controls.Add(titleLabel);

            titleBarPanel.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _lastClick = e.Location;
                }
            };

            titleBarPanel.MouseMove += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    messageBoxForm.Left += e.X - _lastClick.X;
                    messageBoxForm.Top += e.Y - _lastClick.Y;
                }
            };

            Label messageLabel = new Label()
            {
                Text = message,
                AutoSize = true,
                Left = 20,
                Top = titleBarPanel.Bottom + 20,
                MaximumSize = new Size(440, 0),
                ForeColor = Color.Black,
                BackColor = MGS3ButtonColor,
                Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
            };
            messageBoxForm.Controls.Add(messageLabel);

            int formWidth = Math.Min(messageLabel.Width + 40, 500);
            int formHeight = Math.Min(messageLabel.Height + 120, 200);

            messageBoxForm.Width = formWidth;
            messageBoxForm.Height = formHeight;

            messageLabel.Left = (messageBoxForm.ClientSize.Width - messageLabel.Width) / 2;

            int buttonLeft = (messageBoxForm.ClientSize.Width - 2 * 75 - 20) / 2;

            Button copyButton = new Button()
            {
                Text = "Copy",
                Width = 75,
                Height = 30,
                DialogResult = DialogResult.OK,
                Location = new Point(buttonLeft, messageLabel.Bottom + 10),
                Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                BackColor = MGS3ButtonColor,
                ForeColor = Color.Black
            };
            copyButton.Click += (sender, e) =>
            {
                Clipboard.SetText(message);
            };
            messageBoxForm.Controls.Add(copyButton);

            Button okButton = new Button()
            {
                Text = "Ok",
                Width = 75,
                Height = 30,
                DialogResult = DialogResult.Cancel,
                Location = new Point(copyButton.Right + 20, copyButton.Top),
                Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                BackColor = MGS3ButtonColor,
                ForeColor = Color.Black 
            };
            okButton.Click += (sender, e) =>
            {
                messageBoxForm.Close();
            };
            messageBoxForm.Controls.Add(okButton);

            messageBoxForm.ShowDialog();
        }        
    }
}

/* Future Implementations for Icons and sounds:

private static void PlayMessageBoxSound(string soundFilePath)
   {
       try
       {
           SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
           soundPlayer.Play();
       }
       catch (Exception ex)
       {
           Console.WriteLine("Error playing sound: " + ex.Message);
       }
   }

   private static void SetMessageBoxIcon(Form form, string iconFilePath)
   {
       try
       {
           form.Icon = new Icon(iconFilePath);
       }
       catch (Exception ex)
       {
           Console.WriteLine("Error setting custom icon: " + ex.Message);
       }
   }

*/