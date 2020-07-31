namespace Application.Forum.Commands.Update
{
    using MediatR;

    public class EditTopicCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }
    }
}
