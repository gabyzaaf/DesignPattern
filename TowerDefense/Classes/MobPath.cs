using MouseTools;
using MouseTools.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TowerDefense.Classes
{
    public class MobPath : ToolsTree
    {
        public MobPath(Node[,] nodeArray) : base(nodeArray)
        {
        }

        private Node CreateMobPath()
        {
            List<Node> pathList = new List<Node>();
            Tuple<int, int> coordonate = GetRootPosition();
            ChoiceNodeDirection choiceNodeDirection;

            if (coordonate == null)
            {
                throw new Exception("The root node is null ");
            }

            int height = coordonate.Item1;
            int width = coordonate.Item2;
            pathList.Add(nodes[height, width]);
            while (pathList.Count != 0)
            {
                Node current = pathList[0];
                if (current.Visited == false)
                {
                    if (current.Value == 'A')
                    {
                        return current;
                    }
                    current.Visited = true;
                    Node right = Wrapper.GetNodeDirection("Right", nodes, current.Height, current.Width);
                    if (right != null && (right.Value == '+' || right.Value == 'A'))
                    {
                        current.Successor.Add(right);
                        right.Predecessor = current;
                        pathList.Add(right);
                    }
                    Node left = Wrapper.GetNodeDirection("Left", nodes, current.Height, current.Width);
                    if (left != null && (left.Value == '+' || left.Value == 'A'))
                    {
                        current.Successor.Add(left);
                        left.Predecessor = current;
                        pathList.Add(left);
                    }
                    Node top = Wrapper.GetNodeDirection("Top", nodes, current.Height, current.Width);
                    if (top != null && (top.Value == '+' || top.Value == 'A'))
                    {
                        current.Successor.Add(top);
                        top.Predecessor = current;
                        pathList.Add(top);
                    }
                    Node down = Wrapper.GetNodeDirection("Down", nodes, current.Height, current.Width);
                    if (down != null && (down.Value == '+' || down.Value == 'A'))
                    {
                        current.Successor.Add(down);
                        down.Predecessor = current;
                        pathList.Add(down);
                    }
                }
                pathList.RemoveAt(0);
            }
            return null;
        }

        public override List<Node> GetPathList()
        {
            List<Node> pathList = new List<Node>();
            Node finalPath = CreateMobPath();
            if (finalPath == null)
            {
                return null;
            }
            while (finalPath.Value != root)
            {
                pathList.Add(finalPath);
                finalPath = finalPath.Predecessor;
            }
            pathList.Add(finalPath);
            pathList.Reverse();
            return pathList;

        }
        
        public Node[,] deplacerMob(Mob mob, List<Node> path, Node[,] nodeArray)
        {
            Node[,] nodeArrayToReturn = nodeArray;

            // on recopie les emplacements de déplacements des mobs dans la carte nodeArray
            foreach (Node n in path)
            {
                    if(nodeArray[n.Height, n.Width].GetType() == typeof(NodeTowerMob))
                    {
                        NodeTowerMob nt = (NodeTowerMob)nodeArray[n.Height, n.Width];
                        // par défaut les tours enlève 10 de vies au mob
                        if(nt.isZoneTir == true)
                        {
                            mob.Hp = mob.Hp - 10;
                        }
                        if(mob.Hp != 0)
                        {
                            nodeArrayToReturn[n.Height, n.Width] = new NodeTowerMob(n.Height, n.Width, nodeArray[n.Height, n.Width].Value, new Mob(mob.Nom, mob.Type, mob.Hp, mob.Vitesse), nt.isZoneTir);
                        }
                        // Si le mob n'a plus de vie alors il est mort on place un M sur la map pour identifier l'emplacement de sa mort
                        if(mob.Hp == 0)
                        {
                            nodeArrayToReturn[n.Height, n.Width] = new NodeTowerMob(n.Height, n.Width, 'M', null, nt.isZoneTir);
                        }
                }
                    
            }
            return nodeArrayToReturn;
        }

        /*
         * Méthode qui permet de retourner l'emplacement de la mort du mob
         * 
         */
        public Dictionary<int,int> getPlaceOfDeath(Node[,] map) {
            Dictionary<int, int> placeOfDeath = new Dictionary<int, int>();
            int i = 0;
            foreach(Node n in map){
                if(n.Value == 'M')
                {
                    placeOfDeath.Add(n.Height, n.Width);
                }
            }
            return placeOfDeath;
           
        }

        /*
         * Méthode qui permet de placer l'emplacement de la mort du mob dans le parcours du mob(ou il y a M en value)
         * 
         */
        public List<Node> getParcoursWithDeath(Dictionary<int, int> placeOfDeath, List<Node> parcoursMob)
        {
            List<Node> parcoursWithDeath = new List<Node>();
            
            for(int i = 0; i < parcoursMob.Count; i++)
            {
                if (placeOfDeath.Count != 0)
                {
                    if(parcoursMob[i].Height == placeOfDeath.Keys.ElementAt(placeOfDeath.Count - 1) && parcoursMob[i].Width == placeOfDeath.Values.ElementAt(placeOfDeath.Count - 1))
                    {
                        parcoursWithDeath.Add(new Node(parcoursMob[i].Height, parcoursMob[i].Width, 'M'));
                    }
                }
                else
                {
                    parcoursWithDeath.Add(new Node(parcoursMob[i].Height, parcoursMob[i].Width, parcoursMob[i].Value));
                }
            }
            return parcoursWithDeath;
        }

        public int getNbVies(Node[,] map, int nbVies)
        {
            int nbLifes = nbVies;
            bool isMobDied = false;
            foreach (Node n in map)
            {
                // Si le mob n'est pas mort alors on perd une vie
                if (n.Value == 'M')
                {
                    isMobDied = true;
                }
            }
            if (isMobDied == false)
            {
                nbLifes--;
            }

            return nbLifes;
        }
    }
}
