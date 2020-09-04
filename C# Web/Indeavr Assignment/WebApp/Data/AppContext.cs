namespace WebApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebApp.Data.Entities;

    public class AppContext : IdentityDbContext<User>, IAppContext
    {
        public AppContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> AppUsers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameUsers> GamesUsers { get; set; }

        public DbSet<WishList> WishLists { get; set; }

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

            var builder = modelBuilder.Entity<GameUsers>();

            builder.HasKey(k => new { k.UserId, k.GameId });

            builder.HasOne(b => b.User)
                .WithMany(b => b.GameUsers)
                .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Game)
                .WithMany(b => b.GameUsers)
                .HasForeignKey(b => b.GameId)
            .OnDelete(DeleteBehavior.Restrict);

            var builder2 = modelBuilder.Entity<WishList>();

            builder2.HasKey(k => new { k.UserId, k.GameId });

            builder2.HasOne(b => b.User)
                .WithMany(b => b.WishLists)
                .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder2.HasOne(b => b.Game)
                .WithMany(b => b.WishLists)
                .HasForeignKey(b => b.GameId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
