using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Data.Entities;

namespace WebApp.Services.Users
{
    public interface IUserService
    {
        Task<User> GetInfo(string id);

        Task<IEnumerable<Game>> WishList(string id);

        Task BuyGame(string userId, int id);

        Task<IEnumerable<Game>> MyGames(string id);

        Task Wish(string userId, int id);

        Task UnWish(string userId, int id);
    }
}
