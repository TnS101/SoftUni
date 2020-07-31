namespace Application.Employees.Queries
{
    using System.Collections.Generic;

    public class EmployeesListViewModel
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
