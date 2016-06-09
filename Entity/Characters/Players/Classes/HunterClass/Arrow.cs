using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players.Classes.HunterClass
{
    public class Arrow
    {
        private const int Damage = 10;
        private int Speed = 10;
        private Vector2 _position;
        private Vector2 _direction;

        private Vector2 _velocity;

        public Arrow(Vector2 position, Vector2 direction)
        {
            _position = position;
            _direction = direction;

            _velocity = -(_position - _direction);
            _velocity.Normalize();

            // _xVelocity *= 0.01f;
            // _yVelocity *= 0.01f;
        }

        public void Update()
        {
            _position.X += _velocity.X * Speed;
            _position.Y += _velocity.Y * Speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Assets.PlayerHunterArrow.Draw(spriteBatch, (int)_position.X, (int)_position.Y);
        }
    }
}
