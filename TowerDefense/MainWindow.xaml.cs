using MouseTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TowerDefense.Classes;
using TowerDefense.Factory;

namespace TowerDefense
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AbstractTowerMob abstractTowerMob = TowerDefenseFactory.buildMobOrTower("Tower", "Tower1", 90, 0, 100, 100);
            abstractTowerMob.attaquer();

            AbstractTowerMob abstractTowerMob2 = TowerDefenseFactory.buildMobOrTower("Mob", "Mob1", 90, 100, 10, 10);
            abstractTowerMob2.attaquer();

            TowerDefenseConfiguration ms = new TowerDefenseConfiguration();
            // on recupere la mab sous forme de tableau de node
            string[] nodes = ms.GetArray();
            Node[,] tabNodes = ms.GetNodeArray();
            MobPath mp = new MobPath(tabNodes);

            // on creer la liste de node correspondant au parcours des mobs
            List<Node> parcoursMobs = mp.GetPathList();
            //recupération des mobs de la map (pour linstant un seul mob)
            List<AbstractTowerMob> mobsFromMap = new List<AbstractTowerMob>();
            mobsFromMap = ms.getMobsFromMap(tabNodes);
            Node[,] tabNodes2;

            // Prendre les mobs issus de la carte
            // pour linstant la map avec les mobs a toute leur places de déplacements
            // tableau de noeud avec le deplacement du mob
            tabNodes2 = mp.deplacerMob((Mob)mobsFromMap[0], parcoursMobs, tabNodes);
            
            Console.ReadLine();
        }
    }
}
