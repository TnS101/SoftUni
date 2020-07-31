using System;
using System.Linq;
namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split().ToList();
            while (true)
            {
                string[] controller = Console.ReadLine().Split().ToArray();
                string command = controller[0];
                if (command == "END")
                {
                    break;
                }

                if (command == "Insert")
                {
                    int index = int.Parse(controller[1]);
                    int realIndex = index + 1;
                    if (realIndex < input.Count && realIndex >= 0)
                    {
                        string numberToInsert = controller[2];
                        input.Insert(realIndex, numberToInsert);
                    }

                }
                if (command == "Change")
                {
                    string paintingNumber = (controller[1]);
                    string changedNumber = (controller[2]);
                    if (input.Contains(paintingNumber))
                    {
                        int indexOfPaintingNumber = input.IndexOf(paintingNumber);
                        input[indexOfPaintingNumber] = changedNumber;
                    }
                }
                if (command == "Hide")
                {
                    string numberToHide = controller[1];
                    if (input.Contains(numberToHide))
                    {
                        input.Remove(numberToHide);
                    }

                }
                if (command == "Switch")
                {
                    string firstNumber = controller[1];
                    string seccondNumber = controller[2];
                    if (input.Contains(firstNumber) && input.Contains(seccondNumber))
                    {
                        int index1 = input.IndexOf(firstNumber);
                        int index2 = input.IndexOf(seccondNumber);
                        input[index1] = seccondNumber;
                        input[index2] = firstNumber;
                    }

                }
                if (command == "Reverse")
                {
                    input.Reverse(0, input.Count);
                }



            }
            Console.WriteLine(string.Join(" ",input));

        }
    }
}
