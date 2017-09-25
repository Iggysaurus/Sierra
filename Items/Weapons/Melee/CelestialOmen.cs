using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Melee //where is located
{
    public class CelestialOmen : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Omen");
		}
        public override void SetDefaults()
        {    //Sword name
            item.damage = 73;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 50;              //Sword width
            item.height = 50;             //Sword height
            item.useTime = 18;          //how fast 
            item.useAnimation = 18;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 7.5f;      //Sword knockback
            item.value = 100;        
            item.rare = 6;
			item.scale = 1f;
			item.shoot = mod.ProjectileType("Beam");
			item.shootSpeed = 8f;
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed   
item.UseSound = SoundID.Item1; 			
        }
		
    }
}