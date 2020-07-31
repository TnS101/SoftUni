namespace Application.Cakes.Queries
{
    using MediatR;

    public class GetAllCakesQuery : IRequest<CakesListViewModel>
    {
    }
}
