using System;

namespace Repository
{
    public class Person
    {
        private string name;
        private int age;
        private DateTime birthDate;
       
        public Person(string name,int age,DateTime birthDate)
        {
            Name = name;
            Age = age;
            Birthdate = birthDate;
        }
        public string Name
        {
            get => this.name;

            set => this.name = value;
        }
        public int Age
        {
            get => this.age;

            set => this.age = value;
        }
        public DateTime Birthdate
        {
            get => this.birthDate;

            set => this.birthDate = value;
        }
    }
}
