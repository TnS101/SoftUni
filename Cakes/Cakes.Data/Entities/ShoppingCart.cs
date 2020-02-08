using System.Collections.Generic;
using WebApplication1.Data.DbModels;
using WebApplication1.Models;

namespace WebApplication1.Data.Models
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

        public ICollection<Cake> Cakes { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
