using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace Vapor_Winter_sale
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, double>();
            var dict1 = new Dictionary<string, string>();
            string[] input = Console.ReadLine().Split(", ").ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                string[] patern1 = input[i].Split(":").ToArray();
                string[] patern2 = patern1[0].Split("-").ToArray();


            }
            
            




        }
    }
}
