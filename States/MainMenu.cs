using Baligo.Content.Fonts;
using Baligo.Graphics;
using Baligo.Input;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public class MainMenu : State
    {
        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Fonts.Arial,
                "MAIN MENU",
                new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                Color.White);

            Assets.Player.Draw(spriteBatch, 100, 100);
        }

        public override void Init()
        {
        }
    }
}