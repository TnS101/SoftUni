namespace Application.Comments.Commands.Delete
{
    using MediatR;

    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
