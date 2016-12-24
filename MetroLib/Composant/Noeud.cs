using System.Collections.Generic;

namespace MetroLib
{
    public class Noeud : ElementGraphe
    {
        public object Contenu { get; set; }
        public List<Arc> ArcsSortantsList { get; set; }
        public bool DejaParcouru { get; set; }
        //---------------------------------------------------------------
        public Noeud(Graphe gr, string unNom, object unContenu)
            : base(gr, unNom)
        {
            ArcsSortantsList = new List<Arc>();
            gr.AjouteNoeud(unNom, this);
            Contenu = unContenu;
            DejaParcouru = false;
        }

        internal void AjouteArc(Arc arc)
        {
            ArcsSortantsList.Add(arc);
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
