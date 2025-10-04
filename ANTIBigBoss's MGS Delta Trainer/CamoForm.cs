using System;
using System.Windows.Forms;
using static ANTIBigBoss_s_MGS_Delta_Trainer.MGS3UsableObjects;

namespace ANTIBigBoss_s_MGS_Delta_Trainer
{
    public partial class CamoForm : Form
    {

        public CamoForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form3_FormClosing);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Location = MemoryManager.GetLastFormLocation();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddWoodland_Click(object sender, EventArgs e)
        {
            ToggleItemState(Woodland, true);
        }

        private void RemoveWoodland_Click(object sender, EventArgs e)
        {
            ToggleItemState(Woodland, false);
        }

        private void AddBlackPaint_Click(object sender, EventArgs e)
        {
            ToggleItemState(BlackFace, true);
        }

        private void RemoveBlackPaint_Click(object sender, EventArgs e)
        {
            ToggleItemState(BlackFace, false);
        }

        private void AddWater_Click(object sender, EventArgs e)
        {
            ToggleItemState(WaterFace, true);
        }

        private void RemoveWaterPaint_Click(object sender, EventArgs e)
        {
            ToggleItemState(WaterFace, false);
        }

        private void AddDesert_Click(object sender, EventArgs e)
        {
            ToggleItemState(Desert, true);
        }

        private void RemoveDesert_Click(object sender, EventArgs e)
        {
            ToggleItemState(Desert, false);
        }

        private void AddSplitterPaint_Click(object sender, EventArgs e)
        {
            ToggleItemState(SplitterFace, true);
        }

        private void RemoveSplitterPaint_Click(object sender, EventArgs e)
        {
            ToggleItemState(SplitterFace, false);
        }

        private void AddSnowPaint_Click(object sender, EventArgs e)
        {
            ToggleItemState(SnowFace, true);
        }

        private void RemoveSnowPaint_Click(object sender, EventArgs e)
        {
            ToggleItemState(SnowFace, false);
        }

        private void AddKabuki_Click(object sender, EventArgs e)
        {
            ToggleItemState(Kabuki, true);
        }

        private void RemoveKabuki_Click(object sender, EventArgs e)
        {
            ToggleItemState(Kabuki, false);
        }

        private void AddZombie_Click(object sender, EventArgs e)
        {
            ToggleItemState(Zombie, true);
        }

        private void RemoveZombie_Click(object sender, EventArgs e)
        {
            ToggleItemState(Zombie, false);
        }

        private void AddOyama_Click(object sender, EventArgs e)
        {
            ToggleItemState(Oyama, true);
        }

        private void RemoveOyama_Click(object sender, EventArgs e)
        {
            ToggleItemState(Oyama, false);
        }

        private void AddMask_Click(object sender, EventArgs e)
        {
            ToggleItemState(Mask, true);
        }

        private void RemoveMask_Click(object sender, EventArgs e)
        {
            ToggleItemState(Mask, false);
        }

        private void AddGreen_Click(object sender, EventArgs e)
        {
            ToggleItemState(Green, true);
        }

        private void RemoveGreen_Click(object sender, EventArgs e)
        {
            ToggleItemState(Green, false);
        }

        private void AddBrown_Click(object sender, EventArgs e)
        {
            ToggleItemState(Brown, true);
        }

        private void RemoveBrown_Click(object sender, EventArgs e)
        {
            ToggleItemState(Brown, false);
        }

        private void AddInfinity_Click(object sender, EventArgs e)
        {
            ToggleItemState(Infinity, true);
        }

        private void RemoveInfinity_Click(object sender, EventArgs e)
        {
            ToggleItemState(Infinity, false);
        }

        private void AddSovietUnion_Click(object sender, EventArgs e)
        {
            ToggleItemState(SovietUnion, true);
        }

        private void RemoveSovietUnion_Click(object sender, EventArgs e)
        {
            ToggleItemState(SovietUnion, false);
        }

        private void AddUK_Click(object sender, EventArgs e)
        {
            ToggleItemState(UK, true);
        }

        private void RemoveUK_Click(object sender, EventArgs e)
        {
            ToggleItemState(UK, false);
        }

        private void AddFrance_Click(object sender, EventArgs e)
        {
            ToggleItemState(France, true);
        }

        private void RemoveFrance_Click(object sender, EventArgs e)
        {
            ToggleItemState(France, false);
        }

        private void AddGermany_Click(object sender, EventArgs e)
        {
            ToggleItemState(Germany, true);
        }

        private void RemoveGermany_Click(object sender, EventArgs e)
        {
            ToggleItemState(Germany, false);
        }

        private void AddItaly_Click(object sender, EventArgs e)
        {
            ToggleItemState(Italy, true);
        }

        private void RemoveItaly_Click(object sender, EventArgs e)
        {
            ToggleItemState(Italy, false);
        }

