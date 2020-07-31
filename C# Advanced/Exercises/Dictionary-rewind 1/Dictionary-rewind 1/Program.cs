using System;
using System.Collections.Generic;
using System.Linq;
namespace Dictionary_rewind_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayInput = Console.ReadLine().Split().Select(Double.Parse).ToArray();
            var dict = new Dictionary<double,int>();

            foreach (var item in arrayInput)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item,1);
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times.");
            }
        }
    }
}
