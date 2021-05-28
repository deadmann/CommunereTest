using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Interfaces;
using MediatR;

namespace CommunereTest.Application.Contact
{
    public sealed partial class ContactHandler
    {
        public sealed partial class Create
        {
            public class Handler:IRequestHandler<Request, Response>
            {
                private readonly IUnitOfWork _uow;
                private readonly ICurrentUserService _currentUserService;

                public Handler(IUnitOfWork uow, ICurrentUserService currentUserService)
                {
                    _uow = uow;
                    _currentUserService = currentUserService;
                }

                public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                {
                    var contactEntity = new Domain.Entities.Contact
                    {
                        UserId = (await _currentUserService.GetUserAsync(cancellationToken)).Id,
                        
                        FirstName = request.FirstName,
                        MiddleName = request.MiddleName,
                        LastName = request.LastName,
                        
                        BirthDate = request.BirthDate
                    };

                    _uow.ContactRepository.Create(contactEntity);
                    
                    foreach (var detail in request.ContactDetails)
                    {
                        var detailEntity = new Domain.Entities.ContactDetails
                        {
                            Contact = contactEntity,
                        
                            Type = detail.Type!.Value,
                            Description = detail.Description
                        };
                        _uow.ContactDetailRepository.Create(detailEntity);
                    }

                    await _uow.SaveChangesAsync(cancellationToken);

                    return new Response
                    {
                        Id = contactEntity.Id
                    };
                }
            }
        }
    }
}