using System;
using System.Linq;
using System.IO;
namespace MouseTools
{
    public class MouseConfiguration : ConfigurationManager
    {
        protected const char wall = '*';
        protected const char root = 'R';
        protected const char arrived = 'A';
        private const string logPath = "log";
        private const string filePath = "file";

        
        #region LOG_PATH
        public override Log GetLog()
        {
            if (!settingsByKeys.ContainsKey(logPath))
            {
                throw new Exception("the dictionnary don't contains the key log ");
            }
            if (String.IsNullOrEmpty(settingsByKeys[logPath]))
            {
                throw new Exception("The log values not exist ");
            }
            
            string log = settingsByKeys[logPath];
            if (!Directory.Exists(log))
            {
                throw new Exception("the directory not exist ");
            }
            else
            {
                return new Log(log);
            }
        }
        #endregion

        #region CREATE_STRING_ARRAY
        private  string[] GetArray()
        {
            if (!settingsByKeys.ContainsKey(filePath))
            {
                throw new Exception("the dictionnary doesn't contains the key file ");
            }
            if (String.IsNullOrEmpty(settingsByKeys[filePath]))
            {
                throw new Exception("the value from the key file in the dictionnary is null or empty  ");
            }
            string file = settingsByKeys[filePath];
            if (!File.Exists(file))
            {
                throw new Exception("the file node exist in your hard disk");
            }
            string[] lines = File.ReadAllLines(file);
            if (lines == null || lines.Count() == 0)
            {
                throw new Exception("the file doesn't contain value inside");
            }
            CheckLineNode(lines[0]);
            CheckLineNode(lines[lines.Length - 1]);
            int sizeLine = 0;
            foreach (string value in lines)
            {
                sizeLine = value.Count();
                if (value[0] != wall || value[sizeLine - 1] != wall)
                {
                    throw new Exception("No wall in border");
                }
            }
            return lines;
        }
        
        public void CheckLineNode(string line)
        {
            for (int i = 0;i<line.Length;i++)
            {
                if (line[i]!=wall)
                {
                    throw new Exception("The line need to contains only wall");
                }
            }
        }
        
        
        #endregion



        #region CREATE_CHECK_NODE_ARRAY
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
            CheckValue(nodes, root);
            CheckValue(nodes, arrived);
            return nodes;
        }

        public void CheckValue(Node[,] array, char value)
        {
            int foundValue = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[i, j].Value == value)
                    {
                        foundValue++;
                    }
                }
            }
            if (foundValue != 1)
            {
                throw new Exception(String.Format("You need to have only {0} in your array  ", value));
            }
        }
        #endregion
    }

}

