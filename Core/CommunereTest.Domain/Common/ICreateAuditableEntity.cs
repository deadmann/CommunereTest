using System;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Common
{
    public interface ICreateAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
    }
}