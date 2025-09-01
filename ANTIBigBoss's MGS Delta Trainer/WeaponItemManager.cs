using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static ANTIBigBoss_s_MGS_Delta_Trainer.MemoryManager;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{

    #region Base classes
    public class GameObject
    {
        internal string _name = "";
        internal IntPtr _memoryOffset;
    }

    public interface IMGS3Object
    {
        private static string name = "";

        public static string Name { get { return name; } }
    }

    public static class WeaponAddresses
    {
        public const int WeaponOffset = 88; // The offset between weapons
        public const int CurrentAmmoOffset = 0;
        public const int MaxAmmoOffset = 2;
        public const int ClipOffset = 4;
        public const int MaxClipOffset = 6;
        public const int SuppressorToggleOffset = 16; // The offset for the suppressor toggle
                                                      // Suppressor capacity is actually considered an item and not a weapon
        public static IntPtr GetAddress(int index, MemoryManager memoryManager)
        {
            IntPtr aobResult = memoryManager.FindAob("WeaponsTable");
            if (aobResult != IntPtr.Zero)
            {
                return IntPtr.Add(aobResult, AobManager.AOBs["WeaponsTable"].Pattern.Length + 16 + (WeaponOffset * index));
            }
            else
            {
                MessageBox.Show("Weapons table AOB not found in memory.");
                return IntPtr.Zero;
            }
        }

        public static IntPtr GetMaxAmmoAddress(IntPtr baseAddress)
        {
            return baseAddress + MaxAmmoOffset;
        }

        public static IntPtr GetClipAddress(IntPtr baseAddress)
        {
            return baseAddress + ClipOffset;
        }

        public static IntPtr GetMaxClipAddress(IntPtr baseAddress)
        {
            return baseAddress + MaxClipOffset;
        }

        public static IntPtr GetSuppressorToggleAddress(IntPtr baseAddress)
        {
            return baseAddress + SuppressorToggleOffset;
        }
    }

    public static class ItemAddresses
    {
        public const int ItemOffset = 80; // The offset between items
        public const int CurrentCapacityOffset = 0; // The offset for the current capacity
        public const int MaxOffset = 2;   // The offset for the max value

        public static IntPtr GetAddress(int index, MemoryManager memoryManager)
        {
            IntPtr aobResult = memoryManager.FindAob("ItemsTable");
            if (aobResult != IntPtr.Zero)
            {
                // Calculate the specific item address
                return IntPtr.Add(aobResult, AobManager.AOBs["ItemsTable"].Pattern.Length + 12 + (ItemOffset * index));
            }
            else
            {
                MessageBox.Show("Items table AOB not found in memory.");
                return IntPtr.Zero;
            }
        }

        public static IntPtr GetMaxAddress(IntPtr baseAddress)
        {
            return baseAddress + MaxOffset;
        }
    }

    public class Item : WeaponItemManager
    {
        public IntPtr MaxCapacityOffset { get; private set; }
        public string AobKey { get; private set; } // A key to look up AOBs in Constants
        public int Index { get; private set; } // Add this line

        // Constructor for items without a max capacity
        public Item(string name, int index, string aobKey, bool hasMaxCapacity = false)
    : base(name, IntPtr.Zero) // Initially, we don't have the address
        {
            Index = index; // Set the index
            AobKey = aobKey;

            if (hasMaxCapacity)
            {
                MaxCapacityOffset = ItemAddresses.GetMaxAddress(this.MemoryOffset);
            }
        }
    }

    public abstract class WeaponItemManager : IMGS3Object
    {
        protected GameObject gameObject { get; set; }
        public string Name { get { return gameObject._name; } }
        public IntPtr MemoryOffset { get { return gameObject._memoryOffset; } }

        public WeaponItemManager(string name, IntPtr memoryOffset)
        {
            gameObject = new GameObject { _name = name, _memoryOffset = memoryOffset };
        }
    }

    public class Weapon : WeaponItemManager
    {
        public IntPtr MaxAmmoOffset { get; private set; } = IntPtr.Zero;
        public IntPtr ClipOffset { get; private set; } = IntPtr.Zero;
        public IntPtr MaxClipOffset { get; private set; } = IntPtr.Zero;
        public IntPtr SuppressorToggleOffset { get; private set; } = IntPtr.Zero;
        public string AobKey { get; private set; }
        public int Index { get; private set; }


        public Weapon(string name, int index, string aobKey, bool hasAmmo = false, bool hasClip = false,
            bool hasSuppressorToggle = false)
            : base(name, IntPtr.Zero)
        {
            Index = index;
            AobKey = aobKey;

            if (hasAmmo)
            {
                MaxAmmoOffset = WeaponAddresses.GetMaxAmmoAddress(this.MemoryOffset);
            }

            if (hasClip)
            {
                ClipOffset = WeaponAddresses.GetClipAddress(this.MemoryOffset);
                MaxClipOffset = WeaponAddresses.GetMaxClipAddress(this.MemoryOffset);
            }

            if (hasSuppressorToggle)
            {
                SuppressorToggleOffset = WeaponAddresses.GetSuppressorToggleAddress(this.MemoryOffset);
            }
        }
    }

    #endregion

    /// <summary>
    /// A class for all the items in MGS3 Delta
    /// </summary>
    public class MGS3UsableObjects
    {
        // Weapons in delta are 88 bytes apart as opposed to the 80 they are in the original
        #region Weapons
        private static MemoryManager memoryManager = new MemoryManager();


        public static readonly Weapon SurvivalKnife = new("Survival Knife", 0, "WeaponsTable", false, false, false);
        public static readonly Weapon Fork = new("Fork", 1, "WeaponsTable", false, false, false);
        public static readonly Weapon CigSpray = new("Cigspray", 2, "WeaponsTable", true, false, false); // Has ammo but no clip or suppressor
        public static readonly Weapon Handkerchief = new("Handkerchief", 3, "WeaponsTable", true, false, false);
        public static readonly Weapon MK22 = new("MK22", 4, "WeaponsTable", true, true, true);
        public static readonly Weapon M1911A1 = new("M1911A1", 5, "WeaponsTable", true, true, true);
        public static readonly Weapon EzGun = new("Ez Gun", 6, "WeaponsTable", false, false, false);
        public static readonly Weapon SAA = new("SAA", 7, "WeaponsTable", true, true, false); // Has ammo and clips but no suppressor
        public static readonly Weapon Patriot = new("Patriot", 8, "WeaponsTable", false, false, false);
        public static readonly Weapon Scorpion = new("Scorpion", 9, "WeaponsTable", true, true, false);
        public static readonly Weapon XM16E1 = new("XM16E1", 10, "WeaponsTable", true, true, true);
        public static readonly Weapon AK47 = new("AK47", 11, "WeaponsTable", true, true, false);
        public static readonly Weapon M63 = new("M63", 12, "WeaponsTable", true, true, false);
        public static readonly Weapon M37 = new("M37", 13, "WeaponsTable", true, true, false);
        public static readonly Weapon SVD = new("SVD", 14, "WeaponsTable", true, true, false);
        public static readonly Weapon Mosin = new("Mosin", 15, "WeaponsTable", true, true, false);
        public static readonly Weapon RPG7 = new("RPG7", 16, "WeaponsTable", true, true, false);
        public static readonly Weapon Torch = new("Torch", 17, "WeaponsTable", false, false, false);
        public static readonly Weapon Grenade = new("Grenade", 18, "WeaponsTable", true, false, false);
        public static readonly Weapon WpGrenade = new("Wp Grenade", 19, "WeaponsTable", true, false, false);
        public static readonly Weapon StunGrenade = new("Stun Grenade", 20, "WeaponsTable", true, false, false);
        public static readonly Weapon ChaffGrenade = new("Chaff Grenade", 21, "WeaponsTable", true, false, false);
        public static readonly Weapon SmokeGrenade = new("Smoke Grenade", 22, "WeaponsTable", true, false, false);
        public static readonly Weapon EmptyMag = new("Empty Magazine", 23, "WeaponsTable", true, false, false);
        public static readonly Weapon TNT = new("TNT", 24, "WeaponsTable", true, false, false);
        public static readonly Weapon C3 = new("C3", 25, "WeaponsTable", true, false, false);
        public static readonly Weapon Claymore = new("Claymore", 26, "WeaponsTable", true, false, false);
        public static readonly Weapon Book = new("Book", 27, "WeaponsTable", true, false, false);
        public static readonly Weapon Mousetrap = new("Mousetrap", 28, "WeaponsTable", true, false, false);
        public static readonly Weapon DirectionalMic = new("Directional Microphone", 29, "WeaponsTable", false, false, false);
        // When I learn more on how to force certain food items to be in the 19 slots after will implement logic here
        #endregion

        #region Items

        #region Backpack Items
        public static readonly Item LifeMed = new("LIFE MEDICINE", 0, "ItemsTable", true);
        public static readonly Item Pentazemin = new("PENTAZEMIN", 1, "ItemsTable", true);
        public static readonly Item FakeDeathPill = new("FAKE DEATH PILL", 2, "ItemsTable", true);
        // No Capacity, will just have a true 1 or false -1 to give/remove
        public static readonly Item RevivalPill = new("REVIVAL PILL", 3, "ItemsTable", false);
        public static readonly Item Cigar = new("CIGAR", 4, "ItemsTable", false);
        public static readonly Item Binoculars = new("BINOCULARS", 5, "ItemsTable", false);
        public static readonly Item ThermalGoggles = new("THERMAL GOGGLES", 6, "ItemsTable", false);
        public static readonly Item NightVisionGoggles = new("NIGHT VISION GOGGLES", 7, "ItemsTable", false);
        public static readonly Item Camera = new("CAMERA", 8, "ItemsTable", false);
        public static readonly Item MotionDetector = new("MOTION DETECTOR", 9, "ItemsTable", false);
        public static readonly Item ActiveSonar = new("ACTIVE SONAR", 10, "ItemsTable", false);
        public static readonly Item MineDetector = new("MINE DETECTOR", 11, "ItemsTable", false);
        public static readonly Item AntiPersonnelSensor = new("ANTI PERSONNEL SENSOR", 12, "ItemsTable", false);
        //Boxes have slightly different logic and should be set to 25 or -1 as they have a durability
        public static readonly Item CBoxA = new("CBOX A", 13, "ItemsTable", false);
        public static readonly Item CBoxB = new("CBOX B", 14, "ItemsTable", false);
        public static readonly Item CBoxC = new("CBOX C", 15, "ItemsTable", false);
        public static readonly Item CBoxD = new("CBOX D", 16, "ItemsTable", false);
        public static readonly Item CrocCap = new("CROC CAP", 17, "ItemsTable", false);
        public static readonly Item KeyA = new("KEY A", 18, "ItemsTable", false);
        public static readonly Item KeyB = new("KEY B", 19, "ItemsTable", false);
        public static readonly Item KeyC = new("KEY C", 20, "ItemsTable", false);
        public static readonly Item Bandana = new("BANDANA", 21, "ItemsTable", false);
        public static readonly Item StealthCamo = new("STEALTH CAMO", 22, "ItemsTable", false);
        public static readonly Item BugJuice = new("BUG JUICE", 23, "ItemsTable", true);
        public static readonly Item MonkeyMask = new("MONKEY MASK", 24, "ItemsTable", false);
        #endregion        

        #region New Delta Items       
        public static readonly Item AtCamo = new("AT CAMO", 25, "ItemsTable", false);
        public static readonly Item Compass = new("COMPASS", 26, "ItemsTable", false);
        public static readonly Item Itm2 = new("ITM2", 27, "ItemsTable", false);
        public static readonly Item GakoMask = new("GAKO MASK", 28, "ItemsTable", false);
        public static readonly Item KerotanMask = new ("KEROTAN MASK", 29, "ItemsTable", false);
        public static readonly Item BananaCapGold = new ("BANANA CAP (GOLD)", 30, "ItemsTable", false);
        public static readonly Item BombCapGold = new("BOMB CAP (GOLD)", 31, "ItemsTable", false);
        public static readonly Item BombCap = new("BOMB CAP", 32, "ItemsTable", false);
        public static readonly Item CrocCapOneEye = new("CROC CAP (ONE EYED)", 33, "ItemsTable", false);
        public static readonly Item Itm9 = new("ITM9", 34, "ItemsTable", false);
        #endregion

        #region Medicinal Items
        public static readonly Item Serum = new("SERUM", 35, "ItemsTable", true);
        public static readonly Item Antidote = new("ANTIDOTE", 36, "ItemsTable", true);
        public static readonly Item ColdMedicine = new("COLD MEDICINE", 37, "ItemsTable", true);
        public static readonly Item DigestiveMedicine = new("DIGESTIVE MEDICINE", 38, "ItemsTable", true);    
        public static readonly Item Ointment = new("OINTMENT", 39, "ItemsTable", true);
        public static readonly Item Splint = new("SPLINT", 40, "ItemsTable", true);
        public static readonly Item Disinfectant = new("DISINFECTANT", 41, "ItemsTable", true);
        public static readonly Item Styptic = new("STYPTIC", 42, "ItemsTable", true);
        public static readonly Item Bandage = new("BANDAGE", 43, "ItemsTable", true);
        public static readonly Item SutureKit = new("SUTURE KIT", 44, "ItemsTable", true);
        #endregion

        #region Other Items
        // Battery may have a max capacity and need to be changed to true unless address is max capacity
        // Was never able to find a static address for current battery in Cheat Engine
        public static readonly Item Knife = new("KNIFE", 45, "ItemsTable", false); // No use but listing for completeness of table
        public static readonly Item Battery = new("BATTERY", 46, "ItemsTable", false); // Need to look into exactly what this controls
        public static readonly Item M1911A1Surpressor = new("M1911A1 SURPRESSOR", 47, "ItemsTable", false);
        public static readonly Item MK22Surpressor = new("MK22 SURPRESSOR", 48, "ItemsTable", false);
        public static readonly Item XM16E1Surpressor = new("XM16E1 SURPRESSOR", 49, "ItemsTable", false);
        #endregion

        #endregion

        #region Camos

        #region Uniform

        public static readonly Item OliveDrab = new("Olive Drab", 50, "ItemsTable", false);
        public static readonly Item TigerStripe = new("Tiger Stripe", 51, "ItemsTable", false);
        public static readonly Item Leaf = new("Leaf", 52, "ItemsTable", false);
        public static readonly Item TreeBark = new("Tree Bark", 53, "ItemsTable", false);
        public static readonly Item ChocoChip = new("Choco Chip", 54, "ItemsTable", false);
        public static readonly Item Splitter = new("Splitter", 55, "ItemsTable", false);
        public static readonly Item Raindrop = new("Raindrop", 56, "ItemsTable", false);
        public static readonly Item Squares = new("Squares", 57, "ItemsTable", false);
        public static readonly Item Water = new("Water", 58, "ItemsTable", false);
        public static readonly Item Black = new("Black", 59, "ItemsTable", false);
        public static readonly Item Snow = new("Snow", 60, "ItemsTable", false);
        public static readonly Item Naked = new("Naked", 61, "ItemsTable", false);
        public static readonly Item SneakingSuit = new("Sneaking Suit", 62, "ItemsTable", false);
        public static readonly Item Scientist = new("Scientist", 63, "ItemsTable", false);
        public static readonly Item Officer = new("Officer", 64, "ItemsTable", false);
        public static readonly Item Maintenance = new("Maintenance", 65, "ItemsTable", false);
        public static readonly Item Tuxedo = new("Tuxedo", 66, "ItemsTable", false);
        public static readonly Item HornetStripe = new("Hornet Stripe", 67, "ItemsTable", false);
        public static readonly Item Spider = new("Spider", 68, "ItemsTable", false);
        public static readonly Item Moss = new("Moss", 69, "ItemsTable", false);
        public static readonly Item Fire = new("Fire", 70, "ItemsTable", false);
        public static readonly Item Spirit = new("Spirit", 71, "ItemsTable", false);
        public static readonly Item ColdWar = new("Cold War", 72, "ItemsTable", false);
        public static readonly Item Snake = new("Snake", 73, "ItemsTable", false);
        public static readonly Item GaKo = new("Ga-Ko", 74, "ItemsTable", false);
        public static readonly Item DesertTiger = new("DesertTiger", 75, "ItemsTable", false);
        public static readonly Item DPM = new("DPM", 76, "ItemsTable", false);
        public static readonly Item Flecktarn = new("Flecktarn", 77, "ItemsTable", false);
        public static readonly Item Auscam = new("Auscam", 78, "ItemsTable", false);
        public static readonly Item Animals = new("Animals", 79, "ItemsTable", false);
        public static readonly Item Fly = new("Fly", 80, "ItemsTable", false);
        public static readonly Item Banana = new("Banana Camo", 81, "ItemsTable", false);
        public static readonly Item GrenadeCamo = new("Grenade Camo", 82, "ItemsTable", false);
        public static readonly Item Mummy = new("Mummy", 83, "ItemsTable", false);
        public static readonly Item Santa = new("Santa", 84, "ItemsTable", false);
        public static readonly Item Valentine = new("Valentine", 85, "ItemsTable", false);
        public static readonly Item Egermany = new("Egermany", 86, "ItemsTable", false);
        public static readonly Item WGermany = new("WGermany", 87, "ItemsTable", false);
        public static readonly Item SovietWoodland = new("SovietWoodland", 88, "ItemsTable", false);
        public static readonly Item UrbanTiger = new("UrbanTiger", 89, "ItemsTable", false);
        public static readonly Item Klmk = new("Klmk", 90, "ItemsTable", false);
        public static readonly Item Rainbow = new("Rainbow", 91, "ItemsTable", false);
        public static readonly Item Chameleon = new("Chameleon", 92, "ItemsTable", false);
        public static readonly Item Barracuda = new("Barracuda", 93, "ItemsTable", false);
        public static readonly Item Festival = new("Festival", 94, "ItemsTable", false);
        public static readonly Item DoDoDo = new("DoDoDo", 95, "ItemsTable", false);
        public static readonly Item Rock = new("Rock", 96, "ItemsTable", false);
        public static readonly Item Watersnake = new("Watersnake", 97, "ItemsTable", false);
        public static readonly Item NightDesert = new("Night Desert", 98, "ItemsTable", false);
        public static readonly Item Swamp = new("Swamp", 99, "ItemsTable", false);
        public static readonly Item Anubis = new("Anubis", 100, "ItemsTable", false);
        public static readonly Item Bonsai = new("Bonsai", 101, "ItemsTable", false); // Crashes if Equipped
        public static readonly Item Usmx = new("Usmx", 102, "ItemsTable", false); // Crashes if Equipped
        public static readonly Item WhiteTuxedo = new("White Tuxedo", 103, "ItemsTable", false);

        #region DLC Items
        // DLC Items, these should not be added to the trainer. However they're needed to complete the table.
        // Since we jump 80 bytes between each to get to the next object.
        public static readonly Item PwBattleDress = new("PW Battle Dress", 104, "ItemsTable", false);
        public static readonly Item PwSneakingSuit = new("PW Sneaking Suit", 105, "ItemsTable", false);
        public static readonly Item NakedWoodland = new("Naked Woodland", 106, "ItemsTable", false);
        public static readonly Item NakedAmmoBelt = new("Naked Ammo Belt", 107, "ItemsTable", false);
        public static readonly Item GoldSnake = new("Gold Snake", 108, "ItemsTable", false);
        public static readonly Item CrocSuit = new("Croc Suit", 109, "ItemsTable", false);
        public static readonly Item ExtraOutfit1 = new("ExtraOutfit1", 110, "ItemsTable", false);
        public static readonly Item ExtraOutfit2 = new("ExtraOutfit2", 111, "ItemsTable", false);
        public static readonly Item ExtraOutfit3 = new("ExtraOutfit3", 112, "ItemsTable", false);
        public static readonly Item ExtraOutfit4 = new("ExtraOutfit4", 113, "ItemsTable", false);
        public static readonly Item Unknown1 = new("Unknown1", 114, "ItemsTable", false); // Padding possibly?
        public static readonly Item Unknown2 = new("Unknown2", 115, "ItemsTable", false); // Padding possibly?
        #endregion

        #region Face Paint

        public static readonly Item NoPaint = new("No Paint", 116, "ItemsTable", false);
        public static readonly Item Woodland = new("Woodland", 117, "ItemsTable", false);
        public static readonly Item BlackFace = new("Black", 118, "ItemsTable", false);
        public static readonly Item WaterFace = new("Water", 119, "ItemsTable", false);
        public static readonly Item Desert = new("Desert", 120, "ItemsTable", false);
        public static readonly Item SplitterFace = new("Splitter", 121, "ItemsTable", false);
        public static readonly Item SnowFace = new("Snow", 122, "ItemsTable", false);
        public static readonly Item Kabuki = new("Kabuki", 123, "ItemsTable", false);
        public static readonly Item Zombie = new("Zombie", 124, "ItemsTable", false);
        public static readonly Item Oyama = new("Oyama", 125, "ItemsTable", false);
        public static readonly Item Mask = new("Mask", 126, "ItemsTable", false);
        public static readonly Item Green = new("Green", 127, "ItemsTable", false);
        public static readonly Item Brown = new("Brown", 128, "ItemsTable", false);
        public static readonly Item Infinity = new("Infinity", 129, "ItemsTable", false);
        public static readonly Item SovietUnion = new("Soviet Union", 130, "ItemsTable", false);
        public static readonly Item UK = new("UK", 131, "ItemsTable", false);
        public static readonly Item France = new("France", 132, "ItemsTable", false);
        public static readonly Item Germany = new("Germany", 133, "ItemsTable", false);
        public static readonly Item Italy = new("Italy", 134, "ItemsTable", false);
        public static readonly Item Spain = new("Spain", 135, "ItemsTable", false);
        public static readonly Item Sweden = new("Sweden", 136, "ItemsTable", false);
        public static readonly Item Japan = new("Japan", 137, "ItemsTable", false);
        public static readonly Item USA = new("USA", 138, "ItemsTable", false);
        // There's a few DLC and placeholders past this point but we don't really need them since they're
        // All just appended to the end of the table anyway

        #endregion

        #endregion

        #endregion
       
    }
}