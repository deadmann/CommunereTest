using CommunereTest.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CommunereTest.Persistance
{
    public static class PersistenceServiceRegistrationExtensions
    {
        public static void RegisterPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}