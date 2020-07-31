using System;
using System.Collections.Generic;
namespace Mid_zadacha_dve
{
    class Program
    {
        static void Main(string[] args)
        {
           List<string> input = new List<string>(Console.ReadLine().Split("|"));
            
            double treasure = 0;
            
            List<string> output = new List<string>();
            while (true)
            {
               string [] commands = Console.ReadLine().Split();

                if (commands[0] == "Loot")
                {
                  
                    for (int i = 1; i <= commands.Length; i++)
                    {
                        
                        
                        if (!input.Contains(commands[i]))
                        {
                            input.Insert(0, commands[i]);
                        }
                       
                       

                    }
                    
                }
                else if (commands[0] == "Drop")
                {
                    int index = int.Parse(commands[1]);
                    string toAdd = string.Empty;
                    if (0<=index && index < input.Count)
                    {
                        toAdd = input[index];
                       
                        input.RemoveAt(index);
                        input.Add(toAdd);

                    }
                    
                }
                else if (commands[0] == "Steal")
                {
                    int stealCount = int.Parse(commands[1]);
                    int toRemove = Math.Abs(stealCount - input.Count);
                    if (stealCount>input.Count)
                    {
                        
                        for (int i = input.Count - 1; i >= toRemove; i--)
                        {
                            output.Insert(0, input[i]);
                            input.RemoveAt(i);
                        }
                    }
                    else 
                    {
                        
                        for (int i = input.Count - 1; i > stealCount+1; i--)
                        {
                            output.Insert(0,input[i]);
                            input.RemoveAt(i);
                        }


                        
                    }
                   

                    
                }
                else if (commands[0] == "Yohoho!")
                {
                    break;
                }



            }
            foreach (var item in input)
            {
                treasure +=item.Length;
            }
            treasure = treasure / input.Count;
            Console.WriteLine(string.Join(", ", output));
           // Console.WriteLine(input.Count);
            if (input.Count<=0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                Console.WriteLine($"Average treasure gain: {treasure:f2} pirate credits.");
            }

        }
    }
}
