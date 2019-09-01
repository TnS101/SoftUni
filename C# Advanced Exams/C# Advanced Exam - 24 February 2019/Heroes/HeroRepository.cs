using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes
{
   public class HeroRepository
    {
        private List<Hero> data;
        
        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;
        public void Add(Hero hero)
        {
            data.Add(hero);
        }
        public void Remove(string name)
        {
            this.data.Remove(this.data.FirstOrDefault(h => h.Name == name));
        }
        public Hero GetHeroWithHighestStrength()
        {
            int maxStr = this.data.Max(h => h.Item.Strength);
            return this.data.FirstOrDefault(h => h.Item.Strength == maxStr);
        }
        public Hero GetHeroWithHighestAbility()
        {
            int maxAgi = this.data.Max(h => h.Item.Ability);
            return this.data.FirstOrDefault(h => h.Item.Ability == maxAgi);
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            int maxInt = this.data.Max(h => h.Item.Intelligence);
            return this.data.FirstOrDefault(h => h.Item.Intelligence==maxInt);
        }
       
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
