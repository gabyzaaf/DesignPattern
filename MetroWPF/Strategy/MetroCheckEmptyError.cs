using System;
using System.IO;

namespace MetroWPF.Strategy
{
    public class MetroCheckEmptyError : IMetroCheckLignesStations
    {

        #region données membres
        string lignes = MetroDataSource.sourceLignes() + MetroDataSource.nomFichierLignes();
        string stations = MetroDataSource.sourceStation() + MetroDataSource.nomFichierStations();

        #endregion

        #region methode
        public string checkLigne()
        {
            try
            {
                if (new FileInfo(lignes).Length > 0)
                {
                    LogError.WriteToFile("Le fichier "+ MetroDataSource.nomFichierLignes() + " n'est pas vide", "Program");
                    return "noEmpty";
                }
                else
                {
                    throw new Exception("Le fichier " + MetroDataSource.nomFichierLignes() + " est vide");
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
            try
            {
                if (new FileInfo(stations).Length > 0)
                {
                    LogError.WriteToFile("Le fichier " + MetroDataSource.nomFichierStations() + " n'est pas vide", "Program");
                    return "noEmpty";
                }
                else
                {
                    throw new Exception("Le fichier " + MetroDataSource.nomFichierStations() + " est vide");
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
