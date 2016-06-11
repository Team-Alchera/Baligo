using Baligo.Entity.Characters.Players.Classes.HunterClass;
using Baligo.Entity.Characters.Players.Classes.MageClass;
using Baligo.Entity.Characters.Players.Classes.WarriorClass;
using Baligo.Graphics;
using Baligo.Input;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baligo.Entity.Characters.Players
{
    public class PlayerMain : Creature
    {
        // Classes
        public PlayerMain CurrentPlayerClass;
        public Hunter HunterClass;
        public Mage MageClass;
        public Warrior WarriorClass;

        // Sprite Sheet
        protected Texture2D PlayerTexture;
        protected const int SpeedOfAnimations = 50;

        //Mouse position
        public MouseState MousePosition { get; }

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

        // Constructor
        public PlayerMain()
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

            // Collision
            CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, 44, 54);
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

        public override void Update(GameTime gmaTime)
        {
            // Move and pick the orientation
            if (InputManager.AIsPressed)
            {
                Position.X -= Speed;
                Orientation = new Rectangle(0, 64 * 9, 64, 64);
            }
            if (InputManager.DIsPressed)
            {
                Position.X += Speed;
                Orientation = new Rectangle(0, 64 * 11, 64, 64);
            }
            if (InputManager.WIsPressed)
            {
                Position.Y -= Speed;
                Orientation = new Rectangle(0, 64 * 12, 64, 64);
            }
            if (InputManager.SIsPressed)
            {
                Position.Y += Speed;
                Orientation = new Rectangle(0, 64 * 10, 64, 64);
            }

            // Update all animations
            WalkLeft.Update(gmaTime);
            WalkRight.Update(gmaTime);
            WalkDown.Update(gmaTime);
            WalkUp.Update(gmaTime);
            ShootArrowLeft.Update(gmaTime);
            ShootArrowRight.Update(gmaTime);
            ShootArrowUp.Update(gmaTime);
            ShootArrowDown.Update(gmaTime);
            // Update the collision box
            CollisionBox.X = (int)Position.X + 10;
            CollisionBox.Y = (int)Position.Y + 10;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            
            // Pick the right animation to draw
            if (InputManager.AIsPressed)
                spriteBatch.Draw(PlayerTexture, Position, WalkLeft.GetBoundsForFrame(), Color.White);
            else if (InputManager.DIsPressed)
                spriteBatch.Draw(PlayerTexture, Position, WalkRight.GetBoundsForFrame(), Color.White);
            else if (InputManager.WIsPressed)
                spriteBatch.Draw(PlayerTexture, Position, WalkUp.GetBoundsForFrame(), Color.White);
            else if (InputManager.SIsPressed)
                spriteBatch.Draw(PlayerTexture, Position, WalkDown.GetBoundsForFrame(), Color.White);
            else // Stand Positon in last Orientation
                spriteBatch.Draw(PlayerTexture, Position, Orientation, Color.White);

            /*  тук стреля докато ходиш, но стреля и през гъза си. малко по-горе ще видиш public MouseState MousePosition { get; } =>
             *   => той ти дава достъп до мишката, да и правиш каквото поискаш общо взето 
             *
             *      
             *   if (InputManager.LeftButtomDown && InputManager.AIsPressed)
             *   {
             *       spriteBatch.Draw(PlayerTexture, Position, ShootArrowLeft.GetBoundsForFrame(), Color.White);
             *   }
             *   else if (InputManager.LeftButtomDown && InputManager.DIsPressed)
             *   {
             *       spriteBatch.Draw(PlayerTexture, Position, ShootArrowRight.GetBoundsForFrame(), Color.White);
             *   }
             *   else if (InputManager.LeftButtomDown && InputManager.WIsPressed)
             *   {
             *       spriteBatch.Draw(PlayerTexture, Position, ShootArrowUp.GetBoundsForFrame(), Color.White);
             *   }
             *   else if (InputManager.LeftButtomDown && InputManager.SIsPressed)
             *   {
             *       spriteBatch.Draw(PlayerTexture, Position, ShootArrowDown.GetBoundsForFrame(), Color.White);
             *   }
             *   P.S. Сега видях, че си ползвал Mouse класа в InputManager-a и се чувствам глупаво :D
             */
                // Draw player collision if debug is active
                if (BaligoEngine.IsDebugModeActive)
                    spriteBatch.Draw(Assets.RedRectangle1.Texture, new Vector2(CollisionBox.X, CollisionBox.Y), CollisionBox, Color.White);
                    
                    
             
        }
    }
}
