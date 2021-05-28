using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Interfaces.Repositories;

namespace CommunereTest.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IContactRepository ContactRepository { get; set; }

        public IContactDetailRepository ContactDetailRepository { get; set; }
        
        public IUserRepository UserRepository { get; set; }
        public IEmailVerificationCodeRepository EmailVerificationCodes { get; set; }

        public void SaveChanges();
        public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}