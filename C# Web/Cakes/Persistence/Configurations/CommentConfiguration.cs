namespace Persistance.Configurations
{
    using Domain.Entities;
    using FluentValidation;

    public class CommentConfiguration : AbstractValidator<Comment>
    {
        public void Congfiure()
        {
            RuleFor(comment => comment.Content).NotNull().Length(5,200);

            RuleFor(comment => comment.SubmitTime).NotNull();
        }
    }
}
