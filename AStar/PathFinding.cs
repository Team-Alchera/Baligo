using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    public static class PathFinding
    {
        public static void FindPath(Node startNode, Node endNode)
        {
            List<Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                openSet = openSet.OrderBy(a => a.FCost).ToList();
                Node currentNode = openSet.First();

                openSet.RemoveAt(0);
                closedSet.Add(currentNode);

                // Check if we end
                if (currentNode.Id == endNode.Id)
                {
                    Console.WriteLine("Found it");
                    return;
                }
            }
        }

        public static void RetracePath(Node startNode, Node endNode)
        {

        }

        public static int GetDistance(Node nodeA, Node nodeB)
        {
            return 0;
        }
    }
}
