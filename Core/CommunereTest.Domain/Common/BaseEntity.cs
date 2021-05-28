using System;
using System.ComponentModel.DataAnnotations;

namespace CommunereTest.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}