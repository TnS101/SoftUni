using System;
using System.Collections.Generic;
using System.Linq;
namespace Тhe_Final_UQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(" ").ToList();
            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                if (command=="Stop")
                {
                    break;
                }
                
                if (command == "Swap")
                {
                    string firstWord = tokens[1];
                    string secondWord = tokens[2];
                    if (list.Contains(firstWord)&& list.Contains(secondWord))
                    {
                        int firstWordIndex = list.IndexOf(firstWord);
                        int secondWordIndex = list.IndexOf(secondWord);
                        
                        list[firstWordIndex]=secondWord;
                        list[secondWordIndex]=firstWord;
                       

                    }

                    

                }
                if (command == "Put")
                {
                    int index = int.Parse(tokens[2]);
                    string wordToPut = tokens[1];
                    int checkingIndex = index - 1;
                    if (checkingIndex<=list.Count&&checkingIndex>=0)
                    {
                        list.Insert(checkingIndex,wordToPut);
                    }
                }
               else if (command == "Delete")
                {
                    int deleteNumber = int.Parse(tokens[1]);
                    int realDeleteNumber = deleteNumber+1 ;
                    if (realDeleteNumber < list.Count&&deleteNumber>=0 )
                    {
                        list.RemoveAt(realDeleteNumber);
                    }
                }
                if (command == "Sort")
                {
                    list = list.OrderByDescending(c => c).ToList();
                }
               else if (command == "Replace")
                {
                    string word1 = tokens[1];
                    string word2 = tokens[2];
                    if (list.Contains(word2))
                    {
                        int indexOfWord2 = list.IndexOf(word2);

                        list[indexOfWord2] = word1;
                        
                    }

                }

            }
            
            
                Console.Write(string.Join(" ",list));
            
        }
    }
}
