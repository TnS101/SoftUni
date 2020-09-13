namespace Domain.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class Customer : IdentityUser
    {
        public Customer()
        {
            this.Comments = new HashSet<Comment>();
            this.Replies = new HashSet<Reply>();
            this.ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public double Balance { get; set; }

        public string ImageURL { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Reply> Replies { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
