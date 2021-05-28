using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Enums;
using CommunereTest.Domain.Interfaces;
using MediatR;

namespace CommunereTest.Application.Contact
{
    public sealed partial class ContactHandler
    {
        public sealed partial class GetAllByCurrentUser
        {
            public class Handler:IRequestHandler<Request, IEnumerable<Response>>
            {
                private readonly IUnitOfWork _uow;
                private readonly IIdentityService _identityService;

                public Handler(IUnitOfWork uow, IIdentityService identityService)
                {
                    _uow = uow;
                    _identityService = identityService;
                }

                public async Task<IEnumerable<Response>> Handle(Request request, CancellationToken cancellationToken)
                {
                    return (await _uow.ContactRepository.GetAllForDisplayByUserIdAsync(_identityService.CurrentUser.Id,
                            cancellationToken))
                        .Select(s => new Response
                        {
                            FirstName = s.FirstName,
                            MiddleName = s.MiddleName,
                            LastName = s.LastName,
                            PhoneNumber = s.Phone,
                            Email = s.Email,
                            BirthDate = s.BirthDate
                        });
                }
            }
        }
    }
}