using System;

namespace DecoratorPattern.Sample.TimeLogger
{
    public class TimeLoggerDecorator : ILogger
    {
        protected readonly ILogger _logger;

        public TimeLoggerDecorator(ILogger logger)
        {
            _logger = logger;
        }

        public void Error(string msg)
        {
            InsertTimeInfo(ref msg);
            _logger.Error(msg);
        }

        public void Info(string msg)
        {
            InsertTimeInfo(ref msg);
            _logger.Info(msg);
        }

        private void InsertTimeInfo(ref string msg)
        {
            msg = msg.Insert(0, $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]");
        }
    }
}
