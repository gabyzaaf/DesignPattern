using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools.Strategy
{
  public class Left : IgetNode
    {

        private const char wall = '*';
        public Node getNode(Node[,] nodes, int height, int width)
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
            Node node = nodes[height, (width - 1)];
            if (node.Value == wall || node.Visited)
            {
                return null;
            }
            return node;
        }
    }
}
