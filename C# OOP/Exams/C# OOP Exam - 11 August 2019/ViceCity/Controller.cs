using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models;
using ViceCity.Models.Players.Contracts;
using System.Linq;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IPlayer> players;
        private readonly GunRepository guns;
        private readonly GangNeighbourhood gangNeighbourhood;
        private readonly MainPlayer mainPlayer;
        public Controller()
        {
            this.players = new List<IPlayer>();
            this.guns = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
            this.mainPlayer = new MainPlayer();
            
        }

        public string AddGun(string type, string name)
        {
            if (type == "Pistol")
            {
                Pistol pistol = new Pistol(name);
                guns.Add(pistol);
                return $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                Rifle rifle = new Rifle(name);
                guns.Add(rifle);
                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            IPlayer player = players.FirstOrDefault(p=>p.Name == name && p.IsAlive == true);
            IGun gun = guns.Models.FirstOrDefault(g=>g.CanFire);
            if (guns.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }
            else if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gun);
                guns.Remove(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (!players.Any(p=>p.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                player.GunRepository.Add(gun);
                guns.Remove(gun);
                return $"Successfully added {gun.Name} to the Civil Player: {player.Name}"; 
            }
        }

        public string AddPlayer(string name)
        {
            CivilPlayer civil = new CivilPlayer(name);
            this.players.Add(civil);
            return $"Successfully added civil player: {civil.Name}!";
        }

        public string Fight()
        {
            int initialHP = this.mainPlayer.LifePoints;
            int initialPlayersCount = this.players.Count;
            IPlayer civil = this.players.FirstOrDefault(c=>c.IsAlive);
            this.gangNeighbourhood.Action(this.mainPlayer, this.players);

            if (this.mainPlayer.GunRepository.Models.Count == 0 && civil.GunRepository.Models.Count == 0)
            {
                return "Everything is okay!";
            }

          
            if (!this.players.Any(c=>c.IsAlive) && this.mainPlayer.LifePoints == initialHP)
            {
               return "Everything is okay!";
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {initialPlayersCount - this.players.Count} players!");
                sb.AppendLine($"Left Civil Players: {this.players.Count}!");
                return sb.ToString().TrimEnd();
            }
        }
    }
}
