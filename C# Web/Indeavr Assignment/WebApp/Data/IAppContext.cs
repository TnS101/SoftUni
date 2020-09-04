namespace WebApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Data.Entities;

    public interface IAppContext
    {
        DbSet<User> AppUsers { get; set; }

        DbSet<Game> Games { get; set; }

        DbSet<GameUsers> GamesUsers { get; set; }

        DbSet<WishList> WishLists { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
