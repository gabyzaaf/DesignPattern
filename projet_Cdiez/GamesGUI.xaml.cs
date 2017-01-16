using MouseTools;
using MouseTools.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TowerDefense.Classes;
using TowerDefense.Factory;

namespace projet_Cdiez
{
    /// <summary>
    /// Logique d'interaction pour GamesGUI.xaml
    /// </summary>
    public partial class GamesGUI : Window
    {
        int i = 0;
        Node nodePrecedent;
        List<Node> parcoursMouse;
        List<Node> parcoursMobs;
        BitmapImage btmWall = new BitmapImage(new Uri("C:/Users/Baba Daryoush/Cours/ESGI 5AL (2016-2017)/C#/projet_Cdiez/projet_Cdiez/wall.png"));
        BitmapImage btmDoorStart = new BitmapImage(new Uri("C:/Users/Baba Daryoush/Cours/ESGI 5AL (2016-2017)/C#/projet_Cdiez/projet_Cdiez/door_start.png"));
        BitmapImage btmDoorEnd = new BitmapImage(new Uri("C:/Users/Baba Daryoush/Cours/ESGI 5AL (2016-2017)/C#/projet_Cdiez/projet_Cdiez/door_end.png"));
        BitmapImage btmTower = new BitmapImage(new Uri("C:/Users/Baba Daryoush/Cours/ESGI 5AL (2016-2017)/C#/projet_Cdiez/projet_Cdiez/tower.png"));
        BitmapImage btmGrass = new BitmapImage(new Uri("C:/Users/Baba Daryoush/Cours/ESGI 5AL (2016-2017)/C#/projet_Cdiez/projet_Cdiez/grass.jpg"));
        BitmapImage btmMob = new BitmapImage(new Uri("C:/Users/Baba Daryoush/Cours/ESGI 5AL (2016-2017)/C#/projet_Cdiez/projet_Cdiez/wolf.png"));
        BitmapImage btmPath = new BitmapImage(new Uri("C:/Users/Baba Daryoush/Cours/ESGI 5AL (2016-2017)/C#/projet_Cdiez/projet_Cdiez/path.png"));

        public GamesGUI()
        {
            InitializeComponent();
            if (MainWindow.whichGame == 1)
                mouseGame();
            if (MainWindow.whichGame == 2)
                towerDefense();
            if (MainWindow.whichGame == 3)
                subway();
                
        }

        public void subway()
        {

        }

        public void towerDefense()
        {
            AbstractTowerMob abstractTowerMob = TowerDefenseFactory.buildMobOrTower("Tower", "Tower1", 90, 0, 100, 100);
            abstractTowerMob.attaquer();

            AbstractTowerMob abstractTowerMob2 = TowerDefenseFactory.buildMobOrTower("Mob", "Mob1", 90, 100, 10, 10);
            abstractTowerMob2.attaquer();

            TowerDefenseConfiguration ms = new TowerDefenseConfiguration();
            string[] nodes = ms.GetArray();
            Node[,] tabNodes = ms.GetNodeArray();
            ToolsTree tt = new MobPath(tabNodes);
            int nbLifes = ms.getNbLifes();
            int nbMobs = ms.getNbMobs();
            parcoursMobs = tt.GetPathList();

            foreach (Node node in tabNodes)
            {
                (Content as Grid).Children.Add(bitmapToImage(btmGrass, node.Height, node.Width));
            }

            displayMap(tabNodes);
            Console.ReadLine();
        }

        public void mouseGame()
        {
            //mise en place et appel du jeu de la souris
            ToolsTreeCommand tools = new ToolsTreeCommand();
            SwitchAction switchAction = new SwitchAction();
            Node[,] nodez = switchAction.ExecuteReadMap(tools);
            parcoursMouse = switchAction.ExecuteMousePath(tools, nodez);
            Console.ReadLine();
            displayMap(nodez);
        }

        //parcours du tableau de node contenant le placement des éléments puis parcours du déplacement de la souris/mob.
        public void displayMap(Node[,] node)
        {
            try
            {

                Console.ReadLine();

                foreach (Node n in node)
                {
                    Console.WriteLine("Value: " + n.Value + ", Height/Width" + n.Height + "/" + n.Width);
                    if (n.Value == '*')
                    {
                        (Content as Grid).Children.Add(bitmapToImage(btmWall, n.Height, n.Width));
                    }
                    if (n.Value == 'T')
                    {
                        Console.WriteLine("coucou suce");
                        (Content as Grid).Children.Add(bitmapToImage(btmTower, n.Height, n.Width));
                    }
                    if (n.Value == 'R')
                    {
                        Console.WriteLine("coucou suce");
                        (Content as Grid).Children.Add(bitmapToImage(btmDoorStart, n.Height, n.Width));
                    }
                    if (n.Value == 'A')
                    {
                        Console.WriteLine("coucou suce");
                        (Content as Grid).Children.Add(bitmapToImage(btmDoorEnd, n.Height, n.Width));
                    }
                    if (n.Value == '+')
                    {
                        Console.WriteLine("coucou suce");
                        (Content as Grid).Children.Add(bitmapToImage(btmPath, n.Height, n.Width));
                    }
                }
                InitTimer();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        //Timer permettant de faire avancer les objets de manière automatisée (déclenché par appuie de la touche espace)
        System.Timers.Timer aTimer;
        public void InitTimer()
        {

            aTimer = new System.Timers.Timer();

            aTimer.Elapsed += new ElapsedEventHandler(myEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }

        //effectué à chaque seconde du timer
        public void myEvent(object source, ElapsedEventArgs e)
        {

            if (MainWindow.whichGame == 2)
            {
                deplacementObjet(parcoursMobs);

            }
            else if (MainWindow.whichGame == 1)
            {
                deplacementObjet(parcoursMouse);
            }

        }

        //On place l'objet souhaité aux premiers coordonnées de la liste puis on supprime ces premiers coordonnées
        //afin de placer les coordonnées suivants à la prochaine seconde
        public void deplacementObjet(List<Node> parcours)
        {

            try
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {

                //quand il n'y a plus qu'un objet dans la liste on stop le timer afin de 
                //ne pas parcourir une liste vide et d'arreter l'avancé de la souris/mob
                Console.WriteLine("Tour " + i);

                    if (parcours.Count() == 1)
                        aTimer.Stop();

                    Node node = parcours.ElementAt(0);
                    if (i == 1)
                    {
                        Console.WriteLine("Node precedent: " + nodePrecedent.Height + ", " + nodePrecedent.Width);
                        (Content as Grid).Children.Add(bitmapToImage(btmDoorStart, nodePrecedent.Height, nodePrecedent.Width));
                    }
                    else if (i > 0)
                    {
                        (Content as Grid).Children.Add(bitmapToImage(btmPath, nodePrecedent.Height, nodePrecedent.Width));
                    }
                        (Content as Grid).Children.Add(bitmapToImage(btmMob, node.Height, node.Width));
                    Console.WriteLine("Node courant: " + node.Height + ", " + node.Width);
                    nodePrecedent = new Node(node.Height, node.Width);
                    parcours.RemoveAt(0);
                    i++;
                }));
            }catch(Exception e) { Console.WriteLine(e); }
            
        }


        //action à l'appuie de la touche espace
        public void keydownEvent(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Hello from keyDownEvent");

            if (e.Key == Key.Space)
            {
                InitTimer();
            }
        }



        public System.Windows.Controls.Image bitmapToImage(BitmapImage btm, int x, int y)
        {
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Source = btm;
            img.SetValue(Grid.RowProperty, x);
            img.SetValue(Grid.ColumnProperty, y);
            return img;
        }
    }
}
