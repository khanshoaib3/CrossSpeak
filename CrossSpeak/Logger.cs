using Microsoft.Extensions.Logging;

namespace CrossSpeak
{
    public class Logger
    {

        private static ILogger? _loggerInstance;
        private static ILogger LoggerInstance
        {
            get
            {
                if (_loggerInstance == null)
                {
                    using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                    _loggerInstance = factory.CreateLogger("Cross Speak");
                }

                return _loggerInstance;
            }
        }

        public static void LogDebug(string message) => LoggerInstance.Log(LogLevel.Debug, message);

        public static void LogError(string message) => LoggerInstance.Log(LogLevel.Error, message);

        public static void LogInfo(string message) => LoggerInstance.Log(LogLevel.Information, message);

        public static void LogTrace(string message) => LoggerInstance.Log(LogLevel.Trace, message);
    }
}