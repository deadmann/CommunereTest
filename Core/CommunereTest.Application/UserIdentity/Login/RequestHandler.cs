using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Application.Common.Exceptions;
using CommunereTest.Domain.Enums;
using CommunereTest.Domain.Interfaces;
using MediatR;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class Login
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
                    var email = request.Email.ToLower().Trim();
                    var user = await _identity.GetUserByEmailAsync(email, cancellationToken);

                    if (user == null)
                        throw new AppException("Login", "Wrong email or password.");

                    var password = _identity.DecryptPassword(user.Password);
                    if (!password.Equals(request.Password))
                        throw new AppException("Login", "Wrong email or password.");

                    if (user.ActivationStatus != UserActivationStatus.Active)
                        throw new AppException("User", "This account is not active.");

                    if (!user.VerifiedEmail)
                        throw new AppException("Email Verification", "Email has not been verified yet.");

                    var token = _jwtService.GenerateToken(user.Email);

                    var response = new Response
                    {
                        Email = user.Email,
                        IsEmailVerified = user.VerifiedEmail,
                        Name = user.Username,
                        Token = token
                    };

                    return response;
                }
            }
        }
    }
}
