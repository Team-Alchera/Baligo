using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Graphics
{
    public class Tile
    {
        // Store all the tiles
        public static Tile[] Tiles = new Tile[256];
        public Texture2D Texture;
        public Rectangle Bounds;
        public bool IsSolid;
        public int ID;

        public Rectangle CollisionBox;

        // Constructor
        public Tile(Texture2D texture, int id, bool isSolid = false)
        {
            Texture = texture;
            Bounds = new Rectangle(0, 0, Texture.Width, Texture.Height);
            IsSolid = isSolid;
            Tiles[id] = this;
            ID = id;

            CollisionBox = new Rectangle(0, 0, 32, 32);
        }

        public Tile(Tile tile)
        {
            Texture = tile.Texture;
            Bounds = tile.Bounds;
            IsSolid = tile.IsSolid;
            ID = tile.ID;
            CollisionBox = tile.CollisionBox;
        }
        
        // Get Tile from id
        public static Tile GetTile(int id)
        {
            return Tiles[id];
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(Texture, new Vector2(x, y), Bounds, Color.White);

            // Set Cord
            CollisionBox.X = x;
            CollisionBox.Y = y;

            // If Debug Mode Active Collision
            if (BaligoEngine.IsDebugModeActive && IsSolid)
            {
                spriteBatch.Draw(Assets.RedRectangle1.Texture, new Vector2(x, y), CollisionBox, Color.White);
            }
        }

        public void DrawWithRotation(SpriteBatch spriteBatch, int x, int y, float rotation,bool isEnemy = false)
        {
            Vector2 origin = new Vector2(0, 0);
            spriteBatch.Draw(Texture, new Vector2(x, y), Bounds, isEnemy ? Color.Red : Color.White, rotation, origin,
                1.0f, SpriteEffects.None, 1);
        }
    }
}
