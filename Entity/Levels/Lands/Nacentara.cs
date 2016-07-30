using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baligo.Entity.Levels.Lands
{
    class Nacentara : Level
    {
        public Nacentara()
        {
            this.Story = "You already entered the magic land of Baligo. The land of наЦентАра welcomes you. Here is where your" +
                          "jorney starts. наЦентАра people are proud ancestors of the of the Първенюта tribe and always show off with" +
                          "wealth and knowledge. Be aware of their uncommon fetishes" +
                          "Don't forget to collect valuable itemsm, which will help you relent your enemies ";
        }
        public string Story { get; set; }
        public override string GetStory()
        {
            return this.Story;
        }
    }
}
