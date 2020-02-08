namespace WebApplication1.Controllers
{
    using Cakes.Utilities.Handlers;
    using Microsoft.AspNetCore.Mvc;
    using WebApplication1.Data;

    public class CommentController : Controller
    {
        private readonly WebsiteDbContext context = new WebsiteDbContext();
        private readonly CommentHandler commentHandler = new CommentHandler();

        [HttpGet("Comment/Like")]
        [Route("Comment/Like")]
        public IActionResult Like(int commentId)
        {
            commentId = int.Parse(HttpContext.Request.Query["id"]);
            commentHandler.LikeComment.Like(context, commentId);
            return View();
        }

        [HttpGet("Comment/Add")]
        [Route("Comment/Add")]
        public IActionResult Add(int topicId, string content)
        {
            topicId = int.Parse(HttpContext.Request.Query["id"]);
            content = Request.Form["content"];
            if (content == "")
            {
                return View(@"\CommentError");
            }
            else
            {
                commentHandler.AddCommment.Add(context, content, topicId);
                return View();
            }
        }
    }
}
