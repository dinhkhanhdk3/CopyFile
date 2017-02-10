using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SplitFile
{
    class TestFunction
    {
        public int displayList(string[] list)
        {
            foreach(string lt in list)
            {
                Console.WriteLine(lt);
            }

            return 1;
        }

        public int findInArray(string key,string[] list)
        {
            int index = Array.IndexOf(list, key);
            return index;
        }

        public int displayIndexStatus(int[] list)
        {
            foreach (int lt in list)
            {
                Console.WriteLine(lt);
            }
            return 1;
        }

        public int displayAllFileInFolder(string url)
        {
            string lalala = @"D:\元フォルダー\Folder１";
            string[] fileEntries = Directory.GetFiles(lalala);
            foreach (string fileName in fileEntries)
                Console.WriteLine(fileName);
            return 1;
        }
    }
}
