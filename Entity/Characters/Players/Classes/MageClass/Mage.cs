using Baligo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players.Classes.MageClass
{
    public class Mage : PlayerMain
    {
        public Mage() : base()
        {
            PlayerTexture = Assets.PlayerMage.Texture;
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
