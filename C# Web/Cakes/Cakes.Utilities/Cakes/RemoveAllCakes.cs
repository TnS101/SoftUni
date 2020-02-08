namespace Cakes.Utilities.Cakes
{
    using System.Linq;
    using WebApplication1.Data;
    using WebApplication1.Models;

    public class RemoveAllCakes
    {
        public void Remove(WebsiteDbContext context, Customer customer)
        {
            foreach (var cake in context.Cakes.Where(c => c.ShoppingCart.CustomerId == customer.Id))
            {
                context.Cakes.Remove(cake);
            }
            context.SaveChanges();
        }
    }
}
