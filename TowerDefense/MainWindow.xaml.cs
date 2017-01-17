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

            TowerDefenseConfiguration ms = new TowerDefenseConfiguration();
            // on recupere la mab sous forme de tableau de node
            string[] nodes = ms.GetArray();
            Node[,] tabNodes = ms.GetNodeArray();
            MobPath mp = new MobPath(tabNodes);

            // on creer la liste de node correspondant au parcours des mobs
            List<Node> parcoursMobs = mp.GetPathList();
            //recupération des mobs de la map (pour linstant un seul mob)
            List<Mob> mobsFromMap = new List<Mob>();
            mobsFromMap = ms.getMobsFromMap(tabNodes);
            Node[,] tabNodes2;
            // on créer le déplacement des mobs sur la map
            tabNodes2 = mp.deplacerMob(mobsFromMap[0], parcoursMobs, tabNodes);
            // on recupére l'emplacement de la mort du mob
            Dictionary<int, int> placeOfDeath = mp.getPlaceOfDeath(tabNodes2);
            // On place la mort du mob dans le parcours du mob
            List<Node> parcoursWithDeath= mp.getParcoursWithDeath(placeOfDeath, parcoursMobs);
            // on recuperer le nb de vies restantes au joueur après sa mort
            int nbLifesRestantes = mp.getNbVies(tabNodes2, int.Parse(System.Configuration.ConfigurationManager.AppSettings["nbLifes"]));
            Console.ReadLine();
        }
    }
}
