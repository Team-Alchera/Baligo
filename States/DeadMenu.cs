using Baligo.Content;
using Baligo.Content.Fonts;
using Baligo.Input;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public class DeadMenu : State
    {
        public override void Update()
        {
            if (InputManager.D)
            {
                State.SetCurrentState(BaligoEngine.MainMenuState);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Fonts.Arial,
                "DEAD MENU",
                new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                Color.White);
        }

        public override void Init()
        {
        }
    }
}