using System;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Interfaces.Repositories;

namespace CommunereTest.Persistance.Repositories
{
    public class ContactRepository: BaseRepository<Contact, Guid>, IContactRepository 
    {
        public ContactRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}