using System.Collections.Generic;

namespace MouseTools
{
    public class Node
   {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public char Value { get; private set; }
        public bool Visited { get; set; }
        public Node Predecessor { get; set; }
        public List<Node> Successor { get; set; }

        public Node(int iheight, int iwidth)
        {
            Height = iheight;
            Width = iwidth;
            if (Successor == null)
            {
                Successor = new List<Node>();
            }
        }

        public Node(int iheight,int iwidth,char svalue):this(iheight,iwidth)
        {
            Value = svalue;
        }
    }
}
