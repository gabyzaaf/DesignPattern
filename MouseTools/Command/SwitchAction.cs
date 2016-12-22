using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools.Command
{
    public class SwitchAction
    {
        public Node[,] ExecuteReadFile(ImouseCommand command)
        {
            Node[,] nodes = null;
            try
            {
                nodes = command.ReadFile();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return nodes;
        }

        public List<Node> ExecuteMousePath(ImouseCommand command,Node[,] nodeArray)
        {
            List<Node> nodeMousePath = null;
            try
            {
                nodeMousePath = command.MousePath(nodeArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return nodeMousePath;
        }
    }
}
