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
        public string getMobType()
        {
            return settingsByKeys["typeMobs"];
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
                    switch (line[j])
                    {
                        case 'T':
                            List<AbstractTowerMob> towerList = new List<AbstractTowerMob>();
                            towerList.Add(new Tower("Tower", "test", 100, 100, 10));
                            nodes[i, j] = new NodeTowerMob(i, j, line[j], towerList);
                            break;
                        case 'R':
                            // On met tout les mobs sur le node de départ
                            List<AbstractTowerMob> mobList = new List<AbstractTowerMob>();
                            mobList = createMobList();
                            nodes[i, j] = new NodeTowerMob(i, j, line[j], mobList);
                            break;
                        default:
                            nodes[i, j] = new Node(i, j, line[j]);
                            break;

                    }
                }
                i++;
            }
            CheckValue(nodes, root);
            CheckValue(nodes, arrived);
            return nodes;
        }

        /*
         * Méthode qui permet de créer la liste de mob de la map par rapport au nombre et au type qui ont été paramétrés dans le app.config
         * 
         */
        public List<AbstractTowerMob> createMobList()
        {
            List<AbstractTowerMob> mobsList = new List<AbstractTowerMob>();
            for(int a = 0; a < getNbMobs(); a++)
            {
                mobsList.Add(new Mob("Mob", getMobType()+" "+a, 100, 10));
            }

            return mobsList;
        }
    }
}
