using System;
using System.Collections.Generic;
using Baligo.Graphics;
using Baligo.Input;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Enemies
{
    public class EnemyMain : Creature
    {
        // Sprite Sheet
        protected Texture2D PlayerTexture;
        protected const int SpeedOfAnimations = 50;

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
        public EnemyMain()
        {

            // Set Parameters
            EnemyName = "";
            EnemyTexture = Assets.Enemy.Texture;
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

            //defines if the enemy is Boss or standard enemy
            public bool isBoss;
        //stores list of item IDs to be used to defeat the enemy
        public List<int> itemsOfDefeat;
        private Texture2D EnemyTexture;
        public string EnemyName { get; private set; }
        public void Init()
        {
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
            if (BaligoEngine.IsDebugModeActive)
                spriteBatch.Draw(Assets.RedRectangle1.Texture, new Vector2(CollisionBox.X, CollisionBox.Y), CollisionBox, Color.White);
        }
    }
}
