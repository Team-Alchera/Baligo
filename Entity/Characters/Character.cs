using Baligo.Contracts;
using Baligo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters
{
    public abstract class Character : ICharacter
    {
        public Vector2 Position;

        

        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public bool IsAlive { get; set; }

        // Collision
        private Rectangle collisionBox;

        // Animations
        protected Animation WalkLeft { get; set; }
        protected Animation WalkRight { get; set; }
        protected Animation WalkUp { get; set; }
        protected Animation WalkDown { get; set; }

        protected Animation ShootArrowLeft { get; set; }
        protected Animation ShootArrowRight { get; set; }
        protected Animation ShootArrowUp { get; set; }
        protected Animation ShootArrowDown { get; set; }

        // Orientation
        protected Rectangle Orientation { get; set; }
        protected Animation ShootStanding { get; set; }

        // Angle
        public float Angle { get; set; }
        public Vector2 Direction;

        public abstract void Update(GameTime gmaTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Init();
    }
}
