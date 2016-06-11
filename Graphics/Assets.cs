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
        public static Tile GrassTypeOneBackground;
        public static Tile GrassTypeTwoBackground;
        public static Tile WallBackground;
        public static Tile TreeBackground;
        public static Tile LavaBackground;
        public static Tile ClosedDoor;
        public static Tile Fountain;
        // Debug Mode
        public static Tile RedRectangle1;
        public static Tile RedRectangle2;

        public static void LoadAssets(ContentManager content)
        {
            PlayerHunter = new Tile(content.Load<Texture2D>("Textures/Player/Player"));
            PlayerMage = new Tile(content.Load<Texture2D>("Textures/Player/Player"));
            PlayerWarrior = new Tile(content.Load<Texture2D>("Textures/Player/Player"));
            CursorNormal = new Tile(content.Load<Texture2D>("Textures/Cursor/pointer"));
            CursorActive = new Tile(content.Load<Texture2D>("Textures/Cursor/pointer_active"));
            PlayerHunterArrow = new Tile(content.Load<Texture2D>("Textures/Player/arrow"));
            GrassTypeOneBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/floor/grass/grass_full"));
            GrassTypeTwoBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/floor/grass/grass_s"));
            WallBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/wall/stone_brick1"));
            TreeBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/wall/tree1_red"));
            LavaBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/floor/lava3"));
            ClosedDoor = new Tile(content.Load<Texture2D>("Textures/Tiles/dngn_closed_door"));
            Fountain = new Tile(content.Load<Texture2D>("Textures/Tiles/dngn_blue_fountain"));
            RedRectangle1 = new Tile(content.Load<Texture2D>("Textures/Tiles/travel_exclusion"));
            RedRectangle2 = new Tile(content.Load<Texture2D>("Textures/Tiles/travel_exclusion_centre"));
        }
    }
}
