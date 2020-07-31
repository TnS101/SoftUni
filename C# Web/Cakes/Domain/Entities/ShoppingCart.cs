using System.Collections.Generic;

namespace Domain.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Cakes = new HashSet<Cake>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Cake> Cakes { get; private set; }

        public ICollection<Order> Orders { get; private set; }
    }
}
