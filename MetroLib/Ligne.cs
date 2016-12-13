using System.Collections.Generic;

namespace MetroLib
{
    public class Ligne
    {
        public string TitreLigne { get; set; }

        public List<Station> StationsList { get; set; }

        public Ligne(string unTitreLigne)
        {
            TitreLigne = unTitreLigne;
            StationsList = new List<Station>();
        }

        internal void AjouteStation(Station uneStation)
        {
            StationsList.Add(uneStation);
        }
    }
}