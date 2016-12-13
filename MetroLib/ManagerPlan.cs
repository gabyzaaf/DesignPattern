using System.Collections.Generic;
using System.Text;

namespace MetroLib
{
    public class ManagerPlan
    {
        private Graphe Plan { get; set; }

        public Dictionary<string, Station> DicoStations;
        public Dictionary<string, Ligne> DicoLignes;

        public int NombredeLignes => DicoLignes.Count;
        public int NombredeStations => Plan.DicoNoeuds.Count;
        public int NombredeTunnels => Plan.ListeArcs.Count;

        public List<Chemin> TrouverChemins(string stationDepart, string stationArrivée)
        {
            Noeud noeudDepart  = Plan.DonneNoeud(stationDepart);
            Noeud noeudArrivée = Plan.DonneNoeud(stationArrivée);
            Chemin encours = new Chemin(noeudDepart, noeudArrivée);
            List<Chemin> lesCheminsComplets = new List<Chemin>();
            Plan.TrouverChemins(encours, lesCheminsComplets);
            return lesCheminsComplets;
        }

        public ManagerPlan(string strPlan, string[] tabStations, string[] tabLignes)
        {
            DicoStations = RecupèreStations(tabStations);
            DicoLignes = RécupèreLignes(tabLignes, DicoStations);
            ConstruireGraphe(strPlan);
        }

        //----------------------------------------------------------------------
        private void ConstruireGraphe(string strPlan)
        {
            Plan = new Graphe(null, strPlan);
            foreach (KeyValuePair<string, Station> kvpStation in DicoStations)
            {
                new Noeud(Plan, kvpStation.Key, kvpStation.Value );
            }

            foreach (KeyValuePair<string, Ligne> kvpLigne in DicoLignes)
            {
                Noeud stationPrecedente = null;
                foreach (Station uneStation in kvpLigne.Value.StationsList)
                {
                    if (stationPrecedente == null)
                        stationPrecedente = Plan.DonneNoeud(uneStation.Nom);
                    else
                    {
                        Noeud stationCourante = Plan.DonneNoeud(uneStation.Nom);
                        new Arc(Plan, "", stationPrecedente, stationCourante, kvpLigne.Value);
                        stationPrecedente = stationCourante;
                    }
                }
            }
        }
        
        //----------------------------------------------------------------------
        private static Dictionary<string, Station> RecupèreStations(string[] tabStations)
        {
            Dictionary<string, Station> dicoStations = new Dictionary<string, Station>();

            foreach (string strStation in tabStations)
            {
                string strX = strStation.Substring(0, 3);
                string strY = strStation.Substring(4, 3);
                string strNom = strStation.Substring(8);
                dicoStations.Add(strNom, new Station(strNom, strX, strY));
            }
            return dicoStations;
        }

        //----------------------------------------------------------------------
        private static Dictionary<string, Ligne> RécupèreLignes(string[] tabLignes, Dictionary<string, Station> dicoStations)
        {
            Dictionary<string, Ligne> dicoLignes = new Dictionary<string, Ligne>();

            Ligne uneLigne = null;
            foreach (string strLignes in tabLignes)
            {
                if (strLignes.Substring(0, 4) == "####")
                {
                    string unTitreLigne = strLignes.Substring(5);
                    uneLigne = new Ligne(unTitreLigne);
                    dicoLignes.Add(unTitreLigne, uneLigne);
                }
                else
                {
                    int position = strLignes.IndexOf(":");
                    string keyStation = strLignes.Substring(position+1);
                    Station uneStation;
                    if (dicoStations.TryGetValue(keyStation, out uneStation))
                    {
                        uneLigne?.AjouteStation(uneStation);
                    }
                }
            }
            return dicoLignes;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Plan.Nom);
            sb.AppendLine(NombredeLignes + " Lignes");
            sb.AppendLine(NombredeStations + " Stations");
            sb.AppendLine(NombredeTunnels + " Arcs");
            sb.AppendLine();
            return sb.ToString();
        }

        public void LesCheminsOptimaux(List<Chemin> lch, out Chemin cheminLepluscourt, out Chemin cheminAvecleMoinsDeChangement)
        {
            cheminLepluscourt = null;
            int longueurMini = 400;
            cheminAvecleMoinsDeChangement = null;
            int nbreChangementMini = 400;
            foreach (Chemin unChemin in lch)
            {
                if (unChemin.Longueur < longueurMini)
                {
                    longueurMini = unChemin.Longueur;
                    cheminLepluscourt = unChemin;
                }

                if (unChemin.NombreDeChangement < nbreChangementMini)
                {
                    nbreChangementMini = unChemin.NombreDeChangement;
                    cheminAvecleMoinsDeChangement = unChemin;
                }
            }
        }
    }
}
