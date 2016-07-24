using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Contracts;

namespace Baligo.Entity.Levels
{
    abstract class Level : IStory
    {
        public Level()
        {
        }
        public string Story { get; set; }
        public abstract void GetStory();
    }
}
