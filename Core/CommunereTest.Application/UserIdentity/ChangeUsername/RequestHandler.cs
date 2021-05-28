using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class ChangeUsername
        {
            public sealed class RequestHandler : IRequestHandler<Request, Response>
            {
                public Task<Response> Handle(Request request, CancellationToken cancellationToken)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
