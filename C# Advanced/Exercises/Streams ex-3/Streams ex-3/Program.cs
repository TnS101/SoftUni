using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Streams_ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "text.txt";

            string wordsPath = "words.txt";

            string[] textLines = File.ReadAllLines(textPath);
            string[] words = File.ReadAllLines(wordsPath);

            var wordsInfo = new Dictionary<string, int>();

            foreach (var item in words)
            {
                string currentWordLowerCase = item.ToLower();
                if (!wordsInfo.ContainsKey(currentWordLowerCase))
                {

                    wordsInfo.Add(item,0);
                }
            }

            foreach (var item in textLines)
            {
                string[] currentLineWords = item.ToLower().Split(separator: new char[]
                { ' ', '-', ',', '?', '!', '.', '\'', ':',';' });

                foreach (var currentWord in currentLineWords)
                {
                    if (wordsInfo.ContainsKey(currentWord))
                    {
                        wordsInfo[currentWord]++;
                    }
                }
            }

            string actualResultPath = "actualResult.txt";
            string expectedResultPath = "expectedResult.txt";
            foreach (var (key,value) in wordsInfo)
            {
                File.AppendAllText(actualResultPath,contents:$"{key} - {value}" +
                    $"{Environment.NewLine}");
            }
            foreach (var (key,value) in wordsInfo.OrderByDescending(x=>x.Value))
            {
                File.AppendAllText(expectedResultPath, contents: $"{key} - {value}" +
                    $"{Environment.NewLine}");
            }
        }
    }
}
