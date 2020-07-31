namespace Application.Cakes.Commands.Delete
{
    using MediatR;

    public class RemoveCakeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
