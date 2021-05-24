using System;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Interfaces.Repositories
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {
    }
}