using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Text.RegularExpressions;

namespace SplitFile
{
    class Function
    {
        public string CreateFoler(string dir)
        {
            SplitString spl = new SplitString();
            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);

            return "";
        }

        public string CopyFile(string url, string targetPath)
        {
            string fileName = getFileNameInUrl(url);
            string sourcePath = Path.GetDirectoryName(url);

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
            return "";
        }

        public int[] getListStatusIndexCopy(int list1Count,string[] list1, string[] list2)
        {
            int[] listStatusIndexCopy = new int[list1Count];
            int count = 0;
            foreach (string value in list1)
            {
                listStatusIndexCopy[count] = Array.IndexOf(list2, value);
                count++;
            }
            return listStatusIndexCopy;
        }

        public string getFileNameInUrl(string url)
        {
            Uri uri = new Uri(url);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);            
            return filename;
        }

        public string getNameInFile(string fileName)
        {
            string name;
            string[] listname = fileName.Split('_');
            name = listname.Last();
            string[] listname2 = name.Split('.');
            name = listname2.First();
            return name;
        }

        public string getNameInUrl(string url)
        {
            string fileName = getFileNameInUrl(url);
            string name = getNameInFile(fileName);
            return name;
        }

        public string copyAllFile(string[] listUrlFile, string[,] listFromCSV,string configPath)
        {
            Log log = new Log();
            Time time = new Time();
            string nameFileLog = time.Get_Year() + time.Get_Month() + time.Get_Day() + " " + time.Get_Hour() + time.Get_Minute() + time.Get_Second()+".txt";
            int count = listFromCSV.Length / 2;
            foreach (string fileURL in listUrlFile)
            {
                
                string[] tempFolderName = new string[count];
                for (int j = 0; j < count; j++)
                {
                    tempFolderName[j] = listFromCSV[j, 0];
                }
                int checkExist = Array.IndexOf(tempFolderName, getNameInUrl(fileURL));
                if (checkExist > -1)
                {
                    CopyFile(fileURL, listFromCSV[checkExist, 1] + @"\" + getNameInUrl(fileURL));
                    log.createLogFile(configPath, nameFileLog, fileURL, listFromCSV[checkExist, 1], "コピー完了しました");
                    Console.WriteLine(time.Get_TimeLog() + ";" + fileURL + ";" + listFromCSV[checkExist, 1] + ";" + "コピー完了しました");
                }
                else
                {
                    log.createLogFile(configPath, nameFileLog, fileURL, "不在", "コピー完了しました");
                    Console.WriteLine(time.Get_TimeLog() + ";" + fileURL + ";" + "不在" + ";" + "コピー失敗しました");
                }                    
                
            }            
            return "";
        }
    }
}
