using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    public class Point
    {
        public int Row = 0;
        public int Col = 0;

        public bool IsSolid;

        public Point(int row,int col)
        {
            IsSolid = false;
            this.Row = row;
            this.Col = col;
        }
    }
}
