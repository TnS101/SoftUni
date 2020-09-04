using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Data.Entities;

namespace WebApp.Services.Games
{
    public interface IGameService
    {
        Task Create(string title, string imageURL, double price, string description, DateTime releaseDate);

        Task Update(int id, string title, string imageURL, double price, string description, DateTime releaseDate);

        Task Delete(int id);

        Task<IEnumerable<Game>> All();
    }
}
