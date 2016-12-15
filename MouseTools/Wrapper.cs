using MouseTools.Observor;
using MouseTools.Strategy;
using System;

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

        public static void WriteLogFile(string message)
        {
            WrapperObserver wrapper = new WrapperObserver(message);
        }


        public static IgetNode nodeDirection(string type)
        {
            if (String.Equals(type, "left", StringComparison.OrdinalIgnoreCase))
            {
                return new Left();
            }
            if (String.Equals(type, "right", StringComparison.OrdinalIgnoreCase))
            {
                return new Right();
            }
            if (String.Equals(type, "top", StringComparison.OrdinalIgnoreCase))
            {
                return new Top();
            }
            if (String.Equals(type, "down", StringComparison.OrdinalIgnoreCase))
            {
                return new Down();
            }
            return null;
        }

        public static Node GetNodeDirection(string type,Node[,]nodes,int height,int width)
        {
            if (nodeDirection(type) == null)
            {
                throw new Exception("the node type is not recognize");
            }
            return nodeDirection(type).getNode(nodes,height,width);
        }


    }
}
