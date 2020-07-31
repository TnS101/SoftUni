namespace Application.Forum.Queries
{
    using MediatR;

    public class CustomerTopicsQuery : IRequest<CustomerTopicsListViewModel>
    {
        public int Id { get; set; }
    }
}
