using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.ConsoleDebugStats;
using Baligo.Content.Fonts;
using Baligo.Graphics;
using Baligo.Main;
using Baligo.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.ConsoleDebug
{
    public static class DebugMode
    {
        public static int StartPosition = 0;

        public static void Update()
        {
            StartPosition = BaligoEngine.IsConsoleActive ? 370 : 0;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.ConsoleTile.Texture,
                    new Vector2(StartPosition + 40, 48 * 2),
                    new Rectangle(0, 0, 370, 300),
                    Color.White);

            spriteBatch.DrawString(
                Fonts.HealthFont,
                "Debug: Active",
                new Vector2(StartPosition + 50, 100),
                Color.LimeGreen);

            spriteBatch.DrawString(
                Fonts.HealthFont,
                MainGame.Player.CurrentPlayerClass.Angle.ToString(),
                new Vector2(StartPosition + 50, 150),
                Color.LimeGreen);

            spriteBatch.DrawString(
                Fonts.HealthFont,
                BaligoEngine.IsPlayerInGodMode ? "Godmode: True" : "Godmode: False",
                new Vector2(StartPosition + 50, 200),
                Color.LimeGreen);

            spriteBatch.DrawString(
                Fonts.HealthFont,
                string.Format("Arrows Fired: {0}", Statistics.TotalArrowsFired),
                new Vector2(StartPosition + 50, 250),
                Color.LimeGreen);

            spriteBatch.DrawString(
                Fonts.HealthFont,
                string.Format("Arrows Missed: {0}",Statistics.TotalArrowsMissed),
                new Vector2(StartPosition + 50, 300),
                Color.LimeGreen);

            spriteBatch.DrawString(
                Fonts.HealthFont,
                string.Format("Enemies Killed: {0}", Statistics.TotalEnemyKilled),
                new Vector2(StartPosition + 50, 350),
                Color.LimeGreen);
        }
    }
}
