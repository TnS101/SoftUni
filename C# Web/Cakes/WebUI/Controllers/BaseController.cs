namespace WebUI.Controllers
{
    using Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        private IMediator mediator;
        private UserManager<Customer> userManager;
        private SignInManager<Customer> signInManager;

        protected IMediator Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();

        protected UserManager<Customer> UserManager => this.userManager ??= this.HttpContext.RequestServices.GetService<UserManager<Customer>>();

        protected SignInManager<Customer> SignInManager => this.signInManager ??= this.HttpContext.RequestServices.GetService<SignInManager<Customer>>();

        protected string UserId => this.UserManager.GetUserId(this.User); 
    }
}
