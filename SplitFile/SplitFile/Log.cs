using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SplitFile
{
    class Log
    {
        public string createLogFile(string configFilePath, string nameFileLog, string fileUrl, string folderUrl, string status)
        {
            Time time = new Time();
            IniParser newIni = new IniParser(configFilePath);
            string path = newIni.GetSetting("LogFolder", "log") + @"\" + nameFileLog;
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName( ( path ) ));
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(time.Get_TimeLog() + ";" + fileUrl + ";" + folderUrl + ";" + status);                   
                    tw.Close();
                }

            }
            else if (File.Exists(path))
            {
                using (StreamWriter tw = File.AppendText(path))
                {
                    tw.WriteLine(time.Get_TimeLog() + ";" + fileUrl + ";" + folderUrl + ";" + status);                    
                    tw.Close();
                }
            }
            return "";
        }
    }
}
