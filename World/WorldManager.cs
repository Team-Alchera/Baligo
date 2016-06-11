using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baligo.World
{
    public static class WorldManager
    {
        public static Dictionary<string, World> Worlds;
        private static string _currentWorld;

        // All the worlds
        public static World Level1;
        public static World Level2;
        public static World Level3;

        public static void Init()
        {
            Worlds = new Dictionary<string, World>();
            _currentWorld = "level_1";

            // Create worlds
            Level1 = new World("Level1.txt");
            Level2 = new World("Level2.txt");
            Level3 = new World("Level3.txt");

            // Add the worlds
            Worlds.Add("level_1", Level1);
            Worlds.Add("level_2", Level2);
            Worlds.Add("level_3", Level3);
        }

        public static void SetCurrentWorld(string nameOfWorld)
        {
            _currentWorld = nameOfWorld;
        }

        public static World GetCurrentWorld()
        {
            return Worlds[_currentWorld];
        }
    }
}
