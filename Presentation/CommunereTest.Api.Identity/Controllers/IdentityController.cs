using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Application.UserIdentity;
using CommunereTest.Presentation.Shared.Attributes;
using CommunereTest.Presentation.Shared.Controller;
using Microsoft.AspNetCore.Mvc;

namespace CommunereTest.Api.Identity.Controllers
{
    public class IdentityController : BaseApiController
    {
        [HttpPost]
        [Produces(typeof(UserIdentity.Register.Response))]
        public async Task<IActionResult> Register(UserIdentity.Register.Request request, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Produces(typeof(UserIdentity.Login.Response))]
        public async Task<IActionResult> Login(UserIdentity.Login.Request request, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeToken]
        [Produces(typeof(UserIdentity.ChangePassword.Response))]
        public async Task<IActionResult> ChangePassword(UserIdentity.ChangePassword.Request request, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeToken]
        [Produces(typeof(UserIdentity.RecoverPassword.Response))]
        public async Task<IActionResult> RecoverPassword(UserIdentity.RecoverPassword.Request request, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeToken]
        [Produces(typeof(UserIdentity.RefreshToken.Response))]
        public async Task<IActionResult> RefreshToken(UserIdentity.RefreshToken.Request request, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Produces(typeof(UserIdentity.SendEmailVerificationCode.Response))]
        public async Task<IActionResult> SendEmailVerificationCode(UserIdentity.SendEmailVerificationCode.Request request, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Produces(typeof(UserIdentity.VerifyEmail.Response))]
        public async Task<IActionResult> VerifyEmail(UserIdentity.VerifyEmail.Request request, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Produces(typeof(UserIdentity.SendPasswordRecoveryEmail.Response))]
        public async Task<IActionResult> SendPasswordRecoveryEmail(UserIdentity.SendPasswordRecoveryEmail.Request request, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
