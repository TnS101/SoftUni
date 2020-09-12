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
        [HttpGet("Forum/Home")]
        [Route("Forum/Home")]
        public async Task<IActionResult> Home()
        {
            return this.View(await Mediator.Send(new GetAllTopicsQuery { Order = "none" }));
        }

        [HttpGet("Forum/Recent")]
        [Route("Forum/Recent")]
        public async Task<IActionResult> Recent()
        {
            return this.View(await Mediator.Send(new GetAllTopicsQuery { Order = "recent" }));
        }

        [HttpGet("Forum/Popular")]
        [Route("Forum/Popular")]
        public async Task<IActionResult> Popular()
        {
            return this.View(await Mediator.Send(new GetAllTopicsQuery { Order = "popular" }));
        }

        [HttpGet("Forum/CustomerTopics")]
        [Route("Forum/CustomerTopics")]
        public async Task<IActionResult> CustomerTopics()
        {
            return this.View(await Mediator.Send(new CustomerTopicsQuery { Id = 1 }));
        }

        [HttpPost("Forum/CreateTopic")]
        [Route("Forum/CreateTopic")]
        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost("Forum/SubmittedCreate")]
        [Route("Forum/SubmittedCreate")]
        public async Task<IActionResult> SubmittedCreate([FromForm] string topicName, [FromForm] string category, [FromForm] string content)
        {
            await Mediator.Send(new CreateTopicCommand { Name = topicName, Category = category, Content = content, CustomerId = 1 });
            return View();
        }

        [HttpPut("Forum/EditTopic")]
        [Route("Forum/EditTopic")]
        public async Task<IActionResult> EditTopic([FromQuery] int topicId)
        {
            return Ok(await Mediator.Send(new CurrentTopicQuery { Id = topicId }));
        }

        [HttpGet("Forum/SubmittedEdit")]
        [Route("Forum/SubmittedEdit")]
        public async Task<IActionResult> SubmittedEdit([FromForm] string editName, [FromForm] string editCategory, [FromQuery] int topicId, [FromForm] string editContent)
        {
            return Ok(await Mediator.Send(new EditTopicCommand { Name = editName, Category = editCategory, Id = topicId, Content = editContent }));
        }

        [HttpDelete("Forum/RemoveTopic")]
        [Route("Forum/RemoveTopic")]
        public async Task<IActionResult> RemoveTopic([FromQuery] int topicId)
        {
            await Mediator.Send(new RemoveTopicCommand { Id = topicId });
            return View();
        }

        [HttpGet("Forum/CurrentTopic")]
        [Route("Forum/CurrentTopic")]
        public async Task<IActionResult> CurrentTopic([FromQuery] int topicId)
        {
            return Ok(await Mediator.Send(new CurrentTopicQuery { Id = topicId }));
        }

        [HttpPost("Forum/LikeTopic")]
        [Route("Forum/LikeTopic")]
        public async Task<IActionResult> LikeTopic([FromQuery] int topicId)
        {
            await Mediator.Send(new LikeTopicCommand { Id = topicId });
            return View();
        }
    }
}
