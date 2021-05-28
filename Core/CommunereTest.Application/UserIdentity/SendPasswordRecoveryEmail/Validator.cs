using FluentValidation;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class SendPasswordRecoveryEmail
        {
            public sealed class Validator : AbstractValidator<Request>
            {
                public Validator()
                {
                    RuleFor(x => x.Email).NotEmpty().EmailAddress();
                }
            }
        }
    }
}
