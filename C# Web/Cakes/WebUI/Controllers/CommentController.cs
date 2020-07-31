namespace WebUI.Controllers
{
    using Application.Comments.Commands.Create;
    using Application.Comments.Commands.Update;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CommentController : BaseController
    {
        [HttpGet("Comment/Like")]
        [Route("Comment/Like")]
        public async Task<IActionResult> Like([FromQuery]int commentId)
        {
            return Ok(await Mediator.Send(new CommentLikeCommand { Id = commentId }));
        }

        [HttpGet("Comment/Add")]
        [Route("Comment/Add")]
        public async Task<IActionResult> Add([FromQuery]int topicId, [FromForm]string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return Redirect(@"\CommentError");
            }
            else
            {
                return Ok(await Mediator.Send(new CreateCommentCommand { TopicId = topicId, Content = content }));
            }
        }
    }
}
