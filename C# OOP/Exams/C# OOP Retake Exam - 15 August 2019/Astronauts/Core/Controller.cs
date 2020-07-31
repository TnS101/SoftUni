using SpaceStation.Core.Contracts;
using SpaceStation.Models;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Missions;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly List<IAstronaut> astronauts;
        private readonly PlanetRepository planets;
        private readonly Mission mission;
        private int exploredPlanets;
        public Controller()
        {
            this.astronauts = new List<IAstronaut>();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanets = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type == "Biologist")
            {
                IAstronaut bio = new Biologist(astronautName);
                this.astronauts.Add(bio);
                return $"Successfully added {type}: {astronautName}!";
            }
            else if (type == "Geodesist")
            {
                IAstronaut geo = new Geodesist(astronautName);
                this.astronauts.Add(geo);
                return $"Successfully added {type}: {astronautName}!";
            }
            else if (type == "Meteorologist")
            {
                IAstronaut meo = new Meteorologist(astronautName);
                this.astronauts.Add(meo);
                return $"Successfully added {type}: {astronautName}!";
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.planets.Add(planet);
            return$"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            IList<IAstronaut> astronats =this.astronauts.Where(a=>a.Oxygen>60).ToList();

            int initialCount = this.astronauts.Count;
            bool valuedAst = this.astronauts.Any(a=>a.Oxygen > 60);

            if (valuedAst)
            {
                this.mission.Explore(planet,astronats);
                this.exploredPlanets++;
                IList<IAstronaut> ast = astronats.Where(a=>!a.CanBreath).ToList();
                return $"Planet: {planet.Name} was explored! Exploration finished with {ast.Count} dead astronauts!";
            }
            else
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
        }

        public string Report()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"{this.exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (Astronaut item in this.astronauts)
            {
                sb.AppendLine($"Name: {item.Name}");
                sb.AppendLine($"Oxygen: {item.Oxygen}");
                sb.AppendLine($"Bag items: ");
                if (item.Bag.Items.Count == 0)
                {
                    sb.Append("none");
                }
                else
                {
                    foreach (var predmet in item.Bag.Items)
                    {
                        sb.Append(string.Join(", ",item.Bag.Items));
                    }
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FirstOrDefault(a=>a.Name == astronautName);
            if (this.astronauts.Contains(astronaut))
            {
                this.astronauts.Remove(astronaut);
                return$"Astronaut {astronautName} was retired!";
            }
            else
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
        }
    }
}
