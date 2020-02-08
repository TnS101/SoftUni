namespace WebApplication1.Controllers
{
    using Cakes.Utilities.Handlers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WebApplication1.Data;
    using WebApplication1.Models;

    public class ForumController : Controller
    {
        private static WebsiteDbContext context = new WebsiteDbContext();
        private readonly Customer customer = context.Customers.FirstOrDefault();
        private readonly ForumHandler forumHandler = new ForumHandler();

        [HttpGet("Forum/Home")]
        [Route("Forum/Home")]
        public IActionResult Home()
        {
            if (context.Topics.Count() > 0)
            {
                return View(context.Topics.ToList());
            }
            else
            {
                return View(@"\TopicError");
            }
        }

        [HttpGet("Forum/Recent")]
        [Route("Forum/Recent")]
        public IActionResult Recent()
        {
            if (context.Topics.Count() > 0)
            {
                return View(context.Topics.OrderByDescending(t => t.SubmitTime).ToList());
            }
            else
            {
                return View(@"\TopicError");
            }
        }

        [HttpGet("Forum/Popular")]
        [Route("Forum/Popular")]
        public IActionResult Popular()
        {
            if (context.Topics.Count() > 0)
            {
                return View(context.Topics.OrderByDescending(t => t.Likes).ToList());
            }
            else
            {
                return View(@"\TopicError");
            }
        }

        [HttpGet("Forum/CustomerTopics")]
        [Route("Forum/CustomerTopics")]
        public IActionResult CustomerTopics()
        {
            if (context.Topics.Count() > 0)
            {
                return View(context.Topics.Where(t => t.CustomerId == customer.Id).ToList());
            }
            else
            {
                return View(@"\TopicError");
            }
        }

        [HttpPost("Forum/CreateTopic")]
        [Route("Forum/CreateTopic")]
        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost("Forum/SubmittedCreate")]
        [Route("Forum/SubmittedCreate")]
        public IActionResult SubmittedCreate(string topicName, string category, string content)
        {
            topicName = Request.Form["topicName"];
            category = Request.Form["category"];
            content = Request.Form["content"];
            forumHandler.CreateTopic.Create(context, topicName, category, content, customer);
            return View();
        }

        [HttpPut("Forum/EditTopic")]
        [Route("Forum/EditTopic")]
        public IActionResult EditTopic(int topicId)
        {
            topicId = int.Parse(HttpContext.Request.Query["id"]);
            return View(context.Topics.FirstOrDefault(t => t.Id == topicId));
        }

        [HttpGet("Forum/SubmittedEdit")]
        [Route("Forum/SubmittedEdit")]
        public IActionResult SubmittedEdit(string editName, string editCategory, int topicId, string editContent)
        {
            topicId = int.Parse(HttpContext.Request.Query["id"]);
            editName = Request.Form["topicName"];
            editCategory = Request.Form["category"];
            editContent = Request.Form["content"];

            forumHandler.EditTopic.Edit(context, editName, editCategory, editContent, topicId);
            return View();
        }

        [HttpDelete("Forum/RemoveTopic")]
        [Route("Forum/RemoveTopic")]
        public IActionResult RemoveTopic(int topicId)
        {
            topicId = int.Parse(HttpContext.Request.Query["id"]);
            forumHandler.RemoveTopic.Remove(context, topicId);
            return View();
        }

        [HttpGet("Forum/CurrentTopic")]
        [Route("Forum/CurrentTopic")]
        public IActionResult CurrentTopic(int topicId)
        {
            topicId = int.Parse(HttpContext.Request.Query["id"]);
            return View(context.Topics.FirstOrDefault(t => t.Id == topicId));
        }

        [HttpPost("Forum/LikeTopic")]
        [Route("Forum/LikeTopic")]
        public IActionResult LikeTopic(int topicId)
        {
            topicId = int.Parse(HttpContext.Request.Query["id"]);
            forumHandler.LikeTopic.Like(context, topicId);
            return View();
        }
    }
}
