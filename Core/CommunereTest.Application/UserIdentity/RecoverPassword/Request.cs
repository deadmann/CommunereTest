using MediatR;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class RecoverPassword
        {
            public sealed class Request : IRequest<Response>
            {
                public string VerificationCode { get; set; }
                public string NewPassword { get; set; }
            }
        }
    }
}
