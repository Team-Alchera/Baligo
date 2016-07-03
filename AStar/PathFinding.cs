using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    public static class PathFinding
    {
        public static List<Node> Path;

        public static void FindPath(Node startNode, Node endNode)
        {
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            openList.Add(startNode);
            // Node currentNode;

            bool foundPath = false;
            while (openList.Count > 0)
            {
                // Sort the list
                openList = openList.OrderBy(a => a.FCost).ToList();

                // Get the best node
                // currentNode = openList.First();
                Console.WriteLine(openList.First().Row + " " + openList.First().Col);

                if (openList.First().Row == endNode.Row && openList.First().Col == endNode.Col)
                {
                    Console.WriteLine("Found");
                    GetPath(openList.First());
                    foundPath = true;
                    break;
                }

                foreach (var nearByNode in GetNearByNodes(openList.First()))
                {
                    if (DoesContain(closedList, nearByNode) == false && DoesContain(openList,nearByNode) == false)
                    {
                        nearByNode.Parrent = openList.First();
                        nearByNode.Calc();
                        openList.Add(nearByNode);
                    }
                }

                closedList.Add(openList.First());
                openList.RemoveAt(0);
            }

            if (!foundPath)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO PATH POSSIBLE");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public static bool DoesContain(List<Node> nodes, Node checkNode)
        {
            return nodes.Any(node => node.Id == checkNode.Id);
        }

        public static void GetPath(Node current)
        {
            Path = new List<Node>();
            Node asd = current.Clone();

            while (asd.Parrent != null)
            {
                Path.Add(asd);
                if (asd.Parrent != null)
                {
                    asd = asd.Parrent.Clone();
                }
                else
                {
                    break;
                }
            }

            Path.Reverse();
        }

        public static List<Node> GetNearByNodes(Node currentNode)
        {
            var neighbours = new List<Node>();

            int currentRow = currentNode.Row;
            int currentCol = currentNode.Col;

            for (int row = -1; row <= 1; row++)
            {
                for (int col = -1; col <= 1; col++)
                {
                    if (col == 0 && row == 0)
                    {
                        continue;
                    }
                    if (DoesNodeExist(row + currentRow, col + currentCol))
                    {
                        if (World.Board[row + currentRow, col + currentCol].IsSolid == false)
                        {
                            neighbours.Add(World.Board[row + currentRow, col + currentCol]);
                        }
                    }
                }
            }

            return neighbours;
        }

        public static bool DoesNodeExist(int row, int col)
        {
            if (row >= 0 && row < 12)
            {
                if (col >= 0 && col < 18)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
