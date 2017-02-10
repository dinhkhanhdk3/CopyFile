using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.IO;

namespace SplitFile
{
    class FileReader
    {
        public DataTable GetDataTableFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();

            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }

                        csvData.Rows.Add(fieldData);

                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("CSVファイル不在");
                Console.ReadLine();
                
            }

            return csvData;
        }

        public string[] getAColumnInCSVFile(DataTable dt, string nameColumns)
        {
            string[] lastString = new string[dt.Rows.Count];
            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                lastString[count] = row[nameColumns].ToString();
                count++;
            }
            return lastString;
        }

        public string[,] getCSVfileToString(DataTable dt,string name,string targetFolder)
        {
            int count = 0;
            string[,] information = new string[dt.Rows.Count, 2];
            
            foreach (DataRow row in dt.Rows)
            {
                information[count, 0] = row[name].ToString();
                information[count, 1] = row[targetFolder].ToString();
                count++;
            }
            return information;
        }

        public string[] getListNameInConfigFile(string configFilePath)
        {            
            IniParser newIni = new IniParser(configFilePath);
            string[] listSection = newIni.EnumSection("FormerFolder");
            int count = 0;
            string url;
            foreach (string ls in listSection)
            {                
                url = newIni.GetSetting("FormerFolder", ls);
                count = count + Directory.GetFiles(url).Count();
            }
            string[] listNameInConfigFile = new string[count];
            int countFile = 0;
            foreach (string ls in listSection)
            {               
                url = newIni.GetSetting("FormerFolder", ls);
                string[] allFIleInFolder = Directory.GetFiles(url);
                foreach (string fd in allFIleInFolder)
                {
                    listNameInConfigFile[countFile] = fd;
                    countFile++;
                }                
            }

            return listNameInConfigFile;
        }

        public string[] getListNameInCSVFile(string csvFilePath)
        {
            FileReader fr = new FileReader();            
            DataTable csvData = fr.GetDataTableFromCSVFile(csvFilePath);
            string[] listNameInCSVFile = new string[csvData.Rows.Count];
            // Read the file and display it line by line.            

            listNameInCSVFile = fr.getAColumnInCSVFile(csvData, "Name");           

            return listNameInCSVFile;
        }        

    }
}
