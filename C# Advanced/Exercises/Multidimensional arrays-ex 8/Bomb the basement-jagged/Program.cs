using System;
using System.Collections.Generic;
using System.Linq;
namespace Bomb_the_basement_jagged
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] basement = new int[rows][];

            for (int i = 0; i < basement.Length; i++)
            {
                basement[i] = new int[cols];
            }

            int[] coordinates=Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();

            int targetRow = coordinates[0];
            int targetCol = coordinates[1];
            int radius = coordinates[2];

            for (int row = 0; row < basement.Length; row++)
            {
                for (int col = 0; col < basement[row].Length; col++)
                {
                    bool isInRadius = Math.Pow(row - targetRow, 2)
                        + Math.Pow(col - targetCol, 2) <= Math.Pow(radius, 2);
                    if (isInRadius)
                    {
                        basement[row][col] = 1;
                    }
                }
            }

            int counter = 0;
            
            for (int row = basement.Length - 1; row >= 0; row--)
            {
                for (int col = basement[row].Length - 1; col >= 0; col--)
                {
                    if (basement[row][col]==1)
                    {
                        counter++;
                        basement[row][col] = 0;
                    }
                }
                for (int col = 0; col < counter; col++)
                {
                    basement[row][col] = 1;
                }
            }
            foreach (var row in basement)
            {
                Console.WriteLine(string.Join("", row));
            }
            

        }
    }
}
