using System;
using System.Collections.Generic;
using System.Linq;
namespace Sets_and_dicts_ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, string>();
            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    if (!dict.ContainsKey(input[j]))
                    {
                        dict.Add(input[j], "sample text");
                    }
                    
                }
               
            }
            foreach (var item in dict.OrderBy(Key=>Key.Key))
            {

                Console.Write($"{item.Key} ");
            }
           
        }
    }
}
