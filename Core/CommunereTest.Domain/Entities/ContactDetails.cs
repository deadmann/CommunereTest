using System;
using System.ComponentModel.DataAnnotations;
using CommunereTest.Domain.Common;
using CommunereTest.Domain.Enums;

namespace CommunereTest.Domain.Entities
{
    public class ContactDetails:BaseEntity
    {
        public Guid ContactId { get; set; }
        
        public ContactDetailType Type { get; set; }
        public string Description { get; set; }

        public Contact Contact { get; set; }
    }
}