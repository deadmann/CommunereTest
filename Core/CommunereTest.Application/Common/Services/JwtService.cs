using System;
using System.Collections.Generic;
using System.Text;
using CommunereTest.Application.Common.Exceptions;
using CommunereTest.Domain.Interfaces;
using CommunereTest.Domain.Models;
using Jose;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CommunereTest.Application.Common.Services
{
    public class JwtService : IJwtService
    {
        private readonly ITimeService _timeService;
        private readonly JwtConfig _config;

        public JwtService(ITimeService timeService, IConfiguration configuration)
        {
            _timeService = timeService;

            _config = new JwtConfig
            {
                JwtKey = configuration.GetValue<string>("Jwt:JwtKey"),
                JwtAudience = configuration.GetValue<string>("Jwt:JwtAudience"),
                JwtExp = configuration.GetValue<string>("Jwt:JwtExp"),
                JwtIssuer = configuration.GetValue<string>("Jwt:JwtIssuer")
            };
        }

        public string GenerateToken(string email)
        {
            var iss = _config.JwtIssuer;
            var aud = _config.JwtAudience;
            var now = DateTime.Now;
            var nbf = _timeService.GetUnixTimestamp(now);
            var iat = _timeService.GetUnixTimestamp(now);
            var exp = _timeService.GetUnixTimestamp(now.AddDays(int.Parse(_config.JwtExp)));

            var payload = new Dictionary<string, object>
            {
                { "iss", iss },
                { "aud", aud },
                { "nbf", nbf },
                { "iat", iat },
                { "exp", exp },
                { "email", email }
            };

            var key = Encoding.ASCII.GetBytes(_config.JwtKey);
            var token = JWT.Encode(payload, key, JwsAlgorithm.HS256);
            return token;
        }

        public JwtPayload GetTokenPayload(string token)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(_config.JwtKey);
                var json = JWT.Decode(token, key);
                return JsonConvert.DeserializeObject<JwtPayload>(json);
            }
            catch
            {
                throw new AppException("Token", "JWT was not a valid token.");
            }
        }

        public bool IsValidToken(string token)
        {
            var now = _timeService.GetUnixTimestamp(DateTime.Now);
            JwtPayload payload;

            try
            {
                payload = GetTokenPayload(token);
            }
            catch
            {
                return false;
            }

            if (payload.ExpirationTime <= now) return false;
            if (payload.IssuedAt >= now) return false;
            if (payload.ValidNotBefore >= now) return false;
            if (_config.JwtIssuer !=null && !payload.Issuer.Equals(_config.JwtIssuer)) return false;
            if (_config.JwtIssuer !=null && !payload.Audience.Equals(_config.JwtAudience)) return false;

            return true;
        }
    }
}
