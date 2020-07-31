namespace Application.Comments.Queries
{
    using MediatR;

    public class GetAllCommentsQuery : IRequest<CommentsListViewModel>
    {
        public int TopicId { get; set; }
    }
}
