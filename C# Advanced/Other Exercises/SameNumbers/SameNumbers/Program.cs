using System;

namespace SameNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumCheck = 1;
            int sum = 0;
            for (int i = 1; i < number.ToString().Length; i++)
            {
                if (number.ToString()[1] == number.ToString()[i])
                {
                    sumCheck++;
                }
            }
            for (int i = 0; i < number.ToString().Length; i++)
            {
                sum += (int)number.ToString()[i];
            }
            if (sumCheck == number.ToString().Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.WriteLine(sum);
        }
    }
}
