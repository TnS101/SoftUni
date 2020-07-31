using System;
using System.Collections.Generic;
using System.Linq;
namespace Sets_and_dicts_ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstSetSize = sizes[0];
            int secondSetSize = sizes[1];

            for (int i = 0; i < firstSetSize; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                firstSet.Add(currentNumber);
            }
            for (int i = 0; i < secondSetSize; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                secondSet.Add(currentNumber);
            }
            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item+ " ");
                }
            }
        }
    }
}
