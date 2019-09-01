using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
   public class Aquarium
    {
        private string name;
        private int capacity;
        private int size;
        private List<Fish> fishInPool;
        public Aquarium(string name,int capacity,int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            fishInPool = new List<Fish>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Size { get; set; }

        public void Add(Fish fish)
        {
            if (!fishInPool.Contains(fish) && this.Capacity > 0)
            {
                fishInPool.Add(fish);
                this.Capacity--;
            }
        }
        public bool Remove(string name)
        {
            Fish fishToRemove = fishInPool.FirstOrDefault(f => f.Name == name);
            if (fishInPool.Contains(fishToRemove))
            {
                this.Capacity++;
                return fishInPool.Remove(fishToRemove);
                
            }
            else
            {
                return false;
            }
        }
        public Fish FindFish(string name)
        {
            Fish fishToFind = fishInPool.FirstOrDefault(f => f.Name == name);
            if (fishInPool.Contains(fishToFind))
            {
                return fishToFind;
            }
            else
            {
                return null;
            }
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");
            foreach (var item in this.fishInPool)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
