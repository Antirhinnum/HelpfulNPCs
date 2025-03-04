﻿using HelpfulNPCs.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace HelpfulNPCs
{
    [AutoloadHead]
    public class FishermanNPC : ModNPC
    {
        public static bool fish = false;

        public override string Texture
        {
            get
            {
                return "HelpfulNPCs/FishermanNPC";
            }
        }


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fisherman");
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 150;
            NPCID.Sets.AttackType[NPC.type] = 3;
            NPCID.Sets.AttackTime[NPC.type] = 23;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction                  
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Like)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Golfer, AffectionLevel.Like)
                .SetNPCAffection(NPCID.DD2Bartender, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Mechanic, AffectionLevel.Dislike)
            ;

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("The Fisherman loves to fish all day. His connection to the Angler is unkown."),
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;

        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.npcsFoundForCheckActive[NPCID.Angler] && HelpfulNPCs.config.FishermanCanSpawn)
            {
                return true;
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
                { "Ernest",
                  "Thomas",
                  "Michael",
                  "Curt"
            };
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Give a man a fish, and you feed him for a day. Teach a man to fish, and you feed him for a lifetime.";
                case 1:
                    return "*Snore*";
                default:
                    return "How come sometimes I fish up junk? Who's been throwing things in the water?";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Fish";
            button2 = "Bait";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            fish = firstButton;
            shop = true;

        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (fish)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<FishCrate>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 10);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ArmoredCavefish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.AtlanticCod);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Bass);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ChaosFish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.CrimsonTigerfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Damselfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.DoubleCod);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Ebonkoi);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.FlarefinKoi);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Flounder);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.FrostMinnow);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GoldenCarp);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Hemopiranha);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Honeyfin);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.NeonTetra);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Obsidifish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.RedSnapper);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.RockLobster);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Salmon);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Shrimp);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.SpecularFish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Stinkfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Trout);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Tuna);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.VariegatedLardfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Oyster);
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 3);
                nextSlot++;

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PrincessFish);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.Prismite);
                    nextSlot++;
                }

                
            }

            else
            {
                shop.item[nextSlot].SetDefaults(ItemID.ApprenticeBait);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.JourneymanBait);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MasterBait);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ChumBucket);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BlackScorpion);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Buggy);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.HellButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.JuliaButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MonarchButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.PurpleEmperorButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.RedAdmiralButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.SulphurButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TreeNymphButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.UlyssesButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ZebraSwallowtailButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BlackDragonfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BlueDragonfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GreenDragonfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.OrangeDragonfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.RedDragonfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.YellowDragonfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Firefly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GlowingSnail);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Grasshopper);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Grubby);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BlueJellyfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GreenJellyfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.PinkJellyfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.LadyBug);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Lavafly);
                nextSlot++;

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LightningBug);
                    nextSlot++;
                }

                shop.item[nextSlot].SetDefaults(ItemID.Maggot);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Scorpion);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Sluggy);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Snail);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.WaterStrider);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Worm);
                nextSlot++;

                if (NPC.downedGolemBoss || NPC.downedFishron)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 25);
                    nextSlot++;
                }
            }
        }
            

        

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 15;
            knockback = 6f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 60;
            randExtraCooldown = 25;
        }

        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). Item is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
        {
            item = ModContent.Request<Texture2D>("Terraria/Images/Item_" + ItemID.Rockfish).Value; //this defines the item that this npc will use
            
            itemSize = 42;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        {
            itemWidth = 35;
            itemHeight = 35;
        }

        public override bool CanGoToStatue(bool toKingStatue) => true;
    }
}