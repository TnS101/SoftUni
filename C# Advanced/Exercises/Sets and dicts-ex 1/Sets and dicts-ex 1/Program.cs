using System;
using System.Collections.Generic;
namespace Sets_and_dicts_ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, string>();
            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, "sample Text");
                }

            }
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
