using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Geodesist : Astronaut
    {
        private const int oxygen = 50;
        public Geodesist(string name) : base(name, oxygen)
        {
        }

        public override void Breath()
        {
            base.Breath();
        }
    }
}
