using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AStar
{
    public static class World
    {
        public static Node StartNode;
        public static Node FinishNode;

        public static Texture2D Box;
        public static SpriteFont Font;
        private static int _count;
        public static Node[,] Board;

        public static void Init(ContentManager content)
        {
            _count = 7;
            Board = new Node[12, 18];

            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 18; col++)
                {
                    Board[row, col] = new Node(row, col);
                }
            }

            Box = content.Load<Texture2D>("box");
            Font = content.Load<SpriteFont>("Id");
        }

        public static void Update()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && _count == 0)
            {
                UpdateBox();
                _count = 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && _count == 0)
            {
                SetStartPoint();
                _count = 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && _count == 0)
            {
                SetFinishPoint();
                _count = 7;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F1) && _count == 0)
            {
                Console.WriteLine("Finding...");
                PathFinding.FindPath(StartNode, FinishNode);

                _count = 7;
            }

            // =================
            if (_count - 1 >= 0)
                _count--;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw the basic shape with white and black
            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 18; col++)
                {
                    spriteBatch.Draw(Box, new Vector2(col * 64, row * 64), new Rectangle(0, 0, 64, 64),
                        Board[row, col].IsSolid ? Color.Black : Color.White);
                }
            }
            
            // Draw Text
            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 18; col++)
                {
                    spriteBatch.DrawString(Font, Board[row, col].FCost == 0 ? "X" : Board[row, col].FCost.ToString(), 
                        new Vector2(col * 64 + 25, row * 64 + 22), Color.LightSlateGray);
                }
            }

            if (PathFinding.Path != null)
            {
                int a = 1;
                foreach (var node in PathFinding.Path)
                {
                    spriteBatch.Draw(Box, new Vector2(node.Col * 64, node.Row * 64),
                        new Rectangle(0, 0, 64, 64), Color.Yellow);
                    spriteBatch.DrawString(Font, a.ToString() + "\n" + node.FCost, 
                        new Vector2(node.Col * 64 + 10, node.Row * 64 + 10), Color.Blue);
                    a++;
                }
            }

            // Draw Start
            if (StartNode != null)
            {
                spriteBatch.Draw(Box, new Vector2(StartNode.Col * 64, StartNode.Row * 64),
                    new Rectangle(0, 0, 64, 64), Color.LimeGreen);
            }

            // Draw Finish
            if (FinishNode != null)
            {
                spriteBatch.Draw(Box, new Vector2(FinishNode.Col * 64, FinishNode.Row * 64),
                    new Rectangle(0, 0, 64, 64), Color.Blue);
            }
        }

        public static List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int row = -1; row <= 1; row++)
            {
                for (int col = -1; col <= 1; col++)
                {
                    if (row == 0 && col == 0)
                        continue;

                    int checkRow = node.Row + row;
                    int checkCol = node.Col + col;

                    if (checkRow >= 0 && checkRow < 12 && checkCol >= 0 && checkCol < 18)
                    {
                        if (!Board[checkRow, checkCol].IsSolid)
                        {
                            neighbours.Add(Board[checkRow, checkCol]);
                        }
                    }
                }
            }

            return neighbours;
        }

        public static void SetStartPoint()
        {
            int col = Mouse.GetState().X / 64;
            int row = Mouse.GetState().Y / 64;

            if (row >= 0 && row < 12 && col >= 0 && col < 18)
            {
                if (Board[row, col].IsSolid == false)
                {
                    if (row >= 0 && row < 12)
                    {
                        if (col >= 0 && col < 18)
                        {
                            StartNode = new Node(row, col);
                            Console.WriteLine("New start point");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Start Node!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (StartNode != null && FinishNode != null)
                {
                    PathFinding.FindPath(StartNode, FinishNode);
                }
            }
        }

        public static void SetFinishPoint()
        {
            int col = Mouse.GetState().X / 64;
            int row = Mouse.GetState().Y / 64;

            if (row>= 0 && row < 12 && col >= 0 && col < 18)
            {
                if (Board[row, col].IsSolid == false)
                {
                    if (row >= 0 && row < 12)
                    {
                        if (col >= 0 && col < 18)
                        {
                            FinishNode = new Node(row, col);
                            Console.WriteLine("New Finish Node");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Finish Node!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (StartNode != null && FinishNode != null)
                {
                    PathFinding.FindPath(StartNode, FinishNode);
                }
            }
        }

        public static void UpdateBox()
        {
            int col = Mouse.GetState().X / 64;
            int row = Mouse.GetState().Y / 64;

            if (row >= 0 && row < 12 && col >= 0 && col < 18)
            {
                if (row >= 0 && row < 12)
                {
                    if (col >= 0 && col < 18)
                    {
                        Board[row, col].IsSolid = !Board[row, col].IsSolid;
                        Console.WriteLine("Pressed");
                    }
                }

                if (StartNode != null && FinishNode != null)
                {
                    PathFinding.FindPath(StartNode, FinishNode);
                }
            }

            
        }
    }
}
