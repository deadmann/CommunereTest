using System;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Common
{
    public class BaseEntityFull: BaseEntity, ILogicalDeletable, IActiveEntity, ICreateAuditableEntity, IUpdateAuditableEntity
    {
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}