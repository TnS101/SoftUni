using System;
using System.Collections.Generic;
using System.Linq;
namespace Trj_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<int> shields = new List<int>(Console.ReadLine()
                .Split().Select(int.Parse));
            Stack<int> warriors = new Stack<int>();
            for (int i = 1; i <= num; i++)
            {
                warriors = new Stack<int>(Console.ReadLine()
                   .Split().Select(int.Parse));

                if (i % 3 == 0)
                {
                    shields.Add(int.Parse(Console.ReadLine()));
                }
                while (warriors.Count != 0 && shields.Count != 0)
                {
                    int shield = shields[0];
                    int warrior = warriors.Pop();

                    if (warrior > shield)
                    {
                        warrior -= shield;
                        warriors.Push(warrior);
                        shields.RemoveAt(0);
                    }
                    else if (shield > warrior)
                    {
                        shield -= warrior;
                        shields[0] = shield;
                    }
                    else if (shield == warrior)
                    {
                        shields.RemoveAt(0);
                    }

                }
                if (shields.Count == 0)
                {
                    break;
                }

            }
            if (shields.Count == 0)
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                if (warriors.Count != 0)
                {
                    Console.WriteLine($"Warriors left: { string.Join(", ", warriors)}");
                }

            }
            if (warriors.Count == 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                if (shields.Count != 0)
                {
                    Console.WriteLine($"Plates left: {string.Join(", ", shields)}");

                }

            }

        }
    }
}
