namespace Cakes.Utilities.Cakes
{
    using System.Linq;
    using WebApplication1.Data;
    using WebApplication1.Data.DbModels;
    using WebApplication1.Models;

    public class CreateCake
    {
        public void Create(WebsiteDbContext context, int cakeId, Customer customer)
        {
            var mappingCake = context.Cakes.FirstOrDefault(c => c.Id == cakeId);

            var orderedCake = new Cake
            {
                Name = mappingCake.Name,
                Price = mappingCake.Price,
                Description = mappingCake.Description,
                ImageURL = mappingCake.ImageURL,
            };

            context.ShoppingCarts.FirstOrDefault(s => s.CustomerId == customer.Id).Cakes.Add(orderedCake);
            context.SaveChanges();
        }
    }
}
