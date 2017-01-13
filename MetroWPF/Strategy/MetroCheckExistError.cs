using System;
using System.IO;

namespace MetroWPF.Strategy
{
    public class MetroCheckExistError : IMetroCheckLignesStations
    {
        #region données membres
        string lignes = MetroDataSource.sourceLignes()+MetroDataSource.nomFichierLignes();
        string stations = MetroDataSource.sourceStation() + MetroDataSource.nomFichierStations();

        #endregion

        #region methode
        public string checkLigne()
        {
            try
            {
                if (File.Exists(lignes))
                {
                    LogError.WriteToFile("Le fichier " + MetroDataSource.nomFichierLignes() + " existe", "Program");
                    return "exist";
                }
                else
                {
                    throw new Exception("Le fichier " + MetroDataSource.nomFichierLignes() + " n'existe pas il y a une erreur sur la source");
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
            try
            {
                if (File.Exists(stations))
                {
                    LogError.WriteToFile("Le fichier " + MetroDataSource.nomFichierStations() + " existe", "Program");
                    return "exist";
                }
                else
                {
                    throw new Exception("Le fichier " + MetroDataSource.nomFichierStations() + " n'existe pas il y a une erreur sur la source");
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
