using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools
{
    public  class Wrapper
    {
        public static ConfigurationManager GetConfiguration(string type)
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
