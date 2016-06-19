using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baligo.ConsoleDebugStats
{
    public static class Statistics
    {
        public static int PlayerHealth { get; set; }
        public static float PlayerAngle { get; set; }

        public static int TotalArrowsFired { get; set; }
        public static int TotalArrowsMissed { get; set; }

        public static int TotalEnemyKilled { get; set; }
    }
}
