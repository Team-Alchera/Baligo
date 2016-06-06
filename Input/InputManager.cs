using Microsoft.Xna.Framework.Input;

namespace Baligo.Input
{
    public static class InputManager
    {
        public static bool W { get; private set; }
        public static bool A { get; private set; }
        public static bool D { get; private set; }
        public static bool S { get; private set; }

        public static bool Space { get; private set; }
        public static bool Enter { get; private set; }
        public static bool Escape { get; private set; }

        public static void Update()
        {
            W = Keyboard.GetState().IsKeyDown(Keys.W);
            A = Keyboard.GetState().IsKeyDown(Keys.A);
            D = Keyboard.GetState().IsKeyDown(Keys.D);
            S = Keyboard.GetState().IsKeyDown(Keys.S);

            Space = Keyboard.GetState().IsKeyDown(Keys.Space);
            Enter = Keyboard.GetState().IsKeyDown(Keys.Enter);
            Escape = Keyboard.GetState().IsKeyDown(Keys.Escape);
        }
    }
}
