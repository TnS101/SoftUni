using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extract_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int startIndexOfFile = input.LastIndexOf('\\')+1;
            string file = input.Substring(startIndexOfFile);
            string [] final = file.Split(".").ToArray();
            Console.WriteLine($"File name: {final[0]}");
            Console.WriteLine($"File extension: {final[1]}");
        }
    }
}
