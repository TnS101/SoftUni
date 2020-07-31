using System;
using System.Collections.Generic;
namespace Stacks_Lab_1
{
    class StackDemo
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack < char > stack= new Stack<char>();
            foreach (var item in input)
            {
                stack.Push(item);
            }
            while (stack.Count!=0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
