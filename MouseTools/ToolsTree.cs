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
                    if (nodes[i,j].value==root)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return null;
        }

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
            if (node.value=='*')
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
            if (node.value == '*')
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
            if (node.value == '*')
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
            if (node.value == '*')
            {
                return null;
            }
            return node;
        }
    }
}
