using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;


namespace SplitFile
{
    class Program
    {
        static void Main(string[] args)
        {            
            FileReader fr = new FileReader();            
            Function func = new Function();
            TestFunction test = new TestFunction();
            
            string csvFilePath = @"FileFolder\\FolderLink.csv";
            string configFilePath = @"FileFolder\\config.ini";
            
            //Load all list name of folder from CSV file
            DataTable csvData = fr.GetDataTableFromCSVFile(csvFilePath);
            string[,] listFromCSV = fr.getCSVfileToString(csvData, "name","targetfolder");            
            //Load all list url of file from config file
            string[] listUrlFile = fr.getListNameInConfigFile(configFilePath);
            //Process copy file if file name in CVS file exist            
            func.copyAllFile(listUrlFile, listFromCSV, configFilePath);
            
            Console.ReadLine();            
        }


        
        
    }
}
