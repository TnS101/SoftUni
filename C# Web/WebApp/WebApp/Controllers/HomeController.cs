using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Services.Users;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.userService.GetInfo(this.UserManager.GetUserId(this.User)));
        }
    }
}
