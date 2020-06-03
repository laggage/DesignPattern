using System;

namespace DecoratorPattern.Sample.TimeLogger
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string msg)
        {
            Console.WriteLine($"Log to console - error: {msg}");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"Log to console - info: {msg}");
        }
    }
}
