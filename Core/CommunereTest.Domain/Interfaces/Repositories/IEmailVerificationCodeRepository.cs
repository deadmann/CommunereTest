using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Enums;

namespace CommunereTest.Domain.Interfaces.Repositories
{
    public interface IEmailVerificationCodeRepository: IRepository<EmailVerificationCode, int>
    {
        Task<EmailVerificationCode> GetLastByEmailAndVerificationActionAsync(string email,
            EmailVerificationAction verificationAction,
            CancellationToken cancellationToken = default);
    }
}