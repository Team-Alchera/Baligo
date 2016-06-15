using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public abstract class State
    {
        // Field
        private static State currentState;

        public static State GetCurrentState()
        {
            return currentState;
        }

        public static void SetCurrentState(State state)
        {
            currentState = state;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Init();
    }
}