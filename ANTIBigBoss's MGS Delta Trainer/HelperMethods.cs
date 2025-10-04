using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ANTIBigBoss_s_MGS_Delta_Trainer.Constants;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public class HelperMethods
    {
        private static HelperMethods instance;
        private static readonly object lockObj = new object();

        private HelperMethods()
        {
        }

        public static HelperMethods Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new HelperMethods();
                    }

                    return instance;
                }
            }
        }

        #region Helpers
        /// <summary>
        /// This method is used to get the process handle of the game.<br></br>
        /// i.e. METAL GEAR SOLID3.exe
        /// </summary>
        /// <returns></returns>
        public IntPtr GetProcessHandle()
        {
            Process process = MemoryManager.GetMGS3Process();
            if (process == null) return IntPtr.Zero;

            return MemoryManager.OpenGameProcess(process);
        }

        /// <summary>
        /// Gets the target address based on the AOB pattern and offset.
        /// </summary>
        /// <param name="processHandle"></param>
        /// <param name="patternName"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IntPtr GetTargetAddress(IntPtr processHandle, string patternName, int offset)
        {
            IntPtr address = MemoryManager.Instance.FindAob(patternName);
            if (address == IntPtr.Zero) return IntPtr.Zero;

            return IntPtr.Subtract(address, offset);
        }

        /// <summary>
        /// Verifies the memory at the specified address. This is used to check if the cheat is already applied.
        /// Also helpful to check if the game is in the correct state.
        /// </summary>
        /// <param name="processHandle"></param>
        /// <param name="address"></param>
        /// <param name="expectedBytes"></param>
        /// <returns></returns>
        public bool VerifyMemory(IntPtr processHandle, IntPtr address, byte[] expectedBytes)
        {
            byte[] buffer = new byte[expectedBytes.Length];
            if (MemoryManager.ReadProcessMemory(processHandle, address, buffer, (uint)expectedBytes.Length, out _))
            {
                return buffer.SequenceEqual(expectedBytes);
            }

            return false;
        }

        /// <summary>
        /// aobKey is the key to the AOB pattern in the dictionary<br></br><br></br>
        /// offset is the offset to add or subtract from the AOB pattern<br></br><br></br>
        /// forwardInMemory is TRUE means Forward in memory, FALSE means Backward in memory<br></br><br></br>
        /// bytesToRead is the number of bytes to read from the target address<br></br><br></br>
        /// dataType is the Data type listed in the Constants.DataType enum eg:<br></br> UInt8, Int8, Int16, UInt16, Int32, UInt32, Float, Int64, UInt64, Double, ByteArray
        /// </summary>
        /// <param name="aobKey"></param>
        /// <param name="offset"></param>
        /// <param name="forwardInMemory"></param>
        /// <param name="bytesToRead"></param>
        /// <param name="dataType"> </param>
        /// <returns></returns>
        public string ReadMemoryValue(string aobKey, int offset, bool forwardInMemory, int bytesToRead, DataType dataType)
        {
            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS3Process());
            if (processHandle == IntPtr.Zero)
            {
                return "Error: Could not open process.";
            }

            IntPtr aobResult = MemoryManager.Instance.FindAob(aobKey);
            if (aobResult == IntPtr.Zero)
            {
                return "Error: AOB pattern not found.";
            }

            IntPtr targetAddress = forwardInMemory ? IntPtr.Add(aobResult, offset) : IntPtr.Subtract(aobResult, offset);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, bytesToRead, dataType);
        }

        /// <summary>
        /// Input your: AOB Name, Distance from AOB, true for forward/false for forward from AOB, and # of bytes<br></br>
        /// Example: byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("Fog", 4, false, 4);<br></br>
        /// With this you look for Fog's AOB pattern, go back 4 bytes, and read the 4 bytes at that location.
        /// </summary>
        public byte[] ReadMemoryBytes(string aobKey, int offset, bool forwardInMemory, int bytesToRead)
        {
            try
            {
                IntPtr processHandle = GetProcessHandle();
                if (processHandle == IntPtr.Zero) return null;

                IntPtr aobResult = MemoryManager.Instance.FindAob(aobKey);
                if (aobResult == IntPtr.Zero) return null;

                IntPtr targetAddress = forwardInMemory ?
                    IntPtr.Add(aobResult, offset) :
                    IntPtr.Subtract(aobResult, offset);

                return MemoryManager.ReadMemoryBytes(processHandle, targetAddress, bytesToRead);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Writes a value to memory at the specified AOB pattern location with offset.
        /// This method finds the AOB pattern, calculates the target address using the offset and direction,
        /// and writes the specified value to that memory location.
        /// </summary>
        /// <typeparam name="T">The type of value to write (byte, int, float, byte[], etc.)</typeparam>
        /// <param name="aobKey">The key identifying the AOB pattern in the dictionary</param>
        /// <param name="offset">The offset to add or subtract from the AOB pattern address</param>
        /// <param name="forwardInMemory">TRUE means forward in memory (add offset), FALSE means backward in memory (subtract offset)</param>
        /// <param name="value">The value to write to memory</param>
        /// <returns>TRUE if the write operation was successful, FALSE otherwise</returns>
        /// <remarks>
        /// This method handles logging of success/failure and exceptions automatically.
        /// Supported types include: byte, sbyte, short, ushort, int, uint, float, double, and byte[].
        /// </remarks>
        public bool WriteMemoryValue<T>(string aobKey, int offset, bool forwardInMemory, T value)
        {
            try
            {
                IntPtr processHandle = GetProcessHandle();
                if (processHandle == IntPtr.Zero)
                {
                    LoggingManager.Instance.Log($"Error: Could not get process handle for {aobKey}.");
                    return false;
                }

                IntPtr aobResult = MemoryManager.Instance.FindAob(aobKey);
                if (aobResult == IntPtr.Zero)
                {
                    LoggingManager.Instance.Log($"Error: AOB pattern not found for {aobKey}.");
                    return false;
                }

                IntPtr targetAddress = forwardInMemory ?
                    IntPtr.Add(aobResult, offset) :
                    IntPtr.Subtract(aobResult, offset);

                bool writeResult = MemoryManager.WriteMemory(processHandle, targetAddress, value);

                if (writeResult)
                {
                    LoggingManager.Instance.Log($"{aobKey} written successfully at offset {offset}.");
                }
                else
                {
                    LoggingManager.Instance.Log($"Failed to write {aobKey} at offset {offset}.");
                }

                return writeResult;
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error writing {aobKey}: {ex.Message}");
                return false;
            }
        }

        public bool WriteToPointer<T>(int baseOffset, int valueOffset, T value)
        {
            try
            {
                IntPtr processHandle = GetProcessHandle();
                if (processHandle == IntPtr.Zero) return false;

                IntPtr baseAddress = GetBaseAddress();

                // Read the pointer value at baseOffset using your working ReadMemoryBytes
                byte[] pointerBytes = MemoryManager.ReadMemoryBytes(processHandle,
                    IntPtr.Add(baseAddress, baseOffset), IntPtr.Size);
                if (pointerBytes == null) return false;

                // Convert to actual pointer address
                IntPtr actualPointer = IntPtr.Size == 8 ?
                    (IntPtr)BitConverter.ToInt64(pointerBytes, 0) :
                    (IntPtr)BitConverter.ToInt32(pointerBytes, 0);

                IntPtr finalAddress = IntPtr.Add(actualPointer, valueOffset);

                // Write value using your working WriteMemory method
                return MemoryManager.WriteMemory(processHandle, finalAddress, value);
            }
            catch
            {
                return false;
            }
        }

        public byte[] ReadPointerBytes(int baseOffset, int valueOffset, int bytesToRead)
        {
            try
            {
                IntPtr processHandle = GetProcessHandle();
                if (processHandle == IntPtr.Zero) return null;

                IntPtr baseAddress = GetBaseAddress();

                // Read the pointer value at baseOffset using your working ReadMemoryBytes
                byte[] pointerBytes = MemoryManager.ReadMemoryBytes(processHandle,
                    IntPtr.Add(baseAddress, baseOffset), IntPtr.Size);
                if (pointerBytes == null) return null;

                // Convert to actual pointer address
                IntPtr actualPointer = IntPtr.Size == 8 ?
                    (IntPtr)BitConverter.ToInt64(pointerBytes, 0) :
                    (IntPtr)BitConverter.ToInt32(pointerBytes, 0);

                // Read from pointer + offset using your working ReadMemoryBytes
                return MemoryManager.ReadMemoryBytes(processHandle,
                    IntPtr.Add(actualPointer, valueOffset), bytesToRead);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region AddressCalculation

        /// <summary>
        /// Retrieves the base address of the specified process.
        /// </summary>
        /// <param name="processName">Name of the process. Defaults to "METAL GEAR SOLID3".</param>
        /// <returns>Base address as IntPtr.</returns>
        /// <exception cref="ArgumentException">Thrown when the process is not found.</exception>
        public IntPtr GetBaseAddress(string processName = "MGSDelta-Win64-Shipping")
        {
            var processes = Process.GetProcessesByName(processName);

            if (processes.Length == 0)
            {
                throw new ArgumentException($"Process '{processName}' not found. Make sure it is running.");
            }

            return processes[0].MainModule.BaseAddress;
        }
       
        public string ReadMemoryValueOnlyAsString(string aobKey, int offset, int bytesToRead, DataType dataType)
        {
            try
            {
                IntPtr processHandle = HelperMethods.Instance.GetProcessHandle();
                if (processHandle == IntPtr.Zero)
                    return "Error: Process handle is invalid.";

                IntPtr targetAddress = HelperMethods.Instance.GetTargetAddress(processHandle, aobKey, offset);
                if (targetAddress == IntPtr.Zero)
                    return "Error: Target address is invalid.";

                byte[] buffer = MemoryManager.ReadMemoryBytes(processHandle, targetAddress, bytesToRead);
                if (buffer == null || buffer.Length != bytesToRead)
                    return "Error: Could not read memory.";

                return HelperMethods.Instance.FormatReadValueForTextboxes(buffer, dataType);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string FormatReadValueForTextboxes(byte[] buffer, DataType dataType)
        {
            string rawBytes = BitConverter.ToString(buffer);

            string result = dataType switch
            {
                DataType.UInt8 => buffer[0].ToString(),
                DataType.UInt16 => BitConverter.ToUInt16(buffer, 0).ToString(),
                DataType.UInt32 => BitConverter.ToUInt32(buffer, 0).ToString(),
                DataType.Int8 => ((sbyte)buffer[0]).ToString(),
                DataType.Int16 => BitConverter.ToInt16(buffer, 0).ToString(),
                DataType.Int32 => BitConverter.ToInt32(buffer, 0).ToString(),
                DataType.Float => BitConverter.ToSingle(buffer, 0).ToString("F2"),
                _ => BitConverter.ToString(buffer).Replace("-", " "),
            };

            result = result.Trim();
            return result;
        }

        #endregion

        #region Custom Form Classes

        internal class ColouredProgressBar : ProgressBar
        {
            public Color ProgressBarColour { get; set; } = Color.Red; // Default color

            public ColouredProgressBar()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Rectangle rect = e.ClipRectangle;
                float percentage = (float)Value / Maximum;
                rect.Width = (int)(rect.Width * percentage);

                using (Brush brush = new SolidBrush(ProgressBarColour))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, rect.Width, rect.Height);
                }
            }
        }

        internal class CustomFormManager
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
                Form messageBoxForm = new Form()
                {
                    FormBorderStyle = FormBorderStyle.None,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen,
                    MinimizeBox = false,
                    MaximizeBox = false,
                    BackColor = SurvivalViewerColor,
                    Padding = new Padding(0),
                    MinimumSize = new Size(400, 200),
                    MaximumSize = new Size(800, 600)
                };

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

                Point _lastClick = Point.Empty;
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

                Panel mainContainer = new Panel()
                {
                    Dock = DockStyle.Fill,
                    BackColor = SurvivalViewerColor,
                    Padding = new Padding(20)
                };
                messageBoxForm.Controls.Add(mainContainer);

                Panel scrollPanel = new Panel()
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    BackColor = MGS3ButtonColor,
                    Padding = new Padding(15),
                    MinimumSize = new Size(0, 100)
                };
                mainContainer.Controls.Add(scrollPanel);

                Label messageLabel = new Label()
                {
                    Text = message,
                    AutoSize = true,
                    MaximumSize = new Size(500, 0), // Constrain width for word wrapping
                    ForeColor = Color.Black,
                    BackColor = MGS3ButtonColor,
                    Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                };
                scrollPanel.Controls.Add(messageLabel);

                Panel buttonPanel = new Panel()
                {
                    Dock = DockStyle.Bottom,
                    Height = 60,
                    BackColor = SurvivalViewerColor
                };
                mainContainer.Controls.Add(buttonPanel);

                Button copyButton = new Button()
                {
                    Text = "Copy",
                    Width = 80,
                    Height = 35,
                    Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                    BackColor = MGS3ButtonColor,
                    ForeColor = Color.Black
                };
                copyButton.Click += (sender, e) => Clipboard.SetText(message);

                Button okButton = new Button()
                {
                    Text = "OK",
                    Width = 80,
                    Height = 35,
                    Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                    BackColor = MGS3ButtonColor,
                    ForeColor = Color.Black
                };
                okButton.Click += (sender, e) => messageBoxForm.Close();

                void PositionButtons()
                {
                    int totalButtonWidth = copyButton.Width + okButton.Width + 20;
                    int left = (buttonPanel.Width - totalButtonWidth) / 2;
                    int top = (buttonPanel.Height - copyButton.Height) / 2;

                    copyButton.Location = new Point(left, top);
                    okButton.Location = new Point(left + copyButton.Width + 20, top);
                }

                buttonPanel.Controls.Add(copyButton);
                buttonPanel.Controls.Add(okButton);

                messageBoxForm.Load += (sender, e) =>
                {
                    int optimalWidth = Math.Min(Math.Max(messageLabel.Width + 100, 400), 800);

                    int contentHeight = messageLabel.Height + 150;
                    int optimalHeight = Math.Min(Math.Max(contentHeight, 200), 600);

                    messageBoxForm.Size = new Size(optimalWidth, optimalHeight);
                    PositionButtons();
                };

                messageBoxForm.Resize += (sender, e) => PositionButtons();

                messageBoxForm.ShowDialog();
            }

            // This one is mostly just for the button in GameStatsForm to edit their stats
            public static void ShowEditStatsDialog(PointerEffectManager pointerManager)
            {
                Form editForm = new Form()
                {
                    FormBorderStyle = FormBorderStyle.None,
                    Text = "Edit Stats",
                    StartPosition = FormStartPosition.CenterScreen,
                    MinimizeBox = false,
                    MaximizeBox = false,
                    BackColor = SurvivalViewerColor,
                    Width = 500,
                    Height = 500
                };

                Panel titleBarPanel = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = SystemInformation.CaptionHeight,
                    BackColor = MGS3ButtonColor,
                };
                editForm.Controls.Add(titleBarPanel);

                Label titleLabel = new Label()
                {
                    Text = "Edit Stats",
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
                        editForm.Left += e.X - _lastClick.X;
                        editForm.Top += e.Y - _lastClick.Y;
                    }
                };

                Panel inputPanel = new Panel()
                {
                    BackColor = MGS3ButtonColor,
                    Dock = DockStyle.Fill
                };
                editForm.Controls.Add(inputPanel);

                string difficultyCurrent = pointerManager.ReadDifficulty();
                string playTimeCurrent = pointerManager.ReadPlayTime();
                string savesCurrent = pointerManager.ReadSaves();
                string continuesCurrent = pointerManager.ReadContinues();
                string alertsCurrent = pointerManager.ReadAlertsTriggered();
                string humansKilledCurrent = pointerManager.ReadHumansKilled();
                string injuriesCurrent = pointerManager.ReadTimesSeriouslyInjured();
                string totalDamageCurrent = pointerManager.ReadTotalDamageTaken();
                string mealsCurrent = pointerManager.ReadMealsEaten();
                string lifeMedsCurrent = pointerManager.ReadLifeMedsUsed();
                string specialItemsCurrent = pointerManager.ReadSpecialItemsUsed();

                int topOffset = 40;
                int leftOffset = 20;
                int spacing = 40;

                Label CreateLabel(string text)
                {
                    return new Label
                    {
                        Text = text,
                        AutoSize = true,
                        ForeColor = Color.Black,
                        BackColor = MGS3ButtonColor,
                        Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                        Location = new Point(leftOffset, topOffset)
                    };
                }

                TextBox CreateNumericTextBox(string defaultValue)
                {
                    TextBox tb = new TextBox
                    {
                        Width = 100,
                        Location = new Point(leftOffset + 180, topOffset - 2),
                        Font = new Font("Segoe UI", 10f),
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                        Text = defaultValue
                    };

                    tb.KeyPress += (s, e) =>
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    };

                    return tb;
                }

                Label diffLabel = CreateLabel("Difficulty:");
                inputPanel.Controls.Add(diffLabel);

                ComboBox difficultyCombo = new ComboBox
                {
                    Location = new Point(leftOffset + 180, topOffset - 2),
                    Width = 150,
                    Font = new Font("Segoe UI", 10f),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Items = { "Very Easy", "Easy", "Normal", "Hard", "Extreme", "European Extreme" }
                };
                inputPanel.Controls.Add(difficultyCombo);

                if (difficultyCombo.Items.Contains(difficultyCurrent))
                    difficultyCombo.SelectedItem = difficultyCurrent;
                else
                    difficultyCombo.SelectedIndex = 0;

                topOffset += spacing;

                Label playTimeLabel = CreateLabel("Play Time (HH:MM:SS):");
                inputPanel.Controls.Add(playTimeLabel);
                TextBox playTimeBox = new TextBox
                {
                    Width = 100,
                    Location = new Point(leftOffset + 180, topOffset - 2),
                    Font = new Font("Segoe UI", 10f),
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Text = playTimeCurrent
                };
                inputPanel.Controls.Add(playTimeBox);
                topOffset += spacing;

                Label savesLabel = CreateLabel("Saves (0-9999)");
                inputPanel.Controls.Add(savesLabel);
                TextBox savesBox = CreateNumericTextBox(savesCurrent);
                inputPanel.Controls.Add(savesBox);
                topOffset += spacing;

                Label continuesLabel = CreateLabel("Continues (0-9999)");
                inputPanel.Controls.Add(continuesLabel);
                TextBox continuesBox = CreateNumericTextBox(continuesCurrent);
                inputPanel.Controls.Add(continuesBox);
                topOffset += spacing;

                Label alertsLabel = CreateLabel("Alerts Triggered (0-9999)");
                inputPanel.Controls.Add(alertsLabel);
                TextBox alertsBox = CreateNumericTextBox(alertsCurrent);
                inputPanel.Controls.Add(alertsBox);
                topOffset += spacing;

                Label humansLabel = CreateLabel("Humans Killed (0-9999)");
                inputPanel.Controls.Add(humansLabel);
                TextBox humansBox = CreateNumericTextBox(humansKilledCurrent);
                inputPanel.Controls.Add(humansBox);
                topOffset += spacing;

                Label injuriesLabel = CreateLabel("Injuries (0-9999)");
                inputPanel.Controls.Add(injuriesLabel);
                TextBox injuriesBox = CreateNumericTextBox(injuriesCurrent);
                inputPanel.Controls.Add(injuriesBox);
                topOffset += spacing;

                Label totalDamageLabel = CreateLabel("Damage Taken (0-9999)");
                inputPanel.Controls.Add(totalDamageLabel);
                TextBox totalDamageBox = CreateNumericTextBox(totalDamageCurrent);
                inputPanel.Controls.Add(totalDamageBox);
                topOffset += spacing;

                Label lifeMedsLabel = CreateLabel("Life Meds Used (0-9999)");
                inputPanel.Controls.Add(lifeMedsLabel);
                TextBox lifeMedsBox = CreateNumericTextBox(lifeMedsCurrent);
                inputPanel.Controls.Add(lifeMedsBox);
                topOffset += spacing;

                Label mealsLabel = CreateLabel("Meals Eaten (0-9999)");
                inputPanel.Controls.Add(mealsLabel);
                TextBox mealsBox = CreateNumericTextBox(mealsCurrent);
                inputPanel.Controls.Add(mealsBox);
                topOffset += spacing;

                Label specialItemsLabel = CreateLabel("Special Items Used");
                inputPanel.Controls.Add(specialItemsLabel);

                ComboBox specialItemsCombo = new ComboBox
                {
                    Location = new Point(leftOffset + 180, topOffset - 2),
                    Width = 285,
                    Font = new Font("Segoe UI", 10f),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Items =
        {
            "Not Used",
            "Stealth Camo Used",
            "Infinity Facepaint Used",
            "Stealth Camo + Infinity Facepaint Used",
            "Ez Gun Used",
            "Stealth Camo + Ez Gun Used",
            "Infinity Facepaint + Ez Gun Used",
            "Stealth Camo + Infinity Facepaint + Ez Gun Used"
        }
                };
                inputPanel.Controls.Add(specialItemsCombo);
                topOffset += spacing;

                if (specialItemsCombo.Items.Contains(specialItemsCurrent))
                    specialItemsCombo.SelectedItem = specialItemsCurrent;
                else
                    specialItemsCombo.SelectedIndex = 0;

                Button submitButton = new Button
                {
                    Text = "Submit",
                    Width = 75,
                    Height = 30,
                    BackColor = MGS3ButtonColor,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                    Location = new Point(editForm.ClientSize.Width / 2 - 85, topOffset + 20)
                };
                inputPanel.Controls.Add(submitButton);

                Button cancelButton = new Button
                {
                    Text = "Cancel",
                    Width = 75,
                    Height = 30,
                    BackColor = MGS3ButtonColor,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                    Location = new Point(editForm.ClientSize.Width / 2 + 10, topOffset + 20)
                };
                inputPanel.Controls.Add(cancelButton);

                cancelButton.Click += (s, e) => editForm.Close();

                submitButton.Click += (s, e) =>
                {
                    if (difficultyCombo.SelectedItem == null)
                    {
                        CustomMessageBox("Please select a difficulty.", "Input Error");
                        return;
                    }

                    string selectedDifficulty = (string)difficultyCombo.SelectedItem;
                    byte diffVal;
                    switch (selectedDifficulty)
                    {
                        case "Very Easy": diffVal = 10; break;
                        case "Easy": diffVal = 20; break;
                        case "Normal": diffVal = 30; break;
                        case "Hard": diffVal = 40; break;
                        case "Extreme": diffVal = 50; break;
                        case "European Extreme": diffVal = 60; break;
                        default: diffVal = 30; break;
                    }

                    if (!TimeSpan.TryParseExact(playTimeBox.Text, "hh\\:mm\\:ss", null, out TimeSpan newTime))
                    {
                        CustomMessageBox("Invalid PlayTime. Use HH:MM:SS format.", "Input Error");
                        return;
                    }
                    uint frames = (uint)newTime.TotalSeconds * 60;

                    bool CheckUshortLimit(TextBox tb, string fieldName, out ushort val)
                    {
                        val = 0;
                        if (!ushort.TryParse(tb.Text, out ushort result))
                        {
                            CustomMessageBox($"{fieldName} must be a number.", "Input Error");
                            return false;
                        }
                        if (result > 9999)
                        {
                            CustomMessageBox($"{fieldName} cannot exceed 9999.", "Input Error");
                            return false;
                        }
                        val = result;
                        return true;
                    }

                    if (!CheckUshortLimit(alertsBox, "Alerts Triggered", out ushort alertsVal)) return;
                    if (!CheckUshortLimit(savesBox, "Saves", out ushort savesVal)) return;
                    if (!CheckUshortLimit(continuesBox, "Continues", out ushort continuesVal)) return;
                    if (!CheckUshortLimit(humansBox, "Humans Killed", out ushort humansVal)) return;
                    if (!CheckUshortLimit(injuriesBox, "Injuries", out ushort injVal)) return;
                    if (!CheckUshortLimit(mealsBox, "Meals Eaten", out ushort mealsVal)) return;
                    if (!CheckUshortLimit(lifeMedsBox, "Life Meds Used", out ushort lifeMedsVal)) return;
                    if (!CheckUshortLimit(totalDamageBox, "Damage Taken", out ushort damageVal)) return;

                    if (specialItemsCombo.SelectedItem == null)
                    {
                        CustomMessageBox("Please select a Special Items usage.", "Input Error");
                        return;
                    }

                    string selectedSpecialItems = (string)specialItemsCombo.SelectedItem;
                    byte specialItemsVal;
                    switch (selectedSpecialItems)
                    {
                        case "Not Used": specialItemsVal = 0; break;
                        case "Stealth Camo Used": specialItemsVal = 1; break;
                        case "Infinity Facepaint Used": specialItemsVal = 2; break;
                        case "Stealth Camo + Infinity Facepaint Used": specialItemsVal = 3; break;
                        case "Ez Gun Used": specialItemsVal = 4; break;
                        case "Stealth Camo + Ez Gun Used": specialItemsVal = 5; break;
                        case "Infinity Facepaint + Ez Gun Used": specialItemsVal = 6; break;
                        case "Stealth Camo + Infinity Facepaint + Ez Gun Used": specialItemsVal = 7; break;
                        default: specialItemsVal = 0; break;
                    }

                    bool success = true;
                    success &= pointerManager.WriteDifficulty(diffVal);
                    success &= pointerManager.WritePlayTime(frames);
                    success &= pointerManager.WriteAlertsTriggered(alertsVal);
                    success &= pointerManager.WriteSaves(savesVal);
                    success &= pointerManager.WriteContinues(continuesVal);
                    success &= pointerManager.WriteHumansKilled(humansVal);
                    success &= pointerManager.WriteTimesSeriouslyInjured(injVal);
                    success &= pointerManager.WriteMealsEaten(mealsVal);
                    success &= pointerManager.WriteLifeMedsUsed(lifeMedsVal);
                    success &= pointerManager.WriteTotalDamageTaken(damageVal);
                    success &= pointerManager.WriteSpecialItemsUsed(specialItemsVal);

                    if (success)
                    {
                        CustomMessageBox("Stats updated successfully!", "Success");
                        editForm.Close();
                    }
                    else
                    {
                        CustomMessageBox("Some writes failed. Check logs.", "Write Error");
                    }
                };

                editForm.Height = topOffset + 120;
                editForm.ShowDialog();
            }
        }
    }

    #endregion
}
