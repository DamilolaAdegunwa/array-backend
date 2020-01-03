using Array.Repository.DatabaseAccessLayer;
using Array.Repository.DatabaseAccessLayer.Base;
using Array.Repository.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace Array.Repository
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddArrayRepository(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IIdeaRepository, IdeaRepository>();
            return services;
        }
    }
}