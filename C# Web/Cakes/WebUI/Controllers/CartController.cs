namespace WebUI.Controllers
{
    using Application.Cakes.Commands.Create;
    using Application.Cakes.Commands.Delete;
    using Application.Cakes.Queries;
    using Application.Cart.Queries;
    using Application.Carts.Commands.Delete;
    using Application.Carts.Commands.Update;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CartController : BaseController
    {
        [HttpGet("/Cart/")]
        public async Task<IActionResult> Home()
        {
            return this.View(await this.Mediator.Send(new CakeCartQuery { CustomerId = this.UserId }));
        }

        public async Task<IActionResult> RemoveCake([FromQuery] int cakeId)
        {
            await this.Mediator.Send(new RemoveCakeCommand { CustomerId = this.UserId, CakeId = cakeId });

            return this.Redirect("/Cart/");
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            await this.Mediator.Send(new ClearCartCommand { CustomerId = this.UserId });

            return this.Redirect("/Cart/");
        }

        public async Task<IActionResult> AddCake()
        {
            return this.View(await Mediator.Send(new GetAllCakesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddCake(int cakeId)
        {
            await this.Mediator.Send(new AddCakeCommand { CustomerId = this.UserId, CakeId = cakeId });

            return this.Redirect("/Cart/");
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut()
        {
            await this.Mediator.Send(new CheckOutCommand());

            return this.Redirect("/Cart/");
        }
    }
}
