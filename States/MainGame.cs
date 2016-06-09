using Baligo.Content.Fonts;
using Baligo.Entity.Characters.Players;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public class MainGame : State
    {
        protected PlayerMain Player;

        public override void Init()
        {
            Player = new PlayerMain();
        }

        public override void Update(GameTime gameTime)
        {
            Player.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Fonts.Arial,
                "GAME",
                new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                Color.White);

            // Draw Player
            Player.Draw(spriteBatch);
        }
    }
}