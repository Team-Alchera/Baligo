using Baligo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players
{
    public class Warrior : Player
    {
        public Warrior() : base()
        {
            PlayerTexture = Assets.PlayerWarrior.Texture;
        }

        public override void Update(GameTime gmaTime)
        {
            base.Update(gmaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
