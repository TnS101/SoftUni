namespace Application.Forum.Queries
{
    using MediatR;

    public class CustomerTopicsQuery : IRequest<CustomerTopicsListViewModel>
    {
        public string Id { get; set; }
    }
}
