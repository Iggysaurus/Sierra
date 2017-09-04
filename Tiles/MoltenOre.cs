using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Sierra.Tiles
{
    public class MoltenOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileSolid[Type] = true;
			Main.tileBlendAll[this.Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("MoltenChunk");   //put your CustomBlock name
			 ModTranslation name = CreateMapEntryName();
            name.SetDefault("Molten Ore");
            AddMapEntry(new Color(240, 27, 27), name);
			soundType = 21;
            minPick = 130;
            dustType = 258;
            
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            {
                r = 0.4f;
                g = 0.17f;
                b = 0.17f;
            }
        }
    }
}