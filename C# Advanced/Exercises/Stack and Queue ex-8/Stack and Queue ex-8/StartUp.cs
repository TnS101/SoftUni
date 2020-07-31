

namespace Stack_and_Queue_ex_8
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<char> stackOfParenteses = new Stack<char>();

            char[] input = Console.ReadLine()
                .ToCharArray();
            char[] openParanteses = new char[] { '(', '{', '[' };

            bool isValid = true;

            
            foreach (var item in input)
            {
                if (openParanteses.Contains(item))
                {
                    stackOfParenteses.Push(item);
                    continue;
                }

                if (stackOfParenteses.Count==0)
                {
                    isValid = false;
                    break;
                }
               else if (stackOfParenteses.Peek()=='(' && item==')')
                {
                    stackOfParenteses.Pop();
                }
                else if (stackOfParenteses.Peek() == '[' && item == ']')
                {
                    stackOfParenteses.Pop();
                }
                else if (stackOfParenteses.Peek() == '{' && item == '}')
                {
                    stackOfParenteses.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Console.WriteLine("Yes.");
            }
            else
            {
                Console.WriteLine("No.");
            }
        }
    }
}
