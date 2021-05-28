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
        public sealed partial class SendEmailVerificationCode
        {
            public sealed class RequestHandler : IRequestHandler<Request, Response>
            {
                private readonly IUnitOfWork _uow;
                private readonly IIdentityService _identity;

                public RequestHandler(IUnitOfWork uow, IIdentityService identity)
                {
                    _uow = uow;
                    _identity = identity;
                }

                public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                {
                    var email = request.Email.Trim().ToLower();
                    var action = EmailVerificationAction.Register;

                    var verification = await _identity.GetEmailVerificationCodeAsync(email, action, cancellationToken);

                    if (_identity.VerificationCodeIsConfirmed(verification))
                        throw new AppException("Verification Code", "Invalid code.");

                    if (_identity.VerificationCodeIsUnexpired(verification))
                        throw new AppException("Verification Code",
                            "You've got an unexpired code. Please use the current one or retry in 10 minutes.");

                    var user = await _identity.GetUserByEmailAsync(email, cancellationToken);

                    if (user == null)
                        throw new AppException("User", "Not found.");

                    if (user.VerifiedEmail)
                        throw new AppException("User", "Email has been verified for this user.");

                    verification = _identity.CreateEmailVerificationCode(user, action);
                    await _identity.SendEmailVerificationCodeAsync(user, verification.Code, cancellationToken);

                    await _uow.SaveChangesAsync(cancellationToken);

                    return new Response {Succeeded = true};
                }
            }
        }
    }
}