namespace WebUI
{
    using Application.Common;
    using AutoMapper;
    using Domain;
    using Domain.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using WebApplication1.Persistance;
    using Microsoft.Extensions.Configuration;
    using Application.Common.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Common;
    using Application.Common.Mapping;
    using System;
    using MediatR;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Application Services
            new ServiceRegister(services);

            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly);

            //Automapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Database
            services.AddDbContext<WebsiteDbContext>(opt => opt.UseSqlServer(GConst.ConnectionString))
                .AddScoped<IWebsiteDbContext, WebsiteDbContext>();

            // Identity
            services.AddDefaultIdentity<Customer>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
            })
            .AddSignInManager()
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<WebsiteDbContext>();

            // Authorization
            services.AddAuthorization();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
