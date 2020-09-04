namespace WebApp.Services.Users
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Data;
    using WebApp.Data.Entities;

    public class UserService : IUserService
    {
        private readonly IAppContext context;

        public UserService(IAppContext context)
        {
            this.context = context;
        }

        public async Task BuyGame(string userId, int id)
        {
            if (this.context.GamesUsers.FirstOrDefault(w => w.UserId == userId && w.GameId == id) != null)
            {
                throw new System.Exception("You already have that GAME!");
            }

            this.context.WishLists.Remove(await this.context.WishLists.FirstOrDefaultAsync(w => w.UserId == userId && w.GameId == id));

            this.context.GamesUsers.Add(new GameUsers
            {
                UserId = userId,
                GameId = id,
            });

            await this.context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<User> GetInfo(string id)
        {
            return await this.context.AppUsers.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> MyGames(string id)
        {
            return await this.context.GamesUsers.Where(w => w.UserId == id).Select(g => g.Game).ToListAsync();
        }

        public async Task UnWish(string userId, int id)
        {
            this.context.WishLists.Remove(await this.context.WishLists.FirstOrDefaultAsync(w => w.UserId == userId && w.GameId == id));

            await this.context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Wish(string userId, int id)
        {
            if (this.context.WishLists.FirstOrDefault(w => w.UserId == userId && w.GameId == id) != null) 
            {
                throw new System.Exception("You already have that GAME!");
            }

            this.context.WishLists.Add(new WishList
            {
                UserId = userId,
                GameId = id,
            });

            await this.context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<IEnumerable<Game>> WishList(string id)
        {
            return await this.context.WishLists.Where(w => w.UserId == id).Select(g => g.Game).ToListAsync();
        }
    }
}
