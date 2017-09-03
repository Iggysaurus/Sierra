using Terraria.ModLoader;

namespace Sierra
{
	class Sierra : Mod
	{
		public Sierra()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
