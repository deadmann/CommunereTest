using System;
using System.Collections.Generic;
using CommunereTest.Domain.Common;

namespace CommunereTest.Domain.Entities
{
    public class Contact:BaseEntity
    {
        public Contact()
        {
            ContactDetails = new HashSet<ContactDetails>();
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<ContactDetails> ContactDetails { get; set; }
    }
}