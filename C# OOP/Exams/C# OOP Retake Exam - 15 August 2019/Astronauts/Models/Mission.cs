using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Missions;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStation.Models.Missions
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            IAstronaut astronaut = astronauts.FirstOrDefault(a => a.CanBreath);

            if (planet == null)
            {
                return;
            }
            if (astronauts == null )
            {
                return;
            }
            if (planet.Items.Count == 0)
            {
                return;
            }

            while (astronauts.Any(a=>a.CanBreath)&& planet.Items.Count >0)
            {
                string item = planet.Items.FirstOrDefault();
                if (!astronaut.CanBreath)
                {
                    astronaut = astronauts.FirstOrDefault(a => a.CanBreath);
                    continue;
                }
                else
                {
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                }
            }
        }
    }
}
