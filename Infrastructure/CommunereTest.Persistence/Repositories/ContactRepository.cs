using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Enums;
using CommunereTest.Domain.Interfaces.Repositories;
using CommunereTest.Domain.Models.RepositoryDto;
using Microsoft.EntityFrameworkCore;

namespace CommunereTest.Persistence.Repositories
{
    public class ContactRepository: BaseRepository<Contact, Guid>, IContactRepository 
    {
        public ContactRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ContactForDisplayResponse>> GetAllForDisplayByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await (from c in DbContext.Contacts
                where c.UserId == userId
                select new ContactForDisplayResponse
                {
                    Id = c.Id,
                    FirstName= c.FirstName,
                    MiddleName = c.MiddleName,
                    LastName = c.LastName,
                    BirthDate = c.BirthDate,
                    Phone = DbContext.ContactDetails.FirstOrDefault(w=>w.Type == ContactDetailType.Phone || w.Type == ContactDetailType.Mobile).Description,
                    Email = DbContext.ContactDetails.FirstOrDefault(w=>w.Type == ContactDetailType.Email).Description
                }).ToListAsync(cancellationToken);

        }
    }
}