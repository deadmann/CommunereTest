using MediatR;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class Login
        {
            public sealed class Request : IRequest<Response>
            {
                public string Email { get; set; }
                public string Password { get; set; }
            }
        }
    }
}