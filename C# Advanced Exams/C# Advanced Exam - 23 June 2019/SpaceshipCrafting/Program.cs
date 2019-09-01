using System;
using System.Collections.Generic;
using System.Linq;
namespace Spaceship_crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liquidInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> liquids = new Queue<int>();
            foreach (var item in liquidInput)
            {
                liquids.Enqueue(item);
            }
            Stack<int> physical = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int glassCount = 0;
            int litCount = 0;
            int aCount = 0;
            int fiberCount = 0;
            var advancedMaterials = new Dictionary<string, int>();
            while (liquids.Count > 0 && physical.Count > 0)
            {
                int firstLiquid = liquids.Peek();
                int lastPhysical = physical.Peek();
                int sum = firstLiquid + lastPhysical;
                if (sum == 25)
                {
                    string item = "Glass";
                    if (!advancedMaterials.ContainsKey(item))
                    {
                        advancedMaterials.Add(item, 1);
                        glassCount++;
                    }
                    else
                    {
                        advancedMaterials[item]++;
                        glassCount++;
                    }
                    liquids.Dequeue();
                    physical.Pop();
                }
                else if (sum == 50)
                {
                    string item = "Aluminium";
                    if (!advancedMaterials.ContainsKey(item))
                    {
                        advancedMaterials.Add(item, 1);
                        aCount++;
                    }
                    else
                    {
                        advancedMaterials[item]++;
                        aCount++;
                    }
                    liquids.Dequeue();
                    physical.Pop();
                }
                else if (sum == 75)
                {
                    string item = "Lithium"; if (!advancedMaterials.ContainsKey(item))
                    {
                        advancedMaterials.Add(item, 1);
                        litCount++;
                    }
                    else
                    {
                        advancedMaterials[item]++;
                        litCount++;
                    }
                    liquids.Dequeue();
                    physical.Pop();
                }
                else if (sum == 100)
                {
                    string item = "Carbon fiber"; if (!advancedMaterials.ContainsKey(item))
                    {
                        advancedMaterials.Add(item, 1);
                        fiberCount++;
                    }
                    else
                    {
                        advancedMaterials[item]++;
                        fiberCount++;
                    }
                    liquids.Dequeue();
                    physical.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    physical.Pop();
                    physical.Push(lastPhysical+3);
                }
            }
            if (advancedMaterials.ContainsKey("Glass")
                && advancedMaterials.ContainsKey("Lithium")
                && advancedMaterials.ContainsKey("Aluminium")
                && advancedMaterials.ContainsKey("Carbon fiber"))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }
            if (physical.Count==0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ",physical)}");
            }
            Console.WriteLine($"Aluminium: {aCount}");
            Console.WriteLine($"Carbon fiber: {fiberCount}");
            Console.WriteLine($"Glass: {glassCount}");
            Console.WriteLine($"Lithium: {litCount}");
        }
    }
}
