namespace Application.Forum.Queries
{
    using MediatR;

    public class CurrentTopicQuery : IRequest<CurrentTopicViewModel>
    {
        public int Id { get; set; }
    }
}
