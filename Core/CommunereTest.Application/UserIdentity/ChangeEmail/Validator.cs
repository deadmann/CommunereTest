using FluentValidation;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class ChangeEmail
        {
            public sealed class Validator : AbstractValidator<Request>
            {
                public Validator()
                {
                }
            }
        }
    }
}
