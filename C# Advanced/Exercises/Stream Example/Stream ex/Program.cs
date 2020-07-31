using System;
using System.IO;
using System.Linq;
namespace Stream_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"text.txt";

            int counter = 0;

            using (var streamReader=new StreamReader(textFilePath))
            {
                while (true)
                {
                    string test = streamReader.ReadLine();

                    if (test==null)
                    {
                        break;
                    }
                    if (counter%2==0)
                    {
                        string replacedSymbols = ReplaceSpeicalCharacters(test);
                        string reversedWords = ReversedWords(replacedSymbols);


                        Console.WriteLine(reversedWords);
                    }
                    

                    counter++;
                }

            }
        }

        private static string ReversedWords(string replacedSymbols)
        {
            return string.Join(separator: " ", values: replacedSymbols.Split().Reverse());

            
        }

        private static string ReplaceSpeicalCharacters(string test)
        {
           return test.Replace(oldValue: "-", newValue: "@")
                .Replace(oldValue: ",", newValue: "@")
                .Replace(oldValue: ".", newValue: "@")
                .Replace(oldValue: "!", newValue: "@")
                .Replace(oldValue: "?", newValue: "@");
        }
    }
}
