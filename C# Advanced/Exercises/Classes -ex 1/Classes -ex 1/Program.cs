using System;

namespace Classes__ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(20);
           
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
