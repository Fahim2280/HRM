using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using FluentValidation;

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

        }
    }
}
