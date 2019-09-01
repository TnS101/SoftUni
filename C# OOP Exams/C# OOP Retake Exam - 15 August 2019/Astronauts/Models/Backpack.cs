using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
   public class Backpack 
    {
        private readonly List<string> items;
        public Backpack()
        {
            this.items = new List<string>();
        }
        public List<string> Items => items;
    }
}
