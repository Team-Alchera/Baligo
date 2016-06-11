using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Content.Fonts;
using Baligo.Graphics;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players.Classes.HunterClass
{
    public class Arrow
    {
        public Rectangle CollisionBox;
        public const int Damage = 10;
        public const int Speed = 15;
        public Vector2 Position;
        public Vector2 Direction;
        public float Angle;
        public Vector2 Velocity;

        public Arrow(Vector2 position, Vector2 direction)
        {
            // Set Parameters
            Position = position;
            Position.X += 16;
            Position.Y += 32;
            Direction = direction;

            // Calculate Velocity
            Velocity = -(Position - Direction);
            Velocity.Normalize();

            // Calculate Angle
            var toCalcAngle = Position - direction;
            Angle = (float)Math.Atan2(toCalcAngle.Y, toCalcAngle.X);

            // Create Collision
            CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, 10, 10);
        }

        public void Update()
        {
            // Update Position
            Position.X += Velocity.X * Speed;
            Position.Y += Velocity.Y * Speed;

            // Update Collision
            CollisionBox.X = (int)Position.X;
            CollisionBox.Y = (int)Position.Y - 5;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Arrow
            Assets.PlayerHunterArrow.DrawWithRotation(spriteBatch, (int)Position.X, (int)Position.Y, Angle);

            // Draw Arrow Collision if debug is active
            if (BaligoEngine.IsDebugModeActive)
            {
                spriteBatch.Draw(Assets.RedRectangle2.Texture, new Vector2(CollisionBox.X, CollisionBox.Y),
                    CollisionBox,
                    Color.White);
            }
        }
    }
}
