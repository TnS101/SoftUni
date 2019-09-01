using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Password__vtora_zadacha_
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<start>.*)>(?<pass>\d*)\|(?<yes>[a-z]*)\|(?<YES>[A-Z]*)\|(?<bs>.*)<(?<end>.*)";
            int num = int.Parse(Console.ReadLine());
            Regex regex = new Regex(pattern);
            for (int i = 0; i <num; i++)
            {
                string input = Console.ReadLine();
                Match inputMatch = regex.Match(input);
                if (inputMatch.Success)
                {
                    string pass = inputMatch.Groups[2].Value;
                    string yes = inputMatch.Groups[3].Value;
                    string YES = inputMatch.Groups[4].Value;
                    string symbols = inputMatch.Groups[5].Value;
                    string startingChar = inputMatch.Groups["start"].Value;
                    string endingChar = inputMatch.Groups["end"].Value;
                    
                    if (startingChar == endingChar &&!symbols.Contains('<')
                        && !symbols.Contains('>') && pass.Length == 3 && char.IsDigit(pass[0])
                        && char.IsDigit(pass[1])&& char.IsDigit(pass[2]))
                    {
                        
                        var sb = new StringBuilder();
                        foreach (var item in pass)
                        {
                            sb.Append(item);
                        }
                        foreach (var item in yes)
                        {
                            sb.Append(item);
                        }
                        foreach (var item in YES)
                        {
                            sb.Append(item);
                        }
                        foreach (var item in symbols)
                        {
                            sb.Append(item);
                        }

                        Console.WriteLine($"Password: {sb.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Try another password!");
                    }
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
            
        }
    }
}
