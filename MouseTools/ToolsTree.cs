using MouseTools.Strategy;
using System;
using System.Collections.Generic;

namespace MouseTools
{
    public class ToolsTree
    {
        public Node[,] nodes { get; private set; }
        protected const char root = 'R';
        protected const char wall = '*';

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
                        return current;
                    }
                    current.Visited = true;
                    Node right = Wrapper.GetNodeDirection("Right", nodes, current.Height, current.Width);
                    if (right!=null)
                    {
                        current.Successor.Add(right);
                        right.Predecessor = current;
                        pathList.Add(right);
                    }
                   Node left = Wrapper.GetNodeDirection("Left", nodes, current.Height, current.Width);
                    if (left != null)
                    {
                        current.Successor.Add(left);
                        left.Predecessor = current;
                        pathList.Add(left);
                    }
                   Node top = Wrapper.GetNodeDirection("Top", nodes, current.Height, current.Width);
                    if (top != null )
                    {
                        current.Successor.Add(top);
                        top.Predecessor = current;
                        pathList.Add(top);
                    }
                    Node down = Wrapper.GetNodeDirection("Down", nodes, current.Height, current.Width);
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
            Node finalPath = CreateMousePath();
            if (finalPath == null)
            {
                return null;
            }
            while (finalPath.Value!=root)
            {
                pathList.Add(finalPath);
                finalPath = finalPath.Predecessor;
            }
            pathList.Add(finalPath);
            pathList.Reverse();
            return pathList;
           
        }
    }
}
