using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MouseTools;
using TowerDefense.Factory;

namespace TowerDefense.Classes
{
    public class TowerDefenseConfiguration : MouseTools.MouseConfiguration
    {
        //public const char root = 'R';
        //public const char arrived = 'A';
        public string Map { get; set; }
        private string filePath = "file";
        public string[] GetArray()
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
            AbstractTowerMob tower = TowerDefenseFactory.buildMobOrTower("Tower", "Tower1", 90, 0, 100, 100);
            AbstractTowerMob mob = TowerDefenseFactory.buildMobOrTower("Mob", getMobType(), 50, 100, 10, 10);
            string previous = "";
            foreach (string line in array)
            {
                for (int j = 0; j < line.Count(); j++)
                {
                    switch (line[j])
                    {
                        case 'T':
                            nodes[i, j] = new NodeTowerMob(i, j, line[j], tower, false);

                            //Création des zones de tirs
                            if(line[j + 1] == '+')
                            {
                                nodes[i, j + 1] = new NodeTowerMob(i, j + 1, line[j + 1], null, true);
                            }
                            if (line[j - 1] == '+')
                            {
                                nodes[i, j - 1] = new NodeTowerMob(i, j - 1, line[j - 1], null, true);
                            }
                            break;
                        case 'R':
                            nodes[i, j] = new NodeTowerMob(i, j, line[j], mob, false);
                            break;
                        default:
                            if(line[j] == '+')
                            { 
                                if (nodes[i - 1, j].Value == 'T')
                                {
                                    nodes[i, j] = new NodeTowerMob(i, j, line[j], null, true);
                                    break;
                                }
                            }
                            if(nodes[i, j] == null)
                                {
                                    nodes[i, j] = nodes[i, j] = new NodeTowerMob(i, j, line[j], null, false);
                                break;
                                }
                            else
                            {
                                break;
                            }
                            
                    }
                }
                i++;
                previous = line;
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
            for (int a = 0; a < getNbMobs(); a++)
            {
                mobsList.Add(new Mob("Mob", getMobType() + " " + a, 100, 10));
            }

            return mobsList;
        }

        public List<Mob> getMobsFromMap(Node[,] nodeArrayMap)
        {
            List<Mob> mobs = new List<Mob>();
            foreach (Node node in nodeArrayMap)
            {
                if (node.GetType() == typeof(NodeTowerMob))
                {
                    NodeTowerMob nodeToAdd = (NodeTowerMob)node;
                    if (nodeToAdd.Type != null && nodeToAdd.Type.GetType() == typeof(Mob))
                    {
                        mobs.Add((Mob)nodeToAdd.Type);
                    }
                }
            }
            return mobs;
        }

    } 
}
