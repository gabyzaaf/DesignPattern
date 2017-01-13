using System.IO;
using System.Text;
using MetroLib;
using System;
using MetroWPF.Strategy;
using MetroLib.Factory;
using System.Windows;

namespace MetroWPF
{
    public class MetroViewModel
    {

        public ManagerPlan Manager { get; set; }

        public MetroViewModel()
        {
            
            MetroCheck mcheckEmpty = new MetroCheck(new MetroCheckEmptyError());
            MetroCheck mcheckExist = new MetroCheck(new MetroCheckExistError());

            if (mcheckExist.checkLigne() == "exist" && mcheckExist.checkStation() == "exist")
            {
                if(mcheckEmpty.checkLigne() == "noEmpty" && mcheckEmpty.checkStation() == "noEmpty")
                {
                    string[] tabStations = File.ReadAllLines(MetroDataSource.nomFichierStations(), Encoding.Default);
                    string[] tabLignes = File.ReadAllLines(MetroDataSource.nomFichierLignes(), Encoding.Default);

                    Manager = ManagerPlanFactory.createManager("Plan Métro Parisien", tabStations, tabLignes);
                }
                else
                {
                    MessageBox.Show("Le fichier " + MetroDataSource.nomFichierStations() + " est vide");
                }
            }
            else
            {
                MessageBox.Show("Le fichier " + MetroDataSource.nomFichierStations() + " n'existe pas il y a une erreur sur la source");
            }


            

        }
    }

}
