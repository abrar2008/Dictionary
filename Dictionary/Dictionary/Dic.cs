using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Buble_Sort_String
{
    class Dic
    {
        string[] dataArray;
        string searchTerm;
        public void PopulateData(string[] data, string term)
        {
            dataArray = data;
            searchTerm = term;
        }
        public string[] BinarySorting(string[] s)
        {
            string temp = "";
            try
            {
                for (int i = 1; i < s.Length; i++)
                {
                    for (int j = 0; j < s.Length - i; j++)
                    {
                        if (s[j].CompareTo(s[j + 1]) > 0)
                        {
                            temp = s[j];
                            s[j] = s[j + 1];
                            s[j + 1] = temp;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return s;
        }
        public string[] GetWords()
        {
            string[] array = File.ReadAllLines(@"TempWordFile.txt");
            return array;
        }
        public string BinarySearch(int low, int high)
        {
            int mid = (low + high) / 2;
            int compare = string.Compare(dataArray[mid], searchTerm);
            if (low > high)
            {
                return "Not Found";
            }
            if (searchTerm.ToLower() == dataArray[mid].ToLower())
            {
                return mid.ToString();
            }
            else if (compare > 0)
            {
                return BinarySearch(low, mid - 1);
            }
            else
            {
                return BinarySearch(mid + 1, high);
            }
        }
        public string AddWord(string word, string meaning)
        {
            string temp = "\n" + word + ": " + meaning;
            File.AppendAllText(@"Words.txt", temp);
            return "Word Added";
        }
    }
}
