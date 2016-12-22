using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools.Command
{
    public class ToolsTreeCommand : ImouseCommand
    {
        private ToolsTree toolsNodes ;
        private string message;


        public Node[,] ReadFile()
        {
          ConfigurationManager configuration = Wrapper.GetConfiguration("mouse");
          Node[,] nodes = configuration.GetNodeArray();
            if (nodes==null)
            {
                // a ameliorer ajouter dans les exceptions
                message = "The nodes array can't be null check the configuration";
                Wrapper.WriteLogFile(message);
                throw new Exception(message);
            }
            return nodes;
        }

        public List<Node> MousePath(Node[,] nodeArray)
        {
            toolsNodes = new ToolsTree(nodeArray);
            List<Node> listeNode = toolsNodes.GetPathList();
            if (listeNode == null)
            {
                message = "You don't have solution for your map your mouse is lock ";
                Wrapper.WriteLogFile(message);
                throw new Exception(message);
            }
            return listeNode;
        }
    
    }
}
