using System;
using System.Collections.Generic;
using CommunereTest.Domain.Enums;
using MediatR;

namespace CommunereTest.Application.Contact
{
    public sealed partial class ContactHandler
    {
        public sealed partial class Create
        {
            public class Request: IRequest<Response>
            {
                public string FirstName { get; set; }
                public string MiddleName { set; get; }
                public string LastName { get; set; }
                
                public List<RequestContactDetails> ContactDetails { get; set; }
                
                public DateTime? BirthDate { get; set; }
            }
            
            public class RequestContactDetails
            {
                public ContactDetailType? Type { get; set; }
                public string Description { get; set; }
            }
        }
    }
}