using System;
using Loggers.Implementations;

namespace Loggers.Models
{
    public class ConsoleLoggerImpl : BaseLoggerImpl
    {
        public override void WriteLog(LogRequest request)
        {
            Console.WriteLine($"{request.Type.ToString()}: {request.Message}{(string.IsNullOrEmpty(request.ExtraTrace) ? $" ExtraTrace: {request.ExtraTrace}" : string.Empty)}");
        }
    }
}