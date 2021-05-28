using System.Reflection;
using CommunereTest.Application.Common.Behaviours;
using CommunereTest.Application.Common.Services;
using CommunereTest.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommunereTest.Application
{
    public static class ApplicationRegistrationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddTransient<ITimeService, TimeService>();
            services.AddTransient<IJwtService, JwtService>(); // It depends on configuration.
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}