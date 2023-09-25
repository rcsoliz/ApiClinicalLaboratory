using CLINICAL.Application.Interface;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicactionDbContext> ();
            services.AddScoped<IAnalysisRepository, AnalysisRepository>();
            
            return services;
        }

    }
}
