using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Graphics;
using Microsoft.Xna.Framework.Graphics;
using File = System.IO.File;

namespace Baligo.World
{
    public class World
    {
        public Tile[,] WorldData;
        private const int WordWidth = 42;
        private const int WorldHeigth = 24;
        private const int TileSize = 32;
        private readonly string _pathToWorld;
        private const string DefaultPath = "./Content/Levels/";

        public World(string worldName)
        {
            WorldData = new Tile[WorldHeigth, WordWidth];
            _pathToWorld = DefaultPath + worldName;

            LoadWord();
        }

        public void Update()
        {

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int row = 0; row < 24; row++)
            {
                for (int col = 0; col < 42; col++)
                {
                    WorldData[row,col].Draw(spriteBatch, TileSize * col, TileSize * row);
                }
            }
        }

        public void LoadWord()
        {
            string[] fileData = File.ReadLines(_pathToWorld).ToArray();

            int row = 0;
            int col = 0;
            foreach (var currentRow in fileData)
            {
                foreach (var currentCol in currentRow.Split(' '))
                {
                    int a = int.Parse(currentCol);
                    WorldData[row, col] = new Tile(Tile.GetTile(a));
                    col++;
                }
                col = 0;
                row++;
            }
        }
    }
}
