using System;
using System.Collections.Generic;
namespace Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("#");
            var cells = new List<int>();
            double totalWater = double.Parse(Console.ReadLine());
            double totalFire = 0;
            double effort = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split(" = ");
                string fireType = tokens[0];
                int firePower = int.Parse(tokens[1]);
                if (fireType == "High" && firePower >= 81 && firePower <= 125 && totalWater >= firePower)
                {
                    totalWater -= firePower;
                    effort += 0.25 * firePower;
                    totalFire += firePower;
                    cells.Add(firePower);
                }
                if (fireType == "Medium" && firePower >= 51 && firePower <= 80 && totalWater >= firePower)
                {
                    totalWater -= firePower;
                    effort += 0.25 * firePower;
                    totalFire += firePower;
                    cells.Add(firePower);
                }
                if (fireType == "Low" && firePower >= 1 && firePower <= 50 && totalWater >= firePower)
                {
                    totalWater -= firePower;
                    effort += 0.25 * firePower;
                    totalFire += firePower;
                    cells.Add(firePower);
                }
            }
            Console.WriteLine("Cells:");
            foreach (var cell in cells)
            {
                Console.WriteLine($" - {cell}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}