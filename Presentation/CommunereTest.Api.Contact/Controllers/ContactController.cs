using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Application.Contact;
using CommunereTest.Presentation.Shared.Attributes;
using CommunereTest.Presentation.Shared.Controller;
using Microsoft.AspNetCore.Mvc;
using ContactHandler = CommunereTest.Application.Contact.ContactHandler;

namespace CommunereTest.Api.Contact.Controllers
{
    [AuthorizeToken]
    public class ContactController : BaseRestController
    {
        [HttpGet]
        [Produces(typeof(ContactHandler.GetAllByCurrentUser.Response))]
        public async Task<IActionResult> GetAllByUserId(CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(new ContactHandler.GetAllByCurrentUser.Request(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Produces(typeof(ContactHandler.Create.Response))]
        public async Task<IActionResult> Create(ContactHandler.Create.Request request,
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}