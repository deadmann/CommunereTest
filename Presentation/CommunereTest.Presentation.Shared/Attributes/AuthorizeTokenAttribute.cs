using System;
using CommunereTest.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CommunereTest.Presentation.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthorizeTokenAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                HandleUnauthorizedAccess(context);
                return;
            }

            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                HandleUnauthorizedAccess(context);
                return;
            }

            if (string.IsNullOrEmpty(authorizationHeader.ToString()))
            {
                HandleUnauthorizedAccess(context);
                return;
            }

            try
            {
                var authorizationToken = authorizationHeader.ToString()
                    .Replace("Bearer ", "", StringComparison.InvariantCultureIgnoreCase);
                var jwtService = context.HttpContext.RequestServices.GetService<IJwtService>();

                if (!jwtService.IsValidToken(authorizationToken))
                    HandleUnauthorizedAccess(context);
            }
            catch
            {
                HandleUnauthorizedAccess(context);
            }
        }

        private void HandleUnauthorizedAccess(AuthorizationFilterContext context)
        {
            context.Result = new UnauthorizedObjectResult(new { Title = "Unauthorized access." });
        }
    }
}
