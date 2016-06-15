using System;
using Baligo.Content.Fonts;
using Baligo.Entity.Characters.Players;
using Baligo.Entity.Characters.Enemies;
using Baligo.Graphics;
using Baligo.Input;
using Baligo.Main;
using Baligo.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public class MainGame : State
    {
        protected Player Player;
        protected Enemy Enemy;

        public override void Init()
        {
            Player = new Player();
            Player.Init();

            Enemy = new Enemy();
            Enemy.Init();
        }

        public override void Update(GameTime gameTime)
        {
            // Update current player class
            Player.CurrentPlayerClass.Update(gameTime);

            // Update World
            WorldManager.GetCurrentWorld().Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Fonts.Arial,
                "GAME\nPress Left Bottom to shoot\nWORK IN PROGRESS\n",
                new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                Color.White);

            // Render World
            WorldManager.GetCurrentWorld().Draw(spriteBatch);

            // Draw obstacles
            Assets.Fountain.Draw(spriteBatch, 608, 608);

            // Draw enemy
            Enemy.CurrentEnemy.Draw(spriteBatch);

            // Draw current player class
            Player.CurrentPlayerClass.Draw(spriteBatch);
        }
    }
}