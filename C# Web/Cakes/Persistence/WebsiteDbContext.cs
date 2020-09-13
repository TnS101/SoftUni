namespace WebApplication1.Persistance
{
    using Application.Common.Interfaces;
    using Common;
    using Domain.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class WebsiteDbContext : IdentityDbContext, IWebsiteDbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(GConst.ConnectionString);
            }
        }
    }
}
