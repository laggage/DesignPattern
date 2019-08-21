namespace FactoryMethodPattern.Logger
{
    using System;

    public class DatabaseLoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new DatabaseLogger("Database = logger;uid=Xxxx;pwd=Xxxx;");
        }
    }
}
