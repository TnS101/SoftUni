namespace Application.Carts.Commands.Update
{
    using MediatR;
    public class AddCakeCommand : IRequest
    {
        public string CustomerId { get; set; }

        public int CakeId { get; set; }
    }
}
