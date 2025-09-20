using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using static ANTIBigBoss_s_MGS_Delta_Trainer.Constants;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public class GuardManager
    {
        private static GuardManager instance;
        private static readonly object lockObj = new object();

        private GuardManager() { }

        public static GuardManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new GuardManager();
                }
            }
        }

        #region Guard Health and Damage Values

        #region Configuration Structures

        private struct DamageConfig
        {
            public string AobKey { get; set; }
            public int Offset { get; set; }
            public bool Forward { get; set; }
            public object Value { get; set; }
            public int ReadSize { get; set; }
            public Func<byte[], object, bool> Comparer { get; set; }
        }

        private struct DamageProfile
        {
            public List<DamageConfig> Configs { get; set; }
        }

        #endregion

        #region Damage Profiles

        #region Lethal

        private readonly Dictionary<string, DamageProfile> _lethalProfiles = new Dictionary<string, DamageProfile>
        {
            ["Invincible"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig
        {
            AobKey = "GuardDamage",Offset = 11872 ,Forward = false, Value = new byte[] { 0x74, 0x0F, 0x0F, 0xB7, 0x42, 0x08, 0x48, 0x83, 0xC2, 0x08, 0x66, 0x85, 0xC0, 0x79, 0xED, 0x33, 0xC0, 0xF3, 0x0F, 0x59, 0xC1, 0x49, 0xBC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x66, 0x4D, 0x0F, 0x6E, 0xD4, 0xF3, 0x0F, 0x5A, 0xC0, 0xF2, 0x41, 0x0F, 0x59, 0xC2, 0x90, 0x90, 0x90, 0x90, 0xF2, 0x0F, 0x2C, 0xC0, 0xC3 }, ReadSize = 53, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 11849, Forward = false, Value = new byte[] {  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00   }, ReadSize = 8, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 4, Forward = false, Value = 0, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 397936, Forward = true, Value = 0, ReadSize = 4, Comparer = IntComparer }
        }
            },

            ["VeryStrong"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig
        {
            AobKey = "GuardDamage",Offset = 11872 , Forward = false, Value = new byte[] { 0x74, 0x0F, 0x0F, 0xB7, 0x42, 0x08, 0x48, 0x83, 0xC2, 0x08, 0x66, 0x85, 0xC0, 0x79, 0xED, 0x33, 0xC0, 0xF3, 0x0F, 0x59, 0xC1, 0x49, 0xBC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x66, 0x4D, 0x0F, 0x6E, 0xD4, 0xF3, 0x0F, 0x5A, 0xC0, 0xF2, 0x41, 0x0F, 0x59, 0xC2, 0x90, 0x90, 0x90, 0x90, 0xF2, 0x0F, 0x2C, 0xC0, 0xC3 }, ReadSize = 53, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 11849, Forward = false, Value = new byte[] {  0x9A, 0x99, 0x99, 0x99, 0x99, 0x99, 0xB9, 0x3F   }, ReadSize = 8, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 4, Forward = false, Value = 0, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 397936, Forward = true, Value = 0, ReadSize = 4, Comparer = IntComparer }
        }
            },

            ["Default"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig
        {
            AobKey = "GuardDamage",Offset = 11872,Forward = false, Value = new byte[] { 0x74, 0x0F, 0x0F, 0xB7, 0x42, 0x08, 0x48, 0x83, 0xC2, 0x08, 0x66, 0x85, 0xC0, 0x79, 0xED, 0x33, 0xC0, 0xF3, 0x0F, 0x59, 0xC1, 0x49, 0xBC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x66, 0x4D, 0x0F, 0x6E, 0xD4, 0xF3, 0x0F, 0x5A, 0xC0, 0xF2, 0x41, 0x0F, 0x59, 0xC2, 0x90, 0x90, 0x90, 0x90, 0xF2, 0x0F, 0x2C, 0xC0, 0xC3 }, ReadSize = 53, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 11849, Forward = false, Value = new byte[] {  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD0, 0x3F   }, ReadSize = 8, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 4, Forward = false, Value = 0, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 397936, Forward = true, Value = 0, ReadSize = 4, Comparer = IntComparer }
        }
            },

            ["VeryWeak"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig
        {
            AobKey = "GuardDamage",Offset = 11872 ,Forward = false, Value = new byte[] { 0x74, 0x0F, 0x0F, 0xB7, 0x42, 0x08, 0x48, 0x83, 0xC2, 0x08, 0x66, 0x85, 0xC0, 0x79, 0xED, 0x33, 0xC0, 0xF3, 0x0F, 0x59, 0xC1, 0x49, 0xBC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x66, 0x4D, 0x0F, 0x6E, 0xD4, 0xF3, 0x0F, 0x5A, 0xC0, 0xF2, 0x41, 0x0F, 0x59, 0xC2, 0x90, 0x90, 0x90, 0x90, 0xF2, 0x0F, 0x2C, 0xC0, 0xC3 }, ReadSize = 53, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 11849, Forward = false, Value = new byte[] {  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE8, 0x3F   }, ReadSize = 8, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 4, Forward = false, Value = 0, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 397936, Forward = true, Value = 0, ReadSize = 4, Comparer = IntComparer }
        }
            },

            ["Oneshot"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig
        {
            AobKey = "GuardDamage",Offset = 11872 ,Forward = false, Value = new byte[] { 0x74, 0x0F, 0x0F, 0xB7, 0x42, 0x08, 0x48, 0x83, 0xC2, 0x08, 0x66, 0x85, 0xC0, 0x79, 0xED, 0x33, 0xC0, 0xF3, 0x0F, 0x59, 0xC1, 0x49, 0xBC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x66, 0x4D, 0x0F, 0x6E, 0xD4, 0xF3, 0x0F, 0x5A, 0xC0, 0xF2, 0x41, 0x0F, 0x59, 0xC2, 0x90, 0x90, 0x90, 0x90, 0xF2, 0x0F, 0x2C, 0xC0, 0xC3 }, ReadSize = 53, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 11849, Forward = false, Value = new byte[] {  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F   }, ReadSize = 8, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 4, Forward = false, Value = 0, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 397936, Forward = true, Value = 0, ReadSize = 4, Comparer = IntComparer }
        }
            },

            ["x2Damage"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig
        {
            AobKey = "GuardDamage",Offset = 11872 ,Forward = false, Value = new byte[] { 0x74, 0x0F, 0x0F, 0xB7, 0x42, 0x08, 0x48, 0x83, 0xC2, 0x08, 0x66, 0x85, 0xC0, 0x79, 0xED, 0x33, 0xC0, 0xF3, 0x0F, 0x59, 0xC1, 0x49, 0xBC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x66, 0x4D, 0x0F, 0x6E, 0xD4, 0xF3, 0x0F, 0x5A, 0xC0, 0xF2, 0x41, 0x0F, 0x59, 0xC2, 0x90, 0x90, 0x90, 0x90, 0xF2, 0x0F, 0x2C, 0xC0, 0xC3 }, ReadSize = 53, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 11849, Forward = false, Value = new byte[] {  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40   }, ReadSize = 8, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 4, Forward = false, Value = 0, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 397936, Forward = true, Value = 0, ReadSize = 4, Comparer = IntComparer }
        }
            },

            ["x10Damage"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig
        {
            AobKey = "GuardDamage",Offset = 11872 ,Forward = false, Value = new byte[] { 0x74, 0x0F, 0x0F, 0xB7, 0x42, 0x08, 0x48, 0x83, 0xC2, 0x08, 0x66, 0x85, 0xC0, 0x79, 0xED, 0x33, 0xC0, 0xF3, 0x0F, 0x59, 0xC1, 0x49, 0xBC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x66, 0x4D, 0x0F, 0x6E, 0xD4, 0xF3, 0x0F, 0x5A, 0xC0, 0xF2, 0x41, 0x0F, 0x59, 0xC2, 0x90, 0x90, 0x90, 0x90, 0xF2, 0x0F, 0x2C, 0xC0, 0xC3 }, ReadSize = 53, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 11849, Forward = false, Value = new byte[] {  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x24, 0x40   }, ReadSize = 8, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 4, Forward = false, Value = 0, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 397936, Forward = true, Value = 0, ReadSize = 4, Comparer = IntComparer }
        }
            }
        };

        /* Old Default Lethal Profile:
        new DamageConfig { AobKey = "GuardDamage", Offset = 11889, Forward = false, Value = new byte[] { 0xF3, 0x0F, 0x5E, 0x0D, 0x8B, 0xCA, 0x0B, 0x04 }, ReadSize = 8, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102807, Forward = true, Value = 1000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 4, Forward = false, Value = 0, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 397936, Forward = true, Value = 0, ReadSize = 4, Comparer = IntComparer } */

        #endregion

        #region Sleep/ZZZ

        private readonly Dictionary<string, DamageProfile> _sleepProfiles = new Dictionary<string, DamageProfile>
        {
            ["Invincible"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 2161, Forward = true, Value = 90000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2179, Forward = true, Value = 90000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2191, Forward = true, Value = 90000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 7797, Forward = true, Value = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102698, Forward = true, Value = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, ReadSize = 7, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 113777, Forward = true, Value = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            },
            ["VeryStrong"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 2161, Forward = true, Value = -2000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2179, Forward = true, Value = -2000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2191, Forward = true, Value = -2000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 7797, Forward = true, Value = new byte[] { 0x89, 0x87, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102698, Forward = true, Value = new byte[] { 0x44, 0x29, 0xB6, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 7, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 113777, Forward = true, Value = new byte[] { 0x89, 0x8B, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            },
            ["Default"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 2161, Forward = true, Value = -20000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2179, Forward = true, Value = -20000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2191, Forward = true, Value = -20000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 7797, Forward = true, Value = new byte[] { 0x89, 0x87, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102698, Forward = true, Value = new byte[] { 0x44, 0x29, 0xB6, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 7, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 113777, Forward = true, Value = new byte[] { 0x89, 0x8B, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            },
            ["VeryWeak"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 2161, Forward = true, Value = -40000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2179, Forward = true, Value = -40000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2191, Forward = true, Value = -40000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 7797, Forward = true, Value = new byte[] { 0x89, 0x87, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102698, Forward = true, Value = new byte[] { 0x44, 0x29, 0xB6, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 7, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 113777, Forward = true, Value = new byte[] { 0x89, 0x8B, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            },
            ["Oneshot"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 2161, Forward = true, Value = -1000000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2179, Forward = true, Value = -1000000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 2191, Forward = true, Value = -1000000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 7797, Forward = true, Value = new byte[] { 0x89, 0x87, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102698, Forward = true, Value = new byte[] { 0x44, 0x29, 0xB6, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 7, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 113777, Forward = true, Value = new byte[] { 0x89, 0x8B, 0x48, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            }
        };

        #endregion

        #region Stun

        private readonly Dictionary<string, DamageProfile> _stunProfiles = new Dictionary<string, DamageProfile>
        {
            ["Invincible"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 127, Forward = false, Value = 90000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 109, Forward = false, Value = 90000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 97, Forward = false, Value = 90000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102286, Forward = true, Value = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 100556, Forward = true, Value = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            },
            ["VeryStrong"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 127, Forward = false, Value = -2000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 109, Forward = false, Value = -2000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 97, Forward = false, Value = -2000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102286, Forward = true, Value = new byte[] { 0x29, 0x86, 0x40, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 100556, Forward = true, Value = new byte[] { 0x29, 0x86, 0x40, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            },
            ["Default"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 127, Forward = false, Value = -20000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 109, Forward = false, Value = -20000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 97, Forward = false, Value = -20000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102286, Forward = true, Value = new byte[] { 0x29, 0x86, 0x40, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 100556, Forward = true, Value = new byte[] { 0x29, 0x86, 0x40, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            },
            ["VeryWeak"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 127, Forward = false, Value = -40000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 109, Forward = false, Value = -40000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 97, Forward = false, Value = -40000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102286, Forward = true, Value = new byte[] { 0x29, 0x86, 0x40, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 100556, Forward = true, Value = new byte[] { 0x29, 0x86, 0x40, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            },
            ["Oneshot"] = new DamageProfile
            {
                Configs = new List<DamageConfig>
        {
            new DamageConfig { AobKey = "GuardDamage", Offset = 127, Forward = false, Value = -1000000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 109, Forward = false, Value = -1000000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 97, Forward = false, Value = -1000000, ReadSize = 4, Comparer = IntComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 102286, Forward = true, Value = new byte[] { 0x29, 0x86, 0x40, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer },
            new DamageConfig { AobKey = "GuardDamage", Offset = 100556, Forward = true, Value = new byte[] { 0x29, 0x86, 0x40, 0x01, 0x00, 0x00 }, ReadSize = 6, Comparer = ByteArrayComparer }
        }
            }
        };

        #endregion

        #endregion

        #region Comparison Methods

        private static bool ByteArrayComparer(byte[] readBytes, object expectedValue)
        {
            return readBytes.SequenceEqual((byte[])expectedValue);
        }

        private static bool IntComparer(byte[] readBytes, object expectedValue)
        {
            return BitConverter.ToInt32(readBytes, 0) == (int)expectedValue;
        }

        #endregion

        #region Core Methods

        private void WriteValues<T>(nint processHandle, string aobKey, int offset, bool forward, T value)
        {
            nint aobResult = MemoryManager.Instance.FindAob(aobKey);
            if (aobResult == nint.Zero)
            {
                LoggingManager.Instance.Log($"Error: AOB pattern not found for {aobKey}.");
                return;
            }

            nint targetAddress = forward ? nint.Add(aobResult, offset) : nint.Subtract(aobResult, offset);

            bool writeResult;
            if (value is float floatValue)
            {
                writeResult = MemoryManager.WriteMemory(processHandle, targetAddress, floatValue);
            }
            else
            {
                writeResult = MemoryManager.WriteMemory(processHandle, targetAddress, value);
            }

            LoggingManager.Instance.Log(writeResult ? $"{aobKey} written successfully." : $"Failed to write {aobKey}.");
        }

        private void ApplyDamageProfile(string damageType, string profileName)
        {
            nint processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS3Process());
            if (processHandle == nint.Zero)
            {
                LoggingManager.Instance.Log($"Error: Could not open process when applying {profileName} profile for {damageType}.");
                return;
            }

            DamageProfile profile;
            switch (damageType)
            {
                case "Lethal":
                    if (!_lethalProfiles.TryGetValue(profileName, out profile)) return;
                    break;
                case "Sleep":
                    if (!_sleepProfiles.TryGetValue(profileName, out profile)) return;
                    break;
                case "Stun":
                    if (!_stunProfiles.TryGetValue(profileName, out profile)) return;
                    break;
                default:
                    MemoryManager.NativeMethods.CloseHandle(processHandle);
                    return;
            }

            foreach (var config in profile.Configs)
            {
                if (config.Value is byte[] bytes)
                {
                    WriteValues(processHandle, config.AobKey, config.Offset, config.Forward, bytes);
                }
                else if (config.Value is short shortValue)
                {
                    WriteValues(processHandle, config.AobKey, config.Offset, config.Forward, shortValue);
                }
                else if (config.Value is int intValue)
                {
                    WriteValues(processHandle, config.AobKey, config.Offset, config.Forward, intValue);
                }
                else if (config.Value is float floatValue)
                {
                    WriteValues(processHandle, config.AobKey, config.Offset, config.Forward, floatValue);
                }
            }

            MemoryManager.NativeMethods.CloseHandle(processHandle);
        }
       
        #endregion

        #region Lethal Damage Methods

        public void WriteAllLethalInvincibleValues() => ApplyDamageProfile("Lethal", "Invincible");
        public void WriteAllLethalVeryStrongValues() => ApplyDamageProfile("Lethal", "VeryStrong");
        public void WriteAllLethalDefaultValues() => ApplyDamageProfile("Lethal", "Default");
        public void WriteAllLethalVeryWeakValues() => ApplyDamageProfile("Lethal", "VeryWeak");
        public void WriteAllLethalOneshotValues() => ApplyDamageProfile("Lethal", "Oneshot");
        public void WriteAllLethalx2Values() => ApplyDamageProfile("Lethal", "x2Damage");
        public void WriteAllLethalx10Values() => ApplyDamageProfile("Lethal", "x10Damage");

        #endregion

        #region Sleep Damage Methods

        public void WriteAllSleepInvincibleValues() => ApplyDamageProfile("Sleep", "Invincible");
        public void WriteAllSleepVeryStrongValues() => ApplyDamageProfile("Sleep", "VeryStrong");
        public void WriteAllSleepNormalValues() => ApplyDamageProfile("Sleep", "Default");
        public void WriteAllSleepVeryWeakValues() => ApplyDamageProfile("Sleep", "VeryWeak");
        public void WriteAllSleepOneShotValues() => ApplyDamageProfile("Sleep", "Oneshot");

        #endregion

        #region Stun Damage Methods

        public void WriteAllStunInvincibleValues() => ApplyDamageProfile("Stun", "Invincible");
        public void WriteAllStunVeryStrongValues() => ApplyDamageProfile("Stun", "VeryStrong");
        public void WriteAllStunDefaultValues() => ApplyDamageProfile("Stun", "Default");
        public void WriteAllStunVeryWeakValues() => ApplyDamageProfile("Stun", "VeryWeak");
        public void WriteAllStunOneshotValues() => ApplyDamageProfile("Stun", "Oneshot");

        #endregion

        #endregion

        #region Guard Alert Statuses

        internal static void WriteMaxAlertTimerValue(nint alertMemoryRegion)
        {
            nint processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS3Process());
            nint timerAddress = nint.Subtract(alertMemoryRegion, (int)Constants.AlertOffsets.AlertTimerSub);
            short maxTimerValue = short.MaxValue;

            MemoryManager.WriteMemory(processHandle, timerAddress, maxTimerValue);
            MemoryManager.NativeMethods.CloseHandle(processHandle);
        }

        internal static void SetEvasionBits()
        {
            nint alertMemoryRegion = MemoryManager.Instance.FindAob("AlertMemoryRegion");

            if (alertMemoryRegion == nint.Zero)
            {
                LoggingManager.Instance.Log("Alert memory region not found.\n");
                return;
            }

            nint modifyAddress = nint.Add(alertMemoryRegion, (int)Constants.AlertOffsets.AlertTriggerAdd);
            nint processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS3Process());

            byte[] buffer = MemoryManager.ReadMemoryBytes(processHandle, modifyAddress, sizeof(short));
            if (buffer == null || buffer.Length != sizeof(short))
            {
                LoggingManager.Instance.Log($"Failed to read memory at {modifyAddress}");
                MemoryManager.NativeMethods.CloseHandle(processHandle);
                return;
            }

            short currentValue = BitConverter.ToInt16(buffer, 0);
            short modifiedValue = MemoryManager.SetSpecificBits(currentValue, 5, 14, 596);

            bool writeSuccess = MemoryManager.WriteMemory(processHandle, modifyAddress, modifiedValue);
            if (!writeSuccess)
            {
                LoggingManager.Instance.Log($"Failed to write memory at {modifyAddress}");
            }
            else
            {
                LoggingManager.Instance.Log($"Evasion bits successfully set to {modifiedValue} at {modifyAddress}");
            }

            MemoryManager.NativeMethods.CloseHandle(processHandle);
        }

        internal static void RemoveEvasionAndCaution()
        {
            nint alertMemoryRegion = MemoryManager.Instance.FindAob("AlertMemoryRegion");

            if (alertMemoryRegion == nint.Zero)
            {
                LoggingManager.Instance.Log("Alert memory region not found.\n");
                return;
            }

            nint modifyAddress = nint.Add(alertMemoryRegion, (int)Constants.AlertOffsets.AlertTriggerAdd);
            nint processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS3Process());

            // Read current value using the new ReadMemoryBytes function
            byte[] buffer = MemoryManager.ReadMemoryBytes(processHandle, modifyAddress, sizeof(short));
            if (buffer == null || buffer.Length != sizeof(short))
            {
                LoggingManager.Instance.Log($"Failed to read memory at {modifyAddress}");
                MemoryManager.NativeMethods.CloseHandle(processHandle);
                return;
            }

            short currentValue = BitConverter.ToInt16(buffer, 0);
            short modifiedValue = MemoryManager.SetSpecificBits(currentValue, 6, 15, 400);

            // Using the generic WriteMemory method to apply the new value
            bool writeSuccess = MemoryManager.WriteMemory(processHandle, modifyAddress, modifiedValue);
            if (!writeSuccess)
            {
                LoggingManager.Instance.Log($"Failed to write memory at {modifyAddress}");
            }
            else
            {
                LoggingManager.Instance.Log("Evasion and Caution bits removed.");
            }

            MemoryManager.NativeMethods.CloseHandle(processHandle);
        }


        internal static void TriggerAlert(AlertModes alertMode)
        {

            nint alertMemoryRegion = MemoryManager.Instance.FindAob("AlertMemoryRegion");
            if (alertMemoryRegion == nint.Zero)
            {
                MessageBox.Show("Failed to find alert memory region.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nint processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS3Process());
            if (processHandle == nint.Zero)
            {
                MessageBox.Show("Failed to open game process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nint triggerAddress = nint.Add(alertMemoryRegion, (int)Constants.AlertOffsets.AlertTriggerAdd);

            byte alertValue = (byte)alertMode;

            bool writeSuccess = MemoryManager.WriteMemory(processHandle, triggerAddress, alertValue);
            if (!writeSuccess)
            {
                MessageBox.Show("Failed to write alert value.", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (alertMode == AlertModes.Evasion)
                {
                    SetEvasionBits();
                }
            }

            MemoryManager.NativeMethods.CloseHandle(processHandle);
        }

        internal static short ReadAlertTimerValue(nint alertMemoryRegion)
        {
            Process process = MemoryManager.GetMGS3Process();
            nint processHandle = MemoryManager.OpenGameProcess(process);
            nint timerAddress = nint.Subtract(alertMemoryRegion, (int)Constants.AlertOffsets.AlertTimerSub);

            byte[] buffer = MemoryManager.ReadMemoryBytes(processHandle, timerAddress, sizeof(short));
            if (buffer == null || buffer.Length != sizeof(short))
            {
                LoggingManager.Instance.Log($"Failed to read alert timer value at {timerAddress}");
                return 0;
            }

            return BitConverter.ToInt16(buffer, 0);
        }

        internal static short ReadEvasionTimerValue(nint alertMemoryRegion)
        {
            Process process = MemoryManager.GetMGS3Process();
            nint processHandle = MemoryManager.OpenGameProcess(process);
            nint timerAddress = nint.Add(alertMemoryRegion, (int)Constants.AlertOffsets.EvasionTimerAdd);

            byte[] buffer = MemoryManager.ReadMemoryBytes(processHandle, timerAddress, sizeof(short));
            if (buffer == null || buffer.Length != sizeof(short))
            {
                LoggingManager.Instance.Log($"Failed to read evasion timer value at {timerAddress}");
                return 0;
            }

            return BitConverter.ToInt16(buffer, 0);
        }

        internal static short ReadCautionTimerValue(nint alertMemoryRegion)
        {
            Process process = MemoryManager.GetMGS3Process();
            nint processHandle = MemoryManager.OpenGameProcess(process);
            nint timerAddress = nint.Subtract(alertMemoryRegion, (int)Constants.AlertOffsets.CautionTimerSub);

            byte[] buffer = MemoryManager.ReadMemoryBytes(processHandle, timerAddress, sizeof(short));
            if (buffer == null || buffer.Length != sizeof(short))
            {
                LoggingManager.Instance.Log($"Failed to read caution timer value at {timerAddress}");
                return 0;
            }

            return BitConverter.ToInt16(buffer, 0);
        }

        #endregion
    }
}