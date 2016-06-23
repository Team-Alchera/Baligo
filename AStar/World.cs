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
        public static Point StartPoint;
        public static Point FinishPoint;

        public static Texture2D Box;
        private static int _count;
        public static Point[,] Board;

        public static void Init(ContentManager content)
        {
            _count = 7;
            Board = new Point[12, 18];

            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 18; col++)
                {
                    Board[row, col] = new Point(row, col);
                }
            }

            Box = content.Load<Texture2D>("box");
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

            if (_count - 1 >= 0)
            {
                _count--;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 18; col++)
                {
                    spriteBatch.Draw(Box, new Vector2(col*64, row*64), new Rectangle(0, 0, 64, 64),
                        Board[row, col].IsSolid ? Color.Black : Color.White);
                }
            }

            // Draw Start
            if (StartPoint != null)
            {
                spriteBatch.Draw(Box, new Vector2(StartPoint.Col * 64, StartPoint.Row * 64), new Rectangle(0, 0, 64, 64), Color.LimeGreen);
            }

            // Draw Finish
            if (FinishPoint != null)
            {
                spriteBatch.Draw(Box, new Vector2(FinishPoint.Col * 64, FinishPoint.Row * 64), new Rectangle(0, 0, 64, 64), Color.Blue);
            }
        }

        public static void SetStartPoint()
        {
            int col = Mouse.GetState().X / 64;
            int row = Mouse.GetState().Y / 64;

            if (Board[row,col].IsSolid == false)
            {
                if (row >= 0 && row < 12)
                {
                    if (col >= 0 && col < 18)
                    {
                        StartPoint = new Point(row, col);
                        Console.WriteLine("New start point");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Start Point!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void SetFinishPoint()
        {
            int col = Mouse.GetState().X / 64;
            int row = Mouse.GetState().Y / 64;

            if (Board[row, col].IsSolid == false)
            {
                if (row >= 0 && row < 12)
                {
                    if (col >= 0 && col < 18)
                    {
                        FinishPoint = new Point(row, col);
                        Console.WriteLine("New Finish Point");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Finish Point!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void UpdateBox()
        {
            int col = Mouse.GetState().X / 64;
            int row = Mouse.GetState().Y / 64;

            if (row >= 0 && row < 12)
            {
                if (col >= 0 && col < 18)
                {
                    Board[row, col].IsSolid = !Board[row, col].IsSolid;
                    Console.WriteLine("Pressed");
                }
            }
        }
    }
}
