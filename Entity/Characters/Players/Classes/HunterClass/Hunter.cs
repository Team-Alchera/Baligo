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
        private List<Arrow> _arrows; 

        public Hunter()
        {
            PlayerTexture = Assets.PlayerHunter.Texture;
            _arrows = new List<Arrow>();
        }

        public override void Update(GameTime gmaTime)
        {
            if (InputManager.LeftButtomDown)
            {
                _arrows.Add(new Arrow(Position,new Vector2(Mouse.GetState().X, Mouse.GetState().Y)));
            }

            foreach (var arrow in _arrows)
            {
                arrow.Update();
            }

            base.Update(gmaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            foreach (var arrow in _arrows)
            {
                arrow.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }
    }
}
