using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models
{
    public class Rifle : Gun
    {
        private const int bulletsPerBarrel = 50;
        private const int totalBullets = 500;
        public Rifle(string name) : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            int firedBullets = 0;
            int shot = 5;
            while (this.CanFire)
            {
                for (int i = 0; i < shot; i++)
                {
                    this.BulletsPerBarrel--;
                    firedBullets++;
                    if (this.BulletsPerBarrel == 0)
                    {
                        this.BulletsPerBarrel += bulletsPerBarrel;
                        this.TotalBullets -= bulletsPerBarrel;
                    }
                     if (this.TotalBullets == 0)
                    {
                        this.CanFire = false;
                        break;
                    }
                }
            }
            return firedBullets;
        }
    }
}
