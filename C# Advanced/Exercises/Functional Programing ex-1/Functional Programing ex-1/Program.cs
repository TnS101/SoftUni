using System;
using System.Linq;
using System.Collections.Generic;
namespace Functional_Programing_ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printedNames= names=>
            Console.WriteLine(string.Join(Environment.NewLine,names));

            string[] input = Console.ReadLine().Split().ToArray();

            printedNames(input);
        }
    }
}
