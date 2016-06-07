using Baligo.Entity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Enemies
{
    public abstract class Monster : ICharacter
    {
        public Vector2 Position { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update();

        public abstract void Init();
    }
}
