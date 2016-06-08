﻿using Baligo.Entity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players
{
    public abstract class Player : ICharacter
    {
        private static Player _currentPlayerClass;

        public Player CurrentPlayerClass
        {
            get
            {
                return _currentPlayerClass;
            }
            set
            {
                if (value != null)
                {
                    _currentPlayerClass = value;
                }
            }
        }

        public Vector2 Position { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }

        protected abstract void Attack();

        protected abstract void Heal();

        protected abstract void CastSpell();

        public abstract void Init();

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
