using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Replace_Repeating_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                char secondChar = input[i++];
                builder.Append(currentChar);
                if (secondChar==currentChar)
                {
                    builder.Replace(secondChar,'\0');
                }
              


            }
            Console.WriteLine(builder);
        }
    }
}
