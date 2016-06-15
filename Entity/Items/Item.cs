using Baligo.Contracts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Items
{
    public abstract class Item : ICollectable 
    {
        public Vector2 Position;
        public string Name;
        public int Id;

        public abstract void Update(GameTime gmaTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
