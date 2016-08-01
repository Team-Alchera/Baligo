using System.Collections.Generic;
using Baligo.ConsoleDebugStats;
using Baligo.Content.Fonts;
using Baligo.Entity.Characters.Players;
using Baligo.Entity.Characters.Enemies;
using Baligo.Graphics;
using Baligo.Main;
using Baligo.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public class MainGame : State
    {
        public static Player Player;
        public static List<Enemy> Enemies;
        public bool DoesWin;

        public override void Init()
        {
            Player = new Player();
            Player.Init();

            Enemies = new List<Enemy>();
            Enemies.Add(new Enemy(new Vector2(64 * 6, 64 + 48)));
            Enemies.Add(new Enemy(new Vector2(64 * 20, 64 + 10)));
            Enemies.Add(new Enemy(new Vector2(64 * 3, 64 * 10)));
            Enemies.Add(new Enemy(new Vector2(64 + 20, 64 * 7)));
            Enemies.Add(new Enemy(new Vector2(64 * 19, 64 * 9 )));

            DoesWin = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.CurrentPlayerClass.IsAlive)
            {
                // Update current player class
                if (Player.CurrentPlayerClass.IsAlive)
                {
                    Player.CurrentPlayerClass.Update(gameTime);
                }

                for (int i = 0; i < Enemies.Count; i++)
                {
                    Enemies[i].Update(gameTime);

                    if (Enemies[i].Health <= 0)
                    {
                        Enemies.RemoveAt(i);
                        Statistics.TotalEnemyKilled++;
                    }
                }
            }

            // Check if win
            if (Enemies.Count == 0)
            {
                DoesWin = true;
            }

            // Update World
            WorldManager.GetCurrentWorld().Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Render World
            WorldManager.GetCurrentWorld().Draw(spriteBatch);

            // Draw obstacles
            Assets.Fountain.Draw(spriteBatch, 608, 608);

            // Draw enemy
            foreach (var enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }

            // Draw current player class
            if (Player.CurrentPlayerClass.IsAlive)
            {
                Player.CurrentPlayerClass.Draw(spriteBatch);
            }
            else
            {
                Player.CurrentPlayerClass.Draw(spriteBatch);
                spriteBatch.DrawString(
                    Fonts.Arial,
                    "DEAD",
                    new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                    Color.Red);
            }

            MainGameUI.Draw(spriteBatch);

            if (DoesWin)
            {
                spriteBatch.DrawString(
                    Fonts.Arial,
                    "WIN",
                    new Vector2(BaligoEngine.Width / 2 - 50, BaligoEngine.Height / 2 - 20),
                    Color.GreenYellow);
            }
        }
    }
}