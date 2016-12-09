using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MouseTools
{
    public class MouseConfiguration : ConfigurationManager
    {
        const char star = '*';

        public override string GetLog()
        {
            if (!dicos.ContainsKey("log"))
            {
                return null;
            }
            if (String.IsNullOrEmpty(dicos["log"]))
            {
                return null;
            }else
            {
                string log = dicos["log"];
                if (!Directory.Exists(log)) {
                    return null;
                }
                else
                {
                    return log;
                }
            }
        }

        public override string[] GetArray()
        {
            if (!dicos.ContainsKey("file"))
            {
                return null;
            }
            if (String.IsNullOrEmpty(dicos["file"]))
            {
                return null;
            }
            string file = dicos["file"];
            string[] lines = File.ReadAllLines(file);
            int size = lines.Count();
            if (size==0)
            {
                return null;
            }
            int sizeLine = 0;
            foreach (string value in lines)
            {
                sizeLine = value.Count();
                if (value[0]!=star || value[sizeLine-1]!= star)
                {
                    return null;
                }
            }
            return lines;
        }

        public override Node[,] GetNodeArray()
        {
            Node[,] nodes = null;
            try
            {
                string[] array = GetArray();
                int height = array.GetLength(0);
               nodes = new Node[height, array[0].Count()];
                int width = nodes.GetLength(1);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        nodes[i, j] = new Node(i, j);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            return nodes;
        }
    }
}
