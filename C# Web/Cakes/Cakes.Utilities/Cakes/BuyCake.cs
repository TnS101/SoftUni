namespace Cakes.Utilities.Cakes
{
    using System.Linq;
    using WebApplication1.Data;
    using WebApplication1.Data.Models;
    using WebApplication1.Models;

    public class BuyCake
    {
        public void Buy(WebsiteDbContext context, ShoppingCart shoppingCart, decimal totalPrice, Customer customer)
        {
            context.Orders.Add(new Order
            {
                ShoppingCart = shoppingCart,
                Check = totalPrice
            });
            customer.Balance -= totalPrice;
            context.RemoveRange(shoppingCart.Cakes.ToList());
            context.SaveChanges();
        }
    }
}
