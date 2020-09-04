namespace WebApp.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public User()
        {
            this.GameUsers = new HashSet<GameUsers>();
            this.Money = 1000;
            this.WishLists = new HashSet<WishList>();
        }

        public string FullName { get; set; }

        public double Money { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<WishList> WishLists { get; set; }

        public ICollection<GameUsers> GameUsers { get; set; }
    }
}
