using DesignParttern.Shared;

namespace StrategyPattern
{
    class Program
    {
        static void Main()
        {
            var clientManager = new SampleClientManager();
            clientManager.Run();
        }
    }
}
