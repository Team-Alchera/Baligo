using Baligo.Content;
using Baligo.Input;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public class MainMenu : State
    {
        public override void Update()
        {
            if (InputManager.A)
            {
                State.SetCurrentState(BaligoEngine.DeadMenuState);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Fonts.Arial, 
                "MAIN MENU",
                new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                Color.White);
        }

        public override void Init()
        {
        }
    }
}