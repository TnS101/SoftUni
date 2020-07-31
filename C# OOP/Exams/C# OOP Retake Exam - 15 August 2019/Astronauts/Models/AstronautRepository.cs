using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SpaceStation.Models
{
    public class AstronautRepository : IRepository<Astronaut>
    {
        private readonly List<Astronaut> models;
        public AstronautRepository()
        {
            this.models = new List<Astronaut>();
        }

        public IReadOnlyCollection<Astronaut> Models => models;

        public void Add(Astronaut model)
        {
            this.models.Add(model);
        }

        public Astronaut FindByName(string name)
        {
            Astronaut astronaut = this.models.FirstOrDefault(a=>a.Name == name);
            if (models.Contains(astronaut))
            {
                return astronaut;
            }
            else
            {
                return null;
            }
        }

        public bool Remove(Astronaut model)
        {
            return models.Remove(model);
        }
    }
}
