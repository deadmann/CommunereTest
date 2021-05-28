using MediatR;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class ChangeUsername
        {
            public sealed class Request : IRequest<Response>
            {
            }
        }
    }
}
