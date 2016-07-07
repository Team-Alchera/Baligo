using System.Linq;
using Baligo.Graphics;
using Baligo.Main;
using Microsoft.Xna.Framework.Graphics;
using File = System.IO.File;
using Point = Baligo.Pathfinding.Point;

namespace Baligo.World
{
    public class World
    {
        public Tile[,] WorldData;
        public Point[,] PointData;
        private const int WorldWidth = 43;
        private const int WorldHeigth = 24;
        private const int TileSize = 32;
        private readonly string pathToWorld;
        private const string DefaultPath = "./Content/Levels/";

        public World(string worldName)
        {
            WorldData = new Tile[WorldHeigth, WorldWidth];
            PointData = new Point[WorldHeigth, WorldWidth];
            pathToWorld = DefaultPath + worldName;

            LoadWord();
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int row = 0; row < 24; row++)
            {
                for (int col = 0; col < 43; col++)
                {
                    WorldData[row, col].Draw(spriteBatch, TileSize * col, TileSize * row);

                    if (BaligoEngine.IsDebugModeActive)
                    {
                        PointData[row, col].Draw(spriteBatch);
                    }
                }
            }
        }

        public void LoadWord()
        {
            string[] fileData = File.ReadLines(pathToWorld).ToArray();

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

            for (int rowPoint = 0; rowPoint < 24; rowPoint++)
            {
                for (int colPoint = 0; colPoint < 43; colPoint++)
                {
                    PointData[rowPoint, colPoint] = new Point(rowPoint * 32 + 12, colPoint * 32 + 12, WorldData[rowPoint, colPoint].IsSolid);
                }
            }
        }
    }
}
