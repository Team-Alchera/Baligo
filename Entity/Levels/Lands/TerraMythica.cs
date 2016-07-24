using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baligo.Entity.Levels.Lands
{
    class TerraMythica : Level
    {
        public TerraMythica()
        {
            this.Story = "I know you liked the chalga ryhimts, but it is time to go. Your journey ends in Terra Mythica." +
                 "You will meet legendary creatures, who are protecting their way of living and  traditions" +
                 "from the other tribes. They are aggressive, yet very timid if you approach them in the right way" +
                 "Don't forget to collect valuable itemsm, which will help you relent your enemies ";
        }

        public string Story { get; set; }
        public override void GetStory()
        {
        }
    }
}
