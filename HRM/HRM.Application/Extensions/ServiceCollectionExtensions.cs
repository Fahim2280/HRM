using FluentValidation;
using FluentValidation.AspNetCore;
using HRM.Application.Auth.Services;
using HRM.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

            services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();

            // Register Auth Service
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}