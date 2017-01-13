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
        public static string nomFichierLignes()
        {
            return ConfigurationManager.AppSettings["fichierLignes"];
        }
        public static string nomFichierStations()
        {
            return ConfigurationManager.AppSettings["fichierStations"];
        }
        public static string sourceLignes()
        {
            return ConfigurationManager.AppSettings["sourceLignes"];
        }
        public static string sourceStation()
        {
            return ConfigurationManager.AppSettings["sourceStations"];
        }




    }
}
