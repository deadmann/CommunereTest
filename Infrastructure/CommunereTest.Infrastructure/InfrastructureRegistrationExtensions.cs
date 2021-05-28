using CommunereTest.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CommunereTest.Infrastructure
{
    public static class InfrastructureRegistrationExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
