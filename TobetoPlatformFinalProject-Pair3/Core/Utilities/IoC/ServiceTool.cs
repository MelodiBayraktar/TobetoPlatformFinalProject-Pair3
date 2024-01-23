using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        { 
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
            ServiceProvider = services.BuildServiceProvider();
            return services;

        }

        // public static IServiceCollection Create(IServiceCollection services)
        //{
        //    ServiceProvider = services.BuildServiceProvider();
        //    return services;
        //}
    }
}
