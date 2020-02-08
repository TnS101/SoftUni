namespace WebApplication1.Controllers
{
    using Cakes.Utilities.Handlers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WebApplication1.Data;
    using WebApplication1.Models;

    public class CakeController : Controller
    {
        private static readonly WebsiteDbContext context = new WebsiteDbContext();
        private readonly Customer customer = context.Customers.FirstOrDefault();
        private readonly CakeHandler cakeHandler = new CakeHandler();

        [HttpPost("Cake/Add")]
        [Route("Cake/Add")]
        public IActionResult Add()
        {
            return View(context.Cakes.Where(c => c.ShoppingCartId == null).ToList());
        }

        [HttpGet("Cake/Submitted")]
        [Route("Cake/Submitted")]
        public IActionResult Submitted(int cakeId)
        {
            cakeId = int.Parse(HttpContext.Request.Query["id"]);
            cakeHandler.CreateCake.Create(context, cakeId, customer);
            return View();
        }

        [HttpGet("Cake/Cart")]
        [Route("Cake/Cart")]
        public IActionResult Cart()
        {
            var cart = context.Cakes.Where(c => c.ShoppingCart.CustomerId == customer.Id).ToList();

            if (cart.Count > 0)
            {
                return View(cart);
            }
            else
            {
                return View(@"\CartError");
            }
        }

        [HttpDelete("Cake/RemoveCake")]
        [Route("Cake/RemoveCake")]
        public IActionResult RemoveCake(int cakeId)
        {
            cakeId = int.Parse(HttpContext.Request.Query["id"]);
            cakeHandler.RemoveCake.Remove(context,cakeId);
            return View();
        }

        [HttpDelete("Cake/RemoveAll")]
        [Route("Cake/RemoveAll")]
        public IActionResult RemoveAll()
        {
            cakeHandler.RemoveAllCakes.Remove(context, customer);
            return View();
        }

        [HttpDelete("Cake/Buy")]
        [Route("Cake/Buy")]
        public IActionResult Buy()
        {
            var shoppingCart = context.ShoppingCarts.FirstOrDefault(c => c.CustomerId == customer.Id);
            decimal totalPrice = (decimal)shoppingCart.Cakes.Sum(c => c.Price);

            if (customer.Balance < totalPrice)
            {
                return View(@"\BuyError");
            }
            else
            {
                cakeHandler.BuyCake.Buy(context, shoppingCart, totalPrice, customer);
            }
            return View(customer);
        }
    }
}
