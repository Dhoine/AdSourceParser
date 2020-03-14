using Loggers.Enums;
using Loggers.Interfaces;
using Loggers.Models;

namespace Loggers.Implementations
{
    public abstract class BaseLoggerImpl : ILogger
    {
        public void WriteLog(LogType type, string message, string trace = "")
        {
            var request = new LogRequest
            {
                ExtraTrace = trace,
                Message = message,
                Type = type
            };
            WriteLog(request);
        }

        public abstract void WriteLog(LogRequest request);
    }
}