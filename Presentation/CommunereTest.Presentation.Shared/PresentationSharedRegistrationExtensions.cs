using System;
using CommunereTest.Application;
using CommunereTest.Infrastructure;
using CommunereTest.Persistence;
using CommunereTest.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommunereTest.Presentation.Shared
{
    public static class PresentationSharedRegistrationExtensions
    {
        public static IServiceCollection AddSharedPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddInfrastructure();
            services.RegisterPersistenceServices(configuration);
            services.AddApplication();
            return services;
        }
        
    }
}