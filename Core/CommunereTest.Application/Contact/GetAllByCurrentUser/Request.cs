using System;
using System.Collections.Generic;
using MediatR;

namespace CommunereTest.Application.Contact
{
    public sealed partial class ContactHandler
    {
        public sealed partial class GetAllByCurrentUser
        {
            public class Request: IRequest<IEnumerable<Response>>
            {
            }
        }
    }
}