using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Spectre.Console;

namespace CleanArch.Application.Services;

/// <summary>
/// Class ConsoleService. This is the starting point for our application.
/// Implements the <see cref="IHostedService" />
/// </summary>
/// <seealso cref="IHostedService" />
public class ConsoleService : IHostedService
{
    private readonly IHostApplicationLifetime _appLifetime;
    private readonly ILogger<ConsoleService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleService"/> class.
    /// </summary>
    /// <param name="appLifetime">The application lifetime.</param>
    /// <param name="logger">The logger.</param>
    public ConsoleService(IHostApplicationLifetime appLifetime, ILogger<ConsoleService> logger)
    {
        _appLifetime = appLifetime;
        _logger = logger;
    }

    /// <summary>
    /// Triggered when the application host is ready to start the service.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous Start operation.</returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _appLifetime.ApplicationStarted.Register(() =>
        {
            Task.Run(async () =>
            {
                try
                {
                    _logger.LogInformation("Starting Logging process");
                    AnsiConsole.Write(new Markup("[bold yellow] Running the app... [/]"));

                    _logger.LogInformation("Ending logging process");
                    AnsiConsole.Write(new Markup("[bold yellow] Finished... :face_with_open_mouth: [/]"));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred :face_screaming_in_fear: : {Message}", ex.Message);
                    throw;
                }
                finally
                {
                    _appLifetime.StopApplication();
                }
            }, cancellationToken);
        });
        return Task.CompletedTask;
    }

    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous Stop operation.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
