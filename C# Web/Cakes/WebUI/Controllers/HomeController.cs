namespace WebUI.Controllers
{
    using Application.Employees.Queries;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/About")]
        public async Task<IActionResult> About()
        {
            return Ok(await Mediator.Send(new EmployeesQuery { }));
        }

        [Route("Home/CommentSection")]
        public IActionResult CommentSection()
        {
            return View();
        }
    }
}
