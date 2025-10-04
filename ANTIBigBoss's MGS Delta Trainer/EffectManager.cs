using System;
using System.Linq;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    /// <summary>
    /// Any effects that didn't warrant their own file ended up in this file
    /// </summary>
    public class EffectManager
    {
        private static EffectManager instance;
        private static readonly object lockObj = new object();

        private EffectManager()
        {
        }

        
        public static EffectManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new EffectManager();
                    }

                    return instance;
                }
            }
        }
        
        #region Weapons - Weapons Form
        // You might be asking: ANTI why did you put the weapons thing in here?
        // Great question! That's because it's not part of the weapons table.
        

        // Infinite Ammo Methods
        // TODO: Confirm that FilterInstructions is close to avoid 300000+ bytes of distance between effects
        // Reminder: The large range broke the WeaponsForm on Delta Version 1.1.4 find a new one
        public bool IsInfiniteAmmoDisabled()
        {
            byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("PlayerStatusCheck", 336277, false, 5);
            byte[] noInfiniteAmmoBytes = { 0x66, 0xFF, 0x49, 0x28, 0x48 };

            return currentBytes != null && currentBytes.SequenceEqual(noInfiniteAmmoBytes);
        }

        public bool EnableInfiniteAmmo()
        {
            byte[] infiniteAmmoBytes = { 0x0F, 0x1F, 0x40, 0x00, 0x48 };
            return HelperMethods.Instance.WriteMemoryValue("PlayerStatusCheck", 336277, false, infiniteAmmoBytes);
        }

        public bool DisableInfiniteAmmo()
        {
            byte[] noInfiniteAmmoBytes = { 0x66, 0xFF, 0x49, 0x28, 0x48 };
            return HelperMethods.Instance.WriteMemoryValue("PlayerStatusCheck", 336277, false, noInfiniteAmmoBytes);
        }

        // No Reload Methods
        public bool IsNoReloadDisabled()
        {
            byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("PlayerStatusCheck", 336288, false, 7);
            byte[] noInfiniteAmmoBytes = { 0x66, 0xFF, 0xC8, 0x66, 0x89, 0x41, 0x2C };

            return currentBytes != null && currentBytes.SequenceEqual(noInfiniteAmmoBytes);
        }

        public bool EnableNoReload()
        {
            byte[] infiniteAmmoBytes = { 0x0F, 0x1F, 0x80, 0x00, 0x00, 0x00, 0x00 };
            return HelperMethods.Instance.WriteMemoryValue("PlayerStatusCheck", 336288, false, infiniteAmmoBytes);
        }

        public bool DisableNoReload()
        {
            byte[] disableNoReloadBytes = { 0x66, 0xFF, 0x49, 0x28, 0x48 };
            return HelperMethods.Instance.WriteMemoryValue("PlayerStatusCheck", 336288, false, disableNoReloadBytes);
        }

        #endregion

        #region Snake God Mode Effects

        public bool IsInstantLifeRecoveryEnabled()
        {
            byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("SnakeLifeRecovery", 4, false, 4);
            byte[] instantRecoveryBytes = { 0x90, 0x90, 0x90, 0x90 }; // NOPs for instant recovery

            return currentBytes != null && currentBytes.SequenceEqual(instantRecoveryBytes);
        }

        public bool EnableInstantLifeRecovery()
        {
            byte[] instantRecoveryBytes = { 0x90, 0x90, 0x90, 0x90 };
            return HelperMethods.Instance.WriteMemoryValue("SnakeLifeRecovery", 4, false, instantRecoveryBytes);
        }

        public bool DisableInstantLifeRecovery()
        {
            byte[] normalRecoveryBytes = { 0x66, 0x09, 0x71, 0x0C }; // Normal life recovery
            return HelperMethods.Instance.WriteMemoryValue("SnakeLifeRecovery", 4, false, normalRecoveryBytes);
        }

        public bool IsNoDamageTakenEnabled()
        {
            byte[] currentByte = HelperMethods.Instance.ReadMemoryBytes("calcuateCamoIndexOffset", 5539, true, 1);
            byte[] noDamageByte = { 0x1 }; // No damage taken

            return currentByte != null && currentByte.SequenceEqual(noDamageByte);
        }

        public bool EnableNoDamageTaken()
        {
            byte[] noDamageByte = { 0x1 };
            return HelperMethods.Instance.WriteMemoryValue("calcuateCamoIndexOffset", 5539, true, noDamageByte);
        }

        public bool DisableNoDamageTaken()
        {// 
            byte[] damageByte = { 0x29 }; // Damage taken
            return HelperMethods.Instance.WriteMemoryValue("calcuateCamoIndexOffset", 5539, true, damageByte);
        }

        #endregion

        #region Filter Effects

        public bool IsFogEnabled()
        {
            byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("Fog", 4, false, 4);
            byte[] fogOnBytes = { 0x83, 0x78, 0x04, 0x01 };

            return currentBytes != null && currentBytes.SequenceEqual(fogOnBytes);
        }

        public bool EnableFog()
        {
            byte[] fogOnBytes = { 0x83, 0x78, 0x04, 0x01 };
            return HelperMethods.Instance.WriteMemoryValue("Fog", 4, false, fogOnBytes);
        }

        public bool DisableFog()
        {
            byte[] fogOffBytes = { 0x90, 0x90, 0x90, 0x90 };
            return HelperMethods.Instance.WriteMemoryValue("Fog", 4, false, fogOffBytes);
        }

        // F3 0F 11 9B 00 01 00 00 F3 0F 11 93 04 01 00 00 F3 0F 11 8B 08 01 00 00 F3 0F 11 83 0C 01 00 00
        // 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 
        // Checkbox related methods
        public bool IsPissFilterEnabled()
        {
            byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("FilterInstructions", 226, false, 32);
            byte[] pissFilterOnBytes = { 0xF3, 0x0F, 0x11, 0x9B, 0x00, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x93, 0x04, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x8B, 0x08, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x83, 0x0C, 0x01, 0x00, 0x00 };

            return currentBytes != null && currentBytes.SequenceEqual(pissFilterOnBytes);
        }

        public bool EnablePissFilter()
        {
            byte[] pissFilterOnBytes = { 0xF3, 0x0F, 0x11, 0x9B, 0x00, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x93, 0x04, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x8B, 0x08, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x83, 0x0C, 0x01, 0x00, 0x00 };
            return HelperMethods.Instance.WriteMemoryValue("FilterInstructions", 226, false, pissFilterOnBytes);
        }

        public bool DisablePissFilter()
        {
            byte[] pissFilterOffBytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            return HelperMethods.Instance.WriteMemoryValue("FilterInstructions", 226, false, pissFilterOffBytes);
        }

        // Set the value in our form to whatever we want
        public bool SetFilterR(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 38, true, value);
        }

        public bool SetFilterG(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 42, true, value);
        }

        public bool SetFilterB(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 46, true, value);
        }

        public bool SetFilterA(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 50, true, value);
        }

        // Read the values as floats
        public float GetFilterValue1Float() // R
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 38, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        public float GetFilterValue2Float() // G
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 42, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        public float GetFilterValue3Float() // B
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 46, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        public float GetFilterValue4Float() // A
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 50, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        #region Light Colour Effects

        public bool IsLightColourEnabled()
        {
            byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("FilterInstructions", 119, false, 32);
            byte[] lightColourOnBytes = { 0xF3, 0x0F, 0x11, 0x9B, 0x10, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x93, 0x14, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x8B, 0x18, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x83, 0x1C, 0x01, 0x00, 0x00 };

            return currentBytes != null && currentBytes.SequenceEqual(lightColourOnBytes);
        }

        public bool EnableLightColour()
        {
            byte[] lightColourOnBytes = { 0xF3, 0x0F, 0x11, 0x9B, 0x10, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x93, 0x14, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x8B, 0x18, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x83, 0x1C, 0x01, 0x00, 0x00 };
            return HelperMethods.Instance.WriteMemoryValue("FilterInstructions", 119, false, lightColourOnBytes);
        }

        public bool DisableLightColour()
        {
            byte[] lightColourOffBytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            return HelperMethods.Instance.WriteMemoryValue("FilterInstructions", 119, false, lightColourOffBytes);
        }

        public bool SetLightColourR(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 54, true, value);
        }

        public bool SetLightColourG(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 58, true, value);
        }

        public bool SetLightColourB(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 62, true, value);
        }

        public bool SetLightColourA(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 66, true, value);
        }

        public float GetLightColourValue1Float() // R
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 54, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        public float GetLightColourValue2Float() // G
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 58, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        public float GetLightColourValue3Float() // B
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 62, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        public float GetLightColourValue4Float() // A
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 66, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        #endregion

        #region World Lighting

        public bool IsWorldLightEnabled()
        {
            byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("FilterInstructions", 2299, true, 32);
            byte[] worldLightOnBytes = { 0xF3, 0x0F, 0x11, 0x83, 0x6C, 0x02, 0x00, 0x00 };

            return currentBytes != null && currentBytes.SequenceEqual(worldLightOnBytes);
        }

        public bool EnableWorldLight()
        {
            byte[] worldLightOnBytes = { 0xF3, 0x0F, 0x11, 0x83, 0x6C, 0x02, 0x00, 0x00 };
            return HelperMethods.Instance.WriteMemoryValue("FilterInstructions", 2299, true, worldLightOnBytes);
        }

        public bool DisableWorldLight()
        {
            byte[] worldLightOffBytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            return HelperMethods.Instance.WriteMemoryValue("FilterInstructions", 2299, true, worldLightOffBytes);
        }

        public bool SetWorldLightBrightness(float value)
        {
            return HelperMethods.Instance.WriteMemoryValue("FilterEffects", 402, true, value);
        }

        public float GetWorldLightBrightnessFloat()
        {
            byte[] bytes = HelperMethods.Instance.ReadMemoryBytes("FilterEffects", 402, true, 4);
            if (bytes != null && bytes.Length == 4)
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            return 1.0f;
        }

        #endregion


        #endregion

        #region Random

        public bool TriggerStageRestart()
        {
            byte restartValue = 1;
            return HelperMethods.Instance.WriteMemoryValue("StageRestart", 64, true, restartValue);
        }

        #region Infinite Battery Effects

        public bool IsInfiniteBatteryEnabled()
        {
            byte[] currentBytes = HelperMethods.Instance.ReadMemoryBytes("PlayerStatusCheck", 167, true, 7);
            byte[] infiniteBatteryBytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };

            return currentBytes != null && currentBytes.SequenceEqual(infiniteBatteryBytes);
        }

        public bool EnableInfiniteBattery()
        {
            byte[] infiniteBatteryBytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            return HelperMethods.Instance.WriteMemoryValue("PlayerStatusCheck", 167, true, infiniteBatteryBytes);
        }

        public bool DisableInfiniteBattery()
        {
            byte[] normalBatteryBytes = { 0x66, 0x29, 0x88, 0x7E, 0x0B, 0x00, 0x00 };
            return HelperMethods.Instance.WriteMemoryValue("PlayerStatusCheck", 167, true, normalBatteryBytes);
        }

        #endregion

        #endregion
    }
}