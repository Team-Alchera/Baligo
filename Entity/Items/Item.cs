using Baligo.Contracts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Items
{
    public abstract class Item 
    {
        public Vector2 Position;
        public string Name;
        public int Id;

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
