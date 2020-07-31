using System;
using System.Linq;
using System.Collections.Generic;
namespace Multidimentional_Arrays_ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows,cols];

            string snake = Console.ReadLine();
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake[counter++];
                    if (counter>=snake.Length)
                    {
                        counter=0;
                        
                    }
                }
            }
            for (int row = 0; row <matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
