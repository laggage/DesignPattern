using System;

namespace DecoratorPattern.Sample.TimeLogger
{
    public class FileLogger : ILogger
    {
        public void Error(string msg)
        {
            Console.WriteLine($"Log to file - error: {msg}");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"Log to file - info: {msg}");
        }
    }
}
