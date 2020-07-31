namespace Application.Forum.Commands.Delete
{
    using MediatR;

    public class RemoveTopicCommand : IRequest
    {
        public int Id { get; set; }
    }
}
