namespace Cakes.Utilities.Cakes
{
    using System.Linq;
    using WebApplication1.Data;

    public class RemoveCake
    {
        public void Remove(WebsiteDbContext context, int cakeId)
        {
            context.Cakes.Remove(context.Cakes.FirstOrDefault(c => c.Id == cakeId));
            context.SaveChanges();
        }
    }
}
