using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroWPF.Strategy
{
    class MetroCheck
    {
        private IMetroCheckLignesStations imetro;

        public MetroCheck(IMetroCheckLignesStations imetro)
        {
            this.imetro = imetro;
        }

        public string checkLigne()
        {
            return this.imetro.checkLigne();
        }

        public string checkStation()
        {
            return this.imetro.checkStation();
        }

    }
}
