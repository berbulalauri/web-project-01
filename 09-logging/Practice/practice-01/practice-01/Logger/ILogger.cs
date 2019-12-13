using System;

namespace practice_01
{
    public interface ILogger
    {
        public void LogError(Exception ex, string message);
        public void LogWarning(string message);
        public void LogInfo(string message);
    }
}
