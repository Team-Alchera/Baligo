using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baligo.Entity.Custom_Mouse
{
    public static class CustomMaouse
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            int currentX = Mouse.GetState().X;
            int currentY = Mouse.GetState().Y;

            spriteBatch.Draw(
                Mouse.GetState().LeftButton == ButtonState.Pressed
                    ? Assets.CursorActive.Texture
                    : Assets.CursorNormal.Texture, new Vector2(currentX, currentY), null, Color.White);
        }
    }
}
