using System;
using System.Collections.Generic;
using System.Linq;
namespace Funct_programm_ex___5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int> incrementByOne = x => x += 1;
            Func<int, int> multiply = x => x *= 2;
            Func<int, int> substract = x => x -= 1;
            Func<int, int> print = Console.WriteLine(string.Join(" ",));
            string command = Console.ReadLine();
            while (command!="end")
            {
                if (command=="add")
                {
                    input.Select(incrementByOne).ToArray();
                }
                else if (command=="multiply")
                {
                    input.Select(multiply).ToArray();
                }
                else if(command=="substract")
                {
                    input.Select(substract).ToArray();
                }
                else if (command == "print")
                {
                    input.Select(substract).ToArray();
                }
            }

        }
    }
}
