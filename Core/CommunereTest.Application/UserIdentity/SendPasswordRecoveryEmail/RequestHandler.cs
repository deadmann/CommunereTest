using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Application.Common.Exceptions;
using CommunereTest.Domain.Enums;
using CommunereTest.Domain.Interfaces;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class SendPasswordRecoveryEmail
        {
            public sealed class RequestHandler : IRequestHandler<Request, Response>
            {
                private readonly IUnitOfWork _uow;
                private readonly IIdentityService _identity;
                private readonly IJwtService _jwt;

                public RequestHandler(IUnitOfWork uow, IIdentityService identity, IJwtService jwt)
                {
                    _uow = uow;
                    _identity = identity;
                    _jwt = jwt;
                }

                public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                {
                    var email = request.Email.Trim().ToLower();
                    var action = EmailVerificationAction.RecoverPassword;

                    var verification = await _identity.GetEmailVerificationCodeAsync(email, action, cancellationToken);

                    if (_identity.VerificationCodeIsConfirmed(verification))
                        throw new AppException("Verification Code", "Invalid code.");

                    if (_identity.VerificationCodeIsUnexpired(verification))
                        throw new AppException("Verification Code",
                            "You've got an unexpired code. Please use the current one or retry in 10 minutes.");

                    var user = await _identity.GetUserByEmailAsync(email, cancellationToken);

                    if (user == null)
                        throw new AppException("User", "User not found.");

                    verification = _identity.CreateEmailVerificationCode(user, action);

                    var token = _jwt.GenerateToken(user.Email);

                    await _identity.SendPasswordRecoveryEmailAsync(user, verification.Code, token, cancellationToken);

                    await _uow.SaveChangesAsync(cancellationToken);

                    return new Response {Succeeded = true};
                }
            }
        }
    }
}