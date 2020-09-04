namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WebApp.Data.Entities;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        protected UserManager<User> UserManager => this.userManager ??= this.HttpContext.RequestServices.GetService<UserManager<User>>();

        protected SignInManager<User> SignInManager => this.signInManager ??= this.HttpContext.RequestServices.GetService<SignInManager<User>>();
    }
}
