using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static ANTIBigBoss_s_MGS_Delta_Trainer.Constants;
using static ANTIBigBoss_s_MGS_Delta_Trainer.MemoryManager;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    internal class LoggingManager
    {
        private static LoggingManager instance;
        private static readonly object padlock = new object();
        private static string logFolderPath;
        private static string logFileName = "ANTIBigBoss's MGS Delta Trainer_Log.txt";
        private static string logPath;

        static LoggingManager()
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appLogFolder = "MGS Mod Manager and Trainer Logs";

            logFolderPath = Path.Combine(documentsFolder, appLogFolder);
            logPath = Path.Combine(logFolderPath, logFileName);

            EnsureLogFileExists();
        }

        private LoggingManager()
        {
        }

        public static LoggingManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LoggingManager();
                    }

                    return instance;
                }
            }
        }

        private static void EnsureLogFileExists()
        {
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }

            if (!File.Exists(logPath))
            {
                using (var stream = File.Create(logPath))
                {
                }
            }
        }

        public void Log(string message)
        {
            try
            {
                using (var writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while trying to log: {ex.Message}");
            }
        }

        /// <summary>
        /// This is mostly to help me stay ahead of game updates so I can log the <br></br>
        /// offset differences quicker if anything gets shifted around and help <br></br>
        /// me implement things into Crowd Control quicker
        /// </summary>         
        public void LogAOBAddresses()
        {
            Process process = GetMGS3Process();
            if (process == null)
            {
                LoggingManager.Instance.Log("Process not found.");
                return;
            }

            IntPtr processHandle = OpenGameProcess(process);
            if (processHandle == IntPtr.Zero)
            {
                LoggingManager.Instance.Log("Failed to open process.");
                return;
            }

            IntPtr baseAddress = process.MainModule.BaseAddress;
            long moduleSize = process.MainModule.ModuleMemorySize;

            foreach (var aobEntry in AobManager.AOBs)
            {
                string name = aobEntry.Key;
                if (string.IsNullOrEmpty(name)) continue;

                byte[] pattern = aobEntry.Value.Pattern;
                string mask = aobEntry.Value.Mask;

                var foundAddresses =
                    MemoryManager.Instance.ScanForAllAobInstances(processHandle, baseAddress, moduleSize, pattern,
                        mask);
                if (foundAddresses.Count > 0)
                {
                    foreach (var address in foundAddresses)
                    {
                        long offset = address.ToInt64() - baseAddress.ToInt64();
                        byte[] aobBytes = new byte[pattern.Length];
                        if (NativeMethods.ReadProcessMemory(processHandle, address, aobBytes, (uint)aobBytes.Length,
                                out _))
                        {
                            string aobHexString = BitConverter.ToString(aobBytes).Replace("-", " ");
                            LoggingManager.Instance.Log(
                                $"{name}: Instance found at: {address.ToString("X")}, MGSDelta-Win64-Shipping.exe+{offset:X}, AOB: {aobHexString}");
                        }
                        else
                        {
                            LoggingManager.Instance.Log(
                                $"{name}: Instance found at: {address.ToString("X")}, MGSDelta-Win64-Shipping.exe+{offset:X}, but failed to read AOB bytes.");
                        }
                    }
                }
                else
                {
                    LoggingManager.Instance.Log($"{name}: AOB not found.");
                }
            }

            NativeMethods.CloseHandle(processHandle);
        }
       
        public static void LogAllWeaponsAndItemsAddresses()
        {
            LoggingManager.Instance.Log("Logging all weapons and items' addresses...");

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS3Process());
            if (processHandle == IntPtr.Zero)
            {
                LoggingManager.Instance.Log("Failed to open game process.");
                return;
            }

            Process process = MemoryManager.GetMGS3Process();
            IntPtr baseAddress = process.MainModule.BaseAddress;

            LoggingManager.Instance.Log("Weapons:");
            var weapons = typeof(MGS3UsableObjects).GetFields()
                .Where(field => field.FieldType == typeof(Weapon))
                .Select(field => field.GetValue(null) as Weapon)
                .ToList();

            foreach (var weapon in weapons)
            {
                IntPtr weaponAddress = WeaponAddresses.GetAddress(weapon.Index, MemoryManager.Instance);
                if (weaponAddress == IntPtr.Zero) continue;

                // Calculate the offset relative to the base address
                long relativeOffset = weaponAddress.ToInt64() - baseAddress.ToInt64();
                LoggingManager.Instance.Log($"{weapon.Name} - Address: {weaponAddress.ToString("X")} MGSDelta-Win64-Shipping.exe+{relativeOffset:X}");

                // These methods in WeaponAddresses already handle the offset calculations
                if (weapon.MaxAmmoOffset != IntPtr.Zero)
                {
                    IntPtr maxAmmoAddress = WeaponAddresses.GetMaxAmmoAddress(weaponAddress);
                    relativeOffset = maxAmmoAddress.ToInt64() - baseAddress.ToInt64();
                    LoggingManager.Instance.Log($"Max Ammo Address: {maxAmmoAddress.ToString("X")} MGSDelta-Win64-Shipping.exe+{relativeOffset:X}");
                }

                if (weapon.ClipOffset != IntPtr.Zero)
                {
                    IntPtr clipAddress = WeaponAddresses.GetClipAddress(weaponAddress);
                    relativeOffset = clipAddress.ToInt64() - baseAddress.ToInt64();
                    LoggingManager.Instance.Log($"Clip Address: {clipAddress.ToString("X")} MGSDelta-Win64-Shipping.exe+{relativeOffset:X}");
                }

                if (weapon.MaxClipOffset != IntPtr.Zero)
                {
                    IntPtr maxClipAddress = WeaponAddresses.GetMaxClipAddress(weaponAddress);
                    relativeOffset = maxClipAddress.ToInt64() - baseAddress.ToInt64();
                    LoggingManager.Instance.Log($"Max Clip Address: {maxClipAddress.ToString("X")} MGSDelta-Win64-Shipping.exe+{relativeOffset:X}");
                }

                if (weapon.SuppressorToggleOffset != IntPtr.Zero)
                {
                    IntPtr suppressorToggleAddress = WeaponAddresses.GetSuppressorToggleAddress(weaponAddress);
                    relativeOffset = suppressorToggleAddress.ToInt64() - baseAddress.ToInt64();
                    LoggingManager.Instance.Log($"Suppressor Toggle Address: {suppressorToggleAddress.ToString("X")} MGSDelta-Win64-Shipping.exe+{relativeOffset:X}");
                }

            }

            LoggingManager.Instance.Log("Items:");
            var items = typeof(MGS3UsableObjects).GetFields()
                .Where(field => field.FieldType == typeof(Item))
                .Select(field => field.GetValue(null) as Item)
                .ToList();

            foreach (var item in items)
            {
                IntPtr itemAddress = ItemAddresses.GetAddress(item.Index, MemoryManager.Instance);
                if (itemAddress == IntPtr.Zero) continue;

                long relativeOffset = itemAddress.ToInt64() - baseAddress.ToInt64();
                LoggingManager.Instance.Log($"{item.Name} - Address: {itemAddress.ToString("X")} (METAL GEAR SOLID 3.exe+{relativeOffset:X})");

                if (item.MaxCapacityOffset != IntPtr.Zero)
                {
                    IntPtr maxCapacityAddress = ItemAddresses.GetMaxAddress(itemAddress);
                    relativeOffset = maxCapacityAddress.ToInt64() - baseAddress.ToInt64();
                    LoggingManager.Instance.Log($"Max Capacity Address: {maxCapacityAddress.ToString("X")} (METAL GEAR SOLID 3.exe+{relativeOffset:X})");
                }
            }

            MemoryManager.NativeMethods.CloseHandle(processHandle);
            LoggingManager.Instance.Log("Finished logging weapons and items' addresses.");
        }
       
        /// <summary>
        /// Indepth logging with Memory Addresses and the Values at time of method call
        /// </summary>
        public void LogAllMemoryAddressesandValues()
        {
            var LogMemoryAddresses = new Dictionary<string, Func<string>>()
            {

                { "Vomit Fire", () => GetVomitFireValue() },
                { "Alert Status", () => ReadAlertStatus() },
                { "Guard Invincibility", () => GetInvincibilityAddressValue() },
                { "Most Weapons Damage", () => GetMostWeaponsDamageValue() },
                { "Flame Damage", () => GetFlameDamageValue() },
                { "Throat Slit Damage", () => GetThroatSlitDamageValue() },
                { "SleepTimer1", () => GetSleepTimer1Value() },
                { "SleepTimer2", () => GetSleepTimer2Value() },
                { "SleepTimer3", () => GetSleepTimer3Value() },
                { "Sleep Drain", () => GetSleepDrainValue() },
                { "Tranq Head", () => GetTranqHeadshotValue() },
                { "Tranq Body", () => GetTranqBodyShotValue() },
                { "StunTimer1", () => GetStunTimer1Value() },
                { "StunTimer2", () => GetStunTimer2Value() },
                { "StunTimer3", () => GetStunTimer3Value() },
                { "Stun Punch", () => GetStunPunchValue() },
                { "Stun Grenade", () => GetStunGrenadeValue() },
                { "Giant Damage Array", () => GetGiantDamageArrayValue() },
                { "Damage Multiplier", () => GetDamageMultiValue() },
                { "GetSnakeNoDamageValue", () => GetSnakeNoDamageValue() },
                { "GetSnakeInstantLifeRecoveryValue", () => GetSnakeInstantLifeRecoveryValue() },
                { "GetRestartStageValue", () => GetRestartStageValue() },
                { "GetFilterValue1", () => GetFilterValue1() },
                { "GetFilterColor1", () => GetFilterColor1() },
                { "GetFilterLight1", () => GetFilterLight1() },
                { "GetFilterLight2", () => GetFilterLight2() },
                { "GetFilterAccurateColorR", () => GetFilterAccurateColorR() },
                { "GetFilterAccurateColorG", () => GetFilterAccurateColorG() },
                { "GetFilterAccurateColorB", () => GetFilterAccurateColorB() },
                { "GetFilterSkyLight", () => GetFilterSkyLight() },
                { "Fog Array", () => GetFogArrayValue() },
                { "Delta Piss Filter to NOP", () => GetPissFilterNopValue() },
                { "RGB Filter to NOP", () => GetRgbNopValue() },
                { "RGB2 Filter to NOP", () => GetRgb2NopValue() },
                { "Light of Sky to NOP", () => GetSkyLightNopValue() },
            };

            foreach (var reading in LogMemoryAddresses)
            {
                string message = reading.Value.Invoke();
                LoggingManager.Instance.Log($"{reading.Key}:\n{message}\n");
            }
        }

        #region String Methods for LogAllMemoryAddressesAndValues

        public string GetVomitFireValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("ItemsTable", 30234, true, 1, DataType.UInt8);
        }

        public string ReadAlertStatus()
        {
            return HelperMethods.Instance.ReadMemoryValue("AlertMemoryRegion", (int)AlertOffsets.AlertTriggerAdd, true, 1, DataType.UInt8);
        }

        #region GuardDamage Related Methods

        public string GetInvincibilityAddressValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 11889, false, 8, DataType.ByteArray);
        }

        public string GetMostWeaponsDamageValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 102807, true, 4, DataType.Int32);
        }

        public string GetFlameDamageValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 4, false, 4, DataType.Int32);
        }

        public string GetThroatSlitDamageValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 397936, true, 4, DataType.Int32);
        }

        public string GetSleepTimer1Value()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 2161, true, 4, DataType.Int32);
        }

        public string GetSleepTimer2Value()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 2179, true, 4, DataType.Int32);
        }

        public string GetSleepTimer3Value()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 2191, true, 4, DataType.Int32);
        }

        public string GetSleepDrainValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 7797, true, 6, DataType.ByteArray);
        }

        public string GetTranqHeadshotValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 102698, true, 7, DataType.ByteArray);
        }

        public string GetTranqBodyShotValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 113777, true, 6, DataType.ByteArray);
        }

        public string GetStunTimer1Value()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 127, false, 4, DataType.Int32);
        }

        public string GetStunTimer2Value()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 109, false, 4, DataType.Int32);
        }

        public string GetStunTimer3Value()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 97, false, 4, DataType.Int32);
        }

        public string GetStunPunchValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 102286, true, 6, DataType.ByteArray);
        }

        public string GetStunGrenadeValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 100556, true, 6, DataType.ByteArray);
        }

        public string GetGiantDamageArrayValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 11872, false, 54, DataType.ByteArray);
        }

        public string GetDamageMultiValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 11849, false, 4, DataType.Float);
        }

        #endregion

        public string GetRestartStageValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("StageRestart", 64, true, 1, DataType.ByteArray);
        }

        public string GetSnakeNoDamageValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("calcuateCamoIndexOffset", 5538, false, 4, DataType.ByteArray);
        }

        public string GetSnakeInstantLifeRecoveryValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("SnakeLifeRecovery", 4, false, 1, DataType.ByteArray);
        }

        public string GetFogArrayValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("Fog", 4, false, 4, DataType.ByteArray);
        }

        // Filter Values
        // Piss Filter
        public string GetPissFilterNopValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("Fog", 5402346, true, 32, DataType.ByteArray);
        }
        public string GetFilterValue1()// R?
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 38, true, 4, DataType.Float);
        }
        public string GetFilterValue2()// G?
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 42, true, 4, DataType.Float);
        }
        public string GetFilterValue3()// B?
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 46, true, 4, DataType.Float);
        }
        public string GetFilterValue4()// A?
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 50, true, 4, DataType.Float);
        }


        // Should look into if this is part of piss filter or the first RGB NOP
        public string GetFilterColor1()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 54, true, 4, DataType.ByteArray);
        }

        public string GetFilterLight1()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 66, true, 4, DataType.ByteArray);
        }

        public string GetFilterLight2()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 82, true, 4, DataType.ByteArray);
        }

        // RGB Might be Floats since all are 4 bytes away from each other?
        public string GetFilterAccurateColorR()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 70, true, 4, DataType.ByteArray);
        }

        public string GetFilterAccurateColorG()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 74, true, 4, DataType.ByteArray);
        }

        public string GetFilterAccurateColorB()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 78, true, 4, DataType.ByteArray);
        }

        public string GetFilterSkyLight()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 402, true, 8, DataType.ByteArray);
        }

        // Functions to NOP for filter effects
        
        public string GetRgbNopValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("Fog", 5402453, true, 32, DataType.ByteArray);
        }

        public string GetRgb2NopValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("Fog", 5402572, true, 32, DataType.ByteArray);
        }

        public string GetSkyLightNopValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("Fog", 5404871, true, 8, DataType.ByteArray);
        }

        #endregion

    }
}

/* Button to implement later to locate the log file/folder

   private void btnOpenLogFolder_Click(object sender, EventArgs e)
   {
       // Use the Process.Start method to open the log folder in File Explorer
       try
       {
           Process.Start(new ProcessStartInfo
           {
               FileName = LoggingManager.LogFolderPath,
               UseShellExecute = true,
               Verb = "open"
           });
       }
       catch (Exception ex)
       {
           MessageBox.Show($"Failed to open log folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
   }
*/