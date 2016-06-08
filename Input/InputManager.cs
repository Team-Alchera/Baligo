using Microsoft.Xna.Framework.Input;

namespace Baligo.Input
{
    public static class InputManager
    {
        public static bool WIsPressed { get; private set; }
        public static bool AIsPressed { get; private set; }
        public static bool DIsPressed { get; private set; }
        public static bool SIsPressed { get; private set; }

        public static bool Space { get; private set; }
        public static bool Enter { get; private set; }
        public static bool Escape { get; private set; }

        public static void Update()
        {
            WIsPressed = Keyboard.GetState().IsKeyDown(Keys.W);
            AIsPressed = Keyboard.GetState().IsKeyDown(Keys.A);
            DIsPressed = Keyboard.GetState().IsKeyDown(Keys.D);
            SIsPressed = Keyboard.GetState().IsKeyDown(Keys.S);

            Space = Keyboard.GetState().IsKeyDown(Keys.Space);
            Enter = Keyboard.GetState().IsKeyDown(Keys.Enter);
            Escape = Keyboard.GetState().IsKeyDown(Keys.Escape);
        }
    }
}
