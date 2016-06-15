using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Contracts
{
    public interface ICharacter
    {
        void Update(GameTime gmaTime);
        void Draw(SpriteBatch spriteBatch);
        void Init();
    }
}
