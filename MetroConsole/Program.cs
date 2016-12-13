using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MetroLib;

namespace MetroConsole
{
    class Program
    {
        static void Main()
        {
            string[] tabStations = File.ReadAllLines("stations.data", Encoding.Default);
            string[] tabLignes = File.ReadAllLines("lignes.data", Encoding.Default);

            ManagerPlan mp = new ManagerPlan("Plan Métro Parisien", tabStations, tabLignes);
            Console.WriteLine(mp.ToString());
            
            CalculEtAfficheItinéraire(mp, "Liège", "Dugommier");
            CalculEtAfficheItinéraire(mp, "Botzaris", "Cambronne");
            CalculEtAfficheItinéraire(mp, "Concorde", "République");
            Console.ReadLine();
        }

        private static void CalculEtAfficheItinéraire(ManagerPlan mp, string stationDepart, string stationArrivée)
        {
            Console.WriteLine("\n\n======================================================================");
            List <Chemin> lch = mp.TrouverChemins(stationDepart, stationArrivée);
            foreach (Chemin chemin in lch)
            {
                Console.WriteLine(chemin.ToString());
            }
            Chemin cheminAvecleMoinsDeChangement, cheminLepluscourt;
            mp.LesCheminsOptimaux(lch, out cheminLepluscourt, out cheminAvecleMoinsDeChangement);
            Console.WriteLine("Itinéraire : " + stationDepart + " - " + stationArrivée);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(cheminAvecleMoinsDeChangement.ToStringDetails());
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(cheminLepluscourt.ToStringDetails());
        }
    }
}
