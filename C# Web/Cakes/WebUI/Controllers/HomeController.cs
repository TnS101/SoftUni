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
            return this.View();
        }

        public async Task<IActionResult> About()
        {
            return this.View(await Mediator.Send(new EmployeesQuery { }));
        }

        public IActionResult CommentSection()
        {
            return this.View();
        }
    }
}
