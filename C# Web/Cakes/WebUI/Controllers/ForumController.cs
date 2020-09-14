namespace WebUI.Controllers
{
    using Application.Forum.Commands.Create;
    using Application.Forum.Commands.Delete;
    using Application.Forum.Commands.Update;
    using Application.Forum.Queries;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ForumController : BaseController
    {
        public async Task<IActionResult> Start()
        {
            return this.View(await Mediator.Send(new GetAllTopicsQuery { Order = "none" }));
        }
        
        public async Task<IActionResult> Recent()
        {
            return this.View(await Mediator.Send(new GetAllTopicsQuery { Order = "recent" }));
        }

        public async Task<IActionResult> Popular()
        {
            return this.View(await Mediator.Send(new GetAllTopicsQuery { Order = "popular" }));
        }

        public async Task<IActionResult> CustomerTopics()
        {
            return this.View(await Mediator.Send(new CustomerTopicsQuery { Id = this.UserId }));
        }

        public IActionResult CreateTopic()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmittedCreate([FromForm] string topicName, [FromForm] string category, [FromForm] string content)
        {
            await Mediator.Send(new CreateTopicCommand { Name = topicName, Category = category, Content = content, CustomerId = this.UserId });
            return this.View();
        }

        [HttpPut]
        public async Task<IActionResult> EditTopic([FromQuery] int topicId)
        {
            return this.View(await Mediator.Send(new CurrentTopicQuery { Id = topicId }));
        }

        public async Task<IActionResult> SubmittedEdit([FromForm] string editName, [FromForm] string editCategory, [FromQuery] int topicId, [FromForm] string editContent)
        {
            await Mediator.Send(new EditTopicCommand { Name = editName, Category = editCategory, Id = topicId, Content = editContent });
            return this.Redirect("/Forum/Start");
        }

        public async Task<IActionResult> RemoveTopic([FromQuery] int topicId)
        {
            await Mediator.Send(new RemoveTopicCommand { Id = topicId });
            return this.Redirect("/Forum/Start");
        }

        public async Task<IActionResult> CurrentTopic([FromQuery] int topicId)
        {
            return this.View(await Mediator.Send(new CurrentTopicQuery { Id = topicId }));
        }

        [HttpPost]
        public async Task<IActionResult> LikeTopic([FromQuery] int topicId)
        {
            await Mediator.Send(new LikeTopicCommand { Id = topicId });
            return this.Redirect("/Forum/Start");
        }
    }
}
