namespace FactoryMethodPattern.Logger
{
    using System;

    public class FileLoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new FileLogger("./logger.txt");
        }
    }
}
