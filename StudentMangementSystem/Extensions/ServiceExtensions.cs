using System;
using Contracts;
using LoggingService;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Service;
using Service.Contracts;

namespace StudentMangementSystem.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.Configure<CorsOptions>(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });
    }


    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(config => { });
    }

    public static void ConfigureLoggingService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, IRepositoryManager>();
    }

    public static void ConfigureServiceManager(this IServiceCollection services) {
        services.AddScoped<IServiceManager, ServiceManager>();
    }
}
