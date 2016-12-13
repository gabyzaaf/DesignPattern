namespace MetroLib
{
    public class Station
    {
        public string Nom { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        public Station(string unNom, string x, string y)
        {
            Nom = unNom;
            X = int.Parse(x);
            Y = int.Parse(y);
           
        }
    }
}