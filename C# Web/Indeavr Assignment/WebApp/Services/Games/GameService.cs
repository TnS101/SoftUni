namespace WebApp.Services.Games
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Data;
    using WebApp.Data.Entities;

    public class GameService : IGameService
    {
        private readonly IAppContext context;
        public GameService(IAppContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Game>> All()
        {
            return await this.context.Games.ToListAsync();
        }

        public async Task Create(string title, string imageURL, double price, string description, DateTime releaseDate)
        {
            this.context.Games.Add(new Game
            {
                Title = title,
                ImageURL = imageURL,
                Price = price,
                Description = description,
                ReleaseDate = releaseDate,
            });

            await this.context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Delete(int id)
        {
            this.context.Games.Remove(await this.context.Games.FindAsync(id));

            await this.context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Update(int id, string title, string imageURL, double price, string description, DateTime releaseDate)
        {
            var game = await this.context.Games.FindAsync(id);

            if (!string.IsNullOrWhiteSpace(title))
            {
                game.Title = title;
            }

            if (!string.IsNullOrWhiteSpace(imageURL))
            {
                game.ImageURL = imageURL;
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                game.Description = description;
            }

            if (price > 0)
            {
                game.Price = price;
            }

            if (releaseDate != null)
            {
                game.ReleaseDate = releaseDate;
            }

            await this.context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
