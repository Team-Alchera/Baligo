using System.Collections.Generic;
using Baligo.Console;
using Baligo.ConsoleDebugStats;
using Baligo.Entity.Items.Weapons;
using Baligo.Graphics;
using Baligo.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baligo.Entity.Characters.Players
{
    public class Hunter : Player
    {
        // Fields
        public const int InitialCountDown = 15;

        // Constructor
        public Hunter()
        {
            this.PlayerTexture = Assets.PlayerHunter.Texture;
            this.Arrows = new List<Arrow>();
            this.CountDown = InitialCountDown;
        }

        public List<Arrow> Arrows { get; set; }
        public int CountDown { get; set; }

        public override void Update(GameTime gmaTime)
        {
            // If an arrow is fired and countDown allows it
            if (InputManager.LeftButtomDown)
            {
                if (this.CountDown == 0)
                {
                    this.Arrows.Add(new Arrow(this.position, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), this.Arrows.Count + 1));
                    this.CountDown = 15;
                    BaligoConsole.WriteLine("Player arrow Spawned ID: " + this.Arrows.Count, Color.Red);
                    Statistics.TotalArrowsFired++;
                }
            }

            // Update each arrow
            for (int arrowId = 0; arrowId < Arrows.Count; arrowId++)
            {
                if (this.Arrows[arrowId].Timer > 0)
                {
                    this.Arrows[arrowId].Update();
                }
                else
                {
                    BaligoConsole.WriteLine("Player arrow Removed ID: " + this.Arrows[arrowId].Id, Color.Red);
                    this.Arrows.RemoveAt(arrowId);
                }
            }

            Statistics.PlayerHealth = Health;
            Statistics.PlayerAngle = Angle;

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
            
            base.Draw(spriteBatch);
        }
    }
}
