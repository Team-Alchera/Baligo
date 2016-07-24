using System.Collections.Generic;
using Baligo.Console;
using Baligo.ConsoleDebugStats;
using Baligo.Entity.Items.Weapons;
using Baligo.Graphics;
using Baligo.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players
{
    public class Mage : Player
    {
        // Fields             
        //public const int InitialCountDown = 15;

        // Constructor
        public Mage()
        {
            PlayerTexture = Assets.PlayerMage.Texture;
            
        }



    }
}
