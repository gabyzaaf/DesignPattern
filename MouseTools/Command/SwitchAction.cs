using System;
using System.Collections.Generic;

namespace MouseTools.Command
{
    public class SwitchAction
    {
        public Node[,] ExecuteReadMap(ImouseCommand command)
        {
            Node[,] nodes = null;
            try
            {
                nodes = command.ReadMap();
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
