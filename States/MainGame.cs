using Baligo.Content.Fonts;
using Baligo.Entity.Characters.Players;
using Baligo.Graphics;
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
            Player.Init();
        }

        public override void Update(GameTime gameTime)
        {
            // Update current player class
            Player.CurrentPlayerClass.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Fonts.Arial,
                "GAME\nPress Left Bottom to shoot\nWORK IN PROGRESS",
                new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                Color.White);

            // Draw current player class
            Player.CurrentPlayerClass.Draw(spriteBatch);
        }
    }
}