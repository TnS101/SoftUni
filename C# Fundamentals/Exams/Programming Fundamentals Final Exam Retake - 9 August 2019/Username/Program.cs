using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Username___purva_zadacha
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "Sign" && commands[1]=="up")
                {
                    break;
                }
                else if (commands[0]=="Case")
                {
                    string caseType = commands[1];
                    foreach (var item in input)
                    {
                        if (caseType == "upper")
                        {
                            if (char.IsLower(item))
                            {
                                input = input.Replace(item,char.ToUpper(item));
                            }
                        }
                        else if (caseType == "lower")
                        {
                            if (char.IsUpper(item))
                            {
                                input = input.Replace(item, char.ToLower(item));
                            }
                        }
                    }
                    Console.WriteLine(input);
                }
                else if (commands[0] == "Reverse")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    string currentInput = input;
                   
                    if (1<=startIndex && endIndex<currentInput.Length)
                    {
                        var sb = new StringBuilder();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                           sb.Append(currentInput[i]);
                            
                        }
                        char[] charArray = sb.ToString().ToCharArray();
                        Array.Reverse(charArray);
                        Console.WriteLine(charArray);
                    }
                    
                }
                else if (commands[0] == "Cut")
                {
                    string substring = commands[1];
                    if (input.Contains(substring))
                    {
                        input = input.Replace(substring,"");
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine($"The word {input} doesn't contain {substring}.");
                    }
                }
                else if (commands[0] == "Replace")
                {
                    char toReplace = char.Parse(commands[1]);
                    foreach (var item in input)
                    {
                        if (item == toReplace)
                        {
                            input = input.Replace(item,'*');
                        }
                    }
                    Console.WriteLine(input);
                }
                else if (commands[0] == "Check")
                {
                    char toCheck = char.Parse(commands[1]);
                    if (input.Contains(toCheck))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {toCheck}.");
                    }
                }
            }
        }
    }
}
