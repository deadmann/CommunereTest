using FluentValidation;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class Register
        {
            public sealed class Validator : AbstractValidator<Request>
            {
                public Validator()
                {
                    // RuleFor(x => x.Name).NotEmpty();
                    RuleFor(x => x.Email).NotEmpty().EmailAddress();
                    RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
                }
            }
        }
    }
}
