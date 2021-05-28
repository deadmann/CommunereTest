using System;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Common
{
    public interface ICreateAuditableEntity
    {
        Guid? CreatedById { get; set; }
        DateTime? CreatedAt { get; set; }
        User CreatedBy { get; set; }
    }
}