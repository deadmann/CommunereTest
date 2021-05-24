using System;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Interfaces.Repositories;

namespace CommunereTest.Persistance.Repositories
{
    public class UserRepository: BaseRepository<User, Guid>, IUserRepository 
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}