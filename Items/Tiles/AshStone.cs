using Terraria.ModLoader;

namespace Sierra.Items.Tiles
{
	public class AshStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ash Stone");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;			
			item.rare = 4;
			item.createTile = mod.TileType("VolcanoStone");
			item.placeStyle = 0;
		}
	}
}