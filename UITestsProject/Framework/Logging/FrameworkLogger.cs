using Serilog.Core;
using Serilog;

namespace Framework.Logging
{
    public static class FrameworkLogger
    {
        private const string PathToLogFile = "logs\\currentLog.log";

        private static Logger _logger = null!;

        private static object _syncRoot = new();

        public static Logger GetInstance()
        {
            lock (_syncRoot)
            {
                if (_logger == null)
                {
                    _logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.File(PathToLogFile, rollingInterval: RollingInterval.Minute)
                        .CreateLogger();
                }
            }
            return _logger;
        }

        public static void Info(string message)
        {
            GetInstance().Information(message);
        }

        public static void Debug(string message)
        {
            GetInstance().Debug(message);
        }

        public static void Error(string message)
        {
            GetInstance().Error(message);
        }
    }
}
