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
        /// The Mask would like like so for this pattern: "x x x x x x" // each x represents a byte in the pattern
        /// 
        /// 3. If you need to use wildcards use the ? character like so:
        /// (new byte[] { 0x00, 0x00, 0x50, 0x46, 0x00, 0x00 },
        /// 0x00 is what I use for wildcards however if a byte is 00 and not a wildcard the mask tells the scanner to ignore it
        /// The Mask would look like this for this pattern:
        /// "x ? x x x ? Anything in ? is a byte that is accounted for but not acknowledged what the byte is per se
        /// It'd be the same as telling the pattern: (new byte[] {0x00, 0x??, 0xAA, 0x77, 0x63, 0x?? },
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
        public static readonly Dictionary<string, (byte[] Pattern, string Mask, IntPtr? StartOffset, IntPtr? EndOffset)> AOBs =
            new Dictionary<string, (byte[] Pattern, string Mask, IntPtr? StartOffset, IntPtr? EndOffset)>

            {
                
                #region Memory Region Finding AOBs
                {
                    // 22 results outside of exe it seems but 1 in the exe in Delta
                    "AlertMemoryRegion", // ?? ?? 00 00 ?? ?? 00 00 50 46 00 00 FF FF FF FF
                    (new byte[] { 0x00, 0x00, 0x50, 0x46, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF },
                        "? ? x x ? ? x x x x x x x x x x",
                        
                        // Specify the range of memory in the exe to search for
                        new IntPtr(0x1000000),
                        new IntPtr(0x1FF0000)
                    )
                },

                {
                    "WeaponsTable", // 00 00 AA 77 63 00
                    (new byte[] { 0x00, 0x00, 0xAA, 0x77, 0x63, 0x00 },
                        "x x x x x x",
                        new IntPtr(0x135D0000),
                        new IntPtr(0x135E0000)
                        )
                },

                {    
                    "ItemsTable", // 00 00 DA 5A 2B 00
                    (new byte[] { 0x00, 0x00, 0xDA, 0x5A, 0x2B, 0x00 },
                        "x x x x x x",
                        new IntPtr(0x135D0000),
                        new IntPtr(0x135E0000)
                        // Same as weapons but 12 bytes to get to the Life Medicine
                        // Usage to travel forward looks like this it would also be using the class information from BaseMGS3Object.cs:
                        //IntPtr.Add(aobResult, Constants.TestAOBs["ItemsTable"].Pattern.Length + 12 + (ItemOffset * index));
                        )
                },

                {   // Small Chance but this might be usable for animations and camo index(89BE/35262) 
                    // I'll double check if this ended up being usable for both in MC when the time comes to implement
                    "Animations", // 00 00 DA 5A 2B 00
                    // Same as Items but we search in a further region that has the same byte pattern
                    (new byte[] { 0x00, 0x00, 0xDA, 0x5A, 0x2B, 0x00 },
                        "x x x x x x",
                        new IntPtr(0x1C00000),
                        new IntPtr(0x1E00000)
                    )
                },

                {
                    "Alphabet", // 30 00 00 31 00 00 32 00 00 33 - 10958/2ACE is the camo index
                    (new byte[] { 0x30, 0x00, 0x00, 0x31, 0x00, 0x00, 0x32, 0x00, 0x00, 0x33 },
                        "x x x x x x x x x x",
                        new IntPtr(0x1D00000),
                        new IntPtr(0x1F00000)
                    )
                },
 
                #endregion
                
                #region Camera and Model AOBs
                {
                    "ModelDistortion", // 45 0F 29 43 C8 45 0F 29 4B B8 45 0F 29 53 A8 45 0F 29 5B 98 45 0F 29 63 88 44 0F 29 6C 24 30
                    (new byte[] { 0x45, 0x0F, 0x29, 0x43, 0xC8, 0x45, 0x0F, 0x29, 0x4B, 0xB8, 0x45, 0x0F, 0x29, 0x53, 0xA8, 0x45, 0x0F, 0x29, 0x5B, 0x98, 0x45, 0x0F, 0x29, 0x63, 0x88, 0x44, 0x0F, 0x29, 0x6C, 0x24, 0x30 },
                        "x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x",
                        new IntPtr(0x000000),
                        new IntPtr(0xC00000)
                        )
                },

                
                {   // 1595/5525 Byte before this AOB is the filter value (Side note this might work for Animations too)
                    "PissFilter", // 00 00 A0 49 00 00 00 00 FF FF FF 7F
                    (new byte[] { 0x00, 0x00, 0xA0, 0x49, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x7F },
                        "x x x x x x x x x x x x",
                        new IntPtr(0x1C00000),
                        new IntPtr(0x1F00000)
                    )
                },

                {
                    // The byte before this AOB is the instruction value for what changes the filter when a new area loads
                    // All wee do here is change 48 into 90 to disable the instruction
                    // ADD/2781 bytes after this is the instructions for it writing a value to the filter and checking if the 
                    // correct value is there changing F3 0F 11 99 78 03 00 00 to 90 90 90 90 90 90 90 90 will allow a checkbox
                    // to permanently disable the piss filter or turn it back on
                    "PissFilterInstructions", // C7 81 74 03 00 00 00 00 7F 43
                    (new byte[] { 0xC7, 0x81, 0x74, 0x03, 0x00, 0x00, 0x00, 0x00, 0x7F, 0x43 },
                        "x x x x x x x x x x",
                        new IntPtr(0x10000),
                        new IntPtr(0xF0000)
                    )
                },


                { // TODO: Add notes on how many bytes before or after Bloom is for this
                "BloomFilter", // 00 00 A0 49 00 00 00 00 FF FF FF 7F
                (new byte[] { 0x00, 0x00, 0xA0, 0x49, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x7F },
                        "x x x x x x x x x x x x",
                    new IntPtr(0x1C00000),
                    new IntPtr(0x1F00000)
                    )
                },
                
                {
                    "LeftBandana", // 33 33 93 3F 9A 99 B9 3F 9A 99 B9 3F
                    (new byte[] { 0x33, 0x33, 0x93, 0x3F, 0x9A, 0x99, 0xB9, 0x3F, 0x9A, 0x99, 0xB9, 0x3F },
                        "x x x x x x x x x x x x",
                        new IntPtr(0xA00000),
                        new IntPtr(0xB00000)
                    )
                },

                {
                    "RightBandana", // 29 5C 8F 3F 8F C2 B5 3F 8F C2 B5 3F
                    (new byte[] { 0x29, 0x5C, 0x8F, 0x3F, 0x8F, 0xC2, 0xB5, 0x3F, 0x8F, 0xC2, 0xB5, 0x3F },
                        "x x x x x x x x x x x x",
                        new IntPtr(0xA00000),
                        new IntPtr(0xB00000)
                    )
                },

                #endregion

                #region Old AOBs in Delta but Might no longer be useful
                

                {   // 4 Bytes before the AOB is the 4-byte damage value in MC, in Delta it just crashes when edited.
                    "WpNadeDamage", // C3 CC CC CC CC CC 33 C0 39 81 38
                    (new byte[] { 0xC3, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0x33, 0xC0, 0x39, 0x81, 0x38 },
                        "x x x x x x x x x x x",
                        new IntPtr(0x100000),
                        new IntPtr(0x1F0000)
                    )
                },
                
                // These next 3 AOBs were originally used for the XYZ teleporting, in MC they were not in the exe
                // In Delta however all 3 are in the exe, should investigate if these 3 will be helpful at all.
                {
                    "GuardPatroling", // 00 00 00 90 01 52 03
                    (new byte[] { 0x00, 0x00, 0x00, 0x90, 0x01, 0x52, 0x03 },
                        "x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "SnakeAndBossesStanding", // 00 00 00 90 01 20 03
                    (new byte[] { 0x00, 0x00, 0x00, 0x90, 0x01, 0x20, 0x03 },
                        "x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "SnakeAndGuardProne", // 00 00 00 96 00 2C 01
                    (new byte[] { 0x00, 0x00, 0x00, 0x96, 0x00, 0x2C, 0x01 },
                        "x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                // Originally in MGS3 MC was used to find the main pointer region that had everything from:
                // health - stamina, game stats, serious injuries, etc. Unsure if Delta will do the same or not yet.
                {
                    "PointerBytes", // 30 75 ?? ?? ?? ?? 00 00 2C 01 00 00 ??
                    (new byte[] { 0x30, 0x75, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2C, 0x01, 0x00, 0x00, 0x00 },
                        "xx????xxxxxx?",
                        new IntPtr(0x1DFFFFF),
                        new IntPtr(0x1F00000)
                    )
                },

                #endregion

                #region Boss AOBs (Needs Testing)
                // Will test these out further when I play Delta more and have a collection of saves at each area
                {
                    // Fear, Pain and Volgin are confirmed for this AOB Ocelot did not work
                    "TheFearAOB", // F0 49 02 00 F0 49 02 00
                    (new byte[] { 0xF0, 0x49, 0x02, 0x00, 0xF0, 0x49, 0x02, 0x00 },
                        "x x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "TheFury", // 01 00 01 00 D0 00 00 00 06 00
                    (new byte[] { 0x01, 0x00, 0x01, 0x00, 0xD0, 0x00, 0x00, 0x00, 0x06, 0x00 },
                        "x x x x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    // Starting Area for the boss fight with The End
                    "TheEnds063a", // 01 00 01 00 F0 74 00 00 80
                    (new byte[] { 0x01, 0x00, 0x01, 0x00, 0xF0, 0x74, 0x00, 0x00, 0x80 },
                        "x x x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    // Area where The End dies and you proceed to the ladder area also works for s064a
                    "TheEnds065a", // 01 00 01 00 00 01 00 00 80 80 80 80 80 80 80 80
                    (new byte[] { 0x01, 0x00, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80 },
                        "x x x x x x x x x x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "Ocelot", // E0 66 00 00 80 80 80 80 80 80 80 80 80
                    (new byte[] { 0xE0, 0x66, 0x00, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80 },
                        "x x x x x x x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "TheBoss", // D0 6E 00 00 80 80 80 80 80 80 80
                    (new byte[] { 0xD0, 0x6E, 0x00, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80 },
                        "x x x x x x x x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "Shagohod", // E6 99 48 00
                    (new byte[] { 0xE6, 0x99, 0x48, 0x00 },
                        "x x x x",
                        new IntPtr(0x100FFFFFFFF),
                        new IntPtr(0x30000000000)
                    )
                },

                {
                    "VolginOnShagohod", // 00 80 ED C4 00 00 80 3F 00 00 80 3F
                    (new byte[] { 0x00, 0x80, 0xED, 0xC4, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F },
                        "x x x x x x x x x x x x",
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

    }
}