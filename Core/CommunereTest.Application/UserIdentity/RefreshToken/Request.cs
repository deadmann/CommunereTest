using MediatR;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class RefreshToken
        {
            public sealed class Request : IRequest<Response>
            {
            }
        }
    }
}