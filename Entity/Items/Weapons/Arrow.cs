using System;
using Baligo.ConsoleDebugStats;
using Baligo.Graphics;
using Baligo.Main;
using Baligo.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Items.Weapons
{
    public class Arrow: Item
    {
        public Rectangle CollisionBox;
        public const int Damage = 10;
        public const int Speed = 15;
        public Vector2 Direction;
        public float Angle;
        public Vector2 Velocity;
        public bool IsActive;
        public int Timer;
        public bool IsEnemyArrow;

        public Arrow(Vector2 position, Vector2 direction,int id,bool isEnemyArrow = false)
        {
            Id = id;
             
            // Set Parameters
            Position = position;
            Position.X += 16;
            Position.Y += 32;
            Direction = direction;

            // Calculate Velocity
            Velocity = -(Position - Direction);
            Velocity.Normalize();

            // Calculate Angle
            var toCalcAngle =  Position - direction;
            Angle = (float)Math.Atan2(toCalcAngle.Y, toCalcAngle.X);

            // Create Collision
            CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, 10, 10);

            // Set default active state and timer
            IsActive = true;
            Timer = 900;

            IsEnemyArrow = isEnemyArrow;
        }

        public void Update()
        {
            if (IsActive)
            {
                // Update Position
                Position.X += Velocity.X * Speed;
                Position.Y += Velocity.Y * Speed;

                // Update Collision
                CollisionBox.X = (int)Position.X;
                CollisionBox.Y = (int)Position.Y -5; 

                // Check Collision
                for (int row = 0; row < 24; row++)
                {
                    for (int col = 0; col < 43; col++)
                    {
                        Tile currentTile = WorldManager.GetCurrentWorld().WorldData[row, col];

                        if (currentTile.CollisionBox.Intersects(this.CollisionBox) && currentTile.IsSolid)
                        {
                            IsActive = false;
                            Statistics.TotalArrowsMissed++;
                        }
                    }
                }
            }
            else
            {
                if (Timer - 1 >= 0)
                    Timer--;
            }
        }

        public override void Update(GameTime gmaTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw 
            if (IsEnemyArrow)
            {
                Assets.PlayerHunterArrow.DrawWithRotation(spriteBatch, (int)Position.X, (int)Position.Y, Angle,true);
            }
            else
            {
                Assets.PlayerHunterArrow.DrawWithRotation(spriteBatch, (int)Position.X, (int)Position.Y, Angle);
            }

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
