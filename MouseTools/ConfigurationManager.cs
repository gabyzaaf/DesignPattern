using System;
using System.Collections.Generic;
using System.Linq;

namespace MouseTools
{
    public abstract class ConfigurationManager
    {
        protected Dictionary<string, string> settingsByKeys;
        public abstract Log GetLog();
        
        public abstract Node[,] GetNodeArray();

        #region LOAD_DICO
        public ConfigurationManager()
        {
            if (settingsByKeys==null) {
                settingsByKeys = new Dictionary<string, string>(); 
                string[] keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
                if (keys == null || keys.Count() == 0)
                {
                    throw new Exception("Error the keys are empty");
                }
                foreach (string key in keys)
                {
                    settingsByKeys.Add(key, System.Configuration.ConfigurationManager.AppSettings[key]);
                }
            }
        }
        #endregion

        public int GetDicoSize()
        {
            return settingsByKeys.Count;
        }

       

       
    }

}
