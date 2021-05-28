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
        public sealed partial class ChangePassword
        {
            public sealed class RequestHandler : IRequestHandler<Request, Response>
            {
                private readonly IUnitOfWork _uow;
                private readonly IIdentityService _identity;
                private readonly IJwtService _jwtService;

                public RequestHandler(IUnitOfWork uow, IIdentityService identity, IJwtService jwtService)
                {
                    _uow = uow;
                    _identity = identity;
                    _jwtService = jwtService;
                }

                public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                {
                    if (!_identity.IsCurrentUserAuthenticated)
                        throw new AppException("User", "The user is not authenticated.");

                    var user = _identity.CurrentUser;

                    var currentPassword = _identity.DecryptPassword(user.Password);
                    if (!currentPassword.Equals(request.CurrentPassword))
                        throw new AppException("Current Password", "Wrong password.");

                    user.Password = _identity.EncryptPassword(request.NewPassword);

                    user.UpdatedAt = DateTime.Now;
                    user.UpdatedById = user.Id;

                    _identity.UpdateUser(user);
                    await _uow.SaveChangesAsync(cancellationToken);

                    var response = new Response
                    {
                        Succeeded = true,
                        Token = _jwtService.GenerateToken(user.Email)
                    };

                    return response;
                }
            }
        }
    }
}
