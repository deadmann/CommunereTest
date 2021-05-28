using MediatR;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class ChangePassword
        {
            public sealed class Request : IRequest<Response>
            {
                public string CurrentPassword { get; set; }
                public string NewPassword { get; set; }
            }
        }
    }
}