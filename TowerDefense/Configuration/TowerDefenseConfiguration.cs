using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MouseTools;

namespace TowerDefense.Classes
{
    public class TowerDefenseConfiguration : MouseTools.MouseConfiguration
    {
        //public const char root = 'R';
        //public const char arrived = 'A';
        public string Map { get; set; }
 
        public Map getMap()
        {
            return new Map();
        }

        public string[] getContentFiles()
        {
            return GetArray();
        }

        public int getNbTower()
        {
            
            int nbTowers = Map.Count(x => x == 'T');
            return nbTowers;
        }
        public int getNbMobs()
        {
            return int.Parse(settingsByKeys["nbMobs"]);
        }

        public int getNbLifes()
        {

            return int.Parse(settingsByKeys["nbLifes"]); 
        }

        public override Log GetLog()
        {
            throw new NotImplementedException();
        }

       
        public override Node[,] GetNodeArray()
        {
            Console.WriteLine("ca aa");
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
                    if(line[j] == 'T')
                    {
                        nodes[i, j] = new NodeTowerMob(i, j, line[j], new Tower("tower","test",100,100,10));
                    }
                    else
                    {
                        nodes[i, j] = new Node(i, j, line[j]);
                    }
                    
                }
                i++;
            }
            CheckValue(nodes, root);
            CheckValue(nodes, arrived);
            return nodes;
        }
    }
}
