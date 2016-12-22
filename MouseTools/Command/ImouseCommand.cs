using System.Collections.Generic;

namespace MouseTools.Command
{
    public interface ImouseCommand
    {
        Node[,] ReadMap();
        List<Node> MousePath(Node[,] nodeArray);

    }
}