        private void AddSpain_Click(object sender, EventArgs e)
        {
            ToggleItemState(Spain, true);
        }

        private void RemoveSpain_Click(object sender, EventArgs e)
        {
            ToggleItemState(Spain, false);
        }

        private void AddSweden_Click(object sender, EventArgs e)
        {
            ToggleItemState(Sweden, true);
        }

        private void RemoveSweden_Click(object sender, EventArgs e)
        {
            ToggleItemState(Sweden, false);
        }

        private void AddJapan_Click(object sender, EventArgs e)
        {
            ToggleItemState(Japan, true);
        }

        private void RemoveJapan_Click(object sender, EventArgs e)
        {
            ToggleItemState(Japan, false);
        }

        private void AddUSA_Click(object sender, EventArgs e)
        {
            ToggleItemState(USA, true);
        }

        private void RemoveUSA_Click(object sender, EventArgs e)
        {
            ToggleItemState(USA, false);
        }

        private void AddOliveDrab_Click(object sender, EventArgs e)
        {
            ToggleItemState(OliveDrab, true);
        }

        private void RemoveOliveDrab_Click(object sender, EventArgs e)
        {
            ToggleItemState(OliveDrab, false);
        }

        private void AddTigerStripe_Click(object sender, EventArgs e)
        {
            ToggleItemState(TigerStripe, true);
        }

        private void RemoveTigerStripe_Click(object sender, EventArgs e)
        {
            ToggleItemState(TigerStripe, false);
        }

        private void AddLeaf_Click(object sender, EventArgs e)
        {
            ToggleItemState(Leaf, true);
        }

        private void RemoveLeaf_Click(object sender, EventArgs e)
        {
            ToggleItemState(Leaf, false);
        }

        private void AddTreeBark_Click(object sender, EventArgs e)
        {
            ToggleItemState(TreeBark, true);
        }

        private void RemoveTreeBark_Click(object sender, EventArgs e)
        {
            ToggleItemState(TreeBark, false);
        }

        private void AddChocoChip_Click(object sender, EventArgs e)
        {
            ToggleItemState(ChocoChip, true);
        }

        private void RemoveChocoChip_Click(object sender, EventArgs e)
        {
            ToggleItemState(ChocoChip, false);
        }

        private void AddSplitterBody_Click(object sender, EventArgs e)
        {
            ToggleItemState(SplitterBody, true);
        }

        private void RemoveSplitterBody_Click(object sender, EventArgs e)
        {
            ToggleItemState(SplitterBody, false);
        }

        private void AddRaindrop_Click(object sender, EventArgs e)
        {
            ToggleItemState(Raindrop, true);
        }

        private void RemoveRaindrop_Click(object sender, EventArgs e)
        {
            ToggleItemState(Raindrop, false);
        }

        private void AddSquare_Click(object sender, EventArgs e)
        {
            ToggleItemState(Squares, true);
        }

        private void RemoveSquares_Click(object sender, EventArgs e)
        {
            ToggleItemState(Squares, false);
        }

        private void AddWaterBody_Click(object sender, EventArgs e)
        {
            ToggleItemState(Water, true);
        }

        private void RemoveWaterBody_Click(object sender, EventArgs e)
        {
            ToggleItemState(Water, false);
        }

        private void AddBlackBody_Click(object sender, EventArgs e)
        {
            ToggleItemState(Black, true);
        }

        private void RemoveBlackBody_Click(object sender, EventArgs e)
        {
            ToggleItemState(Black, false);
        }

        private void AddSnowBody_Click(object sender, EventArgs e)
        {
            ToggleItemState(Snow, true);
        }

        private void RemoveSnowBody_Click(object sender, EventArgs e)
        {
            ToggleItemState(Snow, false);
        }

        private void AddSneakingSuit_Click(object sender, EventArgs e)
        {
            ToggleItemState(SneakingSuit, true);
        }

        private void RemoveSneakingSuit_Click(object sender, EventArgs e)
        {
            ToggleItemState(SneakingSuit, false);
        }

        private void AddScientist_Click(object sender, EventArgs e)
        {
            ToggleItemState(Scientist, true);
        }

        private void RemoveScientist_Click(object sender, EventArgs e)
        {
            ToggleItemState(Scientist, false);
        }

        private void AddOfficer_Click(object sender, EventArgs e)
        {
            ToggleItemState(Officer, true);
        }

        private void RemoveOfficer_Click(object sender, EventArgs e)
        {
            ToggleItemState(Officer, false);
        }

        private void AddMaintenance_Click(object sender, EventArgs e)
        {
            ToggleItemState(Maintenance, true);
        }

        private void RemoveMaintenance_Click(object sender, EventArgs e)
        {
            ToggleItemState(Maintenance, false);
        }

        private void AddTuxedo_Click(object sender, EventArgs e)
        {
            ToggleItemState(Tuxedo, true);
        }

