using DesignParttern.Shared;

namespace DecoratorPattern.Sample.TimeLogger
{
    class TimeLoggerSampleClient : ISampleClient
    {
        public void Run()
        {
            ILogger logger = new ConsoleLogger();
            ILogger timeLogger = new TimeLoggerDecorator(logger);
            timeLogger.Info("running");
        }

        public override string ToString()
        {
            return "装饰器模式实例 - 基础日志的功能上加上打印时间的功能";
        }
    }
}
