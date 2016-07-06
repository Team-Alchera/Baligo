using Baligo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players
{
    public class Mage : Player
    {
        public Mage() : base()
        {
            PlayerTexture = Assets.PlayerMage.Texture;
        }

        public override void Update(GameTime gmaTime)
        {
            Update(gmaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch);
        }
    }
}
