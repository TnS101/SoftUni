using System;
using System.Collections.Generic;
using System.Linq;
namespace Multidimentional_arrays_ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] inputNumbers = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[r, col] = inputNumbers[col];
                }
            }
            int maxSum = 0;
            int targetRow = 0;
            int targetCol = 0;
            for (int r = 0; r < matrix.GetLength(0)-2; r++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    int currentSum = matrix[r, col] + matrix[r, col + 1] + matrix[r, col + 2]//1-vi red
                        + matrix[r+1,col] + matrix[r + 1, col + 1] + matrix[r + 1, col + 2]//2-i red
                        + matrix[r+2,col]+matrix[r+2,col+1]+matrix[r+2,col+2];//treti red

                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        targetRow = r;
                        targetCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int r = targetRow; r <= targetRow+2; r++)
            {
                for (int col = targetCol; col <= targetCol+2; col++)
                {
                    Console.Write(matrix[r,col]+" ");
                }
                Console.WriteLine();
            }
           
        }
    }
}
