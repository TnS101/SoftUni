namespace Application.Employees.Queries
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class EmployeesQueryHandler : IRequestHandler<EmployeesQuery, EmployeesListViewModel>
    {
        private readonly IWebsiteDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesQueryHandler(IWebsiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeesListViewModel> Handle(EmployeesQuery request, CancellationToken cancellationToken)
        {
            return new EmployeesListViewModel
            {
                Employees = await _context.Employees.ProjectTo<EmployeeViewModel>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
