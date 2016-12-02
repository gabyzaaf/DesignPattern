using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseLibrary.Factory;
namespace MouseLibrary
{
    public class Wrapper : Iaction
    {
        string name;

        public Wrapper(string name) {
            this.name = name;
        }

        public Conf load() {
            return Builds.buildTheConfigurationFile(name);
        }

    }
}
