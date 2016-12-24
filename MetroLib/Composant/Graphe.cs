using System.Collections.Generic;
using System.Linq;

namespace MetroLib
{
    
    public class Graphe : ElementGraphe
    {
        public Dictionary<string,Noeud> DicoNoeuds { get; set; }
        public List<Arc> ListeArcs { get; set; }
        //---------------------------------------------------------------
        public Graphe(Graphe gr, string unNom)
            : base(gr, unNom)
        {
            DicoNoeuds = new Dictionary<string, Noeud>();
            ListeArcs = new List<Arc>();
        }

        internal void AjouteNoeud(string idNoeud, Noeud unNoeud)
        {
            DicoNoeuds.Add(idNoeud, unNoeud);
        }

        public void AjouteArc(Arc unArc)
        {
            ListeArcs.Add(unArc);
        }

        internal Noeud DonneNoeud(string nom)
        {
            return DicoNoeuds[nom];
        }

        public Chemin TrouverChemins(Chemin encours, List<Chemin> cheminComplets )
        {
            if (cheminComplets.Count > 0)
            {
                if (!CheminAGarder(encours, cheminComplets))
                    return null;
            }

            if (encours.EstComplet()) return encours;

            foreach (Arc unArc in encours.Courant.ArcsSortantsList)
            {
                if (!unArc.Arrivée.DejaParcouru)
                {
                    unArc.Arrivée.DejaParcouru = true;
                    Chemin nouveauChemin = new Chemin(encours);
                    nouveauChemin.Courant = unArc.Arrivée;
                    nouveauChemin.AjouterArc(unArc);

                    Chemin leCheminComplet = TrouverChemins(nouveauChemin, cheminComplets);

                    if ((leCheminComplet != null) && (leCheminComplet.EstComplet()))
                    {
                        if (cheminComplets.Count == 0)
                            cheminComplets.Add(leCheminComplet);
                        else
                        {
                            if (CheminAGarder(encours, cheminComplets))
                            {
                                cheminComplets.Add(leCheminComplet);
                            }
                        }
                    }
                    unArc.Arrivée.DejaParcouru = false;
                }
            }
            return null;
        }

        private static bool CheminAGarder(Chemin encours, List<Chemin> cheminComplets)
        {
            return (encours.Longueur <= cheminComplets.Min(c => c.Longueur));
        }
    }
}


