using System;
using System.Linq;

namespace Mid_treta_zadacha
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
           int[] warShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int maxHP = int.Parse(Console.ReadLine());
            bool isWinner = false;
            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "Retire")
                {
                   break;
                }
                else if (commands[0] == "Fire")
                {
                    int index = int.Parse(commands[1]);
                    int damage = int.Parse(commands[2]);
                    
                    if (0<=index && index <=warShip.Length)
                    {
                        
                        if (warShip[index]>damage)
                        {
                            warShip[index] -= damage;
                            
                        }
                        else
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            isWinner = true;
                            break;
                        }
                        
                    }
                }
                else if (commands[0] == "Defend")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int damage = int.Parse(commands[3]);
                    
                    if (0<=startIndex && endIndex<pirateShip.Length)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                           
                           
                            if (pirateShip[i]>damage)
                            {
                               pirateShip[i] -= damage;
                               
                            }
                            else
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                isWinner = false;
                                break;
                            }
                        }
                        
                    }
                }
                else if (commands[0]=="Repair")
                {
                    int index = int.Parse(commands[1]);
                    int health = int.Parse(commands[2]);
                   
                    if (0<=index && index<=pirateShip.Length)
                    {
                         
                        if (pirateShip[index]<=maxHP - health)
                        {
                            pirateShip[index] += health;
                        }
                    }
                }
                else if (commands[0] =="Status")
                {
                    double check = 0.2 * maxHP;
                    int repair = 0;
                    foreach (var item in pirateShip)
                    {
                       
                        if (item<check)
                        {
                            repair++;
                        }
                    }
                    Console.WriteLine($"{repair} sections need repair.");
                }

            }
            int pirateShipSum = 0;

            int warShipSum = 0;

            foreach (var item in pirateShip)
            {
                int incr = (item);
                pirateShipSum += incr;
            }
            foreach (var item in warShip)
            {
                int incr = (item);
                warShipSum += incr;
            }

            if (isWinner==false)
            {
                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warShipSum}");
            }
        }
    }
}
