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

        public void InitTimer()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(600))
            {
                Timer myTimer = new Timer();
                myTimer.Elapsed += new ElapsedEventHandler(myEvent);
                // Set it to go off every five seconds
                myTimer.Interval = 1000;
                // And start it        
                myTimer.Enabled = true;
            }

            s.Stop();
            
        }

        private void myEvent(object source, ElapsedEventArgs e) {
            Console.WriteLine("test");
        }
        public Node[,] deplacerMob(Mob mob, List<Node> path, Node[,] nodeArray)
        {
            Node[,] nodeArrayToReturn = nodeArray;
            // on recopie les emplacements de déplacements des mobs dans la carte nodeArray
            // Faudrait que babar affiche les mobs aux diffents emplacements en effacant au fur et a mesure les anciens emplacements
            foreach (Node n in path)
            {
                nodeArrayToReturn[n.Height, n.Width] = new NodeTowerMob(1, 1, nodeArray[n.Height, n.Width].Value, mob);
            }
            return nodeArrayToReturn;
        }
    }
}

