using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools.Strategy
{
    public class ChoiceNodeDirection
    {
        IgetNode choiceNode;

        public ChoiceNodeDirection(IgetNode ichoiceNode)
        {
            choiceNode = ichoiceNode;
        }

        public Node getNode(Node[,] nodes,int height,int width)
        {
            return choiceNode.getNode(nodes,height,width);
        }

    }
}
