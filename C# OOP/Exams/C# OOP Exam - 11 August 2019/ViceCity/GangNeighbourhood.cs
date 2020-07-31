using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            IGun gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire);
            IPlayer civil = civilPlayers.FirstOrDefault(c => c.IsAlive);

            if (gun == null)
            {
                return;
            }

            if (civil == null)
            {
                return;
            }
            
            while (civilPlayers.Count > 0 && mainPlayer.GunRepository.Models.Any(g=>g.CanFire))
            {
                civil.TakeLifePoints(gun.Fire());
                if (!gun.CanFire)
                {
                    gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire);
                }
                else if (!civil.IsAlive)
                {
                    civilPlayers.Remove(civil);
                    civil = civilPlayers.FirstOrDefault(c => c.IsAlive);
                }
            }

            while (mainPlayer.IsAlive)
            {
                mainPlayer.TakeLifePoints(gun.Fire());
                if (!gun.CanFire)
                {
                    gun = civil.GunRepository.Models.FirstOrDefault(g => g.CanFire);
                }
                else if (civil.GunRepository.Models.Count == 0)
                {
                    civil = civilPlayers.FirstOrDefault(c => c.IsAlive);
                }
            }
        }
    }
}
