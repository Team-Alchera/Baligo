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

            GCost = 0;
            HCost = 0;

            Id = row + " | " + col;
        }

        public void Calc()
        {
            if (Parrent != null)
            {
                GCost = Parrent.GCost + 1;
            }
            
            HCost = Math.Abs(Col - World.FinishNode.Col) +
                    Math.Abs(Row - World.FinishNode.Row);
        }

        public Node Clone()
        {
            Node a = new Node(this.Row, this.Col);

            a.Id = this.Id;
            a.GCost = this.GCost;
            a.HCost = this.HCost;
            a.IsSolid = this.IsSolid;
            a.Parrent = this.Parrent;

            return a;
        }
    }
}
