namespace Domain.Entities
{
    using System.Collections.Generic;

    public class Cake
    {
        public Cake()
        {
            this.ShoppingCarts = new HashSet<ShoppingCart>();
            this.CustomerCakes = new HashSet<CustomerCakes>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public ICollection<CustomerCakes> CustomerCakes { get; set; }
    }
}
