using System;
using System.Linq;
using System.Collections.Generic;
    
namespace Santas_gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list =Console.ReadLine().Split().Select(int.Parse).ToList();
            int santaPosition = 0;
            for (int i = 0; i < n; i++)
            {
                string [] input = Console.ReadLine().Split().ToArray();
                if (input[0]=="Forward")
                {
                    if (santaPosition<0)
                    {
                        break;
                    }
                    int index=int.Parse(input[1]);
                    
                    santaPosition += index;
                    list.RemoveAt(santaPosition);
                }
                if (input[0] == "Back")
                {
                    int index = int.Parse(input[1]);
                    if (santaPosition < 0)
                    {
                        break;
                    }
                    santaPosition -= index;
                    list.RemoveAt(santaPosition);
                    
                    

                }
                if (input[0] == "Gift")
                {
                    int index = int.Parse(input[1]);
                    int houseNumber = int.Parse(input[2]);
                    if (index<0)
                    {
                        break;

                    }
                    list.Insert(index,houseNumber);
                    santaPosition = index;

                }
                if (input[0] == "Swap")
                {
                    int firstNumber = int.Parse(input[1]);
                    int secondNumber = int.Parse(input[2]);
                    int index1 = list.IndexOf(firstNumber);
                    int index2= list.IndexOf(secondNumber);
                    if (index1<=list.Count&&index2<=list.Count&&list.Contains(firstNumber)&&list.Contains(secondNumber))
                    {
                        list.Remove(firstNumber);
                        
                        list.Insert(index2,firstNumber);
                        list.Remove(secondNumber);
                        list.Insert(index1,secondNumber);
                    }
                    else
                    {
                        break;
                    }
                    
                   
                }

            }
            Console.WriteLine(santaPosition);
            Console.WriteLine(String.Join(", ", (list)));

        }
    }
}
