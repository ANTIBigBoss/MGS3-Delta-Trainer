using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ANTIBigBoss_s_MGS_Delta_Trainer.Constants;
using static ANTIBigBoss_s_MGS_Delta_Trainer.MemoryManager;

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
                    // Set a temporary size, will be recalculated later
                    Size = new Size(300, 150)
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

                _lastClick = Point.Empty;
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

                // 1. Create the message label and let it auto-size
                Label messageLabel = new Label()
                {
                    Text = message,
                    AutoSize = true, // This is the key property
                    ForeColor = Color.Black,
                    BackColor = MGS3ButtonColor,
                    Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                    // Position it initially, will be centered later
                    Location = new Point(20, titleBarPanel.Bottom + 20),
                    // Set maximum width to prevent it from going off-screen
                    MaximumSize = new Size(440, 0)
                };
                messageBoxForm.Controls.Add(messageLabel);

                // 2. Create the buttons
                Button copyButton = new Button()
                {
                    Text = "Copy",
                    Width = 75,
                    Height = 30,
                    Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                    BackColor = MGS3ButtonColor,
                    ForeColor = Color.Black,
                    // DialogResult will close the form, so we use Click event for copy
                    DialogResult = DialogResult.None
                };
                copyButton.Click += (sender, e) => Clipboard.SetText(message);
                messageBoxForm.Controls.Add(copyButton);

                Button okButton = new Button()
                {
                    Text = "Ok",
                    Width = 75,
                    Height = 30,
                    DialogResult = DialogResult.OK, // This will auto-close the form
                    Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),
                    BackColor = MGS3ButtonColor,
                    ForeColor = Color.Black
                };
                messageBoxForm.Controls.Add(okButton);

                // 3. Now that all controls are added, we can calculate the layout
                // Force the form to layout its controls so we can get accurate sizes
                messageBoxForm.PerformLayout();

                // --- Calculate Dynamic Sizes and Positions ---

                // Calculate required form width based on the widest element (message or buttons)
                int requiredMessageWidth = messageLabel.Width + 40; // + padding
                int requiredButtonWidth = (copyButton.Width * 2) + 60; // 2 buttons + spacing

                // Form width is the larger of: message width, button row width, or a minimum
                int formWidth = Math.Max(requiredMessageWidth, requiredButtonWidth);
                formWidth = Math.Max(formWidth, 300); // Enforce a minimum width

                // Calculate form height based on content
                int verticalPadding = 20;
                int buttonTop = messageLabel.Bottom + verticalPadding;
                int formHeight = buttonTop + copyButton.Height + verticalPadding;

                // Apply the calculated size to the form
                messageBoxForm.ClientSize = new Size(formWidth, formHeight);

                // 4. Center the message label now that we know the form's final width
                messageLabel.Left = (messageBoxForm.ClientSize.Width - messageLabel.Width) / 2;

                // 5. Position the buttons next to each other in the center
                int totalButtonWidth = copyButton.Width + okButton.Width + 20; // 20px space between
                int buttonStartX = (messageBoxForm.ClientSize.Width - totalButtonWidth) / 2;

                copyButton.Location = new Point(buttonStartX, buttonTop);
                okButton.Location = new Point(buttonStartX + copyButton.Width + 20, buttonTop);

                messageBoxForm.ShowDialog();
            }
        }
    }

    #endregion
}
