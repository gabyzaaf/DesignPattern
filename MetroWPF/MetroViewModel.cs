using System.IO;
using System.Text;
using MetroLib;

namespace MetroWPF
{
    public class MetroViewModel
    {
        public ManagerPlan Manager { get; set; }

        public MetroViewModel()
        {
            string[] tabStations = File.ReadAllLines("stations.data", Encoding.Default);
            string[] tabLignes = File.ReadAllLines("lignes.data", Encoding.Default);

            Manager = new ManagerPlan("Plan Métro Parisien", tabStations, tabLignes);
        }
    }
}