        private void RemoveTuxedo_Click(object sender, EventArgs e)
        {
            ToggleItemState(Tuxedo, false);
        }

        private void AddHornetStripe_Click(object sender, EventArgs e)
        {
            ToggleItemState(HornetStripe, true);
        }

        private void RemoveHornetStripe_Click(object sender, EventArgs e)
        {
            ToggleItemState(HornetStripe, false);
        }

        private void AddMoss_Click(object sender, EventArgs e)
        {
            ToggleItemState(Moss, true);
        }

        private void RemoveMoss_Click(object sender, EventArgs e)
        {
            ToggleItemState(Moss, false);
        }

        private void Addfire_Click(object sender, EventArgs e)
        {
            ToggleItemState(Fire, true);
        }

        private void RemoveFire_Click(object sender, EventArgs e)
        {
            ToggleItemState(Fire, false);
        }

        private void AddSpirit_Click(object sender, EventArgs e)
        {
            ToggleItemState(Spirit, true);
        }

        private void RemoveSpirit_Click(object sender, EventArgs e)
        {
            ToggleItemState(Spirit, false);
        }

        private void AddColdWar_Click(object sender, EventArgs e)
        {
            ToggleItemState(ColdWar, true);
        }

        private void RemoveColdWar_Click(object sender, EventArgs e)
        {
            ToggleItemState(ColdWar, false);
        }

        private void AddSnake_Click(object sender, EventArgs e)
        {
            ToggleItemState(Snake, true);
        }

        private void RemoveSnake_Click(object sender, EventArgs e)
        {
            ToggleItemState(Snake, false);
        }

        private void AddGaKo_Click(object sender, EventArgs e)
        {
            ToggleItemState(GaKo, true);
        }

        private void RemoveGaKo_Click(object sender, EventArgs e)
        {
            ToggleItemState(GaKo, false);
        }

        private void AddDesertTiger_Click(object sender, EventArgs e)
        {
            ToggleItemState(DesertTiger, true);
        }

        private void RemoveDesertTiger_Click(object sender, EventArgs e)
        {
            ToggleItemState(DesertTiger, false);
        }

        private void AddDPM_Click(object sender, EventArgs e)
        {
            ToggleItemState(DPM, true);
        }

        private void RemoveDPM_Click(object sender, EventArgs e)
        {
            ToggleItemState(DPM, false);
        }

        private void AddFlecktarn_Click(object sender, EventArgs e)
        {
            ToggleItemState(Flecktarn, true);
        }

        private void RemoveFlecktarn_Click(object sender, EventArgs e)
        {
            ToggleItemState(Flecktarn, false);
        }

        private void AddAuscam_Click(object sender, EventArgs e)
        {
            ToggleItemState(Auscam, true);
        }

        private void RemoveAuscam_Click(object sender, EventArgs e)
        {
            ToggleItemState(Auscam, false);
        }

        private void AddAnimals_Click(object sender, EventArgs e)
        {
            ToggleItemState(Animals, true);
        }

        private void RemoveAnimals_Click(object sender, EventArgs e)
        {
            ToggleItemState(Animals, false);
        }

        private void AddFly_Click(object sender, EventArgs e)
        {
            ToggleItemState(Fly, true);
        }

        private void RemoveFly_Click(object sender, EventArgs e)
        {
            ToggleItemState(Fly, false);
        }

        private void AddSpider_Click(object sender, EventArgs e)
        {
            ToggleItemState(Spider, true);
        }

        private void RemoveSpider_Click(object sender, EventArgs e)
        {
            ToggleItemState(Spider, false);
        }

        private void AddBanana_Click(object sender, EventArgs e)
        {
            ToggleItemState(Banana, true);
        }

        private void RemoveBanana_Click(object sender, EventArgs e)
        {
            ToggleItemState(Banana, false);
        }

        private void SwapToWeaponsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("Navigating to Weapon Form from the Camo Form");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "WeaponForm");
            WeaponForm form1 = new WeaponForm();
            form1.Show();
            this.Hide();
        }

        private void SwapToItemsForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("Navigating to Item Form from the Camo Form");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "ItemForm");
            ItemForm form2 = new ItemForm();
            form2.Show();
            this.Hide();
        }

        private void StatsAndAlertForm_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Stats and Alert from the camo form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "StatsAndAlertForm");
            StatsAndAlertForm form5 = new();
            form5.Show();
            this.Hide();
        }

        private void MiscFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Misc page from the Items Form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "MiscForm");
            MiscForm form4 = new();
            form4.Show();
            this.Hide();
        }

        private void GameStatsFormSwap_Click(object sender, EventArgs e)
        {
            LoggingManager.Instance.Log("User is changing to the Game Stats page from the Camo Form.\n");
            MemoryManager.UpdateLastFormLocation(this.Location);
            MemoryManager.LogFormLocation(this, "GameStatsForm");
            GameStatsForm form7 = new();
            form7.Show();
            this.Hide();
        }
    }
}