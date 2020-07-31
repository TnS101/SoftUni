using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Song_encryption_regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string artistPattern = @"^(?<artist>[A-Z][a-z ']*)$";
            string songPattern = @"^(?<songName>[A-Z ]+)|$";
            string keepPattern = @"[^' @]";
            string input = Console.ReadLine();
            while (!input.Equals("end"))
            {
                string[] tokens = input.Split(":").ToArray();
                string artist = tokens[0];
                string song = tokens[1];

                bool artistIsValid = Regex.IsMatch(artist, artistPattern);
                bool songIsValid = Regex.IsMatch(song, songPattern);

                if (!artistIsValid || !songIsValid)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (artistIsValid && songIsValid)
                {
                    Match artistMatch = Regex.Match(artist, artistPattern);
                    Match songMatch = Regex.Match(song, songPattern);
                    var sb = new StringBuilder();
                    int length = artist.Length;
                    string text = $"{artistMatch.Groups["artist"].Value}@{songMatch.Groups["songName"].Value}";

                    foreach (var item in text)
                    {
                        char currentSymbol = item;
                        bool isValidSymbol = Regex.IsMatch(currentSymbol
                            .ToString(), keepPattern);
                        if (isValidSymbol)
                        {
                            currentSymbol += (char)length;

                            if (item <= 90 && currentSymbol > 90)
                            {
                                currentSymbol -= (char)26;
                            }
                            else if (item <= 122 && currentSymbol > 122)
                            {
                                currentSymbol -= (char)26;
                            }
                        }
                        sb.Append(currentSymbol);
                        
                    }
                    Console.WriteLine($"{sb}");

                }
                input = Console.ReadLine();
            }
           
        }
        
    }
}
