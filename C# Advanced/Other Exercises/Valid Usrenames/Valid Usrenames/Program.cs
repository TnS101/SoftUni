using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Valid_Usrenames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ").ToArray();
            List<string> validUsernames = new List<string>();
            bool isValid = false;
            Regex pattern = new Regex(@"(?<name>[a-zA-Z]+){3,16}[^a-zA-Z$][^@!]\w+");

            for (int i = 0; i < words.Length; i++)
            {
                
                Match match = pattern.Match(words.ToString());

                    if (match.Success)
                    {
                    string word = match.Groups["name"].Value;
                    isValid = true;
                        validUsernames.Add(word);
                    Console.WriteLine(word);
                    }
                    if (!match.Success)
                    {
                        isValid = false;
                        break;
                    }


                

            }

            if (isValid==true)
            {
                foreach (var item in validUsernames)
                {
                    Console.WriteLine(item);
                }
            }
           

        }
    }
}
