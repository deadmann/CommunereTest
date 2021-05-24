using System;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Common
{
    public interface IUpdateAuditableEntity
    {
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}