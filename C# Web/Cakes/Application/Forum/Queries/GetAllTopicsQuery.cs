namespace Application.Forum.Queries
{
    using MediatR;

    public class GetAllTopicsQuery : IRequest<TopicListViewModel>
    {
        public string Order { get; set; }
    }
}
