using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Club_Party_stack_
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            Stack<string> halls = new Stack<string>(Console.ReadLine()
                .Split());
            var dict = new Dictionary<string, List<int>>();
            for (int i = 0; i < halls.Count; i++)
            {
                string element = halls.Peek();
                if (char.IsLetter(element[0]))
                {
                    string elementToAdd = halls.Pop();
                    if (!dict.ContainsKey(element))
                    {
                        dict.Add(elementToAdd, new List<int>());
                    }
                }

                 else //(char.IsDigit(element[0]))
                {
                    int people = int.Parse(halls.Pop());
                    if (dict[element].Sum() <= hallCapacity - people )
                    {
                        dict[element].Add(people);
                    }
                    else
                    {
                        foreach (var item in dict)
                        {
                            Console.WriteLine($"{item.Key} -> {string.Join(",",item.Value)}");
                        }
                    }
                    
                    
                }
            }
        }
    }
}
