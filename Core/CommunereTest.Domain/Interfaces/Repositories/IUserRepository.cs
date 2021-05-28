using System;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail, CancellationToken cancellationToken = default);
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> IsExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> IsExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
    }
}