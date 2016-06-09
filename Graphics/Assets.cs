using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Main;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Graphics
{
    public static class Assets
    {
        public static Tile Player;
        public static Tile CursorNormal;
        public static Tile CursorActive;

        public static void LoadAssets(ContentManager content)
        {
            Player = new Tile(content.Load<Texture2D>("Textures/Player/Player"));
            CursorNormal = new Tile(content.Load<Texture2D>("Textures/Cursor/pointer"));
            CursorActive = new Tile(content.Load<Texture2D>("Textures/Cursor/pointer_active"));
        }
    }
}
