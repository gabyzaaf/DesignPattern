using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroWPF;
using System.IO;
using MetroLib;
using System.Configuration;

namespace GlobalGame
{
    class Menus
    {
        public ManagerPlan Manager { get; set; }

        public void start(String nameGame)
        {
            
            if(nameGame == "metro")
            {
                MetroViewModel mvm = new MetroViewModel();
                Menus m1 = new Menus();

                string[] tabStations = File.ReadAllLines("stations.data", Encoding.Default);
                string[] tabLignes = File.ReadAllLines("lignes.data", Encoding.Default);

                Manager = new ManagerPlan("Plan Métro Parisien", tabStations, tabLignes);
            }
        }

        public void pause(object game)
        {

        }

        public void close(object game)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string nom = ConfigurationManager.AppSettings["nom"];
            string prenom = ConfigurationManager.AppSettings["prenom"];
            Console.WriteLine("Je m'appelle {0} {1}", prenom, nom);
            Menus m1 = new Menus();
            string nameGame;
            Console.WriteLine("Saisir le nom d'un jeu");
            nameGame = Console.ReadLine();

            m1.start(nameGame);
        }



    }
}


