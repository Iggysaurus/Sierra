using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Localization;
using ReLogic.Graphics;
using System;

namespace Sierra.Items.Weapons.Ranged
{
    public class AshBoomerang : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 38;
            item.melee = true;
            item.width = 24;
            item.height = 40;
            item.useTime = 15;
            item.shootSpeed = 12f;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.shoot = mod.ProjectileType("AshBoomerangProj");
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = 5;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ash Boomerang");
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}