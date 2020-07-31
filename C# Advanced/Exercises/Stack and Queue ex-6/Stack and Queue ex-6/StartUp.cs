namespace Stack_and_Queue_ex_6
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] controls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queueCar = new Queue<string>(controls);
            var servedCars = new Stack<string>();

            string input = Console.ReadLine();

            while (input!="End")
            {
                if (input=="Service"&&queueCar.Count>0)
                {
                    string currentCar = queueCar.Dequeue();
                    servedCars.Push(currentCar);
                    Console.WriteLine($"Vechicle {currentCar} got served.");
                }
                else if (input.Contains("CarInfo"))
                {
                    string carName = input.Split("-")[1];
                    if (queueCar.Contains(carName))
                    {
                        Console.WriteLine($"Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine($"Served.");
                    }
                }
                else if (input=="History")
                {
                    Console.WriteLine(string.Join(",", servedCars));
                }

                input = Console.ReadLine();
            }
            if (queueCar.Count>0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(",", queueCar)}");
            }
            Console.WriteLine($"Served cars{string.Join(",", servedCars)}");

        }
    }
}
