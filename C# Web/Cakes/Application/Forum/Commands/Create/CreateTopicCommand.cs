namespace Application.Forum.Commands.Create
{
    using MediatR;

    public class CreateTopicCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public string CustomerId { get; set; }
    }
}
