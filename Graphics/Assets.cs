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
        public static Tile PlayerHunter;
        public static Tile PlayerMage;
        public static Tile PlayerWarrior;
        public static Tile CursorNormal;
        public static Tile CursorActive;
        public static Tile PlayerHunterArrow;
        
        public static void LoadAssets(ContentManager content)
        {
            PlayerHunter = new Tile(content.Load<Texture2D>("Textures/Player/Player"));
            PlayerMage = new Tile(content.Load<Texture2D>("Textures/Player/Player"));
            PlayerWarrior = new Tile(content.Load<Texture2D>("Textures/Player/Player"));
            CursorNormal = new Tile(content.Load<Texture2D>("Textures/Cursor/pointer"));
            CursorActive = new Tile(content.Load<Texture2D>("Textures/Cursor/pointer_active"));
            PlayerHunterArrow = new Tile(content.Load<Texture2D>("Textures/Player/arrow"));
        }
    }
}
