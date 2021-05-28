using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CommunereTest.Persistence.Repositories
{
    public class UserRepository: BaseRepository<User, Guid>, IUserRepository 
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail, CancellationToken cancellationToken = default)
        {
            return await DbContext.Users.Where(u => u.Username.Equals(usernameOrEmail)
                                              || u.Email.Equals(usernameOrEmail)).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Users
                .Where(u => u.Email.Equals(email) && u.IsActive)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Users.AnyAsync(u => u.Email.Equals(email), cancellationToken);
        }

        public Task<bool> IsExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            return DbContext.Users.AnyAsync(u => u.Username.Equals(username), cancellationToken);
        }
    }
}