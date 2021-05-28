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
        public sealed partial class Register
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
                    if (await _identity.EmailIsAlreadyRegisteredAsync(email, cancellationToken))
                        throw new AppException("Email", "Email is already registered.");

                    var password = _identity.EncryptPassword(request.Password);

                    var user = _identity.AddUser(email, password);

                    var verification = _identity.CreateEmailVerificationCode(user, EmailVerificationAction.Register);
                    await _identity.SendEmailVerificationCodeAsync(user, verification.Code, cancellationToken);

                    await _uow.SaveChangesAsync(cancellationToken);

                    user.CreatedById = user.Id;
                    user.UpdatedById = user.Id;
                    _identity.UpdateUser(user);

                    await _uow.SaveChangesAsync(cancellationToken);

                    var response = new Response
                    {
                        Email = user.Email,
                    };

                    return response;
                }
            }
        }
    }
}
