namespace Persistance.Configurations
{
    using Domain.Entities;
    using FluentValidation;

    public class CustomerConfiguration : AbstractValidator<Customer>
    {
        public void Validator()
        {
            RuleFor(customer => customer.Name).NotNull().Length(4, 20);

            RuleFor(customer => customer.Age).NotNull().InclusiveBetween(10, 100);

            RuleFor(customer => customer.Password).NotNull().Length(6, 30);
        }
    }
}
