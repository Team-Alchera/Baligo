﻿using Baligo.Content.Fonts;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public class MainGame : State
    {
        public override void Init()
        {

        }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Fonts.Arial,
                "GAME",
                new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                Color.White);
        }
    }
}