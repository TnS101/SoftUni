namespace Application.Cakes.Commands.Delete
{
    using MediatR;
    public class DeleteCakeCommand : IRequest
    {
        public int CakeId { get; set; }
    }
}
