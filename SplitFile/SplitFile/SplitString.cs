using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitFile
{
    class SplitString
    {
        //Get last string in an array
        public string GetLastIndexString(char characters, string fistString)
        {
            string[] arrListStr = fistString.Split(characters);
            string lastString = arrListStr[arrListStr.Length - 1];
            return lastString;
        }

        public string getNameNotTypeFile(string fistString)
        {
            string lastString = "";
            string[] arrListStr = fistString.Split('.');
            for (int i = 0; i < arrListStr.Length - 1; i++)
            {
                lastString = lastString + arrListStr[i];
            }
            
            return lastString;
        }

        public string getNameInTxtFile(string fistString)
        {
            string lastString;
            lastString = fistString.Split(',').Last();
            lastString = lastString.Split('.').First();
            return lastString;

        }
    }
}
