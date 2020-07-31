namespace Persistance.Configurations
{
    using Domain.Entities;
    using FluentValidation;

    public class ReplyConfiguration : AbstractValidator<Reply>
    {
        public void Validate()
        {
            RuleFor(reply => reply.CommentId).NotNull();

            RuleFor(reply => reply.SubmitTime).NotNull();
        }
    }
}
