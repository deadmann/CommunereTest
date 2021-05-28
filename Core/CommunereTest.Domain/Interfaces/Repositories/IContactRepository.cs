using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Models.RepositoryDto;

namespace CommunereTest.Domain.Interfaces.Repositories
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {
        Task<IEnumerable<ContactForDisplayResponse>> GetAllForDisplayByUserIdAsync(Guid userId,
            CancellationToken cancellationToken = default);
    }
}