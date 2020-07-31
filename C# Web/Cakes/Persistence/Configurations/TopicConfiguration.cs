namespace Persistance.Configurations
{
    using Domain.Entities;
    using FluentValidation;

    public class TopicConfiguration : AbstractValidator<Topic>
    {
        public void Validate()
        {
            RuleFor(topic => topic.Name).NotNull().Length(3,30);

            RuleFor(topic => topic.Content).NotNull();

            RuleFor(topic => topic.Category).NotNull().Length(3, 30);

            RuleFor(topic => topic.CustomerId).NotNull();

            RuleFor(topic => topic.SubmitTime).NotNull();
        }
    }
}
