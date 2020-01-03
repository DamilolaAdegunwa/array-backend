using Array.ApplicationServices.EntityServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Array.ApplicationServices
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddArrayApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IIdeaService,IdeaService>();
            return services;
        }
    }
}
