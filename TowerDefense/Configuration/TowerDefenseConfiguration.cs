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
    public class TowerDefenseConfiguration : MouseTools.ConfigurationManager
    {
        
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
        public List<Mob> getMobs()
        {
            return new List<Mob>();
        }

        public int getNbLifes()
        {
            string resultString = Regex.Match(Map, @"\d+").Value;
            return int.Parse(resultString);
        }

        public override string GetLog()
        {
            throw new NotImplementedException();
        }

       
        public override Node[,] GetNodeArray()
        {
            throw new NotImplementedException();
        }
    }
}
