namespace Application.Common.Interfaces
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IWebsiteDbContext
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Cake> Cakes { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<Topic> Topics { get; set; }

        DbSet<Reply> Replies { get; set; }

        DbSet<ShoppingCart> ShoppingCarts { get; set; }

        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
