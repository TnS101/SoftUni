namespace Persistance
{
    using Application.Common.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using WebApplication1.Persistance;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConnection connection)
        {
            services.AddDbContext<WebsiteDbContext>(options => options.UseSqlServer(connection.String));

            services.AddScoped(provider => provider.GetService<IWebsiteDbContext>());

            return services;
        }
    }
}
