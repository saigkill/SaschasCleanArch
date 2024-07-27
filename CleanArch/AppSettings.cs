using System.ComponentModel.DataAnnotations;

namespace CleanArch.Settings
{
    /// <summary>
    /// Root object of the appsettings.json
    /// </summary>
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Pathes Pathes { get; set; } = null!;
        public Files Files { get; set; } = null!;
        public bool Emailversand { get; set; }
        public Sentry Sentry { get; set; }
    }

    /// <summary>
    /// Default and Testconnectionstrings
    /// </summary>
    public class ConnectionStrings
    {
        public string? DefaultConnection { get; set; }
    }

    /// <summary>
    /// Some file definitions
    /// </summary>
    public class Files
    {
        public string File { get; set; } = null!;
    }

    /// <summary>
    /// Some path definitions
    /// </summary>
    public class Pathes
    {
        public string Path { get; set; } = null!;
    }

    /// <summary>
    /// Sentry configuration
    /// </summary>
    public class Sentry
    {
        [Required]
        public string Dsn { get; set; } = null!;
        [Required]
        public string MinimumBreadcrumbLevel { get; set; } = null!;

        [Required]
        public string MinimumEventLevel { get; set; } = null!;
        [Range(1, 100)]
        public int MaxBreadcrumbs { get; set; }
    }
}
