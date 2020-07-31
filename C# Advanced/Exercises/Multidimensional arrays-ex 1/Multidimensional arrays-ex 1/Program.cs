using System;
using System.Collections.Generic;
using System.Linq;
namespace Multidimensional_arrays_ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size1 = int.Parse(Console.ReadLine());
            int size2 = size1;
            int[,] matrix = new int [size1,size2];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var input = Console.ReadLine()
                    .Split().Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    
                    matrix[r, col] = input[col];
                }
               
            }
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int sum = 0;
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    sum += matrix[r, c];
                }
                Console.WriteLine(sum);
            }
            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
