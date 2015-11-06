using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Terraria.ModLoader.Default
{
	public class ModLoaderMod : Mod
	{
		private static bool texturesLoaded = false;
		private static readonly string ContentPath = "Content" + Path.DirectorySeparatorChar + "ModLoader";
		private static Texture2D mysteryItemTexture;

		public ModLoaderMod()
		{
			file = "ModLoader";
		}

		public override void SetModInfo(out string name, ref ModProperties properties)
		{
			name = "ModLoader";
		}

		public override void Load()
		{
			LoadTextures();
			AddTexture("MysteryItem", mysteryItemTexture);
			AddItem("MysteryItem", new MysteryItem(), FileName("MysteryItem"));
			AddPlayer("MysteryPlayer", new MysteryPlayer());
		}

		private static void LoadTextures()
		{
#if CLIENT
			if (texturesLoaded)
			{
				return;
			}
            byte[] data = File.ReadAllBytes(ContentPath + Path.DirectorySeparatorChar + "MysteryItem.png");
			using (MemoryStream stream = new MemoryStream(data))
			{
				mysteryItemTexture = Texture2D.FromStream(Main.instance.GraphicsDevice, stream);
			}
			texturesLoaded = true;
#endif
		}
	}
}
