using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TMMC.NPCs
{
    [AutoloadHead]
    public class TMMCTownNPC : ModNPC
    {
        public override string Texture
        {
            get { return "PylonNPC/NPCs/CustomTownNPC"; }
        }

        public override string[] AltTextures
        {
            get { return new[] { "PylonNPC/NPCs/CustomTownNPC_Alt_1" }; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Teleporter Man";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 26;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 5;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; // Town NPC AI Style
            npc.damage = 12;
            npc.defense = 17;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss1)
            {
                return true;
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Etai";
                case 1:
                    return "Alex";
                case 2:
                    return "Ben";
                default: // Default is the default if no other case is true. In this case if the random number is 3 or more
                    return "Riot Games";
            }
        }

        public override string GetChat()
        {
            int otherNPC = NPC.FindFirstNPC(NPCID.Angler);
            if (otherNPC >= 0 && Main.rand.NextBool(4))
            {
                return "Did you know that " + Main.npc[otherNPC].GivenName + " is the angler?";
            }
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "What the fuck did you just fucking say about me, you little bitch?";
                case 1:
                    return "I'll have you know I graduated top of my class in the Navy Seals, and I've been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills.";
                case 2:
                    return "I am trained in gorilla warfare and I'm the top sniper in the entire US armed forces.";
                default:
                    return "You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Click";

        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                // This is makes it a shop
                shop = true;
            }
            else
            {
                Main.npcChatText = "Why?";
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            Mod PreHMTeleportation = ModLoader.GetMod("PreHMTeleportation");
            if (PreHMTeleportation != null)
            {

                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("PreHMTeleportation").ItemType("Transporter"));
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("PreHMTeleportation").ItemType("TransporterKey"));
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

            }
            Mod AlchemistNPC = ModLoader.GetMod("AlchemistNPCLite");
            if (AlchemistNPC != null)
            {

                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPCLite").ItemType("OceanTeleporterPotion"));
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPCLite").ItemType("BeachTeleporterPotion"));
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPCLite").ItemType("DungeonTeleportationPotion"));
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPCLite").ItemType("UnderworldTeleportationPotion"));
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPCLite").ItemType("JungleTeleporterPotion"));
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("TempleTeleportationPotion"));
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

            }
            //Mod PreHMTeleportation = ModLoader.GetMod("PreHMTeleportation");
            //if (PreHMTeleportation != null)
            //{

            //    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("PreHMTeleportation").ItemType("Transporter"));
            //    shop.item[nextSlot].shopCustomPrice = 1;
            //    nextSlot++;

            //    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("PreHMTeleportation").ItemType("TransporterKey"));
            //    shop.item[nextSlot].shopCustomPrice = 1;
            //    nextSlot++;

            //}

        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("TMMCAccessory"));
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 25;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 25;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.DemonScythe;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 5f;
            randomOffset = 2f;
        }


        // This is for if you want custom spawn conditions
        // This example will check for the TMMCTile and TMMCWall

    }
}