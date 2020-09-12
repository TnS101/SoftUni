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

        [HttpGet("Cake/Add")]
        [Route("Cake/Add")]
        public async Task<IActionResult> Add()
        {
            return this.View(await Mediator.Send(new GetAllCakesQuery()));
        }

        [HttpGet("Cake/Submitted")]
        [Route("Cake/Submitted")]
        public async Task<IActionResult> Submitted([FromQuery] int cakeId)
        {
            return this.View(await Mediator.Send(new CreateCakeCommand { Id = cakeId }));
        }

        [HttpGet("Cake/Cart")]
        [Route("Cake/Cart")]
        public async Task<IActionResult> Cart()
        {
            return this.View(await Mediator.Send(new CakeCartQuery { Id = 1 }));
        }

        [HttpDelete("Cake/RemoveCake")]
        [Route("Cake/RemoveCake")]
        public async Task<IActionResult> RemoveCake([FromQuery] int cakeId)
        {
            await Mediator.Send(new RemoveCakeCommand { Id = cakeId });

            return View();
        }

        [HttpDelete("Cake/RemoveAll")]
        [Route("Cake/RemoveAll")]
        public async Task<IActionResult> RemoveAll()
        {
            await Mediator.Send(new RemoveAllCakesCommand { CustomerId = 1 });

            return View();
        }

        [HttpDelete("Cake/Buy")]
        [Route("Cake/Buy")]
        public async Task<IActionResult> Buy()
        {
            await Mediator.Send(new BuyCakeCommand { });
            return View(new CustomerBalanceQuery { Id = 1 });
        }
    }
}
