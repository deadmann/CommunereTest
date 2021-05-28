using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Interfaces
{
    public interface ICurrentUserService
    {
        public string Email { get; }
        public bool IsAuthenticated { get; }

        public Task<User> GetUserAsync(CancellationToken cancellationToken = default);
    }
}
