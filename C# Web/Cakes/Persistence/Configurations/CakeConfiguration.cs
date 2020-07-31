namespace Persistance.Configurations
{
    using Domain.Entities;
    using FluentValidation;

    public class CakeConfiguration : AbstractValidator<Cake>
    {
        public void Validate()
        {
            RuleFor(cake => cake.Name).NotNull();

            RuleFor(cake => cake.Price).NotNull().InclusiveBetween(5, 50);

            RuleFor(cake => cake.Description).NotNull().Length(50, 400);

            RuleFor(cake => cake.ImageURL).NotNull();
        }
    }
}
