using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Models;
using Cake = WebApplication1.Data.DbModels.Cake;

namespace WebApplication1.Data
{
    public class WebsiteDbContext : DbContext
    {
        public WebsiteDbContext()
        {
        }

        public WebsiteDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Cake> Cakes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Connection.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
