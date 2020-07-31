using System;
using System.Collections.Generic;
using System.Text;

namespace Classes__ex_1
{
    class Person
    {
        private string name;
        private int age;
        public string Name {
            get { return this.name; }

            set { this.name = value; }

        }
        public int Age
        {
            get => this.age;
            set => this.age = value;
        }
        public Person(int age)
        {
            Name = "Pesho";
            Age = age;
        }

    }
}
