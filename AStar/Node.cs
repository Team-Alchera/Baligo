using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    public class Node
    {
        // ID
        public string Id;

        // Values
        public int GCost;
        public int HCost;
        public int FCost => GCost + HCost;

        // Position in grid
        public int Row;
        public int Col;

        // Walkable or not
        public bool IsSolid;
        public Node Parrent;

        // Constructor
        public Node(int row, int col)
        {
            IsSolid = false;
            this.Row = row;
            this.Col = col;

            Id = row + " | " + col;
        }
    }
}
