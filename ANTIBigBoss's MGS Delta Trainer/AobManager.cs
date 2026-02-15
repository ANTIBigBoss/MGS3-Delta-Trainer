using ANTIBigBoss_s_MGS_Delta_Trainer;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
// This is all the old MGS3 MC Code will update AOBs when I have access to the game and can get AOB patterns
{
    public class AobManager
    {
        private static AobManager instance;
        private static readonly object lockObj = new object();

        private AobManager() { }

        public static AobManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new AobManager();
                    }
                    return instance;
                }
            }
        }
        private MemoryManager memoryManager;

        /// <summary>
        /// This section is how I handle AOB scanning usage is as follows:
        /// 
        /// 1. Add the AOB to the dictionary like so:
        /// "NameOfAobKeyHere", // Generally use a name that contextually makes sense for what it accesses
        /// 
        /// 2. Add the byte[] pattern this can be a steady pattern or a pattern with wildcards
        /// To use without wildcards list them normally like this:(new byte[] {0x00, 0x00, 0xAA, 0x77, 0x63, 0x00 },
        /// The Mask would like like so for this pattern: "xxxxxx" // each xrepresents a byte in the pattern
        /// 
        /// 3. If you need to use wildcards use the ?character like so:
        /// (new byte[] { 0x00, 0x00, 0x50, 0x46, 0x00, 0x00 },
        /// 0x00 is what I use for wildcards however if a byte is 00 and not a wildcard the mask tells the scanner to ignore it
        /// The Mask would look like this for this pattern:
        /// "x?xxx?Anything in ?is a byte that is accounted for but not acknowledged what the byte is per se
        /// It'd be the same as telling the pattern: (new byte[] {0x00, 0x??, 0xAA, 0x77, 0x63, 0x??},
        /// 
        /// 4. If you need to specify a range of memory to search for the AOB use the StartOffset and EndOffset
        /// from FindAob function in Memory Manager. We're basically telling it look for the pattern in this range of memory
        /// new IntPtr(0x1000000),
        /// new IntPtr(0x1FF0000)
        /// Would basically tell the scanner to look for the pattern in the range of memory from:
        /// METAL GEAR SOLID3.exe+0x1000000 to METAL GEAR SOLID3.exe+0x1FF0000
        /// Once implemented you can use the AOB like so:
        /// IntPtr aobResult = MemoryManager.FindAob("NameOfAobKeyHere");
        /// 
        /// 5.If you need to move forward or backward in memory you can use IntPtr.Add or IntPtr.Subtract like so:
        /// This would move the address 1 byte forward from the AOB: IntPtr targetAddress = IntPtr.Add(aobResult, 1); 
        /// This would move the address 1 byte backward from the AOB IntPtr targetAddress = IntPtr.Subtract(aobResult, 1);
        /// Note: When using IntPtr.Add/ Subtract.Net uses the numbers in decimal, so you don't need to convert to hex.
        /// </summary>
        public static readonly Dictionary<string, (byte[] Pattern, string Mask, IntPtr?StartOffset, IntPtr?EndOffset)> AOBs =
            new Dictionary<string, (byte[] Pattern, string Mask, IntPtr?StartOffset, IntPtr?EndOffset)>

            {

                #region Memory Region Finding AOBs
                

                {
                    "Fog", // 75 05 40 B6 01 EB 03 40 32 F6 48 8B 4C 24 48 48 85 C9 74 05 E8 04 23 F7 FE 40 84 F6
                    (new byte[] { 0x75, 0x05, 0x40, 0xB6, 0x01, 0xEB, 0x03, 0x40, 0x32, 0xF6, 0x48, 0x8B, 0x4C, 0x24, 0x48 },
                        "xxxxxxxxxxxxxxx",
                        new IntPtr(0x1000000),
                        new IntPtr(0x4000000)
                    )
                },

                /* Trying out a new spot for FilterInstructions commenting this out so I can reimplement if need be
                {
                    "FilterInstructions", // F3 0F 11 9B 20 01 00 00 F3 0F 11 93 24 01 00 00 F3 0F 11 8B 28 01 00 00 F3 0F 11 83 2C 01 00 00
                    (new byte[] { 0xF3, 0x0F, 0x11, 0x9B, 0x20, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x93, 0x24, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x8B, 0x28, 0x01, 0x00, 0x00, 0xF3, 0x0F, 0x11, 0x83, 0x2C, 0x01, 0x00, 0x00 },
                        "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                        new IntPtr(0x2000000),
                        new IntPtr(0x2F00000)
                    )
                }, */

                {
                    "FilterInstructions", // 8B 08 01 00 00 75 09 0F 2E 83 0C 01 00 00 74 23
                    (new byte[] { 0x8B, 0x08, 0x01, 0x00, 0x00, 0x75, 0x09, 0x0F, 0x2E, 0x83, 0x0C, 0x01, 0x00, 0x00, 0x74, 0x23 },
                        "xxxxxxxxxxxxxxxx",
                        new IntPtr(0x2000000),
                        new IntPtr(0x2F00000)
                    )
                },

                {
                    "LeftBandana", // 33 33 93 3F 9A 99 B9 3F 9A 99 B9 3F
                    (new byte[] { 0x33, 0x33, 0x93, 0x3F, 0x9A, 0x99, 0xB9, 0x3F, 0x9A, 0x99, 0xB9, 0x3F },
                        "xxxxxxxxxxxx",
                        new IntPtr(0xA00000),
                        new IntPtr(0xB00000)
                    )
                },

                {
                    "RightBandana", // 29 5C 8F 3F 8F C2 B5 3F 8F C2 B5 3F
                    (new byte[] { 0x29, 0x5C, 0x8F, 0x3F, 0x8F, 0xC2, 0xB5, 0x3F, 0x8F, 0xC2, 0xB5, 0x3F },
                        "xxxxxxxxxxxx",
                        new IntPtr(0xA00000),
                        new IntPtr(0xB00000)
                    )
                },

                {
                    "calcuateCamoIndexOffset", // 48 83 EC 30 0F 29 74 24 20 48 8B F9 48 63 F2 E8
                    (new byte[] { 0x48, 0x83, 0xEC, 0x30, 0x0F, 0x29, 0x74, 0x24, 0x20, 0x48, 0x8B, 0xF9, 0x48, 0x63, 0xF2, 0xE8 },
                        "xxxxxxxxxxxxxxxx",
                        new IntPtr(0x6000000),
                        new IntPtr(0x8000000)
                    )
                },


                {   // Unsure if stable                               
                    "CamoIndexInstructions", // BF 2C 92 00 00 01 75 14 E8 7E 0F FF FF 01 43 24
                    (new byte[] { 0xBF, 0x2C, 0x92, 0x00, 0x00, 0x01, 0x75, 0x14, 0xE8, 0x7E, 0x0F, 0xFF, 0xFF, 0x01, 0x43, 0x24 },
                        "xxxxxxxxxxxxxxxx",
                        new IntPtr(0x7800000),
                        new IntPtr(0x7C00000)
                    )
                },

                {
                    "GunReloadInstructions", // 66 39 72 2C 74 07 B9 01 00 00
                    (new byte[] { 0x66, 0x39, 0x72, 0x2C, 0x74, 0x07, 0xB9, 0x01, 0x00, 0x00 },
                        "xxxxxxxxxx",
                        new IntPtr(0x7000000),
                        new IntPtr(0x8000000)
                    )
                },

                {
                    "GuardRegion", // 39 90 38 01 00 00 7E 34
                    (new byte[] { 0x39, 0x90, 0x38, 0x01, 0x00, 0x00, 0x7E, 0x34 },
                        "xxxxxxxx",
                        new IntPtr(0x6000000),
                        new IntPtr(0x8000000)
                    )
                },

                {
                    "PlayerStatusCheck", // 8B D1 B8 01 00 00 00 83 E1 1F D3 E0 8B CA 48 C1
                    (new byte[] { 0x8B, 0xD1, 0xB8, 0x01, 0x00, 0x00, 0x00, 0x83, 0xE1, 0x1F, 0xD3, 0xE0, 0x8B, 0xCA, 0x48, 0xC1 },
                        "xxxxxxxxxxxxxxxx",
                        new IntPtr(0x7000000),
                        new IntPtr(0x9000000)
                    )
                },

                {   // No idea if this is stable so will also use the actual AOB we change down below to confirm for next update
                    // Yeah not present upon update
                    "SnakeDamageMulti", // 00 8B 15 5C 1C AF 0B 0F BF C1 89 05 E7 BA AF 0B
                    (new byte[] { 0x00, 0x8B, 0x15, 0x5C, 0x1C, 0xAF, 0x0B, 0x0F, 0xBF, 0xC1, 0x89, 0x05, 0xE7, 0xBA, 0xAF, 0x0B },
                        "xxxxxxxxxxxxxxxx",
                        new IntPtr(0x6000000),
                        new IntPtr(0x8000000)
                    )
                },

                {   // This is stupidly long but it definitely works if the other AOB breaks on an update
                    "ActualSnakeDamageMulti", // F6 C2 40 74 27 48 8B 05 ?? ?? A5 04 0F BF 90 B4 07 00 00 0F BF 83 80 2F 00 00 8B CA 2B C8 85 C9 7F 0A 66 FF CA 66 89 93 80 2F 00 00 48 8B 0D ?? ?? ?? 04 4C 8D 0D ?? ?? 52 02 0F B7 83 80 2F 00 00
                    (new byte[] { 0xF6, 0xC2, 0x40, 0x74, 0x27, 0x48, 0x8B, 0x05, 0x00, 0x00, 0x00, 0x04, 0x0F, 0xBF, 0x90, 0xB4, 0x07, 0x00, 0x00, 0x0F, 0xBF, 0x83, 0x80, 0x2F, 0x00, 0x00, 0x8B, 0xCA, 0x2B, 0xC8, 0x85, 0xC9, 0x7F, 0x0A, 0x66, 0xFF, 0xCA, 0x66, 0x89, 0x93, 0x80, 0x2F, 0x00, 0x00, 0x48, 0x8B, 0x0D, 0x00, 0x00, 0x00, 0x04, 0x4C, 0x8D, 0x0D, 0x00, 0x00, 0x52, 0x02, 0x0F, 0xB7, 0x83, 0x80, 0x2F, 0x00, 0x00 },
                        "xxxxxxxx???xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx???xxxx??xxxxxxxxx",
                        new IntPtr(0x6000000),
                        new IntPtr(0x8000000)
                    )
                },

                {
                    "SnakeLifeRecovery", // FF C7 83 FF 40 0F 8C 91
                    (new byte[] { 0xFF, 0xC7, 0x83, 0xFF, 0x40, 0x0F, 0x8C, 0x91 },
                        "xxxxxxxx",
                        new IntPtr(0x6000000),
                        new IntPtr(0x8000000)
                    )
                },

                {   // Unsure if stable
                    "CamoIndexHudInstructions", // 79 64 00 48 8B F9 4C 89 B4 24 E0 00 00 00 75 3F
                    (new byte[] { 0x79, 0x64, 0x00, 0x48, 0x8B, 0xF9, 0x4C, 0x89, 0xB4, 0x24, 0xE0, 0x00, 0x00, 0x00, 0x75, 0x3F },
                        "xxxxxxxxxxxxxxxx",
                        new IntPtr(0x6000000),
                        new IntPtr(0x8000000)
                    )
                },

                {
                    "PissFilterInstructions", // C7 81 74 03 00 00 00 00 7F 43
                    (new byte[] { 0xC7, 0x81, 0x74, 0x03, 0x00, 0x00, 0x00, 0x00, 0x7F, 0x43 },
                        "xxxxxxxxxx",
                        new IntPtr(0x7A00000),
                        new IntPtr(0x7F00000)
                    )
                },

                {
                    "GuardDamage", // C3 CC CC CC CC CC 33 C0 39 81 38
                    (new byte[] { 0xC3, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0x33, 0xC0, 0x39, 0x81, 0x38 },
                        "xxxxxxxxxxx",
                        new IntPtr(0x5000000),
                        new IntPtr(0x9000000)
                    )
                },

                {
                    "AlertMemoryRegion", // ?? ?? 00 00 ?? ?? 00 00 50 46 00 00 FF FF FF FF
                    (new byte[] { 0x00, 0x00, 0x50, 0x46, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF },
                        "??xx??xxxxxxxxxx",

                        new IntPtr(0x12000000),
                        new IntPtr(0x14000000)
                    )
                },

                {
                    "WeaponsTable", // 00 00 AA 77 63 00
                    (new byte[] { 0x00, 0x00, 0xAA, 0x77, 0x63, 0x00 },
                        "xxxxxx",
                        new IntPtr(0x135A0000),
                        new IntPtr(0x135F0000)
                        )
                },

                {
                    "ItemsTable", // 00 00 DA 5A 2B 00
                    (new byte[] { 0x00, 0x00, 0xDA, 0x5A, 0x2B, 0x00 },
                        "xxxxxx",
                        new IntPtr(0x13400000),
                        new IntPtr(0x135FEEEE)
                        )
                },

                {
                    "PissFilter", // 00 00 A0 49 00 00 00 00 FF FF FF 7F
                    (new byte[] { 0x00, 0x00, 0xA0, 0x49, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x7F },
                        "xxxxxxxxxxxx",
                    new IntPtr(0x11000000),
                    new IntPtr(0x21000000)
                    )
                },

                {
                    "CodeCaveLocation", // 00 00 00 00 30 C2 66 06 FE 05 07 06 00 00 00
                    (new byte[] { 0x00, 0x00, 0x00, 0x00, 0x30, 0xC2, 0x66, 0x06, 0xFE, 0x05, 0x07, 0x06, 0x00, 0x00, 0x00 },
                        "xxxxxxxxxxxxxxx",
                    new IntPtr(0x12000000),
                    new IntPtr(0x15000000)
                    )
                },

                {
                    "Alphabet", // 30 00 00 31 00 00 32 00 00 33
                    (new byte[] { 0x30, 0x00, 0x00, 0x31, 0x00, 0x00, 0x32, 0x00, 0x00, 0x33 },
                        "xxxxxxxxxx",
                        new IntPtr(0x12000000),
                        new IntPtr(0x14000000)
                    )
                },              
                      
                {
                    "FilterEffects", // 40 40 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 
                    (new byte[] { 0x40, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F  },
                        "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                        new IntPtr(0x13000000),
                        new IntPtr(0x15000000)
                    )
                },
                                
                {                   
                    "StageRestart", // 42 41 53 4C 55 53 2D 32 31 33 35 39 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 10
                    (new byte[] { 0x42, 0x41, 0x53, 0x4C, 0x55, 0x53, 0x2D, 0x32, 0x31, 0x33, 0x35, 0x39, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10 },
                        "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    new IntPtr(0x13A00000),
                    new IntPtr(0x15000000)
                    )
                },
                
                #endregion
               
                #region Boss AOBs (Needs Testing)
                /* Will test these out further when I play Delta more and have a collection of saves at each area
                {
                    // Fear, Pain and Volgin are confirmed for this AOB Ocelot did not work
                    "TheFearAOB", // F0 49 02 00 F0 49 02 00
                    (new byte[] { 0xF0, 0x49, 0x02, 0x00, 0xF0, 0x49, 0x02, 0x00 },
                        "xxxxxxxx",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "TheFury", // 01 00 01 00 D0 00 00 00 06 00
                    (new byte[] { 0x01, 0x00, 0x01, 0x00, 0xD0, 0x00, 0x00, 0x00, 0x06, 0x00 },
                        "xxxxxxxxxx",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    // Starting Area for the boss fight with The End
                    "TheEnds063a", // 01 00 01 00 F0 74 00 00 80
                    (new byte[] { 0x01, 0x00, 0x01, 0x00, 0xF0, 0x74, 0x00, 0x00, 0x80 },
                        "xxxxxxxxx",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    // Area where The End dies and you proceed to the ladder area also works for s064a
                    "TheEnds065a", // 01 00 01 00 00 01 00 00 80 80 80 80 80 80 80 80
                    (new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80 },
                        "xxxxxxxxxxxxxxxx",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "Ocelot", // E0 66 00 00 80 80 80 80 80 80 80 80 80
                    (new byte[] { 0xE0, 0x66, 0x00, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80 },
                        "xxxxxxxxxxxxx",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "TheBoss", // D0 6E 00 00 80 80 80 80 80 80 80
                    (new byte[] { 0xD0, 0x6E, 0x00, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80 },
                        "xxxxxxxxxxx",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "Shagohod", // E6 99 48 00
                    (new byte[] { 0xE6, 0x99, 0x48, 0x00 },
                        "xxxx",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "VolginOnShagohod", // 00 80 ED C4 00 00 80 3F 00 00 80 3F
                    (new byte[] { 0x00, 0x80, 0xED, 0xC4, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F },
                        "xxxxxxxxxxxx",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },
                #endregion
               
            };

        public IntPtr FoundSnakePositionAddress { get; private set; } = IntPtr.Zero;

        public bool FindAndStoreSnakesPositionAOB()
        {
            IntPtr foundAddressStanding = MemoryManager.Instance.FindDynamicAob("SnakeAndBossesStanding");
            if (foundAddressStanding != IntPtr.Zero)
            {
                FoundSnakePositionAddress = foundAddressStanding;
                return true;
            }

            IntPtr foundAddressProne = MemoryManager.Instance.FindDynamicAob("SnakeAndGuardProne");
            if (foundAddressProne != IntPtr.Zero)
            {
                FoundSnakePositionAddress = foundAddressProne;
                return true;
            }

            // If neither pattern is found, return false.
            return false;
        }

        public IntPtr FoundOcelotAddress { get; private set; } = IntPtr.Zero;
        public IntPtr FoundTheFearAddress { get; private set; } = IntPtr.Zero;
        public IntPtr FoundTheEnds063aAddress { get; private set; } = IntPtr.Zero;
        public IntPtr FoundTheEnds065aAddress { get; private set; } = IntPtr.Zero;
        public IntPtr FoundTheFuryAddress { get; private set; } = IntPtr.Zero;
        public IntPtr FoundShagohodAddress { get; private set; } = IntPtr.Zero;
        public IntPtr FoundVolginOnShagohodAddress { get; private set; } = IntPtr.Zero;
        public IntPtr FoundTheBossAddress { get; private set; } = IntPtr.Zero;

        public bool FindAndStoreOcelotAOB()
        {
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("Ocelot");
            if (foundAddress != IntPtr.Zero)
            {
                FoundOcelotAddress = foundAddress;
                return true;
            }
            return false;
        }

        public bool FindAndStoreTheFearAOB()
        {
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("TheFearAOB");
            if (foundAddress != IntPtr.Zero)
            {
                FoundTheFearAddress = foundAddress;
                return true;
            }
            return false;
        }

        public bool FindAndStoreTheEnds063aAOB()
        {
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("TheEnds063a");
            if (foundAddress != IntPtr.Zero)
            {
                FoundTheEnds063aAddress = foundAddress;
                return true;
            }
            return false;
        }

        public bool FindAndStoreTheEnds065aAOB()
        {
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("TheEnds065a");
            if (foundAddress != IntPtr.Zero)
            {
                FoundTheEnds065aAddress = foundAddress;
                return true;
            }
            return false;
        }

        public bool FindAndStoreTheFuryAOB()
        {
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("TheFury");
            if (foundAddress != IntPtr.Zero)
            {
                FoundTheFuryAddress = foundAddress;
                return true;
            }
            return false;
        }

        public bool FindAndStoreTheBossAOB()
        {
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("TheBoss");
            if (foundAddress != IntPtr.Zero)
            {
                FoundTheBossAddress = foundAddress;
                return true;
            }
            return false;
        }

        public bool FindAndStoreShagohodAOB()
        {
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("Shagohod");
            if (foundAddress != IntPtr.Zero)
            {
                FoundShagohodAddress = foundAddress;
                return true;
            }
            return false;
        }

        public bool FindAndStoreVolginOnShagohodAOB()
        {
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("VolginOnShagohod");
            if (foundAddress != IntPtr.Zero)
            {
                FoundVolginOnShagohodAddress = foundAddress;
                return true;
            }
            return false;
        }

                */
#endregion
            };
    }
}