using System;
using System.Linq;
using System.IO;
namespace MouseTools
{
    public class MouseConfiguration : ConfigurationManager
    {
        const char star = '*';
        const char root = 'R';
        const char arrived = 'A';

        public override string GetLog()
        {
            if (!dicos.ContainsKey("log"))
            {
                throw new Exception("the dictionnary don't contains the key log ");
            }
            if (String.IsNullOrEmpty(dicos["log"]))
            {
                throw new Exception("The log values not exist ");
            }
            else
            {
                string log = dicos["log"];
                if (!Directory.Exists(log))
                {
                    throw new Exception("the directory not exist ");
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
                throw new Exception("the dictionnary don't contains the key file ");
            }
            if (String.IsNullOrEmpty(dicos["file"]))
            {
                throw new Exception("the value from the key file in the dictionnary is null or empty  ");
            }
            string file = dicos["file"];
            string[] lines = File.ReadAllLines(file);
            int size = lines.Count();
            if (size == 0)
            {
                throw new Exception("the file don't contain value inside");
            }
            int sizeLine = 0;
            foreach (string value in lines)
            {
                sizeLine = value.Count();
                if (value[0] != star || value[sizeLine - 1] != star)
                {
                    throw new Exception("The wall is not identic ");
                }
            }
            return lines;
        }

        public override Node[,] GetNodeArray()
        {
            Node[,] nodes = null;
            string[] array = GetArray();
            int height = array.GetLength(0);
            nodes = new Node[height, array[0].Count()];
            int width = nodes.GetLength(1);
            int i = 0;
            foreach (string line in array)
            {
                for (int j = 0; j < line.Count(); j++)
                {
                    nodes[i, j] = new Node(i, j, line[j]);
                }
                i++;
            }
            CheckOneRoot(nodes);
            CheckArrived(nodes);
            return nodes;
        }

        private void CheckOneRoot(Node[,] array)
        {

            int foundRoot = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[i, j].value == root)
                    {
                        foundRoot++;
                    }
                }
            }
            if (foundRoot != 1)
            {
                throw new Exception(String.Format("You need to have only on root point in your array {0} ", root));
            }
        }


        private void CheckArrived(Node[,] array)
        {
            int foundArrived = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[i, j].value == arrived)
                    {
                        foundArrived++;
                    }
                }
            }
            if (foundArrived != 1)
            {
                throw new Exception(String.Format("the array need to be with single arrived {0}",arrived));
            }
            
        }
    }

}

