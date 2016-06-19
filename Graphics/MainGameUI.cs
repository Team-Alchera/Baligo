using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.ConsoleDebug;
using Baligo.Content.Fonts;
using Baligo.Main;
using Baligo.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Graphics
{
    public static class MainGameUI
    {
        public static void Init()
        {
            
        }

        public static void Update()
        {

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.ConsoleTile.Texture,
                new Vector2(DebugMode.StartPosition + 40, 48),
                new Rectangle(0, 0, 160, 44),
                Color.White);

            spriteBatch.DrawString(
                Fonts.HealthFont,
                "HP: " + MainGame.Player.CurrentPlayerClass.Health.ToString().PadLeft(3, '0'),
                new Vector2(DebugMode.StartPosition + 48, 48),
                MainGame.Player.CurrentPlayerClass.Health > 20 ? Color.LimeGreen : Color.Red);
        }
    }
}
