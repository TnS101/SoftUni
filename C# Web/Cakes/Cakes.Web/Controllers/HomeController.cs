using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private static WebsiteDbContext Context = new WebsiteDbContext();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/About")]
        public IActionResult About()
        {
            return View(Context.Employees.ToList());
        }

        [Route("Home/CommentSection")]
        public IActionResult CommentSection()
        {
            return View();
        }
    }
}
