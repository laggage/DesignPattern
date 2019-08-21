namespace FactoryMethodPattern.Logger
{
    using System;

    class DatabaseLogger : ILogger
    {
        private string _connectString;

        public DatabaseLogger(string connectString)
        {
            _connectString = connectString;
        }

        public void Log()
        {
            Console.WriteLine("Log info to database");
        }
    }
}
