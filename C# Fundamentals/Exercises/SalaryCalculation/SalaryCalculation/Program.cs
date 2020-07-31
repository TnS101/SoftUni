using System;

namespace SalaryCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            double salary = 0;
            double taxes = 0;
            double savings = 0;
            Console.WriteLine("Insert the number of working days.");
            Console.WriteLine();
            int workingDays = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Insert the number of night shifts.");
            Console.WriteLine();
            int nightShifts = int.Parse(Console.ReadLine());
            salary += workingDays * 120 + nightShifts * 140;
            double initialSalary = salary;
            Console.WriteLine();
            Console.WriteLine($"Your initial salary for this month is : {salary:f2}!");
            Console.WriteLine();
            Console.WriteLine("Insert taxes.(Enter 12345 when ready)");
            Console.WriteLine();
            while (true)
            {
                double tax = double.Parse(Console.ReadLine());
                
                if (tax == 12345)
                {
                    Console.WriteLine();
                    break;
                }
                
                if (salary >= tax)
                {
                    taxes += tax;
                    salary -= tax;
                    Console.WriteLine($"Great! You still have {salary:f2} lv. left!");
                    Console.WriteLine();
                    continue;
                }
                else if (salary < tax)
                {
                    Console.WriteLine($"You cannot set more money for taxes (Maximum : {salary:f2}).");
                    Console.WriteLine();
                    Console.WriteLine("Please,insert taxes again.");
                    Console.WriteLine();
                    continue;
                }
                
                
            }
            
            Console.WriteLine("Would you like to save money this month? (Up Arrow = yes , Down Arrow = no)");
            Console.WriteLine();
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    Console.WriteLine("How much money would you like to save?");
                    savings = double.Parse(Console.ReadLine());
                    if (salary - savings >= 0)
                    {
                        salary -= savings;
                        Console.WriteLine();
                        Console.WriteLine($"Sweet! You have saved {savings:f2} leva!");
                        Console.WriteLine();
                        Console.WriteLine("Total Summary :");
                        Console.WriteLine($"[] Initial salary for this month : {initialSalary:f2}");
                        Console.WriteLine();
                        Console.WriteLine($"[] Total taxes for this month : {taxes:f2}");
                        Console.WriteLine();
                        Console.WriteLine($"[] Saved money for this month : {savings:f2}");
                        Console.WriteLine();
                        Console.WriteLine($"[] Money left : {salary:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"You can't save that much money!");
                        Console.WriteLine();
                        Console.WriteLine($"You can only save {salary:f2} leva! (Press UpArrow to save money or Press DownArrow to exit.)");
                        continue;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    Console.WriteLine();
                    Console.WriteLine("Okay...maybe next month! :)");
                    Console.WriteLine();
                    Console.WriteLine("Total Summary :");
                    Console.WriteLine($"[] Initial salary for this month : {initialSalary:f2}");
                    Console.WriteLine();
                    Console.WriteLine($"[] Total taxes for this month : {taxes:f2}");
                    Console.WriteLine();
                    Console.WriteLine($"[] Money left : {salary}");
                }
                else
                {
                    Console.WriteLine("Invalid command!Please try again!");
                    continue;
                }
            }
        }
    }
}
