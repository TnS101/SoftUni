using System;

namespace Mid_Izpit___zadacha_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double plunder = 0;
            double expectedPlunder = double.Parse(Console.ReadLine());
            for (int i = 1; i <= days; i++)
            {
                plunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    plunder += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {
                    plunder -= 0.3 * plunder;
                }
              
               

            }
            if (plunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {plunder:f2} plunder gained.");
            }
            else 
            {
                
               
                double output = plunder / expectedPlunder *100;
                

                // 250 - 50 = 200
                Console.WriteLine($"Collected only {output:f2}% of the plunder.");
            }

        }
    }
}
