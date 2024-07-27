using Ardalis.GuardClauses;
using CleanArch.Application.Services;
using CleanArch.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace CleanArch;

/// <summary>
/// Class DependencyInjection.
/// </summary>
public static class DependencyInjection
{
    private static IConfigurationRoot Configuration { get; set; } = null!;

    /// <summary>
    /// Creates the host builder.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns>IHostBuilder.</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(static (hostingContext, configuration) =>
            {
                configuration.Sources.Clear();
                configuration
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var configurationRoot = configuration.Build();
                Guard.Against.Null(configurationRoot);
                Configuration = configurationRoot;
            }).ConfigureServices(AddInfrastructureServices)
            .ConfigureServices(AddApplicationServices)
            .ConfigureServices(AddDomainServices)
            .ConfigureServices(AddPresentationServices)
            .ConfigureLogging((c, l) =>
            {
                l.AddConfiguration(c.Configuration);
                // Adding Sentry integration to Microsoft.Extensions.Logging
                l.AddSentry();
            });

    /// <summary>
    /// Adds the infrastructure services.
    /// </summary>
    /// <param name="services">The services.</param>
    private static void AddInfrastructureServices(IServiceCollection services)
    {
        Guard.Against.Null(services);
        services.AddOptions<AppSettings>().Bind(Configuration).ValidateOnStart();
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddNLog();
        });
        // Add your services and DBContexts here.
        //services.AddDbContext<iSMSContext>(options =>
        //    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        services.AddHostedService<ConsoleService>(); // This is the main service, starts all other stuff.
    }

    /// <summary>
    /// Adds the presentation services.
    /// </summary>
    /// <param name="services">The services.</param>
    private static void AddPresentationServices(IServiceCollection services)
    {
        Guard.Against.Null(services);
    }

    /// <summary>
    /// Adds the application services.
    /// </summary>
    /// <param name="services">The services.</param>
    private static void AddApplicationServices(IServiceCollection services)
    {
        Guard.Against.Null(services);
    }

    /// <summary>
    /// Adds the domain services.
    /// </summary>
    /// <param name="services">The services.</param>
    private static void AddDomainServices(IServiceCollection services)
    {
        Guard.Against.Null(services);
    }
}
