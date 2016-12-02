using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace MouseLibrary
{
     class MouseConfiguration : Conf
    {

        

        private string checkConf(string key)
        {
           string file = this.checking(key);
            if (File.Exists(file)==false)
            {
                string error = String.Format("the file {0} not exist  ", file);
                throw new Exception(error);
            }
            return file;
        }

        public override string getLogPath() 
        {
           return  this.checkConf("log");  
        }

        public override string getMap()
        {
            return this.checkConf("map");
        }

        public override string getNom()
        {
            return this.checkConf("nom");
        }

        public override string getSerializePath()
        {
            return this.checkConf("serializePath");
        }
    }
}
