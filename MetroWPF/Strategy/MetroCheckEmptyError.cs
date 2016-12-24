using System;
using System.IO;

namespace MetroWPF.Strategy
{
    public class MetroCheckEmptyError : IMetroCheckLignesStations
    {

        #region données membres
        string lignes;
        string stations;
        MetroDataSource mds = new MetroDataSource();
        #endregion

        #region encapsulation
        public string fichierLignes
        {
            get
            {
                return mds.nomFichierLignes;
            }

            set
            {
                fichierStation = mds.nomFichierLignes;
            }
        }

        public string fichierStation
        {
            get
            {
                return mds.nomFichierStations;
            }

            set
            {
                fichierStation = mds.nomFichierStations;
            }
        }

        public string sourceLignes
        {
            get
            {
                return mds.sourceLignes;
            }

            set
            {
                sourceLignes = mds.sourceLignes;
            }
        }

        public string sourceStation
        {
            get
            {
                return mds.sourceStation;
            }

            set
            {
                sourceStation = mds.sourceStation;
            }
        }
        #endregion

        #region methode
        public string checkLigne()
        {
            lignes = sourceLignes + fichierLignes;
            try
            {
                if (new FileInfo(lignes).Length > 0)
                {
                    LogError.WriteToFile("Le fichier lignes.data n'est pas vide", "Program");
                    return "noEmpty";
                }
                else
                {
                    throw new Exception("Le fichier lignes.data est vide");
                }

            }
            catch (Exception e)
            {
                LogError.WriteToFile(e.Message, "Program");
                return "empty";
            }

        }

        public string checkStation()
        {
            stations = sourceStation + fichierStation;
            try
            {
                if (new FileInfo(stations).Length > 0)
                {
                    LogError.WriteToFile("Le fichier stations.data n'est pas vide", "Program");
                    return "noEmpty";
                }
                else
                {
                    throw new Exception("Le fichier stations.data est vide");
                }

            }
            catch (Exception e)
            {
                LogError.WriteToFile(e.Message, "Program");
                return "empty";
            }
        }
        #endregion
    }
}
