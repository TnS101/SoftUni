namespace Application.Comments.Commands.Create
{
    using MediatR;

    public class CreateCommentCommand : IRequest
    {
        public string Content { get; set; }

        public int TopicId { get; set; }
    }
}
