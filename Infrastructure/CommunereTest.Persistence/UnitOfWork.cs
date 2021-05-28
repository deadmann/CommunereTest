using System;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Interfaces;
using CommunereTest.Domain.Interfaces.Repositories;
using CommunereTest.Persistence.Repositories;

namespace CommunereTest.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            ContactRepository = new ContactRepository(dbContext);
            ContactDetailRepository = new ContactDetailRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
            EmailVerificationCodes = new EmailVerificationCodeRepository(dbContext);
        }

        public IContactRepository ContactRepository { get; set; }
        public IContactDetailRepository ContactDetailRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IEmailVerificationCodeRepository EmailVerificationCodes { get; set; }


        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
