using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools
{
   public class Node
   {
        public int height { get; private set; }
        public int width { get; private set; }
        public char value { get; private set; }
        public int visited { get; set; }
        public Node Predecessor { get; set; }
        public List<Node> successor { get; set; }

        public Node(int iheight,int iwidth,char svalue)
        {
            height = iheight;
            width = iwidth;
            value = svalue;
            init_List();

        }

        public Node(int iheight, int iwidth)
        {
            height = iheight;
            width = iwidth;
            init_List();
        }

        private void init_List()
        {
            if (successor == null)
            {
                successor = new List<Node>();
            }
        }




    }
}
