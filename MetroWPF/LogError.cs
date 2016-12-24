using System;
using System.IO;


namespace MetroWPF
{
    class LogError
    {
        public static void WriteToFile(string errorMessage, string className)
        {
            DateTime dateNow = DateTime.Now;
            string dateRaccourci = String.Format("{0:yyyy-MM-dd}", dateNow);
            string nomFichier = string.Format("{0}.log", dateRaccourci);

            nomFichier = nomFichier.Replace("/", "-");

            string pathChemin = Path.GetFullPath("./Data/Log/");

            string pathCheminComplet = string.Format(@"{0}{1}", pathChemin, nomFichier);

            if (!Directory.Exists(pathChemin))
            {
                Directory.CreateDirectory(pathChemin);
            }

            if (!File.Exists(pathCheminComplet))
            {
                FileStream f = File.Create(pathCheminComplet);
                f.Close();
            }

            using (StreamWriter writer = new StreamWriter(pathCheminComplet, true))
            {
                writer.WriteLine(string.Format(
                                       "[{0} ON {1}] : {2}",
                                       DateTime.Now,
                                       className,
                                       errorMessage));
            }
        }
    }
}
