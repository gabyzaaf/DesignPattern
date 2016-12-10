using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools
{
    public  abstract class ConfigurationManager
    {
        protected Dictionary<string, string> dicos;

        public ConfigurationManager()
        {
            if (dicos==null) {
                dicos = new Dictionary<string, string>(); 
                string[] keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
                if (keys.Count()==0)
                {
                    throw new Exception("Error the keys are empty");
                }
                foreach (string key in keys)
                {
                    dicos.Add(key, System.Configuration.ConfigurationManager.AppSettings[key]);
                }
            }
        }

        public int GetDicoSize()
        {
            return dicos.Count;
        }

        public abstract string GetLog();
        public abstract string[] GetArray();
        public abstract Node[,] GetNodeArray();

        
    }
}
