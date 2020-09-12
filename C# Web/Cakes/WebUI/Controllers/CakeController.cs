namespace WebUI.Controllers
{
    using Application.Cakes.Commands.Create;
    using Application.Cakes.Commands.Delete;
    using Application.Cakes.Queries;
    using Application.Cart.Queries;
    using Application.Customer.Queries;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CakeController : BaseController
    {
        public CakeController()
        {
        }
        
        public async Task<IActionResult> Add()
        {
            return this.View(await Mediator.Send(new GetAllCakesQuery()));
        }

        public async Task<IActionResult> Submitted([FromQuery] int cakeId)
        {
            return this.View(await Mediator.Send(new CreateCakeCommand { Id = cakeId }));
        }
        
        public async Task<IActionResult> Cart()
        {
            return this.View(await Mediator.Send(new CakeCartQuery { Id = 1 }));
        }

        public async Task<IActionResult> RemoveCake([FromQuery] int cakeId)
        {
            await this.Mediator.Send(new RemoveCakeCommand { Id = cakeId });

            return View();
        }
        
        public async Task<IActionResult> RemoveAll()
        {
            await this.Mediator.Send(new RemoveAllCakesCommand { CustomerId = 1 });

            return View();
        }
        
        public async Task<IActionResult> Buy()
        {
            await this.Mediator.Send(new BuyCakeCommand { });
            return View(new CustomerBalanceQuery { Id = 1 });
        }
    }
}
