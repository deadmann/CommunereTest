using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Application.Common.Exceptions;
using CommunereTest.Domain.Enums;
using CommunereTest.Domain.Interfaces;

namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class RecoverPassword
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
                    if (!_identity.IsCurrentUserAuthenticated)
                        throw new AppException("User", "The user is not authenticated.");

                    var user = _identity.CurrentUser;
                    var action = EmailVerificationAction.RecoverPassword;

                    var verification =
                        await _identity.GetEmailVerificationCodeAsync(user.Email, action, cancellationToken);

                    if (verification == null)
                        throw new AppException("Email Verification Code", "Not found.");

                    if (verification.Confirmed)
                        throw new AppException("Verification Code", "Invalid code.");

                    var now = DateTime.Now;
                    var expirationTime = verification.CreatedAt.Value.AddMinutes(10);

                    if (now >= expirationTime)
                        throw new AppException("Email Verification", "Verification code has been expired.");

                    if (!verification.Code.Equals(request.VerificationCode))
                        throw new AppException("Email Verification", "Verification code is wrong.");

                    verification.Confirmed = true;
                    verification.UpdatedAt = now;
                    verification.UpdatedById = user.Id;

                    _identity.UpdateEmailVerificationCode(verification);

                    if (!user.VerifiedEmail)
                        user.VerifiedEmail = true;

                    var password = _identity.EncryptPassword(request.NewPassword);
                    user.Password = password;
                    user.UpdatedAt = now;
                    user.UpdatedById = user.Id;

                    _identity.UpdateUser(user);

                    await _uow.SaveChangesAsync(cancellationToken);

                    var token = _jwt.GenerateToken(user.Email);

                    var response = new Response
                    {
                        Email = user.Email,
                        IsEmailVerified = user.VerifiedEmail,
                        Token = token
                    };

                    return response;
                }
            }
        }
    }
}
