namespace WebApp.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using WebApp.Services.Games;

    public class AdminController : Controller
    {
        private readonly IGameService service;

        public AdminController(IGameService service)
        {
            this.service = service;
        }

        [HttpGet("/Admin/Admin/")]
        public async Task<IActionResult> GetAll() 
        {
            return View(await this.service.All());
        }

        [HttpGet]
        public IActionResult CreateGame() 
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(string title, string imageURL, double price, string description, DateTime releaseDate) 
        {
            await this.service.Create(title, imageURL, price, description, releaseDate);
            return this.Redirect("/Admin/Admin");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGame(int id, string title, string imageURL, double price, string description, DateTime releaseDate) 
        {
            await this.service.Update(id, title, imageURL, price, description, releaseDate);
            return this.Redirect("/Admin/Admin");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await this.service.Delete(id);
            return this.Redirect("/Admin/Admin");
        }
    }
}
