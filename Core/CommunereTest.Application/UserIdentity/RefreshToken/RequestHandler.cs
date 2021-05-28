using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Application.Common.Exceptions;
using CommunereTest.Domain.Interfaces;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class RefreshToken
        {
            public sealed class RequestHandler : IRequestHandler<Request, Response>
            {
                private readonly IIdentityService _identity;
                private readonly IJwtService _jwtService;

                public RequestHandler(IIdentityService identity, IJwtService jwtService)
                {
                    _identity = identity;
                    _jwtService = jwtService;
                }

                public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                {
                    if (!_identity.IsCurrentUserAuthenticated)
                        throw new AppException("User", "The user is not authenticated.");

                    return await Task.FromResult(
                        new Response {Token = _jwtService.GenerateToken(_identity.CurrentUser.Email)}
                    );
                }
            }
        }
    }
}
