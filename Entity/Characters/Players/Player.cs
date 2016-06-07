using Baligo.Entity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players
{
    public abstract class Player : ICharacter
    {
        public Vector2 Position { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }

        public abstract void Init();

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
