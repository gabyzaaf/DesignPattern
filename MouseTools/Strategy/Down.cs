using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools.Strategy
{
   public class Down : IgetNode
    {
        
        public Node getNode(Node[,] nodes, int height, int width)
        {
            int arrayHeight = nodes.GetLength(0);
            int arrayWidth = nodes.GetLength(1);

            if (height < 0 || height > arrayHeight - 1)
            {
                return null;
            }
            if (height + 1 > arrayHeight - 1)
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
    }
}
