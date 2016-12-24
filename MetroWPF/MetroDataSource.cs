using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroWPF
{
    public class MetroDataSource
    {

        public string nomFichierLignes { get; private set; }
        public string nomFichierStations { get; private set; }
        public string sourceLignes { get; private set; }
        public string sourceStation { get; private set; }
        public string sourceLog { get; private set; }
        
        public MetroDataSource()
        {
            nomFichierLignes = ConfigurationManager.AppSettings["fichierLignes"];
            nomFichierStations = ConfigurationManager.AppSettings["fichierStations"];
            sourceLignes = ConfigurationManager.AppSettings["sourceLignes"];
            sourceStation = ConfigurationManager.AppSettings["sourceStations"];
            sourceLog = ConfigurationManager.AppSettings["sourceLog"];
        }



    }
}
