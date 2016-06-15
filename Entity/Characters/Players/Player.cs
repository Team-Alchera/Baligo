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

        // Collision
        public Rectangle CollisionBox;

        // Animations
        protected readonly Animation WalkLeft;
        protected readonly Animation WalkRight;
        protected readonly Animation WalkUp;
        protected readonly Animation WalkDown;

        protected readonly Animation ShootArrowLeft;
        protected readonly Animation ShootArrowRight;
        protected readonly Animation ShootArrowUp;
        protected readonly Animation ShootArrowDown;

        // Orientation
        protected Rectangle Orientation;
        protected Animation ShootStanding;

        // Angle
        public float Angle;
        public Vector2 Direction;

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

            // Position
            Position = new Vector2(600, 500);

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
            CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, 44, 54);

            // Get First Direction
            Direction = new Vector2(MousePosition.X, MousePosition.Y);
        }

        public void Init()
        {
            // Init Player Classes
            HunterClass = new Hunter();
            MageClass = new Mage();
            WarriorClass = new Warrior();

            // Set Default Class
            CurrentPlayerClass = HunterClass;
        }

        private Vector2 _lastPosition;
        public override void Update(GameTime gmaTime)
        {


            // Move and pick the orientation
            if (InputManager.AIsPressed)
            {
                Position.X -= Speed;
                if (CheckCollision(Position))
                {
                    Position.X += Speed;
                }
                Orientation = new Rectangle(0, 64 * 9, 64, 64);
                ShootStanding = ShootArrowLeft;
            }
            if (InputManager.DIsPressed)
            {
                Position.X += Speed;
                if (CheckCollision(Position))
                {
                    Position.X -= Speed;
                }
                Orientation = new Rectangle(0, 64 * 11, 64, 64);
                ShootStanding = ShootArrowRight;
            }
            if (InputManager.WIsPressed)
            {
                Position.Y -= Speed;
                if (CheckCollision(Position))
                {
                    Position.Y += Speed;
                }
                Orientation = new Rectangle(0, 64 * 12, 64, 64);
                ShootStanding = ShootArrowUp;
            }
            if (InputManager.SIsPressed)
            {
                Position.Y += Speed;
                if (CheckCollision(Position))
                {
                    Position.Y -= Speed;
                }
                Orientation = new Rectangle(0, 64 * 10, 64, 64);
                ShootStanding = ShootArrowDown;
            }
            
            // Update the collision box
            CollisionBox.X = (int)Position.X + 10;
            CollisionBox.Y = (int)Position.Y + 10;
            
            // Calculate Angle
            MousePosition = Mouse.GetState();
            Direction.X = MousePosition.X;
            Direction.Y = MousePosition.Y;
            Vector2 tempPosition = Position;
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

            _lastPosition = Position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Pick the right animation to draw
            if (InputManager.AIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, Position,
                    InputManager.LeftButtomDown ? ShootArrowLeft.GetBoundsForFrame() : WalkLeft.GetBoundsForFrame(),
                    Color.White);
            }
            else if (InputManager.DIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, Position,
                    InputManager.LeftButtomDown ? ShootArrowRight.GetBoundsForFrame() : WalkRight.GetBoundsForFrame(),
                    Color.White);
            }
            else if (InputManager.WIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, Position,
                    InputManager.LeftButtomDown ? ShootArrowUp.GetBoundsForFrame() : WalkUp.GetBoundsForFrame(),
                    Color.White);
            }
            else if (InputManager.SIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, Position,
                    InputManager.LeftButtomDown ? ShootArrowDown.GetBoundsForFrame() : WalkDown.GetBoundsForFrame(),
                    Color.White);
            }
            else // Stand Positon in last Orientation
            {
                spriteBatch.Draw(PlayerTexture, Position,
                    InputManager.LeftButtomDown ? ShootStanding.GetBoundsForFrame() : Orientation, Color.White);
            }

            // Draw player collision if debug is active
            if (BaligoEngine.IsDebugModeActive)
            {
                spriteBatch.Draw(Assets.RedRectangle1.Texture, new Vector2(CollisionBox.X, CollisionBox.Y), CollisionBox, Color.White);
                spriteBatch.DrawString(
                    Fonts.Arial,
                    Angle.ToString(),
                    new Vector2(250, 32),
                    Color.Wheat);
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
