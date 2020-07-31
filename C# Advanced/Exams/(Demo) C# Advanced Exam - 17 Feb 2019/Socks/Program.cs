using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> leftSocks = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> rightSocks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            List<int> pairs = new List<int>();

           while (true)
            {
                if (leftSocks.Count == 0 || rightSocks.Count ==0)
                {
                    break;
                }
                int lastLeftSock = leftSocks.Peek();
                int firstRightSock = rightSocks.Peek();

                if (lastLeftSock > firstRightSock)
                {
                    int pair = lastLeftSock + firstRightSock;
                    pairs.Add(pair);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                    
                }
                else if (lastLeftSock<firstRightSock)
                {
                    leftSocks.Pop();
                }
                else if (lastLeftSock == firstRightSock)
                {
                    rightSocks.Dequeue();
                    leftSocks.Push(leftSocks.Peek()+1);
                }
            }
            int maxP = pairs.Max();
            Console.WriteLine(maxP);
            Console.WriteLine(string.Join(" ",pairs));
        }
    }
}
