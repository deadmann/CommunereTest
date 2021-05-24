using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Interfaces;
using CommunereTest.Domain.Interfaces.Repositories;
using CommunereTest.Persistance.Repositories;

namespace CommunereTest.Persistance
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
        }

        public IContactRepository ContactRepository { get; set; }
        public IContactDetailRepository ContactDetailRepository { get; set; }
        public IUserRepository UserRepository { get; set; }


        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
