using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Meteorologist : Astronaut
    {
        private const int oxygen = 90;
        public Meteorologist(string name) : base(name, oxygen)
        {
        }

        public override void Breath()
        {
            base.Breath();
        }
    }
}
