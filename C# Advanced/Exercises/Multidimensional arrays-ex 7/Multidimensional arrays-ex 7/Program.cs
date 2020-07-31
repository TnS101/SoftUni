using System;
namespace Multidimensional_arrays_ex_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                char[] inputRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    matrix[r, col] = inputRow[col];
                }
            }

            int counter = 0;
            while (true)
            {
                int knightsCount = 0;
                int maxCount=0;
                int knightRow = 0;
                int knightCol = 0;
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[r, col] == 'K')
                        {
                            if (isInside(matrix, r - 2, col + 1) && matrix[r - 2, col + 1] == 'K')
                            {
                                knightsCount++;
                            }
                            if (isInside(matrix, r - 2, col - 1) && matrix[r - 2, col - 1] == 'K')
                            {
                                knightsCount++;
                            }
                            if (isInside(matrix, r + 2, col + 1) && matrix[r + 2, col + 1] == 'K')
                            {
                                knightsCount++;
                            }
                            if (isInside(matrix, r + 2, col - 1) && matrix[r + 2, col - 1] == 'K')
                            {
                                knightsCount++;
                            }
                            if (isInside(matrix, r - 1, col - 2) && matrix[r - 1, col - 2] == 'K')
                            {
                                knightsCount++;
                            }
                            if (isInside(matrix, r + 1, col - 2) && matrix[r + 1, col - 2] == 'K')
                            {
                                knightsCount++;
                            }
                            if (isInside(matrix, r + 1, col + 2) && matrix[r + 1, col + 2] == 'K')
                            {
                                knightsCount++;
                            }
                            if (isInside(matrix, r - 1, col + 2) && matrix[r - 1, col + 2] == 'K')
                            {
                                knightsCount++;
                            }
                        }
                        if (knightsCount>maxCount)
                        {
                            maxCount = knightsCount;
                            knightRow = r;
                            knightCol = col;
                        }
                    }
                }
                if (knightsCount==0)
                {
                    break;
                }
                matrix[knightRow, knightCol] = '0';
                counter++;
            }
            Console.WriteLine(counter);
        }

        private static bool isInside(char[,] matrix, int desiredRow, int desiredCol)
        {
            return desiredRow < matrix.GetLength(0)
                && desiredRow >= 0
                && desiredCol < matrix.GetLength(1)
                && desiredCol >= 0;
        }
    }
}
