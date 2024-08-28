using Application.Services;
using Ardalis.GuardClauses;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SaschasCleanArch.DependencyInjection;

namespace SaschasCleanArch;

/// <summary>
/// Class Program.
/// </summary>
public static class Program
{
	private static IConfigurationRoot Configuration { get; set; } = null!;

	/// <summary>
	/// Main Entry Point
	/// </summary>
	/// <param name="args">Given Arguments</param>
	static async Task Main(string[] args)
	{
		using IHost host = CreateHostBuilder(args).Build();
		await host.RunAsync().ConfigureAwait(false);
		// your coding starts in CondoleService.cs
		// update appsettings.json
		// update nlog.config
	}

	/// <summary>
	/// Creates the host builder.
	/// </summary>
	/// <param name="args">The arguments.</param>
	/// <returns>IHostBuilder.</returns>
	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration(static (configuration) =>
			{
				configuration.Sources.Clear();
				configuration
					.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

				var configurationRoot = configuration.Build();
				Guard.Against.Null(configurationRoot);
				Configuration = configurationRoot;
			}).ConfigureServices(services =>
			{
				services.AddOptions<AppSettings>().Bind(Configuration).ValidateOnStart();
				//services.AddDbContext<iSMSContext>(options =>
				//    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
				services.AddLogging(builder =>
				{
					builder.ClearProviders();
					builder.AddNLog();
				});
			})
			.ConfigureContainer<ContainerBuilder>(builder =>
			{
				builder.RegisterModule(new ApplicationModule());
				builder.RegisterModule(new DomainModule());
				builder.RegisterModule(new InfrastructureModule());
				builder.RegisterModule(new PresentationModule());
			})
			.ConfigureLogging((c, l) =>
			{
				l.AddConfiguration(c.Configuration);
				// Adding Sentry integration to Microsoft.Extensions.Logging
				l.AddSentry();
			});
}
