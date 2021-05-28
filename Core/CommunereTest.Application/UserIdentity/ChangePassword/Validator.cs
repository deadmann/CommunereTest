using FluentValidation;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class ChangePassword
        {
            public sealed class Validator : AbstractValidator<Request>
            {
                public Validator()
                {
                    RuleFor(x => x.CurrentPassword).NotEmpty().MinimumLength(8);
                    RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8);
                }
            }
        }
    }
}
