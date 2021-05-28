using System;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Common
{
    public interface IUpdateAuditableEntity
    {
        Guid? UpdatedById { get; set; }
        DateTime? UpdatedAt { get; set; }
        User UpdatedBy { get; set; }
    }
}