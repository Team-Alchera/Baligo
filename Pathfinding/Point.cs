using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Pathfinding
{
    public class Point
    {
        public Vector2 Position;
        public bool IsSolid;

        public int H;
        public int G;
        public int F;

        public Point(int row, int col,bool isSolid)
        {
            Position = new Vector2(col, row);
            IsSolid = isSolid;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(IsSolid ? Assets.RedDot.Texture : Assets.BlueDot.Texture, Position,
                new Rectangle(0, 0, 8, 8), Color.White);
        }
    }
}
