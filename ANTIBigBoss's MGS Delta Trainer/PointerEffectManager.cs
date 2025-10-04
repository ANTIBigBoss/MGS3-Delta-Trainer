using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static ANTIBigBoss_s_MGS_Delta_Trainer.Constants;
using static ANTIBigBoss_s_MGS_Delta_Trainer.Constants.Offsets;
using static ANTIBigBoss_s_MGS_Delta_Trainer.MemoryManager;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    internal class PointerEffectManager
    {

        private static readonly Dictionary<int, string> DifficultyMappings = new()
        {
        { 10, "Very Easy" },
        { 20, "Easy" },
        { 30, "Normal" },
        { 40, "Hard" },
        { 50, "Extreme" },
        { 60, "European Extreme" }
        };

        private static readonly Dictionary<int, string> SpecialItemCombos = new()
        {
        { 0, "NOT USED" },
        { 1, "STEALTH CAMO USED" },
        { 2, "INFINITY FACEPAINT USED" },
        { 3, "STEALTH CAMO + INFINITY FACEPAINT USED" },
        { 4, "EZ GUN USED" },
        { 5, "STEALTH CAMO + EZ GUN USED" },
        { 6, "INFINITY FACEPAINT + EZ GUN USED" },
        { 7, "STEALTH CAMO + INFINITY FACEPAINT + EZ GUN USED" }
        };

        #region Read Methods (Pointer-based)

        public string ReadDifficulty()
        {
            byte difficultyValue = GetStatByte(GameStats.Difficulty);
            if (DifficultyMappings.TryGetValue(difficultyValue, out string description))
            {
                return description;
            }
            return "Unknown Difficulty";
        }

        public string ReadPlayTime()
        {
            uint totalFrames = GetStatUInt(GameStats.GameTime);
            if (totalFrames > 0)
            {
                uint totalSeconds = totalFrames / 60;
                TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
                int hours = (int)timeSpan.TotalHours;
                string formattedTime = $"{hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
                LoggingManager.Instance.Log($"Formatted PlayTime: {formattedTime}");
                return formattedTime;
            }
            return "00:00:00";
        }

        public string ReadContinues()
        {
            ushort continues = GetStatUShort(GameStats.Continues);
            return continues.ToString();
        }

        public string ReadSaves()
        {
            ushort saves = GetStatUShort(GameStats.Saves);
            return saves.ToString();
        }

        public string ReadAlertsTriggered()
        {
            ushort alerts = GetStatUShort(GameStats.AlertsTriggered);
            return alerts.ToString();
        }

        public string ReadHumansKilled()
        {
            ushort kills = GetStatUShort(GameStats.Kills);
            return kills.ToString();
        }

        public string ReadTimesSeriouslyInjured()
        {
            ushort injuries = GetStatUShort(GameStats.SeriousInjury);
            return injuries.ToString();
        }

        public string ReadTotalDamageTaken()
        {
            ushort damage = GetStatUShort(GameStats.TotalDamage);
            return damage.ToString();
        }

        public string ReadLifeMedsUsed()
        {
            ushort lifeMeds = GetStatUShort(GameStats.LifeMeds);
            return lifeMeds.ToString();
        }

        public string ReadPlantsAndAnimalsCaptured()
        {
            byte plants = GetStatByte(GameStats.PlantsAndAnimalsCaptured);
            return plants.ToString();
        }

        public string ReadMealsEaten()
        {
            ushort meals = GetStatUShort(GameStats.MealsEaten);
            return meals.ToString();
        }

        public string ReadSpecialItemsUsed()
        {
            byte specialItems = GetStatByte(GameStats.SpecialItems);
            if (SpecialItemCombos.TryGetValue(specialItems, out string description))
            {
                return description;
            }
            return "Unable to determine usage";
        }

        #endregion

        #region Write Methods (Pointer-based)

        public bool WriteDifficulty(byte value) => WriteStat(GameStats.Difficulty, value);
        public bool WritePlayTime(uint value) => WriteStat(GameStats.GameTime, value);
        public bool WriteContinues(ushort value) => WriteStat(GameStats.Continues, value);
        public bool WriteSaves(ushort value) => WriteStat(GameStats.Saves, value);
        public bool WriteAlertsTriggered(ushort value) => WriteStat(GameStats.AlertsTriggered, value);
        public bool WriteHumansKilled(ushort value) => WriteStat(GameStats.Kills, value);
        public bool WriteTimesSeriouslyInjured(ushort value) => WriteStat(GameStats.SeriousInjury, value);
        public bool WriteTotalDamageTaken(ushort value) => WriteStat(GameStats.TotalDamage, value);
        public bool WriteLifeMedsUsed(ushort value) => WriteStat(GameStats.LifeMeds, value);
        public bool WritePlantsAndAnimalsCaptured(byte value) => WriteStat(GameStats.PlantsAndAnimalsCaptured, value);
        public bool WriteMealsEaten(ushort value) => WriteStat(GameStats.MealsEaten, value);
        public bool WriteSpecialItemsUsed(byte value) => WriteStat(GameStats.SpecialItems, value);

        #endregion

        #region Helper Methods for Pointer Access

        private byte GetStatByte(int offset)
        {
            byte[] bytes = HelperMethods.Instance.ReadPointerBytes(Constants.MainPointerRegionOffset, offset, 1);
            return bytes != null && bytes.Length == 1 ? bytes[0] : (byte)0;
        }

        private ushort GetStatUShort(int offset)
        {
            byte[] bytes = HelperMethods.Instance.ReadPointerBytes(Constants.MainPointerRegionOffset, offset, 2);
            return bytes != null && bytes.Length == 2 ? BitConverter.ToUInt16(bytes, 0) : (ushort)0;
        }

        private uint GetStatUInt(int offset)
        {
            byte[] bytes = HelperMethods.Instance.ReadPointerBytes(Constants.MainPointerRegionOffset, offset, 4);
            return bytes != null && bytes.Length == 4 ? BitConverter.ToUInt32(bytes, 0) : 0;
        }

        private bool WriteStat<T>(int offset, T value) where T : struct
        {
            return HelperMethods.Instance.WriteToPointer(Constants.MainPointerRegionOffset, offset, value);
        }

        #endregion

        #region Static Methods for Difficulty (for form compatibility)

        public static byte GetDifficultyValue()
        {
            byte[] difficultyBytes = HelperMethods.Instance.ReadPointerBytes(
                Constants.MainPointerRegionOffset, GameStats.Difficulty, 1);
            return difficultyBytes != null && difficultyBytes.Length == 1 ? difficultyBytes[0] : (byte)30;
        }

        public static bool SetDifficultyValue(byte difficultyValue)
        {
            return HelperMethods.Instance.WriteToPointer(
                Constants.MainPointerRegionOffset, GameStats.Difficulty, difficultyValue);
        }

        #endregion


        public string ProjectedRank(string difficulty)
        {
            int alerts = SafeParse(ReadAlertsTriggered());
            int kills = SafeParse(ReadHumansKilled());
            int lifeMedsUsed = SafeParse(ReadLifeMedsUsed());
            int continues = SafeParse(ReadContinues());
            int saves = SafeParse(ReadSaves());
            int mealsEaten = SafeParse(ReadMealsEaten());
            int plantsCaptured = SafeParse(ReadPlantsAndAnimalsCaptured());
            int injuries = SafeParse(ReadTimesSeriouslyInjured());
            int damageBars = SafeParse(ReadTotalDamageTaken());
            string specialItemsUsed = ReadSpecialItemsUsed();
            string formattedPlayTime = ReadPlayTime();
            TimeSpan playTime = SafeParseTime(formattedPlayTime);
            //LoggingManager.Instance.Log($"Play Time for Rank Projection: {playTime}");

            var rankConditions = new List<RankCondition>
    {
    // Top Performance Ranks
    new RankCondition("FoxHound", "Extreme/European Extreme", maxPlayTimeMinutes: 5 * 60, maxSaves: 25, maxContinues: 0, specialItems: "NOT USED", maxLifeMeds: 0, maxKills: 0, maxAlerts: 0, maxDamageBars: 5, maxInjuries: 20),
    new RankCondition("Fox", "Hard/Extreme/European Extreme", maxPlayTimeMinutes: 5 * 60, maxSaves: 35, maxContinues: 0, specialItems: "NOT USED", maxLifeMeds: 0, maxKills: 0, maxAlerts: 3, maxDamageBars: 5, maxInjuries: 20),
    new RankCondition("Doberman", "Normal/Hard/Extreme/European Extreme", maxPlayTimeMinutes: 5 * 60 + 30, maxSaves: 50, maxContinues: 0, specialItems: "NOT USED", maxLifeMeds: 0, maxKills: 0, maxAlerts: 5, maxDamageBars: 5),


    new RankCondition("Hound", "Easy/Normal/Hard/Extreme/European Extreme", maxPlayTimeMinutes: 6 * 60, maxSaves: 25, maxContinues: 0, specialItems: "NOT USED", maxLifeMeds: 0, maxKills: 0, maxAlerts: 10),

    // Extreme Playtime Ranks
    new RankCondition("Chicken", "Very Easy/Easy", minPlayTimeMinutes: 50 * 60, minSaves: 100, minContinues: 60,
                      specialItems: "Allowed", minLifeMeds: 10, minKills: 250, minAlerts: 250, minDamageBars: 30),
    new RankCondition("Mouse", "Normal", minPlayTimeMinutes: 50 * 60, minSaves: 100, minContinues: 60,
                      specialItems: "Allowed", minLifeMeds: 10, minKills: 250, minAlerts: 250, minDamageBars: 30),
    new RankCondition("Rabbit", "Hard", minPlayTimeMinutes: 50 * 60, minSaves: 100, minContinues: 60,
                      specialItems: "Allowed", minLifeMeds: 10, minKills: 250, minAlerts: 250, minDamageBars: 30),
    new RankCondition("Ostrich", "Extreme/European Extreme", minPlayTimeMinutes: 50 * 60, minSaves: 100, minContinues: 60,
                      specialItems: "Allowed", minLifeMeds: 10, minKills: 250, minAlerts: 250, minDamageBars: 30),

    // Special Titles
    new RankCondition("Chameleon", "Any", maxAlerts: 0),
    new RankCondition("Markhor", "Any", minPlantsCaptured: 48),
    new RankCondition("Pigeon", "Any", maxKills: 0),

    // Injury-Based Ranks all other below this might need minInjuries at 21 since these ranks go sequentially
    new RankCondition("Flying Squirrel", "Very Easy/Easy", maxInjuries: 20),
    new RankCondition("Bat", "Normal", maxInjuries: 20),
    new RankCondition("Flying Fox", "Hard", maxInjuries: 20),
    new RankCondition("Night Owl", "Extreme/European Extreme", maxInjuries: 20),

    // Playtime-Based Ranks
    new RankCondition("Swallow", "Very Easy/Easy", maxPlayTimeMinutes: 5 * 60),
    new RankCondition("Falcon", "Normal", maxPlayTimeMinutes: 5 * 60),
    new RankCondition("Hawk", "Hard", maxPlayTimeMinutes: 5 * 60),
    new RankCondition("Eagle", "Extreme/European Extreme", maxPlayTimeMinutes: 5 * 60),

    // Meals-Based Ranks
    new RankCondition("Pig", "Very Easy/Easy", minMeals: 250),
    new RankCondition("Elephant", "Normal", minMeals: 250),
    new RankCondition("Mammoth", "Hard", minMeals: 250),
    new RankCondition("Whale", "Extreme/European Extreme", minMeals: 250),

    // Alerts Triggered
    new RankCondition("Cow", "Any", minAlerts: 300),

    // Kills-Based Ranks
    new RankCondition("Piranha", "Very Easy/Easy", minKills: 250),
    new RankCondition("Shark", "Normal", minKills: 250),
    new RankCondition("Jaws", "Hard", minKills: 250),
    new RankCondition("Orca", "Extreme/European Extreme", minKills: 250),

    // High Injury-Based Ranks
    new RankCondition("Mongoose", "Very Easy/Easy", minInjuries: 250),
    new RankCondition("Hyena", "Normal", minInjuries: 250),
    new RankCondition("Tasmanian Devil", "Extreme/European Extreme", minInjuries: 250),
    
    // 50+ hours
    new RankCondition("Koala", "Very Easy/Easy", minPlayTimeMinutes: 50 * 60),
    new RankCondition("Capybara", "Normal", minPlayTimeMinutes: 50 * 60),
    new RankCondition("Sloth", "Hard", minPlayTimeMinutes: 50 * 60),
    new RankCondition("Giant Panda", "Extreme/European Extreme", minPlayTimeMinutes: 50 * 60),

    // Saves-Based Ranks
    new RankCondition("Cat", "Very Easy/Easy", minSaves: 100),
    new RankCondition("Deer", "Normal", minSaves: 100),
    new RankCondition("Zebra", "Hard", minSaves: 100),
    new RankCondition("Hippopotamus", "Extreme/European Extreme", minSaves: 100),

    // Continues and Kills
    new RankCondition("Scorpion", "Any", maxContinues: 50, maxKills: 100, maxAlerts: 20),
    new RankCondition("Jaguar", "Any", maxContinues: 50, maxKills: 100, minAlerts: 21, maxAlerts: 50),
    new RankCondition("Iguana", "Any", maxContinues: 50, maxKills: 100, minAlerts: 51),

    new RankCondition("Tarantula", "Any", maxContinues: 50, minKills: 101, maxAlerts: 20),
    new RankCondition("Panther", "Any", maxContinues: 50, minKills: 101, minAlerts: 21, maxAlerts: 50),
    new RankCondition("Crocodile", "Any", maxContinues: 50, minKills: 101, minAlerts: 51),

    new RankCondition("Centipede", "Any", minContinues: 51, maxKills: 100, maxAlerts: 20),
    new RankCondition("Leopard", "Any", minContinues: 51, maxKills: 100, minAlerts: 21, maxAlerts: 50),
    new RankCondition("Komodo Dragon", "Any", minContinues: 50, minKills: 1, maxKills: 100, minAlerts: 81, maxAlerts: 248, minInjuries: 21),

    new RankCondition("Spider", "Any", minContinues: 51, minKills: 101, maxAlerts: 19),
    new RankCondition("Puma", "Any", minContinues: 51, minKills: 101, maxKills: 299, minAlerts: 22, maxAlerts: 50),
    new RankCondition("Alligator", "Any", minContinues: 51, minKills: 101, minAlerts: 51)
};

            foreach (var rank in rankConditions)
            {

                if (rank.Matches(difficulty, alerts, kills, lifeMedsUsed, continues, saves, mealsEaten, injuries, damageBars, plantsCaptured, playTime, specialItemsUsed))
                {
                    return rank.Name;
                }
            }

            return "Unknown Rank";
        }

        public class RankCondition
        {
            public string Name { get; }
            public string Difficulty { get; }
            public int? MaxPlayTimeMinutes { get; }
            public int? MinPlayTimeMinutes { get; }
            public int? MaxSaves { get; }
            public int? MinSaves { get; }
            public int? MaxContinues { get; }
            public int? MinContinues { get; }
            public string SpecialItems { get; }
            public int? MaxKills { get; }
            public int? MinKills { get; }
            public int? MaxAlerts { get; }
            public int? MinAlerts { get; }
            public int? MaxLifeMeds { get; }
            public int? MinLifeMeds { get; }
            public int? MaxDamageBars { get; }
            public int? MinDamageBars { get; }
            public int? MaxInjuries { get; }
            public int? MinInjuries { get; }
            public int? MinPlantsCaptured { get; }
            public int? MinMeals { get; }

            public RankCondition(string name, string difficulty = null,
                int? maxPlayTimeMinutes = null, int? minPlayTimeMinutes = null,
                int? maxSaves = null, int? minSaves = null,
                int? maxContinues = null, int? minContinues = null,
                string specialItems = null,
                int? maxKills = null, int? minKills = null,
                int? maxAlerts = null, int? minAlerts = null,
                int? maxLifeMeds = null, int? minLifeMeds = null,
                int? maxDamageBars = null, int? minDamageBars = null,
                int? maxInjuries = null, int? minInjuries = null,
                int? minPlantsCaptured = null, int? minMeals = null)
            {
                Name = name;
                Difficulty = difficulty;
                MaxPlayTimeMinutes = maxPlayTimeMinutes;
                MinPlayTimeMinutes = minPlayTimeMinutes;
                MaxSaves = maxSaves;
                MinSaves = minSaves;
                MaxContinues = maxContinues;
                MinContinues = minContinues;
                SpecialItems = specialItems;
                MaxKills = maxKills;
                MinKills = minKills;
                MaxAlerts = maxAlerts;
                MinAlerts = minAlerts;
                MaxLifeMeds = maxLifeMeds;
                MinLifeMeds = minLifeMeds;
                MaxDamageBars = maxDamageBars;
                MinDamageBars = minDamageBars;
                MaxInjuries = maxInjuries;
                MinInjuries = minInjuries;
                MinPlantsCaptured = minPlantsCaptured;
                MinMeals = minMeals;
            }

            public bool Matches(string difficulty, int alerts, int kills, int lifeMeds, int continues, int saves,
                    int meals, int injuries, int damageBars, int plantsCaptured, TimeSpan playTime, string specialItems)
            {
                if (Difficulty != null && Difficulty != "Any")
                {
                    var possibleDifficulties = Difficulty.Split('/');
                    var normalizedDifficulty = NormalizeDifficulty(difficulty);

                    if (!possibleDifficulties.Contains(normalizedDifficulty)) return false;
                }

                if (MaxPlayTimeMinutes.HasValue && playTime.TotalMinutes > MaxPlayTimeMinutes.Value) return false;
                if (MinPlayTimeMinutes.HasValue && playTime.TotalMinutes <= MinPlayTimeMinutes.Value) return false;

                if (MaxSaves.HasValue && saves > MaxSaves.Value) return false;
                if (MinSaves.HasValue && saves <= MinSaves.Value) return false;
                if (MaxContinues.HasValue && continues > MaxContinues.Value) return false;
                if (MinContinues.HasValue && continues <= MinContinues.Value) return false;

                if (MaxKills.HasValue && kills > MaxKills.Value) return false;
                if (MinKills.HasValue && kills < MinKills.Value) return false;

                if (MaxAlerts.HasValue && alerts > MaxAlerts.Value) return false;
                if (MinAlerts.HasValue && alerts < MinAlerts.Value) return false;

                if (MaxLifeMeds.HasValue && lifeMeds > MaxLifeMeds.Value) return false;
                if (MinLifeMeds.HasValue && lifeMeds < MinLifeMeds.Value) return false;

                if (MaxDamageBars.HasValue && damageBars > MaxDamageBars.Value) return false;
                if (MinDamageBars.HasValue && damageBars < MinDamageBars.Value) return false;

                if (MaxInjuries.HasValue && injuries > MaxInjuries.Value) return false;
                if (MinInjuries.HasValue && injuries < MinInjuries.Value) return false;

                if (MinPlantsCaptured.HasValue && plantsCaptured < MinPlantsCaptured.Value) return false;
                if (MinMeals.HasValue && meals < MinMeals.Value) return false;

                if (SpecialItems != null)
                {
                    if (SpecialItems == "Allowed")
                    {
                    }
                    else if (SpecialItems == "NOT USED")
                    {
                        if (specialItems != "NOT USED") return false;
                    }
                    else
                    {
                        if (specialItems != SpecialItems) return false;
                    }
                }

                return true;
            }

            private string NormalizeDifficulty(string difficulty)
            {
                return difficulty switch
                {
                    "European Extreme" => "European Extreme",
                    "Extreme" => "Extreme",
                    "Hard" => "Hard",
                    "Normal" => "Normal",
                    "Easy" => "Easy",
                    "Very Easy" => "Very Easy",
                    _ => difficulty
                };
            }
        }

        private int SafeParse(string value)
        {
            return int.TryParse(value, out int result) ? result : 0;
        }

        private TimeSpan SafeParseTime(string value)
        {
            //LoggingManager.Instance.Log($"Parsing PlayTime value: '{value}'");
            var parts = value.Split(':');
            if (parts.Length == 3
                && int.TryParse(parts[0], out int hours)
                && int.TryParse(parts[1], out int minutes)
                && int.TryParse(parts[2], out int seconds))
            {
                return new TimeSpan(hours, minutes, seconds);
            }
            LoggingManager.Instance.Log("Manual TimeSpan parse failed, returning zero.");
            return TimeSpan.Zero;
        }


        internal static void ApplyInjury(Constants.InjuryType injuryType)
        {
            try
            {
                Process process = GetMGS3Process();
                if (process == null)
                {
                    return;
                }

                nint processHandle = NativeMethods.OpenProcess(0x1F0FFF, false, process.Id);
                nint moduleBaseAddress = process.MainModule.BaseAddress;
                nint pointerToInjurySlot = moduleBaseAddress + Constants.MainPointerRegionOffset;

                byte[] buffer = new byte[nint.Size];
                if (!NativeMethods.ReadProcessMemory(processHandle, pointerToInjurySlot, buffer, (uint)buffer.Length, out _))
                {
                    NativeMethods.CloseHandle(processHandle);
                    return;
                }

                nint baseInjurySlotAddress = nint.Size == 8 ? (nint)BitConverter.ToInt64(buffer, 0) : BitConverter.ToInt32(buffer, 0);
                byte[] injuryBytes = Constants.InjuryData.GetInjuryBytes(injuryType);

                bool injuryApplied = false;
                for (int slot = 1; slot <= Constants.Offsets.InjurySlots.TotalSlots; slot++)
                {
                    nint injurySlotAddress = nint.Add(baseInjurySlotAddress, Constants.Offsets.InjurySlots.CalculateOffset(slot));

                    byte[] currentInjuryData = ReadMemoryBytes(processHandle, injurySlotAddress, Constants.Offsets.InjurySlots.SlotSize);
                    if (currentInjuryData == null || !currentInjuryData.SequenceEqual(new byte[Constants.Offsets.InjurySlots.SlotSize]))
                    {
                        continue;
                    }

                    if (NativeMethods.WriteProcessMemory(processHandle, injurySlotAddress, injuryBytes, (uint)injuryBytes.Length, out _))
                    {
                        injuryApplied = true;
                        break;
                    }
                }

                if (!injuryApplied)
                {
                }
                NativeMethods.CloseHandle(processHandle);
            }
            catch (Exception ex)
            {
            }
        }

        internal static void RemoveAllInjuries()
        {
            Process process = GetMGS3Process();
            if (process == null)
            {
                return;
            }

            nint processHandle = NativeMethods.OpenProcess(0x1F0FFF, false, process.Id);
            nint moduleBaseAddress = process.MainModule.BaseAddress;
            nint pointerToInjurySlot = moduleBaseAddress + Constants.MainPointerRegionOffset;

            byte[] buffer = new byte[nint.Size];
            if (!NativeMethods.ReadProcessMemory(processHandle, pointerToInjurySlot, buffer, (uint)buffer.Length, out _))
            {
                NativeMethods.CloseHandle(processHandle);
                return;
            }

            nint baseInjurySlotAddress = nint.Size == 8 ? (nint)BitConverter.ToInt64(buffer, 0) : BitConverter.ToInt32(buffer, 0);

            byte[] emptyInjuryData = new byte[Constants.Offsets.InjurySlots.SlotSize];


            bool allCleared = true;
            for (int slot = 1; slot <= 68; slot++)
            {
                nint injurySlotAddress = nint.Add(baseInjurySlotAddress, Constants.Offsets.InjurySlots.CalculateOffset(slot));

                bool writeSuccess = NativeMethods.WriteProcessMemory(processHandle, injurySlotAddress, emptyInjuryData, (uint)emptyInjuryData.Length, out _);
                if (!writeSuccess)
                {
                    allCleared = false;
                    break;
                }
            }

            NativeMethods.CloseHandle(processHandle);

            if (allCleared)
            {
            }
        }

        internal static void ModifyHealthOrStamina(Constants.HealthType healthType, int value, bool setExactValue = false)
        {
            try
            {
                int valueOffset = healthType switch
                {
                    Constants.HealthType.MaxHealth => Constants.Offsets.Health.Max,
                    Constants.HealthType.Stamina => Constants.Offsets.Stamina.Current,
                    _ => Constants.Offsets.Health.Current
                };

                byte[] currentBytes = HelperMethods.Instance.ReadPointerBytes(
                    Constants.MainPointerRegionOffset, valueOffset, sizeof(short));
                if (currentBytes == null) return;

                short currentValue = BitConverter.ToInt16(currentBytes, 0);

                short newValue = (short)(setExactValue
                    ? Math.Max(0, Math.Min(value, short.MaxValue))
                    : Math.Max(0, Math.Min(currentValue + value, short.MaxValue)));

                HelperMethods.Instance.WriteToPointer(
                    Constants.MainPointerRegionOffset, valueOffset, newValue);
            }
            catch
            {

            }
        }
    }
}