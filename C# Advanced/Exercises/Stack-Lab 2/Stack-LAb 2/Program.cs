using System;
using System.Collections.Generic;
using System.Linq;
namespace Stack_LAb_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] expression = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(expression.Reverse());

            while (stack.Count!=0)
            {
                int opperand1 = int.Parse(stack.Pop());
                int opperand2 = int.Parse(stack.Pop());
                string opr = stack.Pop();

                switch (opr)
                {
                    case "+":
                        stack.Push((opperand1 + opperand2).ToString());
                        break;
                    case "-":
                        stack.Push((opperand1 - opperand2).ToString());
                        break;
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}
