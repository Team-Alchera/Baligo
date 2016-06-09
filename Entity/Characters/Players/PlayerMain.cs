using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Graphics;
using Baligo.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players
{
    public class PlayerMain : Creature
    {
        // Sprite Sheet
        private Texture2D PlayerTexture;
        private const int SpeedOfAnimations = 50;

        // Animations
        private readonly Animation WalkLeft;
        private readonly Animation WalkRight;
        private readonly Animation WalkUp;
        private readonly Animation WalkDown;

        // Orientation
        protected Rectangle Orientation;

        public PlayerMain()
        {
            this.PlayerTexture = Assets.Player.Texture;
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

        public override void Update(GameTime gmaTime)
        {
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
