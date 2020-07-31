﻿using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Planet : IPlanet
    {
        private string name;
        private readonly List<string> items;
        public Planet(string name)
        {
            this.items = new List<string>();
            this.Name = name;
        }
        public ICollection<string> Items => items;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                name = value;
            }
        }
    }
}
