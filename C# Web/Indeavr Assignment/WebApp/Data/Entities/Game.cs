using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.Entities
{
    public class Game
    {
        public Game()
        {
            this.GameUsers = new HashSet<GameUsers>();
            this.WishLists = new HashSet<WishList>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string ImageURL { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<WishList> WishLists { get; set; }

        public ICollection<GameUsers> GameUsers { get; set; }
    }
}
