using System;

namespace MetroLib
{

    public class Arc : ElementGraphe
    {
        public Object Contenu { get; set; }
        public Noeud Depart { get; set; }
        public Noeud Arrivée { get; set; }
        public bool Parcouru { get; set; }

        //---------------------------------------------------------------
        public Arc(Graphe gr, String nom, Noeud deb, Noeud fin, object unContenu = null)
            : base(gr, nom)
        {
            Depart = deb;
            Arrivée = fin;
            Depart.AjouteArc(this);
            gr.AjouteArc(this);
            Contenu = unContenu;
        }
    }

}
