using System;

namespace TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfAdventure = int.Parse(Console.ReadLine());
            int countOfPeople = int.Parse(Console.ReadLine());
            double energyLevel = double.Parse(Console.ReadLine());
            double waterForOnePerson = double.Parse(Console.ReadLine());
            double foodForOnePerson = double.Parse(Console.ReadLine());
            double energyLoss = 0;
            double totalWater = daysOfAdventure * countOfPeople * waterForOnePerson;
            double totalFood = daysOfAdventure * countOfPeople * foodForOnePerson;
            double currentEnergy = energyLevel;
            double currentWater = totalWater;
            double currentFood = totalFood;

            for (int i = 1; i <= daysOfAdventure; i++)
            {
                energyLoss = double.Parse(Console.ReadLine());

                currentEnergy -= energyLoss;
                if (currentEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {currentFood:f2} food and {currentWater:f2} water.");
                    return;
                }
                if (i % 2 == 0)
                {
                    currentEnergy += 0.05 * currentEnergy;
                    currentWater = currentWater - 0.3 * currentWater;
                }
                if (i % 3 == 0)
                {
                    currentEnergy += 0.10 * currentEnergy;
                    currentFood -= totalFood / countOfPeople;
                }


            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {currentEnergy:f2} energy!");
        }
    }
}