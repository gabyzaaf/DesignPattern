using System.IO;
using System.Text;
using MetroLib;
using System;
using MetroWPF.Strategy;

namespace MetroWPF
{
    public class MetroViewModel
    {

        public ManagerPlan Manager { get; set; }

        public MetroViewModel()
        {
            MetroCheckExistError mcExist = new MetroCheckExistError();
            MetroCheckEmptyError mcEmpty = new MetroCheckEmptyError();

            MetroCheck mcheckEmpty = new MetroCheck(new MetroCheckEmptyError());
            MetroCheck mcheckExist = new MetroCheck(new MetroCheckExistError());

            mcheckExist.checkLigne();
            mcheckExist.checkStation();
            mcheckEmpty.checkLigne();
            mcheckEmpty.checkStation();

            /*mcExist.checkLigne();
            mcExist.checkStation();
            mcEmpty.checkLigne();
            mcEmpty.checkStation();*/

            string[] tabStations = File.ReadAllLines("stations.data", Encoding.Default);
            string[] tabLignes = File.ReadAllLines("lignes.data", Encoding.Default);

            Manager = new ManagerPlan("Plan Métro Parisien", tabStations, tabLignes);

        }
    }

}
