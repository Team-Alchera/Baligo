using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public abstract class State
    {
        private static State _currentState;

        public static State GetCurrentState()
        {
            return _currentState;
        }

        public static void SetCurrentState(State state)
        {
            _currentState = state;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Init();
    }
}