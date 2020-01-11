using Microsoft.Extensions.Logging;

namespace $rootnamespace$.Logging
{
    public static class LoggingConfiguration
    {
        /// <summary>
        ///     Gets or sets the <see cref="ILoggerFactory"/> to power logging throughout this library.
        /// </summary>
        public static ILoggerFactory LoggerFactory { get; set; } = Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance;
    }
}
