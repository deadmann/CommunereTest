using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Enums;
using CommunereTest.Domain.Interfaces.Repositories;

namespace CommunereTest.Persistence.Repositories
{
    public class EmailVerificationCodeRepository: BaseRepository<EmailVerificationCode, int>, IEmailVerificationCodeRepository 
    {
        public EmailVerificationCodeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<EmailVerificationCode> GetLastByEmailAndVerificationActionAsync(string email,
            EmailVerificationAction verificationAction,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.EmailVerificationCodes.Where(e => e.Email.Equals(email)
                                                             && e.IsActive && e.Action == verificationAction)
                .OrderByDescending(e => e.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}