using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroLib
{
    public class Chemin
    {
        private readonly List<Arc> arcList;
        public Noeud Courant { get; set; }
        public Noeud Origine { get; set; }
        public Noeud Destination { get; set; }

        public int Longueur => arcList.Count;

        public bool EstComplet()
        {
            if (Longueur == 0)
                return false;
            return (arcList.Last().Arrivée == Destination);
        }

        public Chemin(Noeud uneOrigine, Noeud uneDestination)
        {
            arcList = new List<Arc>();
            Origine = uneOrigine;
            Destination = uneDestination;
            Courant = uneOrigine;
        }

        public Chemin(Chemin unChemin)
        {
            arcList = new List<Arc>();
            arcList.AddRange(unChemin.arcList);
            Origine = unChemin.Origine;
            Destination = unChemin.Destination;
            Courant = unChemin.Origine;
        }

        public string ToStringDetails()
        {
            StringBuilder sb = new StringBuilder(ToString());
            Arc arcPrecedent = null;
            foreach (Arc unArc in arcList)
            {
                if (arcPrecedent == null)
                {
                    arcPrecedent = unArc;
                    sb.AppendFormat("\n{0,-25}\n", unArc.Depart);
                }
                else
                {
                    if (arcPrecedent.Contenu != unArc.Contenu)
                    {
                        sb.AppendFormat("{0,-25}        [Correspondance {1}]\n", unArc.Depart, ((Ligne)unArc.Contenu).TitreLigne);
                    }
                    else sb.AppendLine(unArc.Depart.ToString());
                    arcPrecedent = unArc;
                }
            }
            if (arcPrecedent != null)
                sb.AppendFormat("{0,-25}\n", arcPrecedent.Arrivée);

            return  sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Chemin de {0} à {1} ({2} arcs - {3} changements)", Origine, Destination, arcList.Count, NombreDeChangement);
            return sb.ToString();
        }

        public int NombreDeChangement
        {
            get
            {
                int nbreChangement = 0;
                Arc arcPrecedent = null;
                foreach (Arc unArc in arcList)
                {
                    if (arcPrecedent == null)
                        arcPrecedent = unArc;
                    else
                    {
                        if (arcPrecedent.Contenu != unArc.Contenu)
                        {
                            nbreChangement++;
                        }
                        arcPrecedent = unArc;
                    }
                }
                return nbreChangement;
            }
        }

        public void AjouterArc(Arc unArc)
        {
            arcList.Add(unArc);
        }

        
    }
}