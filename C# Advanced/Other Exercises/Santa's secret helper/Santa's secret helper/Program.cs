using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;
 
namespace Santa_s_secret_helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string input = string.Empty;
            var sb = new StringBuilder();
            while (input != "end")
            {
                input = Console.ReadLine();
                for (int i = 0; i < input.Length; i++)
                {
                    int charIndex = (int)(input[i] - num);
                    char realChar = Convert.ToChar(charIndex);
                    sb.Append(realChar);
                }

            }

            List<string> inputs = sb.ToString().Split('@').ToList();

            string namePat = @"[A-Z][a-z]+";
            string goodPat = @"(?<=!)[A-Z](?=!)";

            Regex options1 = new Regex(namePat);
            Regex options2 = new Regex(goodPat);

            foreach (var m in inputs)
            {
                Match match = options1.Match(m);
                if (match.Success)
                {
                    string name = match.Value;

                    match = options2.Match(m);
                    string good = match.Value;

                    if (good != "N")
                    {
                        Console.WriteLine($"{name}");
                    }
                }

            }

        }
    }
}