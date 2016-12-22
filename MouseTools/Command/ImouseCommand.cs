using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools.Command
{
    public interface ImouseCommand
    {
        Node[,] ReadFile();
        List<Node> MousePath(Node[,] nodeArray);

    }
}
