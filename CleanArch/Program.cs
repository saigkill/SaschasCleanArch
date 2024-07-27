using Microsoft.Extensions.Hosting;

using System.Diagnostics;

namespace CleanArch
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Entry Point
        /// </summary>
        /// <param name="args">Given Arguments</param>
        static async Task Main(string[] args)
        {
            using IHost host = DependencyInjection.CreateHostBuilder(args).Build();
            await host.RunAsync();
            // your coding starts in CondoleService.cs
            // update appsettings.json
            // update nlog.config
        }
    }
}
