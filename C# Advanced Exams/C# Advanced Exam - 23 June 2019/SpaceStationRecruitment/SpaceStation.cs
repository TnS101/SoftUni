using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        
        private List<Astronaut> data;
            public SpaceStation(string name,int capacity)
        {
            
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();

        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;
        public void Add(Astronaut astronaut)
        {
            data.Add(astronaut);
        }
        public void Remove(string name)
        {
            this.data.Remove(this.data.FirstOrDefault(h => h.Name == name));
        }
        public Astronaut GetOldestAstronaut()
        {
            int oldest = this.data.Max(h => h.Age);
            return this.data.FirstOrDefault(h => h.Age == oldest);
        }
        public Astronaut GetAstronaut(string name)
        {
            return this.data.FirstOrDefault(p=>p.Name==name);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            Console.WriteLine($"Astronauts working at Space Station {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
