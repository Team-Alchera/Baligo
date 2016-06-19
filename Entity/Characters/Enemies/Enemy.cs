using System;
using System.Collections.Generic;
using Baligo.Console;
using Baligo.Entity.Characters.Players;
using Baligo.Entity.Items.Weapons;
using Baligo.Graphics;
using Baligo.Main;
using Baligo.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baligo.Entity.Characters.Enemies
{
    public class Enemy : Character
    {
        //defines if the enemy is Boss or standard enemy
        public bool IsBoss;
        //stores list of item IDs to be used to defeat the enemy
        public List<int> ItemsOfDefeat;
        public List<Arrow> Arrows;

        //Sprite Sheet
        protected Texture2D EnemyTexture;
        protected const int SpeedOfAnimations = 50;

        // Collision
        public Rectangle CollisionBox;

        // Animations
        protected readonly Animation ShootArrowLeft;
        protected readonly Animation ShootArrowRight;
        protected readonly Animation ShootArrowUp;
        protected readonly Animation ShootArrowDown;

        // Orientation
        protected Rectangle Orientation;

        // Constructor
        public Enemy(Vector2 _position)
        {
            // Set Parameters
            EnemyTexture = Assets.Enemy.Texture;
            Health = 100;
            Armor = 100;
            Damage = 10;
            IsAlive = true;
            Speed = 5;
            

            // Position
            Position = _position;

            // Animation
            ShootArrowLeft = new Animation(SpeedOfAnimations, 17, 12);
            ShootArrowRight = new Animation(SpeedOfAnimations, 19, 12);
            ShootArrowUp = new Animation(SpeedOfAnimations, 16, 12);
            ShootArrowDown = new Animation(SpeedOfAnimations, 18, 12);

            // Orientation
            Orientation = new Rectangle(0, 64 * 11, 64, 64);

            // Collision
            CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, 44, 54);

            // Set default arrow list
            Arrows = new List<Arrow>();
        }

        public override void Init()
        {
        }

        private int countDown = 120;
        public override void Update(GameTime gmaTime)
        {
            // Update the collision box
            CollisionBox.X = (int)Position.X + 10;
            CollisionBox.Y = (int)Position.Y + 10;

            if (countDown == 0)
            {
                Vector2 PlayerPosition = MainGame.Player.CurrentPlayerClass.Position;
                PlayerPosition.Y += 32;
                PlayerPosition.X += 16;

                Arrows.Add(new Arrow(Position, PlayerPosition
                    , Arrows.Count - 1, true));
                countDown = 120;
                BaligoConsole.WriteLine("Enemy arrow Spawned ID: " + Arrows.Count, Color.Tomato);
            }

            // Update each arrow
            for (int arrowId = 0; arrowId < Arrows.Count; arrowId++)
            {
                Rectangle playerCollision = MainGame.Player.CurrentPlayerClass.CollisionBox;

                if (Arrows[arrowId].Timer > 0)
                {
                    Arrows[arrowId].Update();
                    if (Arrows[arrowId].CollisionBox.Intersects(playerCollision) && Arrows[arrowId].IsActive)
                    {
                        MainGame.Player.CurrentPlayerClass.Health -= this.Damage;
                        BaligoConsole.WriteLine("Damage Taken 10 | Current Health: " +
                            MainGame.Player.CurrentPlayerClass.Health, Color.Thistle);

                        BaligoConsole.WriteLine("Arrow Removed ID: " + Arrows[arrowId].Id + " Player Collision!", Color.Tomato);
                        Arrows.RemoveAt(arrowId);
                    }
                }
                else
                {
                    BaligoConsole.WriteLine("Enemy arrow Removed ID: " + Arrows[arrowId].Id, Color.Tomato);
                    Arrows.RemoveAt(arrowId);
                }
            }

            // Check for collision
            for (int i = 0; i < MainGame.Player.HunterClass.Arrows.Count; i++)
            {
                var arrow = MainGame.Player.HunterClass.Arrows[i];

                if (arrow.CollisionBox.Intersects(this.CollisionBox))
                {
                    this.Health -= 25;
                    BaligoConsole.WriteLine("Enemy hit: 25 | Health: " + this.Health, Color.Cyan);

                    BaligoConsole.WriteLine("Player arrow Removed ID: " + i, Color.Red);
                    MainGame.Player.HunterClass.Arrows.RemoveAt(i);
                }
            }
            
            if (countDown - 1 >= 0)
            {
                countDown--;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(EnemyTexture, Position, Orientation, Color.White);

            foreach (var arrow in Arrows)
            {
                arrow.Draw(spriteBatch);
            }

            if (BaligoEngine.IsDebugModeActive)
                spriteBatch.Draw(Assets.RedRectangle1.Texture, new Vector2(CollisionBox.X, CollisionBox.Y), CollisionBox, Color.White);
        }
    }
}
