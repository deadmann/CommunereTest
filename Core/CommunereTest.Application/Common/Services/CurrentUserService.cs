using System;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CommunereTest.Application.Common.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IUnitOfWork _uow;
        private User _user;

        public string Email { get; }
        public bool IsAuthenticated { get; }

        public async Task<User> GetUserAsync(CancellationToken cancellationToken = default)
        {
            if (_user != null) return _user;

            _user = await _uow.UserRepository.GetUserByEmailAsync(Email, cancellationToken);
            return _user;
        }


        public CurrentUserService(IJwtService jwt, IHttpContextAccessor httpContextAccessor, IUnitOfWork uow)
        {
            _uow = uow;
            var authorizationHeaderExists = httpContextAccessor.HttpContext.Request
                .Headers.TryGetValue("Authorization", out var authorizationHeader);

            if (!authorizationHeaderExists)
                Email = string.Empty;

            if (string.IsNullOrEmpty(authorizationHeader.ToString()))
                Email = string.Empty;

            try
            {
                var authorizationToken = authorizationHeader.ToString().Replace("Bearer ", "", StringComparison.InvariantCultureIgnoreCase);

                if (!jwt.IsValidToken(authorizationToken))
                    Email = string.Empty;

                var payload = jwt.GetTokenPayload(authorizationToken);
                Email = payload.Email;
            }
            catch
            {
                Email = string.Empty;
            }

            IsAuthenticated = !string.IsNullOrEmpty(Email);
        }
    }
}
