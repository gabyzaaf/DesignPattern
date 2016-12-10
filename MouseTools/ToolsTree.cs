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

    }
}
