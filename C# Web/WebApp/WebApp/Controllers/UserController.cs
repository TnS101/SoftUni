namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebApp.Services.Games;
    using WebApp.Services.Users;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService service;
        private readonly IGameService gameService;

        public UserController(IUserService service, IGameService gameService)
        {
            this.service = service;
            this.gameService = gameService;
        }

        public async Task<IActionResult> Panel()
        {
            return this.View(await this.service.MyGames(this.UserManager.GetUserId(this.User)));
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int gameId) 
        {
            await this.service.BuyGame(this.UserManager.GetUserId(this.User), gameId);
            return this.Redirect("/User/Panel");
        }

        public async Task<IActionResult> Shop() 
        {
            return this.View(await this.gameService.All());
        }

        public async Task<IActionResult> WishList()
        {
            return this.View(await this.service.WishList(this.UserManager.GetUserId(this.User)));
        }

        [HttpPost]
        public async Task<IActionResult> AddToWishList(int gameId) 
        {
            await this.service.Wish(this.UserManager.GetUserId(this.User), gameId);
            return this.Redirect("/User/WishList");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWishList(int gameId) 
        {
            await this.service.UnWish(this.UserManager.GetUserId(this.User), gameId);
            return this.Redirect("/User/WishList");
        }
    }
}
