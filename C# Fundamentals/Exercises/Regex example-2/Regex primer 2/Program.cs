using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp178
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex dishes = new Regex(@"<([\da-z]+)>");
            Regex house = new Regex(@"\[([\dA-Z]+)\]");
            Regex laundry = new Regex(@"{([\W\w\d]+)}");

            int dishesTime = 0;
            int houseTime = 0;
            int laundryTime = 0;

            Regex numbers = new Regex(@"[\d]");

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "wife is happy")
                {
                    break;
                }
                var disheshMatch = dishes.Match(command);
                var houseMatch = house.Match(command);
                var laundryMatch = laundry.Match(command);
                if (disheshMatch.Success)
                {
                    var time = numbers.Matches(disheshMatch.Groups[0].Value);
                    foreach (var item in time)
                    {
                        dishesTime += int.Parse(item.ToString());
                    }

                }
                if (houseMatch.Success)
                {
                    var time = numbers.Matches(houseMatch.Groups[0].Value);
                    foreach (var item in time)
                    {
                        houseTime += int.Parse(item.ToString());
                    }
                }
                if (laundryMatch.Success)
                {
                    var time = numbers.Matches(laundryMatch.Groups[0].Value);
                    foreach (var item in time)
                    {
                        laundryTime += int.Parse(item.ToString());
                    }
                }
            }
            Console.WriteLine($"Doing the dishes - {dishesTime} min.");
            Console.WriteLine($"Cleaning the house - {houseTime} min.");
            Console.WriteLine($"Doing the laundry - {laundryTime} min.");
            Console.WriteLine($"Total - {dishesTime + houseTime + laundryTime} min.");



        }
    }
}