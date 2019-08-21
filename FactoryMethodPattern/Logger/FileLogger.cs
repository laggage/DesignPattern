namespace FactoryMethodPattern.Logger
{
    using System;

    public class FileLogger:ILogger
    {
        private string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void Log()
        {
            Console.WriteLine("Log info to file {0}.", _logFilePath);
        }
    }
}
