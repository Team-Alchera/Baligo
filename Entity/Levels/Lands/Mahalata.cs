﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baligo.Entity.Levels.Lands
{
    class Mahalata : Level
    {
        public Mahalata()
        {
            this.Story = "You just left наЦентАра. It was a nice land, isn't it? Now you should go in the deep dark sites of the Ma'alata" +
                        "Inhabited by the exotic Roma people, Ma'alata is not the quiteest place to stay bacause of the non-stop" +
                        "chalga rythims.Romas are the poorest people in Baligo and always tricks people with their strange street games" +
                        "Don't forget to collect valuable itemsm, which will help you relent your enemies ";
        }
        public string Story { get; set; }
        public override string GetStory()
        {
            return this.Story;
        }
    }
}
