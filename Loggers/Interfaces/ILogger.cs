using Loggers.Enums;
using Loggers.Models;

namespace Loggers.Interfaces
{
    public interface ILogger
    {
        void WriteLog(LogType type, string message, string trace = "");

        void WriteLog(LogRequest request);
    }
}