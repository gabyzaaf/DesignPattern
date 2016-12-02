using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MouseLibrary
{
    public abstract class Conf
    {
        protected string[] keyTab;

        public Conf()
        {
           keyTab = ConfigurationSettings.AppSettings.AllKeys;
        }

        protected bool keyExist(string key)
        {
            return keyTab.Contains(key);
        }

        protected string checking(string key)
        {
            if (keyTab.Contains(key) == false)
            {
                throw new Exception(String.Format("the key {0} not exist",key));
            }
            string file = ConfigurationSettings.AppSettings.Get(key);
            if (file == null || file.Equals(""))
            {
                throw new Exception(String.Format("the file with the key {0} not exist ",key));
            }
            return file;
        }
        public abstract string getNom();
        public abstract string getLogPath();
        public abstract string getMap();
        public abstract string getSerializePath();


    }
}
