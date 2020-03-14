using Loggers.Enums;

namespace Loggers.Models
{
    public class LogRequest
    {
        public string Message { get; set; }
        public string ExtraTrace { get; set; }
        public LogType Type { get; set; }
    }
}