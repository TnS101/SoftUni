using System;

namespace CLasses_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(10);

            myCar.Drive(76);

            Console.WriteLine(myCar.Fuel);
            
        }
    }
}
