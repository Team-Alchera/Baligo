using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Graphics;
using Baligo.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baligo.Entity.Characters.Players.Classes.HunterClass
{
    public class Hunter : PlayerMain
    {
        private readonly List<Arrow> _arrows;
        private int _countDown;

        public Hunter()
        {
            PlayerTexture = Assets.PlayerHunter.Texture;
            _arrows = new List<Arrow>();
            _countDown = 15;
        }

        public override void Update(GameTime gmaTime)
        {
            if (InputManager.LeftButtomDown)
            {
                if (_countDown == 0)
                {
                    _arrows.Add(new Arrow(Position, new Vector2(Mouse.GetState().X, Mouse.GetState().Y)));
                    _countDown = 15;
                }
            }

            foreach (var arrow in _arrows)
                arrow.Update();

            if (_countDown - 1 >= 0)
                _countDown--;

            base.Update(gmaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var arrow in _arrows)
                arrow.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
