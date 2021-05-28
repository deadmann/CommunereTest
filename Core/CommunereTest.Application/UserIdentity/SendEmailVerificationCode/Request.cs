using MediatR;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class SendEmailVerificationCode
        {
            public sealed class Request : IRequest<Response>
            {
                public string Email { get; set; }
            }
        }
    }
}
