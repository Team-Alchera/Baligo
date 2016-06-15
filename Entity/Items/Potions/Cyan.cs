using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Baligo.Graphics;

namespace Baligo.Entity.Items.Potions
{
    public class Cyan : Item
    {
        protected Texture2D PlayerTexture;
        public Cyan()
        {
            Position = new Vector2(150 , 150);
            Name = "Cyan Potion";
            Id = 1;
            PlayerTexture = Assets.Cyan.Texture;
        }

        public override void Update(GameTime gmaTime)
        {
            // throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // throw new NotImplementedException();
        }
    }
}
