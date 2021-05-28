using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CommunereTest.Presentation.Shared.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseRestController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
