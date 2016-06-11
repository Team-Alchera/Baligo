﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // Constructor
        public Tile(Texture2D texture,int id,bool isSolid = false)
        {
            this.Texture = texture;
            this.Bounds = new Rectangle(0, 0, Texture.Width, Texture.Height);
            this.IsSolid = isSolid;
            Tiles[id] = this;
        }

        // Get Tile from id
        public static Tile GetTile(int id)
        {
            return Tiles[id];
        }
        
        public void Update()
        {
            if (IsSolid)
            {
                // implement
            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(Texture, new Vector2(x, y), Bounds, Color.White);
        }

        public void DrawWithRotation(SpriteBatch spriteBatch, int x, int y,float rotation)
        {
            Vector2 origin = new Vector2(0, 0);
            spriteBatch.Draw(Texture, new Vector2(x,y), Bounds, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 1);
        }
    }
}
