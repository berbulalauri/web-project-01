using NLog;
using System;

namespace tutorial_02
{
    public class Log : ILogger
    {
        private readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public void LogError(Exception ex, string message)
            =>  _logger.Error(ex, message);
        public void LogInfo(string message)
            =>  _logger.Info(message);
        public void LogWarning(string message)
            => _logger.Warn(message);


    }
}
