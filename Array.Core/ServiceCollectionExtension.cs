using Array.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Array.Core
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddArrayCore(this IServiceCollection services)
        {
            services.AddTransient<IUserValidationService, UserValidationService>();
            return services;
        }
    }
}
