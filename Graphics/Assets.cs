using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Console;
using Baligo.Main;
using Microsoft.Xna.Framework;
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
        public static Tile BlueDot;
        public static Tile RedDot;
        public static Tile GreenDot;
        // enemy
        public static Tile Enemy;
        // Console
        public static Tile ConsoleTile;
        // Potion
        public static Tile Cyan;

        public static void LoadAssets(ContentManager content)
        {
            // When you create a tile give:
            // 1. Texture with content.Load - Texture2D
            // 2. ID - Integer
            // 3. IsSolid - Boolean (optional)

            PlayerHunter = new Tile(content.Load<Texture2D>("Textures/Player/Player"), 0);
            PlayerMage = new Tile(content.Load<Texture2D>("Textures/Player/Player"), 1);
            PlayerWarrior = new Tile(content.Load<Texture2D>("Textures/Player/Player"), 2);
            CursorNormal = new Tile(content.Load<Texture2D>("Textures/Cursor/pointer"), 3);
            CursorActive = new Tile(content.Load<Texture2D>("Textures/Cursor/pointer_active"), 4);
            PlayerHunterArrow = new Tile(content.Load<Texture2D>("Textures/Player/arrow"), 5);
            GrassTypeOneBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/floor/grass/grass_full"), 6);
            GrassTypeTwoBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/floor/grass/grass_s"), 7);
            WallBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/wall/stone_brick1"), 8, true);
            TreeBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/wall/tree1_red"), 9);
            LavaBackground = new Tile(content.Load<Texture2D>("Textures/Tiles/floor/lava3"), 10);
            ClosedDoor = new Tile(content.Load<Texture2D>("Textures/Tiles/dngn_closed_door"), 11);
            Fountain = new Tile(content.Load<Texture2D>("Textures/Tiles/dngn_blue_fountain"), 12);

            // Custom
            RedRectangle1 = new Tile(content.Load<Texture2D>("Textures/Tiles/travel_exclusion"), 13);
            RedRectangle2 = new Tile(content.Load<Texture2D>("Textures/Tiles/travel_exclusion_centre"), 14);
            BlueDot = new Tile(content.Load<Texture2D>("Textures/blue_dot"),18);
            RedDot = new Tile(content.Load<Texture2D>("Textures/red_dot"),19);
            GreenDot = new Tile(content.Load<Texture2D>("Textures/green_dot"),20);
            // Enemy
            Enemy = new Tile(content.Load<Texture2D>("Textures/Enemies/Enemy"), 15);
            // Console
            ConsoleTile = new Tile(content.Load<Texture2D>("Textures/Console"), 16);
            Cyan = new Tile(content.Load<Texture2D>("Textures/Items/potion/cyan"), 17);

            // Info
            BaligoConsole.WriteLine("All assets loaded !",Color.Magenta);
            BaligoConsole.WriteLine("=======",Color.Yellow);
        }
    }
}
