using System;
using System.Linq;
using System.Collections.Generic;
namespace Funct_program_ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();

            int lowerBounds = input[0];
            int upperBounds = input[1];

            List<int> numbers = new List<int>();

            string numberType = Console.ReadLine();

            for (int i = lowerBounds; i <= upperBounds; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = number => number % 2 == 0;
            Predicate<int> isOdd = number => number % 2 != 0;
            Action<List<int>> printedNumbers = outputNumbers => Console.WriteLine
            (string.Join(" ",outputNumbers));
            if (numberType=="odd")
            {
                numbers=numbers.Where(x => isOdd(x)).ToList();
            }
            else
            {
                numbers = numbers.Where(x => isEven(x)).ToList();
            }

            printedNumbers(numbers);
        }
    }
}
