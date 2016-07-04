using System;
using Baligo.Content.Fonts;
using Baligo.Graphics;
using Baligo.Input;
using Baligo.Main;
using Baligo.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baligo.Entity.Characters.Players
{
    public class Player : Character
    {
        // Classes
        public Player CurrentPlayerClass;
        public Hunter HunterClass;
        public Mage MageClass;
        public Warrior WarriorClass;

        // Sprite Sheet
        protected Texture2D PlayerTexture;
        protected const int SpeedOfAnimations = 50;

        //Mouse position
        public MouseState MousePosition { get; set; }
        public Rectangle CollisionBox;


        // Constructor
        public Player()
        {
            // Set Parameters
            PlayerTexture = Assets.PlayerHunter.Texture;
            Health = 100;
            Armor = 100;
            Damage = 10;
            IsAlive = true;
            Speed = 5;

            // position
            position = new Vector2(600, 500);

            // Animation
            WalkLeft = new Animation(SpeedOfAnimations, 9, 9);
            WalkRight = new Animation(SpeedOfAnimations, 11, 9);
            WalkUp = new Animation(SpeedOfAnimations, 8, 9);
            WalkDown = new Animation(SpeedOfAnimations, 10, 9);
            ShootArrowLeft = new Animation(SpeedOfAnimations, 17, 12);
            ShootArrowRight = new Animation(SpeedOfAnimations, 19, 12);
            ShootArrowUp = new Animation(SpeedOfAnimations, 16, 12);
            ShootArrowDown = new Animation(SpeedOfAnimations, 18, 12);

            // Orientation
            Orientation = new Rectangle(0, 64 * 11, 64, 64);
            ShootStanding = ShootArrowRight;

            // Collision
            CollisionBox = new Rectangle((int)position.X, (int)position.Y, 44, 54);

            // Get First Direction
            Direction = new Vector2(MousePosition.X, MousePosition.Y);
        }

        public override void Init()
        {
            // Init Player Classes
            HunterClass = new Hunter();
            MageClass = new Mage();
            WarriorClass = new Warrior();

            // Set Default Class
            CurrentPlayerClass = HunterClass;
        }

        public override void Update(GameTime gmaTime)
        {
            // Move and pick the orientation
            if (InputManager.AIsPressed)
            {
                this.position.X -= Speed;
                if (CheckCollision(position))
                {
                    position.X += Speed;
                }
                Orientation = new Rectangle(0, 64 * 9, 64, 64);
                ShootStanding = ShootArrowLeft;
            }
            if (InputManager.DIsPressed)
            {
                position.X += Speed;
                if (CheckCollision(position))
                {
                    position.X -= Speed;
                }
                Orientation = new Rectangle(0, 64 * 11, 64, 64);
                ShootStanding = ShootArrowRight;
            }
            if (InputManager.WIsPressed)
            {
                position.Y -= Speed;
                if (CheckCollision(position))
                {
                    position.Y += Speed;
                }
                Orientation = new Rectangle(0, 64 * 12, 64, 64);
                ShootStanding = ShootArrowUp;
            }
            if (InputManager.SIsPressed)
            {
                position.Y += Speed;
                if (CheckCollision(position))
                {
                    position.Y -= Speed;
                }
                Orientation = new Rectangle(0, 64 * 10, 64, 64);
                ShootStanding = ShootArrowDown;
            }

            // Update the collision box
            CollisionBox.X = (int)position.X + 10;
            CollisionBox.Y = (int)position.Y + 10;

            // Calculate Angle
            MousePosition = Mouse.GetState();
            Direction.X = MousePosition.X;
            Direction.Y = MousePosition.Y;
            Vector2 tempPosition = position;
            tempPosition.X += 32;
            tempPosition.Y += 32;
            var toCalcAngle = tempPosition - Direction;
            Angle = (float)Math.Atan2(toCalcAngle.Y, toCalcAngle.X);

            // Update all animations
            WalkLeft.Update(gmaTime);
            WalkRight.Update(gmaTime);
            WalkDown.Update(gmaTime);
            WalkUp.Update(gmaTime);
            ShootArrowLeft.Update(gmaTime);
            ShootArrowRight.Update(gmaTime);
            ShootArrowUp.Update(gmaTime);
            ShootArrowDown.Update(gmaTime);
            ShootStanding.Update(gmaTime);

            // If Player in god mode
            if (BaligoEngine.IsPlayerInGodMode)
            {
                Health = 100;
            }

            // Check if dead
            if (Health <= 0)
            {
                this.IsAlive = false;
                Health = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!this.IsAlive)
            {
                spriteBatch.Draw(PlayerTexture, position, Orientation, Color.White);
                return;
            }

            // Pick the right animation to draw
            if (InputManager.AIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, position,
                    InputManager.LeftButtomDown ? ShootArrowLeft.GetBoundsForFrame() : WalkLeft.GetBoundsForFrame(),
                    Color.White);
            }
            else if (InputManager.DIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, position,
                    InputManager.LeftButtomDown ? ShootArrowRight.GetBoundsForFrame() : WalkRight.GetBoundsForFrame(),
                    Color.White);
            }
            else if (InputManager.WIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, position,
                    InputManager.LeftButtomDown ? ShootArrowUp.GetBoundsForFrame() : WalkUp.GetBoundsForFrame(),
                    Color.White);
            }
            else if (InputManager.SIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, position,
                    InputManager.LeftButtomDown ? ShootArrowDown.GetBoundsForFrame() : WalkDown.GetBoundsForFrame(),
                    Color.White);
            }
            else // Stand Positon in last Orientation
            {
                spriteBatch.Draw(PlayerTexture, position,
                    InputManager.LeftButtomDown ? ShootStanding.GetBoundsForFrame() : Orientation, Color.White);
            }

            // Draw player collision if debug is active
            if (BaligoEngine.IsDebugModeActive)
            {
                spriteBatch.Draw(Assets.RedRectangle1.Texture, new Vector2(CollisionBox.X, CollisionBox.Y), CollisionBox, Color.White);
            }

            if (BaligoEngine.IsPlayerInGodMode)
            {
                spriteBatch.DrawString(
                    Fonts.Console,
                    "GOD",
                    new Vector2(position.X + 10, position.Y),
                    Color.Yellow);
            }
        }

        private bool CheckCollision(Vector2 Position)
        {
            CollisionBox.X = (int)Position.X + 10;
            CollisionBox.Y = (int)Position.Y + 10;

            for (int row = 0; row < 24; row++)
            {
                for (int col = 0; col < 43; col++)
                {
                    Tile currentTile = WorldManager.GetCurrentWorld().WorldData[row, col];

                    if (currentTile.CollisionBox.Intersects(this.CollisionBox) && currentTile.IsSolid)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
