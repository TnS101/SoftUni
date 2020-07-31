using System;
using System.Collections.Generic;
using System.Linq;
namespace Sets_and_cits_ex_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string,int>>();
            for (int i = 0; i <num; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
               
                if (!dict.ContainsKey(color))
                {
                    dict.Add(color, new Dictionary<string, int>());
                }
                string[] clothes = input[1].Split(",");
                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!dict[color].ContainsKey(clothes[j]))
                    {
                        dict[color].Add(clothes[j], 0);
                    }
                    dict[color][clothes[j]]++;
                }
                
            }

            string[] targetCloth = Console.ReadLine().Split();

            string colorOfTarget = targetCloth[0];
            string clothOfTarget = targetCloth[1];

            foreach (var (color,clothes) in dict)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (cloth,count) in clothes)
                {
                    string result=$"* {cloth} - {count}";
                    if (color==colorOfTarget&&clothOfTarget==cloth)
                    {
                        result +=" (found!)";
                    }
                    Console.WriteLine(result);
                }
            }
        }
    }
}
