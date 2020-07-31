namespace Persistance.Configurations
{
    using Domain.Entities;
    using FluentValidation;

    public class EmployeeConfiguration : AbstractValidator<Employee>
    {
        public void Validate()
        {
            RuleFor(employee => employee.Name).NotNull().Length(8,50);

            RuleFor(employee => employee.ImageURL).NotNull();

            RuleFor(employee => employee.Position).NotNull().Length(8, 50);

            RuleFor(employee => employee.Salary).InclusiveBetween(500, 3000);
        }
    }
}
