using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_and_objects_und_demo
{
    class Computer
    {
        private string make;

        public Computer()
        {
            this.Make = "n/a";
        }

        public Computer(string make)
        {
            this.make = make;
        }

        public string Make
        {
            get
            { return this.make; }

            set
            { this.make = value; }
        }
        public void Start()
        {
            Console.WriteLine("SDS");
        }
    }
}
