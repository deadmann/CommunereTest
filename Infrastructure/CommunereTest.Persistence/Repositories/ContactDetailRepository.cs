using System;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Interfaces.Repositories;

namespace CommunereTest.Persistence.Repositories
{
    public class ContactDetailRepository: BaseRepository<ContactDetails, Guid>, IContactDetailRepository 
    {
        public ContactDetailRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}