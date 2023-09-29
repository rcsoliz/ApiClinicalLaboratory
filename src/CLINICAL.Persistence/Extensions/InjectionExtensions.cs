﻿using CLINICAL.Application.Interface.Interfaces;
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

            services.AddScoped<IExamRepository, ExamRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            return services;
        }

    }
}
