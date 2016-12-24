namespace MetroLib
{
    public abstract class ElementGraphe
    {
        protected Graphe Parent;
        public string Nom { get; }

        //---------------------------------------------------------------
        protected ElementGraphe(Graphe unGraphe, string unNom)
        {
            Parent = unGraphe;
            Nom = unNom;
        }

    }
}
