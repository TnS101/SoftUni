using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
namespace WebApp
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using WebApp.Data;
    using WebApp.Data.Entities;
    using WebApp.Models;
    using WebApp.Services.Games;
    using WebApp.Services.Users;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Custom
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();

            //Mapper
            services.AddAutoMapper(typeof(Startup));

            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });

            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Context
            services.AddDbContext<AppContext>(opt => opt.UseSqlServer("Server=.;Database=App;Integrated Security=True;MultipleActiveResultSets=true;"))
                .AddScoped<IAppContext,AppContext>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            //Identity
            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
            .AddSignInManager()
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddEntityFrameworkStores<AppContext>();

            services.AddControllersWithViews();
            services.AddMvc();
            services.AddAuthorization();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
