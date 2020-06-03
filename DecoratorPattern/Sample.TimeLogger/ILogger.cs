namespace DecoratorPattern.Sample.TimeLogger
{
    public interface ILogger
    {
        void Error(string msg);
        void Info(string msg);
    }
}
