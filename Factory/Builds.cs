using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseLibrary.Factory
{
    public class Builds
    {
        public static Conf buildTheConfigurationFile(string type)
        {
            if (String.Equals(type, "mouse", StringComparison.OrdinalIgnoreCase))
            {
                return new MouseConfiguration();
            }
            else
            {
                return null;
            }
        }

    }
}
