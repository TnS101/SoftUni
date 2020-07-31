using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_and_dicts___ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < num; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, 0);
                    
                }
                dict[input]++;
            }
            var evenTimesNumber = dict.SingleOrDefault(number=>number.Value%2==0).Key;
            Console.WriteLine(evenTimesNumber);
        }
    }
}
