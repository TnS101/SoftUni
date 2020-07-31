using System;
using System.Linq;
using System.Text;

namespace Phone_Number_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which country would you like to generate a code from?");
            Console.WriteLine("[USA, Russia, Bulgaria].");
            string input = "";
            string [] country = CountryCheck(input);
            Console.WriteLine("How many numbers do you want to generate?");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(CodeGenerator(country));
            }
        }

        public static string[] AmericanStateCheck()
        {
            Console.WriteLine("Choose a state! Supported : (Alabama,Arizona,California,Florida,Kansas,Michigan,Texas and New York).");
            StringBuilder pattern = new StringBuilder();
            pattern.Append("+1 ");
            string[] output = { "","USA" };
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Alabama")
                {
                    pattern.Append("(205) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Arizona")
                {
                    pattern.Append("(928) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "California")
                {
                    pattern.Append("(510) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Florida")
                {
                    pattern.Append("(786) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Kansas")
                {
                    pattern.Append("(765) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Michigan")
                {
                    pattern.Append("(269) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Texas")
                {
                    pattern.Append("(806) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "New York")
                {
                    pattern.Append("(845) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else
                {
                    Console.WriteLine("Incorrect or not supported state!Please try again!");
                    continue;
                }
            }
        }

        public static string[] RussianRegionCheck()
        {
            Console.WriteLine("Choose a region! Supported regions : (Dagestan,Volgograd,Ivanovo,Altai,Komi,Omsk)");
            StringBuilder pattern = new StringBuilder();
            string[] output = { "", "Russia" };
            pattern.Append("+7 ");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Dagestan")
                {
                    pattern.Append("(872) ");
                    output[0] = pattern.ToString();
                    return output;
                    
                }
                else if (input == "Volgograd")
                {
                    pattern.Append("(844) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Ivanovo")
                {
                    pattern.Append("(493) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Altai")
                {
                    pattern.Append("(388) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Komi")
                {
                    pattern.Append("(821) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else if (input == "Omsk")
                {
                    pattern.Append("(381) ");
                    output[0] = pattern.ToString();
                    return output;
                }
                else
                {
                    Console.WriteLine("Incorrect or not supported region!Please try again!");
                    continue;
                }
            }
        }

        public static string CodeGenerator(string [] output)
        {
            var rng = new Random();
            int num = rng.Next(48,58);
            StringBuilder finishedCode = new StringBuilder();
            finishedCode.Append(output[0]);
            if (output[1] == "USA" || output[1] == "Bulgaria")
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (i == 4)
                    {
                        finishedCode.Append("-");
                    }
                    else
                    {
                        num = rng.Next(48, 58);
                        finishedCode.Append($"{(char)num}");
                    }
                 
                }
                return finishedCode.ToString();
                
            }
            else 
            {

                for (int i = 1; i <= 8; i++)
                {
                    if (i == 4)
                    {
                        finishedCode.Append("-");
                    }
                    if (i == 6)
                    {
                        finishedCode.Append("-");
                    }
                    else
                    {
                        num = rng.Next(48, 58);
                        finishedCode.Append($"{(char)num}");
                    }

                }
                return finishedCode.ToString();
            }
        }

        public static string[] CountryCheck(string input)
        {
            var rng = new Random();
            StringBuilder pattern = new StringBuilder();
            string[] output = {"",""};
            while (true)
            {
                input = Console.ReadLine();

                if (input == "USA")
                {
                    pattern.Append("+1 ");
                    Console.WriteLine("USA Toll Free number or a state number?(free / state)");
                    while (true)
                    {
                        string choice = Console.ReadLine();
                        if (choice == "free")
                        {
                            int num = rng.Next(51, 57);
                            pattern.Append($"(8{(char)num}{(char)num}) ");
                            output[0] = pattern.ToString();
                            output[1] = input;
                            return output;
                        }
                        else if (choice == "state")
                        {
                           return AmericanStateCheck();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect option or state!Please try again!");
                            continue;
                        }
                    }
                    
                }
                else if (input == "Russia")
                {
                    pattern.Append("+7 ");
                    Console.WriteLine("Russian capital number or a region number?(capital / region)");
                    while (true)
                    {
                        string choice = Console.ReadLine();
                        if (choice == "capital")
                        {
                            int num = rng.Next(0, 3);
                            if (num == 0)
                            {
                                pattern.Append("(495) ");
                            }
                            else if (num == 1)
                            {
                                pattern.Append("(498) ");
                            }
                            else
                            {
                                pattern.Append("(499) ");
                            }
                            output[0] = pattern.ToString();
                            output[1] = input;
                            return output;
                        }
                        else if (choice == "region")
                        {
                           return RussianRegionCheck();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect option or region!Please try again!");
                            continue;
                        }
                    }
                }
                else if (input == "Bulgaria")
                {
                    pattern.Append("+359 ");
                    Console.WriteLine("Choose a phone operator : (Vivacom, Telenor, A1)");
                    while (true)
                    {
                        string choice = Console.ReadLine();
                        if (choice == "Vivacom")
                        {
                            pattern.Append("87 ");
                            output[0] = pattern.ToString();
                            output[1] = input;
                            return output;
                        }
                        else if (choice == "Telenor")
                        {
                            pattern.Append("89 ");
                            output[0] = pattern.ToString();
                            output[1] = input;
                            return output;
                        }
                        else if (choice == "A1")
                        {
                            pattern.Append("88 ");
                            output[0] = pattern.ToString();
                            output[1] = input;
                            return output;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect option or region!Please try again!");
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid country,please try again!");
                    continue;
                }
            }
        } 
    }
}
