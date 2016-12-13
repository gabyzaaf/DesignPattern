using MouseTools.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools
{
    public class ToolsTree
    {
        public Node[,] nodes { get; private set; }
        private const char root = 'R';

        public ToolsTree(Node[,] nodeArray)
        {
            nodes = nodeArray;
        }

        public Tuple<int,int> GetRootPosition()
        {
            int height = nodes.GetLength(0);
            int width = nodes.GetLength(1);
            for (int i=0;i<height;i++)
            {
                for (int j = 0;j<width;j++)
                {
                    if (nodes[i,j].Value==root)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return null;
        }

        #region GET_LEFT_RIGHT_TOP_DOWN
        public Node GetLeft(int height,int width)
        {
            int arrayHeight = nodes.GetLength(0);
            int arrayWidth = nodes.GetLength(1);

            if (width < 0 || width > arrayWidth - 1)
            {
                return null;
            }

            if (width-1<0)
            {
                return null;
            }
            Node node = nodes[height, (width - 1)];
            if (node.Value=='*' || node.Visited)
            {
                return null;
            }
            return node;
        }

        public Node GetRight(int height, int width)
        {
            int arrayHeight = nodes.GetLength(0);
            int arrayWidth = nodes.GetLength(1);

            if (width < 0 || width > arrayWidth - 1)
            {
                return null;
            }
            if (width - 1 < 0)
            {
                return null;
            }
            Node node = nodes[height, (width + 1)];
            if (node.Value == '*' || node.Visited)
            {
                return null;
            }
            return node;
        }

        public Node GetTop(int height, int width)
        {
            int arrayHeight = nodes.GetLength(0);
            int arrayWidth = nodes.GetLength(1);

            if (height < 0 || height > arrayHeight -1)
            {
                return null;
            }
            if (height -1 < 0)
            {
                return null;
            }
            Node node = nodes[height-1, width];
            if (node.Value == '*' || node.Visited)
            {
                return null;
            }
            return node;
        }

        public Node GetDown(int height, int width)
        {
            int arrayHeight = nodes.GetLength(0);
            int arrayWidth = nodes.GetLength(1);

            if (height < 0 || height > arrayHeight - 1)
            {
                return null;
            }
            if (height + 1 > arrayHeight -1 )
            {
                return null;
            }
            Node node = nodes[height + 1, width];
            if (node.Value == '*' || node.Visited)
            {
                return null;
            }
            return node;
        }
        #endregion


        #region DIJKSTRA_ALGO
        private  Node CreateMousePath()
        {
            List<Node> pathList = new List<Node>();
            Tuple<int, int> coordonate = GetRootPosition();
            if (coordonate==null)
            {
                throw new Exception("The root node is null ");
            }
            int height = coordonate.Item1;
            int width = coordonate.Item2;
            pathList.Add(nodes[height, width]);
            while (pathList.Count!=0)
            {
                Node current = pathList[0];
                if (current.Visited==false)
                {
                    if (current.Value=='A')
                    {
                        Console.WriteLine("foundElement");
                        return current;

                    }
                    current.Visited = true;
                    Node right = new ChoiceNodeDirection(new Right()).getNode(nodes, current.Height, current.Width);
                    if (right!=null)
                    {
                        current.Successor.Add(right);
                        right.Predecessor = current;
                        pathList.Add(right);
                    }
                    Node left = new ChoiceNodeDirection(new Left()).getNode(nodes, current.Height, current.Width);
                    if (left != null)
                    {
                        current.Successor.Add(left);
                        left.Predecessor = current;
                        pathList.Add(left);
                    }
                    Node top = new ChoiceNodeDirection(new Top()).getNode(nodes, current.Height, current.Width);
                    if (top != null )
                    {
                        current.Successor.Add(top);
                        top.Predecessor = current;
                        pathList.Add(top);
                    }
                    Node down = new ChoiceNodeDirection(new Down()).getNode(nodes, current.Height, current.Width);
                    if (down != null)
                    {
                        current.Successor.Add(down);
                        down.Predecessor = current;
                        pathList.Add(down);
                    }
                }
                pathList.RemoveAt(0);
            }
            return null;
        }
        #endregion

        public List<Node> GetPathList()
        {
            List<Node> pathList = new List<Node>();
            Node path = CreateMousePath();
            if (path == null)
            {
                return null;
            }
            while (path.Value!=root)
            {
               pathList.Add(path);
                path = path.Predecessor;
            }
            pathList.Add(path);
            pathList.Reverse();
            return pathList;
           
        }
    }
}
