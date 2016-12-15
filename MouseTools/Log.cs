using System;
using System.IO;
namespace MouseTools
{
    public class Log
    {
        private string fileName = "Mouse_Game_Log.txt";
        public string Path { get; private set; }

        public Log(string sPath)
        {
            Path = sPath;
        }

        public void WriteContent(string message)
        {
            try {
                File.AppendAllText(Path+fileName, message + Environment.NewLine);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            
        }
    }
}
