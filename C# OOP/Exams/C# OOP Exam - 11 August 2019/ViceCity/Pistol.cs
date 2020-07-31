using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models
{
    public class Pistol : Gun   
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;
        public Pistol(string name) : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            int firedBullets = 0;
            int shot = 1;
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
