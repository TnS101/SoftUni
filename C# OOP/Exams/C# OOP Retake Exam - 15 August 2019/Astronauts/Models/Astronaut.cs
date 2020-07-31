using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }

        public string Name
        {
            get => name;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value;
            }
        }

        public bool CanBreath { get; protected set; } = true;

        public IBag Bag { get; protected set; }

        public virtual void Breath()
        {
            if (this.Oxygen <= 10)
            {
                this.Oxygen = 0;
                
            }
            if (this.Oxygen == 0)
            {
                this.CanBreath = false;
            }
            else
            {
                this.Oxygen -= 10;
            }
        }
    }
}
