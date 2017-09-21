
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Buble_Sort_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dic dic = new Dic();
        label:

            Console.WriteLine("\t\t\t\tWEL COME");
            Console.WriteLine("Dictionary");
            Console.WriteLine("Select your Choice");
            Console.WriteLine("1. To Search");
            Console.WriteLine("2. To Enter a new word");
            Console.WriteLine("3. To get all words of the alphabat");
            Console.WriteLine("4. To Exit");
            try
            {
                char opt = Convert.ToChar(Console.ReadLine());
                if (opt == '1')
                {
                    Console.WriteLine("Enter Word to Search");
                    string reqWord = Console.ReadLine();
                    string[] data = File.ReadAllLines(@"Words.txt");
                    File.WriteAllText(@"TempWordFile.txt", "");
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].Substring(0, 1).ToLower() == reqWord.Substring(0, 1).ToLower())
                        {
                            File.AppendAllText(@"TempWordFile.txt", data[i] + "\n");
                        }
                    }
                    string[] temp = new string[2];
                    string[] wordsmeaning = dic.GetWords();
                    wordsmeaning = dic.BinarySorting(wordsmeaning);
                    string[] wordsList = new string[wordsmeaning.Length];
                    for (int i = 0; i < wordsmeaning.Length; i++)
                    {
                        temp = wordsmeaning[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        wordsList[i] = temp[0];
                    }
                    dic.PopulateData(wordsList, reqWord);
                    string index = dic.BinarySearch(0, wordsList.Length);
                    if (index != "Not Found")
                    {
                        Console.WriteLine("Total Words are: " + wordsList.Length);
                        Console.WriteLine(wordsmeaning[Convert.ToInt32(index)]);
                        Console.ReadLine();
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.WriteLine("Word Not Found");
                        Console.ReadLine();
                        Console.Clear();
                        goto label;
                    }
                }
                else if (opt == '2')
                {
                    Console.WriteLine("Enter Word to Add");
                    string word = Console.ReadLine();
                    Console.WriteLine("Enter Meaning");
                    string meaning = Console.ReadLine();
                    Console.WriteLine(dic.AddWord(word, meaning));
                    Console.ReadLine();
                    Console.Clear();
                    goto label;
                }
                else if (opt == '4')
                {
                    Environment.Exit(0);
                }
                else if (opt == '3')
                {
                    Console.WriteLine("Enter Alphabat to Search");
                    string reqWord = Console.ReadLine();
                    string[] data = File.ReadAllLines(@"Words.txt");
                    File.WriteAllText(@"TempWordFile.txt", "");
                    int count = 0;
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].Substring(0, 1).ToLower() == reqWord.Substring(0, 1).ToLower())
                        {
                            Console.WriteLine(data[i]);
                            count++;
                        }
                    }
                    Console.WriteLine("Total Words: " + count);
                    Console.ReadLine();
                    goto label;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try Again");
                    Console.ReadLine();
                    Console.Clear();
                    goto label;
                }
            }
            catch
            {
                Console.WriteLine("Wrong Input Try Again");
                Console.ReadLine();
                Console.Clear();
                goto label;
            }
        }
    }
}
    

