using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models
{
    public class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private readonly GunRepository guns;
        public Player(string name,int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            guns = new GunRepository();
        }

        public string Name
        {
            get => name;
             set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }
                name = value;
            }
        }

        public bool IsAlive { get; private set; } = true;

        public IRepository<IGun> GunRepository => guns;

        public int LifePoints
        {
            get => lifePoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            
            if (this.LifePoints <= points)
            {
                this.LifePoints = 0;
                this.IsAlive = false;
            }
            else
            {
                this.LifePoints -= points;
            }
        }
    }
}
