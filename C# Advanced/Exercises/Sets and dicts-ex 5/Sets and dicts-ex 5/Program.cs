using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_and_dicts_ex_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict.Add(input[i],0);
                }
                dict[input[i]]++;
            }
            foreach (var item in dict.OrderBy(Key=>Key.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
