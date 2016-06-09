using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Entity.Characters.Players.Classes;
using Baligo.Entity.Characters.Players.Classes.HunterClass;
using Baligo.Entity.Characters.Players.Classes.MageClass;
using Baligo.Entity.Characters.Players.Classes.WarriorClass;
using Baligo.Graphics;
using Baligo.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players
{
    public class PlayerMain : Creature
    {
        public PlayerMain CurrentPlayerClass;
        public Hunter HunterClass;
        public Mage MageClass;
        public Warrior WarriorClass;

        // Sprite Sheet
        protected Texture2D PlayerTexture;
        protected const int SpeedOfAnimations = 50;

        // Animations
        protected readonly Animation WalkLeft;
        protected readonly Animation WalkRight;
        protected readonly Animation WalkUp;
        protected readonly Animation WalkDown;

        // Orientation
        protected Rectangle Orientation;

        public PlayerMain()
        {
            this.PlayerTexture = Assets.PlayerHunter.Texture;
            this.Health = 100;
            this.Armor = 100;
            this.Damage = 10;
            this.IsAlive = true;
            this.Speed = 5;
            
            // Position
            Position = new Vector2(600, 500);

            // Animation
            WalkLeft = new Animation(SpeedOfAnimations, 9, 9);
            WalkRight = new Animation(SpeedOfAnimations, 11, 9);
            WalkUp = new Animation(SpeedOfAnimations, 8, 9);
            WalkDown = new Animation(SpeedOfAnimations, 10, 9);

            // Orientation
            Orientation = new Rectangle(0, 64 * 11, 64, 64);
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
            if (InputManager.AIsPressed)
            {
                Position.X -= Speed;
                // WalkLeft.Update(gmaTime);
                Orientation = new Rectangle(0, 64 * 9, 64, 64);
            }
            if (InputManager.DIsPressed)
            {
                Position.X += Speed;
                // WalkRight.Update(gmaTime);
                Orientation = new Rectangle(0, 64 * 11, 64, 64);
            }
            if (InputManager.WIsPressed)
            {
                Position.Y -= Speed;
                // WalkUp.Update(gmaTime);
                Orientation = new Rectangle(0, 64 * 12, 64, 64);
            }
            if (InputManager.SIsPressed)
            {
                Position.Y += Speed;
                // WalkDown.Update(gmaTime);
                Orientation = new Rectangle(0, 64 * 10, 64, 64);
            }

            WalkLeft.Update(gmaTime);
            WalkRight.Update(gmaTime);
            WalkDown.Update(gmaTime);
            WalkUp.Update(gmaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (InputManager.AIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, Position, WalkLeft.GetBoundsForFrame(), Color.White);
            }
            else if (InputManager.DIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, Position, WalkRight.GetBoundsForFrame(), Color.White);
            }
            else if (InputManager.WIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, Position, WalkUp.GetBoundsForFrame(), Color.White);
            }
            else if (InputManager.SIsPressed)
            {
                spriteBatch.Draw(PlayerTexture, Position, WalkDown.GetBoundsForFrame(), Color.White);
            }
            else // Stand Positon in last Orientation
            {
                spriteBatch.Draw(PlayerTexture, Position, Orientation, Color.White);
            }
        }
    }
}
