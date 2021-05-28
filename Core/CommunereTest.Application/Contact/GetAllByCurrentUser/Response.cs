using System;
using System.Collections.Generic;

namespace CommunereTest.Application.Contact
{
    public sealed partial class ContactHandler
    {
        public sealed partial class GetAllByCurrentUser
        {
            public class Response
            {
                public string FirstName { get; set; }
                public string MiddleName { get; set; }
                public string LastName { get; set; }
                
                public string PhoneNumber { get; set; }
                public string Email { get; set; }
                
                public DateTime? BirthDate { get; set; }
            }
        }
    }
}