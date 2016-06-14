using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Baligo.Graphics;

namespace Baligo.Entity.Items.Potions
{
    class Cyan : Item
    {
        protected Texture2D PlayerTexture;
        public CyanMain()
        {
            Position = new Vector2(150 , 150);
            Name = "Cyan Potion";
            Id = 1;
            PlayerTexture = Assets.Cyan.Texture;
        }   
    }
}
