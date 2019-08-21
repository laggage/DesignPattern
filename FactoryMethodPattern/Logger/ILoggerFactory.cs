namespace FactoryMethodPattern.Logger
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
}
