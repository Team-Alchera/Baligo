using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Console;
using Baligo.Graphics;
using Baligo.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baligo.Entity.Characters.Players.Classes.HunterClass
{
    public class Hunter : PlayerMain
    {
        // Fields
        public readonly List<Arrow> Arrows;
        public int CountDown;

        // Constructor
        public Hunter()
        {
            PlayerTexture = Assets.PlayerHunter.Texture;
            Arrows = new List<Arrow>();
            CountDown = 15;
        }

        public override void Update(GameTime gmaTime)
        {
            // If an arrow is fired and countDown allows it
            if (InputManager.LeftButtomDown)
            {
                if (CountDown == 0)
                {
                    Arrows.Add(new Arrow(Position, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Arrows.Count + 1));
                    CountDown = 15;
                    BaligoConsole.WriteLine("Arrow Spawned ID: " + Arrows.Count, Color.LimeGreen);
                }
            }

            // Update each arrow
            for (int arrowId = 0; arrowId < Arrows.Count; arrowId++)
            {
                if (Arrows[arrowId].Timer > 0)
                {
                    Arrows[arrowId].Update();
                }
                else
                {
                    BaligoConsole.WriteLine("Arrow Removed ID: " + Arrows[arrowId].Id, Color.Red);
                    Arrows.RemoveAt(arrowId);
                }
            }

            // Work with countDown
            if (CountDown - 1 >= 0)
                CountDown--;

            // Update the main player functions
            base.Update(gmaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw Every Arrow
            foreach (var arrow in Arrows)
                arrow.Draw(spriteBatch);

            // Draw Player with animation

            base.Draw(spriteBatch);
        }
    }
}
