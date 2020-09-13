namespace WebUI.Controllers
{
    using Application.Comments.Commands.Create;
    using Application.Comments.Commands.Update;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CommentController : BaseController
    {
        public async Task<IActionResult> Like([FromQuery]int commentId)
        {
            return this.View(await this.Mediator.Send(new CommentLikeCommand { Id = commentId }));
        }

        public async Task<IActionResult> Add([FromQuery]int topicId, [FromForm]string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return Redirect(@"\CommentError");
            }
            else
            {
                return this.View(await this.Mediator.Send(new CreateCommentCommand { TopicId = topicId, Content = content }));
            }
        }
    }
}
