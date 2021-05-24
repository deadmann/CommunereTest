using System;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        
    }
}