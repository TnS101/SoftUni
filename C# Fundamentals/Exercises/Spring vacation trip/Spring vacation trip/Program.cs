using System;
using System.Collections.Generic;
using System.Linq;

namespace Spring_vacation_trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelPerDay = double.Parse(Console.ReadLine());
            double foodExpenseForOnePerson = double.Parse(Console.ReadLine());
            double hotelRoomForOneNight = double.Parse(Console.ReadLine());
            double allFood = people * days * foodExpenseForOnePerson;
            double allHotel = people * days * hotelRoomForOneNight;
            double traveledDistance = 0;
            if (people>10)
            {
                allHotel -= allHotel * 0.25;
            }
            
            double currentExpense = allFood+allHotel;
            for (int i = 1; i <= days; i++)
            {
                double kmPerDay = double.Parse(Console.ReadLine());
              
                 traveledDistance += kmPerDay;
               
                currentExpense += kmPerDay * fuelPerDay;
                if (i%3==0||i%5==0)
                {
                    currentExpense += 0.4 * currentExpense;
                }
               
                if (i%7==0&&i%3!=0&&i%5!=0)
                {
                    currentExpense -=currentExpense/people;
                }
                if (currentExpense > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {Math.Abs(budget - currentExpense):f2}$ more.");
                    break;
                }

            }
            if (currentExpense<=budget)
            {
                Console.WriteLine($"You have reached the destination. You have {budget-currentExpense:f2}$ budget left.");
            }
            
            
                
            
            
        }
    }
}
