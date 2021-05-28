using FluentValidation;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class RecoverPassword
        {
            public sealed class Validator : AbstractValidator<Request>
            {
                public Validator()
                {
                    RuleFor(x => x.VerificationCode).NotEmpty().MinimumLength(5);
                    RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8);
                }
            }
        }
    }
}
