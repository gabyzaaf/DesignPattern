using System;
using System.IO;

namespace MetroWPF.Strategy
{
    public class MetroCheckExistError : IMetroCheckLignesStations
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
                if (File.Exists(lignes))
                {
                    LogError.WriteToFile("Le fichier " +fichierLignes+ " existe", "Program");
                    return "exist";
                }
                else
                {
                    throw new Exception("Le fichier " + fichierLignes + " n'existe pas il y a une erreur sur la source");
                }

            }
            catch (Exception e)
            {
                LogError.WriteToFile(e.Message, "Program");
                return "noExist";
            }
        }

        public string checkStation()
        {
            stations = sourceStation + fichierStation;
            try
            {
                if (File.Exists(stations))
                {
                    LogError.WriteToFile("Le fichier " + fichierStation + " existe", "Program");
                    return "exist";
                }
                else
                {
                    throw new Exception("Le fichier " + fichierStation + " n'existe pas il y a une erreur sur la source");
                }

            }
            catch (Exception e)
            {
                LogError.WriteToFile(e.Message, "Program");
                return "noExist";
            }
        }
        #endregion
    }
}
