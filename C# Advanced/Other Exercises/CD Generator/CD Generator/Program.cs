using System;
using System.Linq;
using System.Text;

namespace CD_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Upper Case or Lower Case (Upper Arrow / Down Arrow) Characters or Digits(Spacebar).");
            
            int[] keyCheck = KeyCheck();

            Console.WriteLine("Choose the number of the required CD keys.");

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string output = CodeGenerate(keyCheck);
                Console.WriteLine(Print(output));
            }
        }

        private static string Print(string output)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < output.Length; i++)
            {
                if (i % 4 == 0 && i == output.Length - 4)
                {
                    sb.Append($"{output.Substring(i, 4)}");
                }
                else if (i % 4 == 0)
                {
                    sb.Append($"{output.Substring(i, 4)}-");
                }
            }
            return sb.ToString();
        }

        private static string CodeGenerate(int[] array)
        {
            var sb = new StringBuilder();
            var rng = new Random();

            for (int i = 0; i < 16; i++)
            {
                int num = rng.Next(array[0], array[1]);
                sb.Append((char)num);
            }
            return IdenticalCharactersCheck(sb.ToString(),array);
        }

        private static string IdenticalCharactersCheck(string sb, int[] array)
        {
            var rng = new Random();

            for (int i = 1; i < sb.Length; i++)
            {
                if (sb[0] == sb[i])
                {
                    int num = rng.Next(array[0],array[1]);
                    sb.ToList().Insert(i, (char)num);
                }
            }

            return sb;
        }

        private static int[] KeyCheck()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    int[] array = { 65, 91 };
                    return array;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    int[] array = { 97, 123 };
                    return array;
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    int[] array = { 48, 58 };
                    return array;
                }
                else
                {
                    Console.WriteLine("Wrong command,please insert a valid key (Up Arrow / Down Arrow / Spacebar).");
                    continue;
                }
            }
        }
    }

}
