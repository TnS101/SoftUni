using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Purva_zadacha____stack_and_queue_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ingridients = new List<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshLevel = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var dict = new Dictionary<string, int>();
            while (ingridients.Count != 0 && freshLevel.Count!= 0)
            {
                int ingridient = ingridients[0];
                int fresh = freshLevel.Peek();
                int sum = ingridient * fresh;

                if (ingridient == 0)
                {
                    ingridients.Remove(ingridient);
                    continue;
                }

                if (sum== 150)
                {
                    string cocktail = "Mimosa";
                    if (!dict.ContainsKey(cocktail))
                    {
                        dict.Add(cocktail, 1);
                    }
                    else
                    {
                        dict[cocktail]++;
                    }
                    freshLevel.Pop();
                    ingridients.Remove(ingridient);
                }
                else if (sum == 250)
                {
                    string cocktail = "Daiquiri";
                    if (!dict.ContainsKey(cocktail))
                    {
                        dict.Add(cocktail, 1);
                    }
                    else
                    {
                        dict[cocktail]++;
                    }
                    freshLevel.Pop();
                    ingridients.Remove(ingridient);
                }
                else if (sum == 300)
                {
                    string cocktail = "Sunshine";
                    if (!dict.ContainsKey(cocktail))
                    {
                        dict.Add(cocktail, 1);
                    }
                    else
                    {
                        dict[cocktail]++;
                    }
                    freshLevel.Pop();
                    ingridients.Remove(ingridient);
                }
                else if (sum == 400)
                {
                    string cocktail = "Mojito";
                    if (!dict.ContainsKey(cocktail))
                    {
                        dict.Add(cocktail, 1);
                    }
                    else
                    {
                        dict[cocktail]++;
                    }
                    freshLevel.Pop();
                    ingridients.Remove(ingridient);
                }
                else
                {
                    freshLevel.Pop();
                    ingridients.Remove(ingridient);
                    ingridients.Add(ingridient + 5);
                }
            }
            if (dict.ContainsKey("Mimosa") && dict.ContainsKey("Mojito") && dict.ContainsKey("Sunshine") 
                && dict.ContainsKey("Daiquiri"))
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }
            if (ingridients.Count != 0)
            {
                Console.WriteLine($"Ingredients left: {ingridients.Sum()}");
            }
            foreach (var item in dict.OrderBy(k=>k.Key))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}
