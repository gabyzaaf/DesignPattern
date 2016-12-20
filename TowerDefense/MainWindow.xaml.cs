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
            AbstractTowerMob abstractTowerMob = TowerDefenseFactory.buildMobOrTower("Tower", "ben", 90, 0, 100, 100);
            abstractTowerMob.attaquer();

            AbstractTowerMob abstractTowerMob2 = TowerDefenseFactory.buildMobOrTower("Mob", "ben", 90, 100, 10, 10);
            abstractTowerMob2.attaquer();

            TowerDefenseConfiguration ms = new TowerDefenseConfiguration();
            string[] nodes = ms.GetArray();
            Node[,] tabNodes = ms.GetNodeArray();
            ToolsTree tt = new ToolsTree(tabNodes);
            int nbLifes = ms.getNbLifes();
            int nbMobs = ms.getNbMobs();
            Console.ReadLine();
            // EN debut de partie inialise les mobs en 0,0
        }
    }
}
