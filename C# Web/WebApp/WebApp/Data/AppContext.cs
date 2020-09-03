namespace WebApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebApp.Data.Entities;

    public class AppContext : IdentityDbContext<User>
    {
        public AppContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> AppUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=.;Database=App;Integrated Security=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);

            //modelBuilder.Entity<User>(appUser =>
            //{
            //    appUser
            //    .HasMany(e => e.Claims)
            //    .WithOne()
            //    .HasForeignKey(e => e.UserId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);
            //});
        }
    }
}
