using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.IO;
using System.IO;
using System;

namespace CMusicPlanet
{
    

    public class CMusicPlanet : Mod
    {

        public override void Load()
        {
            Config.Load();
        }

        public bool unloadCalled = false;

        internal static ModConfiguration modConfiguration;

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.musicVolume != 0)
            {
                if (Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
                {
                    
                    if (Main.npc.Any(n => n.active && n.boss))
                    {
                        
                    }
                    else
                    {
                        //space
                        if (Main.LocalPlayer.position.Y / 16 <= Main.worldSurface * 0.35)
                        {
                            if (CMusicPlanet.modConfiguration.PlanetoidMusic)
                            {
                                if (((Main.screenTileCounts[TileID.Dirt] > 20) || (Main.screenTileCounts[TileID.Mud] > 20) || (Main.screenTileCounts[TileID.Stone] > 20)) && (Main.screenTileCounts[TileID.Cloud] < 2))
                                {
                                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Planetoids");
                                    priority = MusicPriority.Environment;
                                }
                            }
                        }
                        //Minibosses
                        Mod CalamityMod = ModLoader.GetMod("CalamityMod");
                        if (CalamityMod != null)
                        {
                            if (CMusicPlanet.modConfiguration.WyrmMusic)
                            {
                                if (NPC.AnyNPCs(CalamityMod.NPCType("EidolonWyrmHeadHuge")))
                                {
                                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/EidolonWyrm");
                                    priority = MusicPriority.BossHigh;
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}