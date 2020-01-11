using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace YourRootNamespace
{

    internal static class LogProvider<TCategoryName>
    {
        private static ILogger<TCategoryName> _logger;

        public static ILogger<TCategoryName> GetCurrentClassLogger()
        {
            if (LoggingConfiguration.LoggerFactory == null || LoggingConfiguration.LoggerFactory.GetType() == typeof(NullLoggerFactory))
            {
                _logger = null;
                return _logger;
            }

            if (_logger == null || _logger.GetType() == typeof(NullLogger<TCategoryName>) || _logger.GetType() == typeof(NullLogger))
            {
                _logger = LoggingConfiguration.LoggerFactory.CreateLogger<TCategoryName>();
            }

            return _logger;
        }
    }
}
