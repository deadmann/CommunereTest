using System;

namespace CommunereTest.Application.Contact
{
    public sealed partial class ContactHandler
    {
        public sealed partial class Create
        {
            public class Response
            {
                public Guid Id { get; set; }
            }
        }
    }
}