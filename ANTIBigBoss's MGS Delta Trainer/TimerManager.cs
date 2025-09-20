using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using static ANTIBigBoss_s_MGS_Delta_Trainer.Constants;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public class TimerManager
    {
        private static TimerManager instance;
        private static readonly object lockObj = new object();

        private TimerManager() { }

        public static TimerManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                        instance = new TimerManager();
                    return instance;
                }
            }
        }

        // Timer declarations
        private static System.Windows.Forms.Timer AlertTimer = new System.Windows.Forms.Timer();
        private static System.Windows.Forms.Timer EvasionTimer = new System.Windows.Forms.Timer();
        private static System.Windows.Forms.Timer EvasionStepTimer = new System.Windows.Forms.Timer();
        private static System.Windows.Forms.Timer CautionTimer = new System.Windows.Forms.Timer();
        private static System.Windows.Forms.Timer SuppressorTimer = new System.Windows.Forms.Timer();

        // State variables
        private static bool infiniteAlertEnabled = false;
        private static bool infiniteEvasionEnabled = false;
        private static bool infiniteCautionEnabled = false;
        private static bool infiniteSuppressorEnabled = false;
        private static int EvasionStep = 0;

        static TimerManager()
        {
            // Initialize all timers
            AlertTimer.Interval = 1000;
            AlertTimer.Tick += AlertTimer_Tick;

            EvasionTimer.Interval = 1000;
            EvasionTimer.Tick += EvasionTimer_Tick;

            EvasionStepTimer.Interval = 3000;
            EvasionStepTimer.Tick += EvasionStepTimer_Tick;

            CautionTimer.Interval = 1000;
            CautionTimer.Tick += CautionTimer_Tick;

            SuppressorTimer.Interval = 500;
            SuppressorTimer.Tick += SuppressorTimer_Tick;
        }

        #region Public Properties
        public static bool IsInfiniteAlertEnabled => infiniteAlertEnabled;
        public static bool IsInfiniteEvasionEnabled => infiniteEvasionEnabled;
        public static bool IsInfiniteCautionEnabled => infiniteCautionEnabled;
        public static bool IsInfiniteSuppressorEnabled => infiniteSuppressorEnabled;
        #endregion

        #region Infinite Alert Status
        private static void AlertTimer_Tick(object sender, EventArgs e)
        {
            nint alertMemoryRegion = MemoryManager.Instance.FindAob("AlertMemoryRegion");

            if (alertMemoryRegion != nint.Zero)
            {
                GuardManager.TriggerAlert(AlertModes.Alert);
            }
            else
            {
                ToggleInfiniteAlert(false);
            }
        }

        public static void ToggleInfiniteAlert(bool enable)
        {
            infiniteAlertEnabled = enable;

            if (enable)
            {
                AlertTimer.Start();
                LoggingManager.Instance.Log("Infinite Alert enabled.\n");
            }
            else
            {
                AlertTimer.Stop();
                LoggingManager.Instance.Log("Infinite Alert disabled.\n");
            }
        }
        #endregion

        #region Infinite Evasion Status
        public static void StartEvasionSequence()
        {
            EvasionStep = 0;
            EvasionStepTimer.Start();
        }

        private static void EvasionStepTimer_Tick(object sender, EventArgs e)
        {
            switch (EvasionStep)
            {
                case 0:
                    GuardManager.RemoveEvasionAndCaution();
                    GuardManager.TriggerAlert(AlertModes.Caution);
                    EvasionStepTimer.Interval = 3000;
                    EvasionStep = 1;
                    break;
                case 1:
                    GuardManager.SetEvasionBits();
                    EvasionStepTimer.Interval = 750;
                    EvasionStep = 2;
                    break;
                case 2:
                    GuardManager.TriggerAlert(AlertModes.Alert);
                    EvasionStepTimer.Stop();
                    EvasionStep = 0;
                    break;
            }
        }

        private static void EvasionTimer_Tick(object sender, EventArgs e)
        {
            if (!infiniteEvasionEnabled) return;

            nint alertMemoryRegion = MemoryManager.Instance.FindAob("AlertMemoryRegion");
            if (alertMemoryRegion == nint.Zero) return;

            short alertTimerValue = GuardManager.ReadAlertTimerValue(alertMemoryRegion);
            short evasionTimerValue = GuardManager.ReadEvasionTimerValue(alertMemoryRegion);

            if (alertTimerValue <= 0 && evasionTimerValue <= 0 && EvasionStep == 0)
            {
                StartEvasionSequence();
            }
        }

        public static void ToggleInfiniteEvasion(bool enable)
        {
            infiniteEvasionEnabled = enable;
            if (enable)
            {
                EvasionTimer.Start();
                LoggingManager.Instance.Log("Infinite Evasion enabled.\n");
            }
            else
            {
                EvasionTimer.Stop();
                EvasionStepTimer.Stop();
                LoggingManager.Instance.Log("Infinite Evasion disabled.\n");
            }
        }
        #endregion

        #region Infinite Caution Status
        private static void CautionTimer_Tick(object sender, EventArgs e)
        {
            if (IsInfiniteCautionEnabled)
            {
                GuardManager.TriggerAlert(AlertModes.Caution);
            }
        }

        public static void ToggleInfiniteCaution(bool enable)
        {
            infiniteCautionEnabled = enable;
            if (enable)
            {
                CautionTimer.Start();
                LoggingManager.Instance.Log("Infinite Caution enabled.\n");
            }
            else
            {
                CautionTimer.Stop();
                LoggingManager.Instance.Log("Infinite Caution disabled.\n");
            }
        }
        #endregion

        #region Infinite Suppressor Status
        /// <summary>
        /// Timer tick event handler for maintaining infinite suppressor functionality.<br></br>
        /// Executes every 500ms when infinite suppressor is enabled to maintain suppressor quantities.<br></br>
        /// Having the event here instead of the form allows us to keep ticking even when<br></br>
        /// navigating away from the form.
        /// </summary>
        private static void SuppressorTimer_Tick(object sender, EventArgs e)
        {
            if (!infiniteSuppressorEnabled) return;

            // Maintain all three suppressors directly
            MaintainSuppressor(MGS3UsableObjects.M1911A1Surpressor);
            MaintainSuppressor(MGS3UsableObjects.MK22Surpressor);
            MaintainSuppressor(MGS3UsableObjects.XM16E1Surpressor);
        }

        /// <summary>
        /// 1. Retrieves the item's memory address using AOB patterns<br></br>
        /// 2. Reads the current suppressor quantity from memory<br></br>
        /// 3. If not a multiple of 30, rounds up to the nearest multiple<br></br>
        /// 4. Writes the new quantity back to memory<br></br>
        /// 5. Handles both current and max capacity values if available
        /// </summary>
        private static void MaintainSuppressor(Item suppressor)
        {
            try
            {
                IntPtr itemAddress = ItemAddresses.GetAddress(suppressor.Index, MemoryManager.Instance);
                if (itemAddress == IntPtr.Zero) return;

                IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS3Process());
                if (processHandle == IntPtr.Zero) return;

                IntPtr currentCapacityAddress = IntPtr.Add(itemAddress, ItemAddresses.CurrentCapacityOffset);
                byte[] currentCapacityBytes = MemoryManager.ReadMemoryBytes(processHandle, currentCapacityAddress, sizeof(short));

                if (currentCapacityBytes != null && currentCapacityBytes.Length == sizeof(short))
                {
                    short currentCapacity = BitConverter.ToInt16(currentCapacityBytes, 0);

                    if (currentCapacity % 30 != 0)
                    {
                        short roundedCapacity = (short)(Math.Ceiling(currentCapacity / 30.0) * 30);

                        MemoryManager.WriteMemory(processHandle, currentCapacityAddress, roundedCapacity);

                        if (suppressor.MaxCapacityOffset != IntPtr.Zero)
                        {
                            IntPtr maxCapacityAddress = IntPtr.Add(itemAddress, suppressor.MaxCapacityOffset.ToInt32());
                            MemoryManager.WriteMemory(processHandle, maxCapacityAddress, roundedCapacity);
                        }

                        LoggingManager.Instance.Log($"Rounded {suppressor.Name} from {currentCapacity} to {roundedCapacity}.");
                    }
                }

                MemoryManager.NativeMethods.CloseHandle(processHandle);
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error maintaining {suppressor.Name}: {ex.Message}");
            }
        }

        /// <summary>
        /// Enables or disables the infinite suppressor functionality. When enabled, <br></br>
        /// starts a timer that maintains suppressor quantities at multiples of 30.<br></br>
        /// When disabled, stops the maintenance timer.
        /// </summary>
        /// <param name="enable">True to enable infinite suppressor, false to disable</param>
        /// <remarks>
        /// This controls the automatic maintenance of:<br></br>
        /// - M1911A1 Suppressor<br></br>
        /// - MK22 Suppressor  <br></br>
        /// - XM16E1 Suppressor<br></br>
        /// The timer runs every 500ms when enabled.
        /// </remarks>
        public static void ToggleInfiniteSuppressor(bool enable)
        {
            infiniteSuppressorEnabled = enable;

            if (enable)
            {
                SuppressorTimer.Start();
                LoggingManager.Instance.Log("Infinite Suppressor enabled for all weapons.");
            }
            else
            {
                SuppressorTimer.Stop();
                LoggingManager.Instance.Log("Infinite Suppressor disabled.");
            }
        }
        #endregion
    }
}