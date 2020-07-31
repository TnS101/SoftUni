namespace Application.Forum.Commands.Update
{
    using MediatR;

    public class LikeTopicCommand : IRequest
    {
        public int Id { get; set; }
    }
}
