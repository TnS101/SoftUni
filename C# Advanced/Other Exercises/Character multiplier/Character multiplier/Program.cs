using System;
using System.Linq;
using System.Collections.Generic;
namespace Character_multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            string firstWord = tokens[0];
            string secondWord = tokens[1];

            string longestWord = string.Empty;
            string shortestWord = string.Empty;
            int sum = 0;
            if (firstWord.Length >= secondWord.Length)
            {
                longestWord = firstWord;
                shortestWord = secondWord;
            }
            else
            {
                longestWord = secondWord;
                shortestWord = firstWord;
            }

            for (int i = 0; i < shortestWord.Length; i++)
            {
                sum += longestWord[i] * shortestWord[i];
            }
            for (int i = shortestWord.Length; i < longestWord.Length; i++)
            {
                sum += longestWord[i];
            }
            Console.WriteLine(sum);
        }
    }
}
