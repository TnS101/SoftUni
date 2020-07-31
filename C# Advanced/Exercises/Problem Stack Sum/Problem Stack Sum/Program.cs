using System;
using System.Collections.Generic;
using System.Linq;
namespace Problem_Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack <int> stack= new Stack<int>();
            string[] command = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int number = 0;

            while (command[0]?.ToLower()!="end")
            {
                if (int.TryParse(command[0],out number))
                {
                    foreach (var item in command)
                    {
                        stack.Push(int.Parse(item));
                    }
                }
                else
                {
                    string controller = command[0]?.ToLower();

                    switch (controller)
                    {
                        case "add":
                            for (int i = 1; i < command.Length; i++)
                            {
                                stack.Push(int.Parse(command[i]));
                            }
                            break;
                        case "remove":
                            int count = int.Parse(command[1]);
                            if (count> stack.Count())
                            {
                                break;
                            }
                            for (int i = 0; i <count; i++)
                            {
                                stack.Pop();
                            }
                            break;
                        default:
                            break;
                    }
                }
                command = Console.ReadLine().Split(" ");
            }

            Console.WriteLine(stack.Sum());
        }
    }
}
