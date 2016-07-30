using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baligo.Contracts
{
    public interface IStory
    {
        string Story { get; set; }
        string GetStory();
    }
}
