﻿using System;

namespace MouseTools
{
    public class Wrapper
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


        public static Log GetLogPath(string type)
        {
            if (String.Equals(type, "mouse", StringComparison.OrdinalIgnoreCase))
            {
                return GetConfiguration("mouse").GetLog();
            }
            else
            {
                return null;
            } 
        }
        

    }
}
