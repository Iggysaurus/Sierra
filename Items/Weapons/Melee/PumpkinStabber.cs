using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Sierra.Items.Weapons.Melee
{
    public class PumpkinStabber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pumpkin Stabber");
        }
        public override void SetDefaults()
        {
            item.damage = 40;
            item.melee = true;
            item.width = 36;
            item.height = 40;
            item.useTime = 4;
            item.useAnimation = 4;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 20000;
            item.rare = 10;
            item.UseSound = SoundID.Item18;
			item.autoReuse = true;
        }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(player.position, player.width,player.height, 6);
			}
		}

	}
}