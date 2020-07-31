using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SpaceStation.Models
{
    public class PlanetRepository : IRepository<Planet>
    {
        private readonly List<Planet> models;
        public PlanetRepository()
        {
            this.models = new List<Planet>();
        }
        public IReadOnlyCollection<Planet> Models => models;

        public void Add(Planet model)
        {
            this.models.Add(model);
        }

        public Planet FindByName(string name)
        {
            return this.models.FirstOrDefault(c=>c.Name == name);
        }

        public bool Remove(Planet model)
        {
            return this.models.Remove(model);
        }
    }
}
