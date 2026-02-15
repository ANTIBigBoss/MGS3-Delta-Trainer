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
        private static string logFileName = "Delta Trainer Log.txt";
        private static string logPath;

        static LoggingManager()
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appLogFolder = "MGS Mod Manager and Trainer";

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

                long relativeOffset = weaponAddress.ToInt64() - baseAddress.ToInt64();
                LoggingManager.Instance.Log($"{weapon.Name} - Address: {weaponAddress.ToString("X")} MGSDelta-Win64-Shipping.exe+{relativeOffset:X}");

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

        #region AOBs from AobManager
        { "Fog AOB", () => FogAob() },
        { "FilterInstructions AOB", () => FilterInstructionsAob() },
        { "LeftBandana AOB", () => LeftBandanaAob() },
        { "RightBandana AOB", () => RightBandanaAob() },
        { "CalculateCamoIndexOffset AOB", () => CalculateCamoIndexOffsetAob() },
        { "CamoIndexInstructions AOB", () => CamoIndexInstructionsAob() },
        { "GunReloadInstructions AOB", () => GunReloadInstructionsAob() },
        { "GuardRegion AOB", () => GuardRegionAob() },
        { "PlayerStatusCheck AOB", () => PlayerStatusCheckAob() },
        { "SnakeDamageMulti AOB", () => SnakeDamageMultiAob() },
        { "ActualSnakeDamageMulti AOB", () => ActualSnakeDamageMultiAob() },
        { "SnakeLifeRecovery AOB", () => SnakeLifeRecoveryAob() },
        { "CamoIndexHudInstructions AOB", () => CamoIndexHudInstructionsAob() },
        { "PissFilterInstructions AOB", () => PissFilterInstructionsAob() },
        { "GuardDamage AOB", () => GuardDamageAob() },
        { "AlertMemoryRegion AOB", () => AlertMemoryRegionAob() },
        { "WeaponsTable AOB", () => WeaponsTableAob() },
        { "ItemsTable AOB", () => ItemsTableAob() },
        { "PissFilter AOB", () => PissFilterAob() },
        { "CodeCaveLocation AOB", () => CodeCaveLocationAob() },
        { "Alphabet AOB", () => AlphabetAob() },
        { "FilterEffects AOB", () => FilterEffectsAob() },
        { "StageRestart AOB", () => StageRestartAob() },
        #endregion

        #region Snake's Various States

        { "Snake Vomits or Set on Fire", () => VomitFireValue() },
        { "Snake has a Quick Sleep", () => SnakeQuickSleepValue() },
        { "Snake No Damage", () => SnakeNoDamageValue() },
        { "Snake Instant Life Recovery", () => SnakeInstantLifeRecoveryValue() },
        { "Snake's Tactical Reload Instructions", () => TacticalReloadValue() },
        { "Snake's Manual Reload Instructions", () => ManualReloadValue() },
        { "Snake's Camo Index Hud Instructions", () => CamoIndexHudInstructions() },
        { "Snake's Camo Index Instructions", () => CamoIndexInstructions() },
        { "Snake's Camo Index Instructions Backup", () => CamoIndexInstructionsBackup() },
        { "Snake's Camo Index Value", () => CamoIndexValue() },
        { "Snake's Damage Multi Instructions", () => SnakeDamageMultiInstructions() },
        { "Snake's Damage Multi Instructions Backup", () => SnakeDamageMultiInstructionsBackup() },
        { "Snake's Damage Multi Instructions Backup 2", () => SnakeDamageMultiInstructionsBackup2() },
        { "Snake's Damage Multi Value", () => SnakeDamageMultiValue() },
        #endregion

        #region GuardDamage Related Methods

        { "Guard Invincibility", () => GetInvincibilityAddressValue() },
        { "Most Weapons Damage", () => GetMostWeaponsDamageValue() },
        { "Flame Damage", () => GetFlameDamageValue() },
        { "Throat Slit Damage", () => GetThroatSlitDamageValue() },
        { "Sleep Timer 1", () => GetSleepTimer1Value() },
        { "Sleep Timer 2", () => GetSleepTimer2Value() },
        { "Sleep Timer 3", () => GetSleepTimer3Value() },
        { "Sleep Drain", () => GetSleepDrainValue() },
        { "Tranq Head", () => GetTranqHeadshotValue() },
        { "Tranq Body", () => GetTranqBodyShotValue() },
        { "Stun Timer 1", () => GetStunTimer1Value() },
        { "Stun Timer 2", () => GetStunTimer2Value() },
        { "Stun Timer 3", () => GetStunTimer3Value() },
        { "Stun Punch", () => GetStunPunchValue() },
        { "Stun Grenade", () => GetStunGrenadeValue() },
        { "Giant Damage Array", () => GetGiantDamageArrayValue() },
        { "Damage Multiplier", () => GetDamageMultiValue() },

        #endregion

        #region Alert Status and Timers

        { "Alert Status", () => AlertStatus() },
        { "Alert Timer", () => AlertTimer() },
        { "Evasion Timer", () => EvasionTimer() },
        { "Caution Timer", () => CautionTimer() },

                #endregion

        #region Filter Effects

        { "Fog Status", () => FogStatus() },

        { "Piss Filter Status", () => PissFilterStatus() },
        { "Filter R Value", () => FilterRValue() },
        { "Filter G Value", () => FilterGValue() },
        { "Filter B Value", () => FilterBValue() },
        { "Filter A Value", () => FilterAValue() },
        
        // Light Colour Effects
        { "Light Colour Status", () => LightColourStatus() },
        { "Light Colour R Value", () => LightColourRValue() },
        { "Light Colour G Value", () => LightColourGValue() },
        { "Light Colour B Value", () => LightColourBValue() },
        { "Light Colour A Value", () => LightColourAValue() },

        // Extra Light Colour Effects
        { "Extra Light Colour Status", () => ExtraLightColourStatus() },
        { "Extra Light Colour R Value", () => ExtraLightColourRValue() },
        { "Extra Light Colour G Value", () => ExtraLightColourGValue() },
        { "Extra Light Colour B Value", () => ExtraLightColourBValue() },
        { "Extra Light Colour A Value", () => ExtraLightColourAValue() },
        
        // World Lighting
        { "World Light Status", () => WorldLightStatus() },
        { "World Light Brightness", () => WorldLightBrightnessValue() },

        #endregion

        #region Utility

                { "RestartStageValue", () => RestartStageValue() },
        { "Code Cave Locator", () => CodeCaveLocator() },

        #endregion

            };

            foreach (var reading in LogMemoryAddresses)
            {
                string message = reading.Value.Invoke();
                LoggingManager.Instance.Log($"{reading.Key}:\n{message}\n");
            }
        }

        #region String Methods for LogAllMemoryAddressesAndValues

        #region AOBs From AobManager

        public string FogAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("Fog", 0, false, 15, DataType.ByteArray);
        }

        public string FilterInstructionsAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 0, false, 32, DataType.ByteArray);
        }

        public string LeftBandanaAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("LeftBandana", 0, false, 12, DataType.ByteArray);
        }

        public string RightBandanaAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("RightBandana", 0, false, 12, DataType.ByteArray);
        }

        public string CalculateCamoIndexOffsetAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("CalculateCamoIndexOffset", 0, false, 24, DataType.ByteArray);
        }

        public string CamoIndexInstructionsAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("CamoIndexInstructions", 0, false, 16, DataType.ByteArray);
        }

        public string GunReloadInstructionsAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("GunReloadInstructions", 0, false, 10, DataType.ByteArray);
        }

        public string GuardRegionAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardRegion", 0, false, 8, DataType.ByteArray);
        }

        public string PlayerStatusCheckAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("PlayerStatusCheck", 0, false, 16, DataType.ByteArray);
        }

        public string SnakeDamageMultiAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("SnakeDamageMulti", 0, false, 16, DataType.ByteArray);
        }

        public string ActualSnakeDamageMultiAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("ActualSnakeDamageMulti", 0, false, 64, DataType.ByteArray);
        }

        public string SnakeLifeRecoveryAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("SnakeLifeRecovery", 0, false, 8, DataType.ByteArray);
        }

        public string CamoIndexHudInstructionsAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("CamoIndexHudInstructions", 0, false, 16, DataType.ByteArray);
        }

        public string PissFilterInstructionsAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("PissFilterInstructions", 0, false, 10, DataType.ByteArray);
        }

        public string GuardDamageAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardDamage", 0, false, 11, DataType.ByteArray);
        }

        public string AlertMemoryRegionAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("AlertMemoryRegion", 0, false, 10, DataType.ByteArray);
        }

        public string WeaponsTableAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("WeaponsTable", 0, false, 6, DataType.ByteArray);
        }

        public string ItemsTableAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("ItemsTable", 0, false, 6, DataType.ByteArray);
        }

        public string PissFilterAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("PissFilter", 0, false, 12, DataType.ByteArray);
        }

        public string CodeCaveLocationAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("CodeCaveLocation", 0, false, 15, DataType.ByteArray);
        }

        public string AlphabetAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("Alphabet", 0, false, 10, DataType.ByteArray);
        }

        public string FilterEffectsAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 0, false, 34, DataType.ByteArray);
        }

        public string StageRestartAob()
        {
            return HelperMethods.Instance.ReadMemoryValue("StageRestart", 0, false, 33, DataType.ByteArray);
        }

        #endregion

        #region Snake's Various States

        public string VomitFireValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("ItemsTable", 30234, true, 1, DataType.UInt8);
        }

        public string SnakeQuickSleepValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("ItemsTable", 30235, true, 1, DataType.UInt8);
        }
        
        public string SnakeNoDamageValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("CalculateCamoIndexOffset", 5571, true, 1, DataType.ByteArray);
        }

        public string SnakeInstantLifeRecoveryValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("SnakeLifeRecovery", 4, false, 1, DataType.ByteArray);
        }

        public string TacticalReloadValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GunReloadInstructions", 24, false, 4, DataType.ByteArray);
        }

        public string ManualReloadValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("GunReloadInstructions", 2378, false, 4, DataType.ByteArray);
        }

        public string CamoIndexHudInstructions()
        {
            return HelperMethods.Instance.ReadMemoryValue("CamoIndexHudInstructions", 16, true, 6, DataType.ByteArray);
        }

        public string CamoIndexInstructions()
        {
            return HelperMethods.Instance.ReadMemoryValue("CamoIndexInstructions", 32, true, 6, DataType.ByteArray);
        }

        public string CamoIndexInstructionsBackup()
        {
            return HelperMethods.Instance.ReadMemoryValue("GuardRegion", 78311, false, 6, DataType.ByteArray);
        }

        public string CamoIndexValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("CamoIndexHudInstructions", 180, false, 4, DataType.Int32);
        }

        public string SnakeDamageMultiInstructions()
        {
            return HelperMethods.Instance.ReadMemoryValue("SnakeDamageMulti", 16, true, 65, DataType.ByteArray);
        }

        public string SnakeDamageMultiInstructionsBackup()
        {
            return HelperMethods.Instance.ReadMemoryValue("ActualSnakeDamageMulti", 0, true, 65, DataType.ByteArray);
        }

        public string SnakeDamageMultiInstructionsBackup2()
        {
            return HelperMethods.Instance.ReadMemoryValue("CalculateCamoIndexOffset", 5505, true, 65, DataType.ByteArray);
        }
        public string SnakeDamageMultiValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("SnakeDamageMulti", 18, true, 1, DataType.Int8);
        }

        #endregion

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

        #region Alert Status and Timers

        public string AlertStatus()
        {
            return HelperMethods.Instance.ReadMemoryValue("AlertMemoryRegion", 78, true, 1, DataType.UInt8);
        }

        public string AlertTimer()
        {
            return HelperMethods.Instance.ReadMemoryValue("AlertMemoryRegion", 6, false, 2, DataType.UInt16);
        }

        public string EvasionTimer()
        {
            return HelperMethods.Instance.ReadMemoryValue("AlertMemoryRegion", 18, true, 2, DataType.UInt16);
        }

        public string CautionTimer()
        {
            return HelperMethods.Instance.ReadMemoryValue("AlertMemoryRegion", 2, false, 2, DataType.UInt16);
        }

        #endregion

        #region Filter Effects

        public string FogStatus()
        {
            return HelperMethods.Instance.ReadMemoryValue("Fog", 4, false, 4, DataType.ByteArray);
        }

        #region Piss Filter
        public string PissFilterStatus()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 16, true, 32, DataType.ByteArray);
        }

        public string FilterRValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 38, true, 4, DataType.Float);
        }

        public string FilterGValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 42, true, 4, DataType.Float);
        }

        public string FilterBValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 46, true, 4, DataType.Float);
        }

        public string FilterAValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 50, true, 4, DataType.Float);
        }

        #endregion

        #region Light Colour Effects

        public string LightColourStatus()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 123, true, 32, DataType.ByteArray);
        }

        public string LightColourRValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 54, true, 4, DataType.Float);
        }

        public string LightColourGValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 58, true, 4, DataType.Float);
        }

        public string LightColourBValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 62, true, 4, DataType.Float);
        }

        public string LightColourAValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 66, true, 4, DataType.Float);
        }

        #endregion

        #region Light Colour Effects

        public string ExtraLightColourStatus()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 242, true, 32, DataType.ByteArray);
        }

        public string ExtraLightColourRValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 70, true, 4, DataType.Float);
        }

        public string ExtraLightColourGValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 74, true, 4, DataType.Float);
        }

        public string ExtraLightColourBValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 78, true, 4, DataType.Float);
        }

        public string ExtraLightColourAValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 82, true, 4, DataType.Float);
        }

        #endregion

        #region World Lighting

        public string WorldLightStatus()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterInstructions", 2299, true, 8, DataType.ByteArray);
        }

        public string WorldLightBrightnessValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("FilterEffects", 402, true, 4, DataType.Float);
        }

        #endregion

        #endregion

        #region Utility

        public string RestartStageValue()
        {
            return HelperMethods.Instance.ReadMemoryValue("StageRestart", 64, true, 1, DataType.ByteArray);
        }

        public string CodeCaveLocator()
        {
            return HelperMethods.Instance.ReadMemoryValue("CodeCaveLocation", 114, true, 1065, DataType.ByteArray);
        }

        #endregion

        #endregion
    }
}