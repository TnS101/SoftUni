using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Biologist : Astronaut
    {
        private const int oxygen = 70;
        public Biologist(string name) : base(name, oxygen)
        {
        }
        public override void Breath()
        {
            if (this.Oxygen <= 5)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 5;
            }
        }
    }
}
