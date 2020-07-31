namespace Application.Comments.Commands.Update
{
    using MediatR;

    public class CommentLikeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
